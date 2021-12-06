using System.Collections.Generic;
using UnityEngine;
using UnityGame.Stats;
using UnityGame.Units;

namespace UnityGame.Spawning
{
    public class UnitFactory : MonoBehaviour
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Transform _spawnedUnitsParent;
        [SerializeField] private Transform _playerPosition;

        public Player SpawnPlayer()
        {
            Player player = Instantiate(_playerPrefab, _spawnedUnitsParent);

            player.transform.SetPositionAndRotation(_playerPosition.position, Quaternion.identity);

            HashSet<IStat> stats = new HashSet<IStat>()
            {
                new Health(100)
            };
            player.Init(stats);

            return player;
        }
    }
}
