namespace UnityGame.States
{
    public interface IState
    {
        public string Id { get; }
        public void OnEnter();
        public void OnExit();
        public void Tick(float deltaTime);
    }
}
