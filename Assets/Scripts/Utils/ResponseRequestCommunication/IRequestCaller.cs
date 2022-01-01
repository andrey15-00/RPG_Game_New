namespace UnityGame.ResponseRequestCommunication
{
    public interface IRequestCaller<RequestType, ReturnType>
    {
        ReturnType Call(RequestType request);
    }
}
