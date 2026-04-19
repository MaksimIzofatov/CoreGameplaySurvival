using UnityEngine;
using UnityEngine.InputSystem;

namespace CameraUp
{
    public class CameraMover : MonoBehaviour
    {
        public float dragSpeed = 0.1f;
        private bool _isDragging;
        private Vector2 _mouseDelta;
        
        public void OnDragClick(InputAction.CallbackContext context)
        {
            _isDragging = context.started || context.performed;
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