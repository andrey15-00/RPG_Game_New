namespace UnityGame.ResponseRequestCommunication
{
    public interface IRequestProcessor<RequestType, ReturnType> where RequestType: class
    {
        ReturnType Handle(RequestType request);
    }
}
