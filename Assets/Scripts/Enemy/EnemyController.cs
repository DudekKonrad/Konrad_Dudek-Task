using Player;
using UnityEngine;
using CharacterController = Character.CharacterController;

namespace Enemy
{
    public class EnemyController : CharacterController
    {
        private PlayerController _player;
        private bool _canMove = true;
        
        private void Update()
        {
            if (_canMove)
            {
                CheckMove();
                var direction = transform.position - _player.transform.position;
                direction.Normalize();
                transform.position += direction * (_settings.EnemySpeed * Time.deltaTime);
            }
        }

        public void SetPlayer(PlayerController player)
        {
            _player = player;
        }

        public void DisableMovement()
        {
            _canMove = false;
        }
    }
}