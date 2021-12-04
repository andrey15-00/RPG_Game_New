namespace UnityGame.Stats
{
    public interface IStat
    {
        public int Count { get; }
        public StatType Type { get; }

        public void Add(int count);
    }
}
