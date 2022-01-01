namespace UnityGame.GameLogic
{
    public interface IInteractable
    {
        void ShowUI();
        void HideUI();
        void StartInteract();
        void StopInteract();
    }
}
