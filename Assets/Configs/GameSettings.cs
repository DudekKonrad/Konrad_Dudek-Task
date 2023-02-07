using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/Game Settings")]
    public class GameSettings : ScriptableObject
    {
        public float PlayerSpeed = 10.0f;
        public float EnemySpeed = 5.0f;
        public int NumberOfEnemies = 1000;
        public float SpawnRadius = 5f;
    }
}