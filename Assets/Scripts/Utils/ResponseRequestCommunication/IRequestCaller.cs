namespace UnityGame.ResponseRequestCommunication
{
    public interface IRequestCaller<RequestType, ReturnType> where RequestType : class
    {
        ReturnType Call(RequestType request);
    }
}
