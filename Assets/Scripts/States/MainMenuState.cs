namespace UnityGame.States
{
    public class MainMenuState : IState
    {
        public string Id => nameof(MainMenuState);
        public IState NextState { get; private set; }

        public bool IsFinished()
        {
            return false;
        }

        public void OnEnter()
        {
            
        }

        public void OnExit()
        {
            
        }

        public void Tick(float deltaTime)
        {
            
        }
    }
}
