using Configs;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private PlayerController _player;
        [SerializeField] protected GameSettings _settings;
        private EnemyController[] _enemies;

        private void Awake()
        {
            _enemies = new EnemyController[_settings.NumberOfEnemies];
            for (var i = 0; i < _settings.NumberOfEnemies; i++)
            {
                _enemies[i] = SpawnEnemy();
            }
        }

        private EnemyController SpawnEnemy()
        {
            var spawnPosition = Random.onUnitSphere * _settings.SpawnRadius;
            spawnPosition.z = 0f;
            while (Vector3.Distance(spawnPosition, _player.transform.position) < 1f)
            {
                spawnPosition = Random.onUnitSphere * _settings.SpawnRadius;
                spawnPosition.z = 0f;
            }

            var enemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
            enemy.transform.parent = transform;
            var enemyController = enemy.GetComponent<EnemyController>();
            enemyController.SetPlayer(_player);
            return enemyController;
        }
    }
}