using UnityGame.GameLogic;
using Zenject;

namespace UnityGame.States
{
    public class GameplayState : IState
    {
        private LevelInitializer _levelInitializer;
        private InteractablesSearcher _interactablesSearcher;

        public string Id => nameof(GameplayState);

        public GameplayState(LevelInitializer levelInitializer, InteractablesSearcher interactablesSearcher)
        {
            _levelInitializer = levelInitializer;
            _interactablesSearcher = interactablesSearcher;
        }

        public void OnEnter()
        {
            _levelInitializer.InitLevel();
            _interactablesSearcher.Init(_levelInitializer.Player);
            _interactablesSearcher.Activate();
        }

        public void OnExit()
        {
            _interactablesSearcher.Deactivate();
            _levelInitializer.DestroyLevel();
        }

        public void Tick(float deltaTime)
        {
            
        }
    }
}
