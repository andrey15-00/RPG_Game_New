using System.Collections.Generic;
using UnityGame.Stats;

namespace UnityGame.Units
{
    public interface IUnit
    {
        public void Init(HashSet<IStat> stats);
        public void ApplyStat(IStat stat);
    }
}
