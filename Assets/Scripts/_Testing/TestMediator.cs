using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityGame.Mediation;

namespace Temp
{
    public class MediationableObjectInfo
    {
        public object instance;
        public MethodInfo method;

        public MediationableObjectInfo(object instance, MethodInfo method)
        {
            this.instance = instance;
            this.method = method;
        }
    }

    public class TestMediator : MonoBehaviour, IMediator
    {
        [SerializeField] private Button _publish;

        private Dictionary<Type, List<MediationableObjectInfo>> _handlersInfos =
           new Dictionary<Type, List<MediationableObjectInfo>>();


        private void Start()
        {
            _publish.onClick.AddListener(OnPublishClicked);
        }

        private void OnPublishClicked()
        {
            Publish(new TestMessage(5053));
        }

        public void Publish<MsgType>(MsgType message) where MsgType : IMediatorMessage
        {
            Type type = typeof(MsgType);
            if (_handlersInfos.TryGetValue(type, out var infos))
            {
                object[] parameters = new object[1] { message };
                foreach (var info in infos)
                {
                    info.method.Invoke(info.instance, parameters);
                }
            }
        }

        public void SubscribeHandler<HandlerType, MsgType>(HandlerType handler)
            where HandlerType : IMediatorMessageHandler<MsgType>
            where MsgType : IMediatorMessage
        {
            Type msgType = typeof(MsgType);
            MethodInfo method = handler.GetType().GetMethod(nameof(IMediatorMessageHandler<MsgType>.Handle));
            
            var handlerInfo = new MediationableObjectInfo(handler, method);

            if (_handlersInfos.TryGetValue(msgType, out List<MediationableObjectInfo> subscribers))
            {
                if(subscribers.Find(o=>o.method == method) == null)
                {
                    subscribers.Add(handlerInfo);
                }
            }
            else
            {
                _handlersInfos[msgType] = new List<MediationableObjectInfo>()
                {
                    handlerInfo
                };
            }
        }
    }
}