namespace UnityGame.ResponseRequestCommunication
{
    public class RequestTest
    {
        private class RequestProcessor : IRequestProcessor<TestRequest, string>
        {
            public string Handle(TestRequest input)
            {
                return "Success with input " + input.value;
            }
        }

        public class TestRequest
        {
            public int value;

            public TestRequest(int v)
            {
                this.value = v;
            }
        }

        public void Test()
        {
            IRequestProcessor<TestRequest, string> processor = new RequestProcessor();
            RequestCaller<TestRequest, string> handler = new RequestCaller<TestRequest, string>(processor);
            string result = handler.Call(new TestRequest(5));
            LogWrapper.Log("Request processed. Result: " + result);
        }
    }
}
