using UnityEngine;

namespace ChroniclesOfADrifter.Components
{
    /// <summary>
    /// Health component - represents entity health
    /// Attach to any GameObject that can take damage
    /// </summary>
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float currentHealth;
        
        public float MaxHealth 
        { 
            get => maxHealth; 
            set => maxHealth = value; 
        }
        
        public float CurrentHealth 
        { 
            get => currentHealth; 
            set => currentHealth = Mathf.Clamp(value, 0, maxHealth); 
        }
        
        public bool IsAlive => currentHealth > 0;
        public float HealthPercentage => currentHealth / maxHealth;
        
        // Events for health changes
        public System.Action<float> OnDamage;
        public System.Action<float> OnHeal;
        public System.Action OnDeath;
        
        private void Awake()
        {
            currentHealth = maxHealth;
        }
        
        /// <summary>
        /// Apply damage to this entity
        /// </summary>
        public void Damage(float amount)
        {
            if (amount <= 0) return;
            
            float oldHealth = currentHealth;
            currentHealth = Mathf.Max(0, currentHealth - amount);
            
            OnDamage?.Invoke(amount);
            
            if (IsAlive == false && oldHealth > 0)
            {
                OnDeath?.Invoke();
            }
        }
        
        /// <summary>
        /// Heal this entity
        /// </summary>
        public void Heal(float amount)
        {
            if (amount <= 0) return;
            
            currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
            OnHeal?.Invoke(amount);
        }
        
        /// <summary>
        /// Restore to full health
        /// </summary>
        public void FullHeal()
        {
            Heal(maxHealth - currentHealth);
        }
    }
}
