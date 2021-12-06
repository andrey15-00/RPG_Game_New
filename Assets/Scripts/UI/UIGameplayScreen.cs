using UnityEngine;
using UnityEngine.UI;
using UnityGame.GameLogic;
using UnityGame.Mediation;
using Zenject;

namespace UnityGame.UI
{
    public class UIGameplayScreen : UIAbstractScreen, IMediatorMessageHandler<GameFinishedMessage>
    {
        [SerializeField] private Button _goToMain;
        [Inject] private IMediator<AbstractGameFlowMessage> _gameFlowMediator;


        protected override void InitInternal()
        {
            _goToMain.onClick.AddListener(OnGoToMainClicked);
        }

        [Inject]
        private void Constructor(IMediator<AbstractGameFlowMessage> mediator)
        {
            _gameFlowMediator = mediator;
            mediator.SubscribeHandler<UIGameplayScreen, GameFinishedMessage>(this);
            LogWrapper.Log("[UIGameplayScreen] Constructor called. ");
        }

        private void OnGoToMainClicked()
        {
            LogWrapper.Log("[UIGameplayScreen] OnGoToMainClicked. ");
            _uiSystem.ChangeScreen<UILoadingScreen>();
            _gameFlowMediator.Publish(new FinishGameMessage());
        }

        public void Handle(GameFinishedMessage message)
        {
            _uiSystem.ChangeScreen<UIMainScreen>();
        }
    }
}
