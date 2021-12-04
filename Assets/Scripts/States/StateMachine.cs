using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityGame.States
{
    public class StateMachine : MonoBehaviour
    {
       // private List<IState> _states = new List<IState>();
        private IState _currentState;

        public void Init(List<IState> states, string startStateId)
        {
            //_states = states;
            IState startState = states.Find(state => state.Id == startStateId);
            startState.OnEnter();
            _currentState = startState;
        }

        private void Update()
        {
            if(_currentState == null)
            {
                return;
            }

            if (_currentState.IsFinished())
            {
                IState nextState = _currentState.NextState;
                _currentState.OnExit();
                _currentState = nextState;
                _currentState.OnEnter();
            }
            else
            {
                _currentState.Tick(Time.deltaTime);
            }
        }
    }
}
