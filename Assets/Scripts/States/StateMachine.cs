using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityGame.GameLogic;
using UnityGame.Mediation;
using Zenject;

namespace UnityGame.States
{
    public class StateMachine : MonoBehaviour, IMediatorMessageHandler<StartGameMessage>, IMediatorMessageHandler<FinishGameMessage>
    {
        private IState _currentState;
        private List<IState> _states = new List<IState>();
        [Inject] private IMediator<AbstractGameFlowMessage> _gameFlowMediator;

        public void Init(List<IState> states, string startStateId)
        {
            _gameFlowMediator.SubscribeHandler<StateMachine, StartGameMessage>(this);
            _gameFlowMediator.SubscribeHandler<StateMachine, FinishGameMessage>(this);

            _states = states;

            IState startState = states.Find(state => state.Id == startStateId);
            ChangeState(startState);
        }

        public void Handle(StartGameMessage message)
        {
            LogWrapper.Log("[StateMachine] Message received. Type: " + nameof(StartGameMessage));
            ChangeState<GameplayState>();
            _gameFlowMediator.Publish(new GameStartedMessage());
        }

        public void Handle(FinishGameMessage message)
        {
            LogWrapper.Log("[StateMachine] Message received. Type: " + nameof(StartGameMessage));
            ChangeState<MainMenuState>();
            _gameFlowMediator.Publish(new GameFinishedMessage());
        }

        private void ChangeState<T>() where T: IState
        {
            if (_currentState != null)
            {
                _currentState.OnExit();
            }

            Type type = typeof(T);
            IState state = _states.Find(state => state.GetType() == type);
            state.OnEnter();

            _currentState = state;

            LogWrapper.Log("[StateMachine] State changed. Id: " + state.Id);
        }

        private void ChangeState<T>(T state) where T : IState
        {
            if (_currentState != null)
            {
                _currentState.OnExit();
            }

            state.OnEnter();

            _currentState = state;

            LogWrapper.Log("[StateMachine] State changed. Id: " + state.Id);
        }

        private void Update()
        {
            if (_currentState == null)
            {
                return;
            }

            _currentState.Tick(Time.deltaTime);
        }
    }
}
