using System.Collections.Generic;
using UnityEngine;
using UnityGame.Stats;

namespace UnityGame.Units
{
    public class Player : MonoBehaviour, IUnit
    {
        private Dictionary<StatType, IStat> _stats;

        public void Init(HashSet<IStat> stats)
        {
            _stats = new Dictionary<StatType, IStat>();
            foreach (var stat in stats)
            {
                _stats[stat.Type] = stat;
            }
        }

        public void ApplyStat(IStat stat)
        {
            _stats[stat.Type].Add(stat.Count);
        }
    }
}
