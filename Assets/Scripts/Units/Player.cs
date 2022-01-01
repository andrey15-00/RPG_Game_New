using System.Collections.Generic;
using UnityEngine;
using UnityGame.GameLogic;
using UnityGame.Stats;
using Zenject;

namespace UnityGame.Units
{
    public class Player : MonoBehaviour, IUnit
    {
        [SerializeField] private float _speed;
        private Dictionary<StatType, IStat> _stats;
        private InputSystem _inputSystem;

        [Inject]
        private void Constructor(InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }

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

        private void Update()
        {
            Vector2 move = _inputSystem.MoveInput * _speed * Time.deltaTime;
            transform.position += new Vector3(move.x, 0, move.y);
        }
    }
}
