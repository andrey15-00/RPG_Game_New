using UnityGame.Mediation;

namespace Temp
{
    public class TestMessage : IMediatorMessage
    {
        public int value;
        public TestMessage(int value)
        {
            this.value = value;
        }
    }
}