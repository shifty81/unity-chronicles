using UnityEngine;

namespace ChroniclesOfADrifter.Components
{
    /// <summary>
    /// Camera follow system for 2D top-down view
    /// Smoothly follows the player with optional look-ahead
    /// </summary>
    public class CameraFollow : MonoBehaviour
    {
        [Header("Target")]
        [SerializeField] private Transform target;
        
        [Header("Follow Settings")]
        [SerializeField] private float smoothSpeed = 5f;
        [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);
        
        [Header("Look-Ahead")]
        [SerializeField] private bool enableLookAhead = true;
        [SerializeField] private float lookAheadDistance = 2f;
        [SerializeField] private float lookAheadSmoothSpeed = 2f;
        
        [Header("Bounds")]
        [SerializeField] private bool constrainToBounds = false;
        [SerializeField] private Bounds cameraBounds;
        
        private Vector3 velocity = Vector3.zero;
        private Vector3 lookAheadPosition;
        
        private void LateUpdate()
        {
            if (target == null)
            {
                // Try to find player
                var player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    target = player.transform;
                }
                return;
            }
            
            // Calculate desired position
            Vector3 desiredPosition = target.position + offset;
            
            // Add look-ahead based on target velocity
            if (enableLookAhead)
            {
                Rigidbody2D targetRb = target.GetComponent<Rigidbody2D>();
                if (targetRb != null && targetRb.velocity.magnitude > 0.1f)
                {
                    Vector3 lookAheadTarget = new Vector3(
                        targetRb.velocity.x,
                        targetRb.velocity.y,
                        0
                    ).normalized * lookAheadDistance;
                    
                    lookAheadPosition = Vector3.Lerp(
                        lookAheadPosition,
                        lookAheadTarget,
                        Time.deltaTime * lookAheadSmoothSpeed
                    );
                }
                else
                {
                    lookAheadPosition = Vector3.Lerp(
                        lookAheadPosition,
                        Vector3.zero,
                        Time.deltaTime * lookAheadSmoothSpeed
                    );
                }
                
                desiredPosition += lookAheadPosition;
            }
            
            // Smoothly move camera
            Vector3 smoothedPosition = Vector3.SmoothDamp(
                transform.position,
                desiredPosition,
                ref velocity,
                1f / smoothSpeed
            );
            
            // Apply bounds if enabled
            if (constrainToBounds)
            {
                float cameraHalfHeight = Camera.main.orthographicSize;
                float cameraHalfWidth = cameraHalfHeight * Camera.main.aspect;
                
                smoothedPosition.x = Mathf.Clamp(
                    smoothedPosition.x,
                    cameraBounds.min.x + cameraHalfWidth,
                    cameraBounds.max.x - cameraHalfWidth
                );
                
                smoothedPosition.y = Mathf.Clamp(
                    smoothedPosition.y,
                    cameraBounds.min.y + cameraHalfHeight,
                    cameraBounds.max.y - cameraHalfHeight
                );
            }
            
            transform.position = smoothedPosition;
        }
        
        /// <summary>
        /// Set the camera target
        /// </summary>
        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }
        
        /// <summary>
        /// Set camera bounds
        /// </summary>
        public void SetBounds(Bounds bounds)
        {
            cameraBounds = bounds;
            constrainToBounds = true;
        }
        
        private void OnDrawGizmosSelected()
        {
            if (constrainToBounds)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireCube(cameraBounds.center, cameraBounds.size);
            }
        }
    }
}
