using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityGame.GameLogic;
using UnityGame.Mediation;
using Zenject;

namespace UnityGame.UI
{
    public class UIMainScreen : UIAbstractScreen, IMediatorMessageHandler<GameStartedMessage>
    {
        [SerializeField] private Button _play;
        [Inject] private GameFlowMediator _gameFlowMediator;

        protected override void InitInternal()
        {
            _play.onClick.AddListener(OnPlayClicked);
        }

        [Inject]
        private void Init(GameFlowMediator mediator)
        {
            _gameFlowMediator = mediator;
            mediator.SubscribeHandler<UIMainScreen, GameStartedMessage>(this);
        }

        private void OnPlayClicked()
        {
            _uiSystem.ChangeScreen<UILoadingScreen>();
            _gameFlowMediator.Publish(new StartGameMessage());
        }

        public void Handle(GameStartedMessage message)
        {
            _uiSystem.ChangeScreen<UIGameplayScreen>();
        }
    }
}
