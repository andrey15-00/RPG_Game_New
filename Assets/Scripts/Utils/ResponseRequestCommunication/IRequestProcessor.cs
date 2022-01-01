namespace UnityGame.ResponseRequestCommunication
{
    public interface IRequestProcessor<RequestType, ReturnType>
    {
        ReturnType Handle(RequestType input);
    }
}
