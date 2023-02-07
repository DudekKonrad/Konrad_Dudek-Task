using Enemy;
using UnityEngine;
using CharacterController = Character.CharacterController;

namespace Player
{
    public class PlayerController : CharacterController
    {
        private void Update()
        {
            CheckMove();
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            var moveDirection = new Vector3(horizontal, vertical, 0f);
            transform.position += moveDirection * (_settings.PlayerSpeed * Time.deltaTime);
            
            if (Input.GetMouseButton(0))
            {
                var mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                var newPos = new Vector3(mousePos.x, mousePos.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPos, _settings.PlayerSpeed * Time.deltaTime);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<EnemyController>() == true)
            {
                other.gameObject.GetComponent<EnemyController>().DisableMovement();
            }
        }
    }
}