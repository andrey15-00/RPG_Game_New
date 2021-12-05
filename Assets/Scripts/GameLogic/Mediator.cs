using Mediation;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityGame.Mediation;

namespace UnityGame.GameLogic
{
    public class Mediator<T> : IMediator<T> where T : IMediatorMessage
    {
        private Dictionary<Type, List<MediationableObjectInfo>> _handlersInfos =
           new Dictionary<Type, List<MediationableObjectInfo>>();

        public void Publish<MsgType>(MsgType message) where MsgType : T
        {
            Type msgType = typeof(MsgType);

            if (_handlersInfos.TryGetValue(msgType, out var infos))
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

            MethodInfo method = handler.GetType().GetMethod(nameof(IMediatorMessageHandler<MsgType>.Handle), new Type[] { msgType });
            
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