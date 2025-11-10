using UnityEngine;

namespace ChroniclesOfADrifter.Components
{
    /// <summary>
    /// Player controller - handles player movement and input
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float moveSpeed = GameConstants.DefaultPlayerSpeed;
        [SerializeField] private float swimSpeedMultiplier = GameConstants.SwimSpeedMultiplier;
        
        [Header("Combat")]
        [SerializeField] private float attackCooldown = 0.5f;
        
        private Rigidbody2D rb;
        private Vector2 moveInput;
        private float lastAttackTime;
        private bool isSwimming;
        
        // Properties
        public float Speed => moveSpeed;
        public bool IsSwimming 
        { 
            get => isSwimming; 
            set => isSwimming = value; 
        }
        
        // Events
        public System.Action OnAttack;
        public System.Action<Vector2> OnMove;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0; // Top-down game, no gravity
            rb.freezeRotation = true; // Prevent rotation
        }
        
        private void Update()
        {
            // Get movement input
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
            
            // Normalize diagonal movement
            if (moveInput.magnitude > 1)
            {
                moveInput.Normalize();
            }
            
            // Handle attack input
            if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
            {
                TryAttack();
            }
        }
        
        private void FixedUpdate()
        {
            // Apply movement
            float speedMultiplier = isSwimming ? swimSpeedMultiplier : 1f;
            Vector2 velocity = moveInput * moveSpeed * speedMultiplier;
            rb.velocity = velocity;
            
            if (velocity.magnitude > 0.01f)
            {
                OnMove?.Invoke(velocity);
            }
        }
        
        private void TryAttack()
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                lastAttackTime = Time.time;
                OnAttack?.Invoke();
            }
        }
    }
}
