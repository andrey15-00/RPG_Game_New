namespace UnityGame.ResponseRequestCommunication
{
    public class RequestCaller<T, V> : IRequestCaller<T, V>
    {
        private IRequestProcessor<T, V> _processor;

        public RequestCaller(IRequestProcessor<T,V> processor)
        {
            _processor = processor;
        }

        public V Call(T request)
        {
            return _processor.Handle(request);
        }
    }
}
