using Configs;
using UnityEngine;

namespace Character
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] protected GameSettings _settings;
        private SpriteRenderer _spriteRenderer;
        private Camera _mainCamera;
        private float _minX;
        private float _maxX;
        private float _minY;
        private float _maxY;
        
        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _mainCamera = Camera.main;
            var spriteWidth = _spriteRenderer.bounds.size.x / 2;
            var spriteHeight = _spriteRenderer.bounds.size.y / 2;

            var bottomLeft = _mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));
            var topRight = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

            _minX = bottomLeft.x + spriteWidth;
            _maxX = topRight.x - spriteWidth;
            _minY = bottomLeft.y + spriteHeight;
            _maxY = topRight.y - spriteHeight;
        }
        
        protected void CheckMove()
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, _minX, _maxX),
                Mathf.Clamp(transform.position.y, _minY, _maxY),
                transform.position.z
            );
        }
    }
}