﻿using System.Threading;
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
        [SerializeField] private Button _openInventory;
        private IMediator<AbstractGameFlowMessage> _gameFlowMediator;

        protected override void InitInternal()
        {
            _play.onClick.AddListener(OnPlayClicked);
            _openInventory.onClick.AddListener(OnOpenInventoryClicked);
        }

        [Inject]
        private void Init(IMediator<AbstractGameFlowMessage> flowMediator)
        {
            _gameFlowMediator = flowMediator;
            flowMediator.SubscribeHandler<UIMainScreen, GameStartedMessage>(this);
        }

        public void Handle(GameStartedMessage message)
        {
            _uiSystem.ChangeScreen<UIGameplayScreen>();
        }

        private void OnPlayClicked()
        {
            _uiSystem.ChangeScreen<UILoadingScreen>();
            _gameFlowMediator.Publish(new StartGameMessage());
        }

        private void OnOpenInventoryClicked()
        {
            _uiSystem.ChangeScreen<UIInventoryScreen>();
        }
    }
}
