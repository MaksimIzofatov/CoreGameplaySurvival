using UnityEngine;
using UnityEngine.InputSystem;

namespace Camera
{
    public class CameraMover : MonoBehaviour
    {
        public float dragSpeed = 0.1f; // Чувствительность перетаскивания
        private bool _isDragging;
        private Vector2 _mouseDelta;

        // Методы для связи с Input Action (через PlayerInput или напрямую)
        public void OnDragClick(InputAction.CallbackContext context)
        {
            _isDragging = context.started;
        }

        public void OnMouseDelta(InputAction.CallbackContext context)
        {
            _mouseDelta = context.ReadValue<Vector2>();
        }

        private void Update()
        {
            if (_isDragging && _mouseDelta != Vector2.zero)
            {
                Vector3 forward = transform.forward;
                Vector3 right = transform.right;
                
                forward.y = 0;
                right.y = 0;
                forward.Normalize();
                right.Normalize();
                
                Vector3 move = (right * _mouseDelta.x + forward * _mouseDelta.y) * dragSpeed;
                
                transform.position -= move; 
            }
        }
    }
}