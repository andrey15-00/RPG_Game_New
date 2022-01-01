namespace UnityGame.ResponseRequestCommunication
{
    public class RequestTest
    {
        private class RequestProcessor : IRequestProcessor<int, string>
        {
            public string Handle(int input)
            {
                return "Success with input " + input;
            }
        }

        public void Test()
        {
            IRequestProcessor<int, string> processor = new RequestProcessor();
            RequestCaller<int, string> handler = new RequestCaller<int, string>(processor);
            string result = handler.Call(5);
            LogWrapper.Log("Request processed. Result: " + result);
        }
    }
}
