namespace UnityGame.States
{
    public class LoadingState : IState
    {
        public string Id => nameof(LoadingState);
        public IState NextState => new MainMenuState();

        public bool IsFinished()
        {
            return true;
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
