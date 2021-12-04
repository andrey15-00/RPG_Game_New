using UnityEngine;
using UnityEngine.UI;
using UnityGame.Mediation;

namespace Temp
{
    public class TestHandler : MonoBehaviour, IMediatorMessageHandler<TestMessage>
    {
        [SerializeField] private Button _subscribe;
        [SerializeField] private TestMediator _mediator;

        private void Start()
        {
            _subscribe.onClick.AddListener(OnSubscribeClicked);
        }

        private void OnSubscribeClicked()
        {
            _mediator.SubscribeHandler<IMediatorMessageHandler<TestMessage>, TestMessage>(this);
        }

        public void Handle(TestMessage message)
        {
            LogWrapper.Log("Message received! Type: " + message.GetType() + "; Value: " + message.value);
        }
    }

}