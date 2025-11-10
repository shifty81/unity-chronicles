using UnityEngine;

namespace ChroniclesOfADrifter.Components
{
    /// <summary>
    /// Enemy AI component - basic enemy behavior
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyAI : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private float wanderRadius = 10f;
        [SerializeField] private float wanderInterval = 3f;
        
        [Header("Combat")]
        [SerializeField] private float detectionRange = 5f;
        [SerializeField] private float attackRange = 1.5f;
        [SerializeField] private float attackCooldown = 1f;
        [SerializeField] private float attackDamage = 10f;
        
        private Rigidbody2D rb;
        private Transform target;
        private Vector2 wanderTarget;
        private float nextWanderTime;
        private float lastAttackTime;
        private Vector3 spawnPosition;
        
        public enum AIState
        {
            Idle,
            Wandering,
            Chasing,
            Attacking
        }
        
        public AIState CurrentState { get; private set; } = AIState.Idle;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.freezeRotation = true;
            spawnPosition = transform.position;
        }
        
        private void Start()
        {
            // Find player
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
        }
        
        private void Update()
        {
            if (target == null) return;
            
            float distanceToPlayer = Vector2.Distance(transform.position, target.position);
            
            // State machine
            if (distanceToPlayer <= attackRange)
            {
                CurrentState = AIState.Attacking;
                Attack();
            }
            else if (distanceToPlayer <= detectionRange)
            {
                CurrentState = AIState.Chasing;
                ChasePlayer();
            }
            else
            {
                CurrentState = AIState.Wandering;
                Wander();
            }
        }
        
        private void ChasePlayer()
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
        }
        
        private void Wander()
        {
            if (Time.time >= nextWanderTime)
            {
                // Pick a random point within wander radius from spawn
                Vector2 randomDirection = Random.insideUnitCircle * wanderRadius;
                wanderTarget = (Vector2)spawnPosition + randomDirection;
                nextWanderTime = Time.time + wanderInterval;
            }
            
            Vector2 direction = (wanderTarget - (Vector2)transform.position).normalized;
            float distance = Vector2.Distance(transform.position, wanderTarget);
            
            if (distance > 0.5f)
            {
                rb.velocity = direction * moveSpeed * 0.5f; // Slower when wandering
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
        
        private void Attack()
        {
            rb.velocity = Vector2.zero;
            
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                lastAttackTime = Time.time;
                
                // Try to damage player
                var playerHealth = target.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.Damage(attackDamage);
                }
            }
        }
        
        private void OnDrawGizmosSelected()
        {
            // Visualize detection and attack ranges
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectionRange);
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
            
            // Visualize wander radius
            Gizmos.color = Color.blue;
            Vector3 origin = Application.isPlaying ? spawnPosition : transform.position;
            Gizmos.DrawWireSphere(origin, wanderRadius);
        }
    }
}
