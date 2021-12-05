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
        [Inject] private GameFlowMediator _gameFlowMediator;


        protected override void InitInternal()
        {
            _goToMain.onClick.AddListener(OnGoToMainClicked);
        }

        [Inject]
        private void Init(GameFlowMediator mediator)
        {
            _gameFlowMediator = mediator;
            mediator.SubscribeHandler<UIGameplayScreen, GameFinishedMessage>(this);
        }

        private void OnGoToMainClicked()
        {
            LogWrapper.Log("[Gameplay] OnGoToMainClicked. ");
            _uiSystem.ChangeScreen<UILoadingScreen>();
            _gameFlowMediator.Publish(new FinishGameMessage());
        }

        public void Handle(GameFinishedMessage message)
        {
            _uiSystem.ChangeScreen<UIMainScreen>();
        }
    }
}
