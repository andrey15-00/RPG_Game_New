namespace UnityGame.Stats
{
    public class Health : IStat
    {
        public int Count { get; private set; }
        public StatType Type { get => StatType.Health; }

        public Health(int count)
        {
            Count = count;
        }

        public void Add(int count)
        {
            Count += count;
        }
    }
}
