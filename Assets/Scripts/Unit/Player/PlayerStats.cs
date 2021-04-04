using UnityEngine;

namespace Unit.Player
{
    public class PlayerStats: MonoBehaviour, global::IUnitStats
    {

        public int health;
        public int maxHealth;
        public int speed;
        public int damage;
        public int jumpHeight;

        public HealthBar HealthBar;
        
        public void Start()
        {
            maxHealth = 3;
            health = 3;
            speed = 3;
            damage = 3;
            jumpHeight = 5;
            UpdateHealthBarMaxHealth();
            UpdateHealthBarCurrentHealth();
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            UpdateHealthBarCurrentHealth();
        }

        public void RestoreHealth(int health)
        {
            if (this.health + health >= maxHealth)
                this.health = maxHealth;
            else this.health += health;
            UpdateHealthBarCurrentHealth();
        }

        public void UpdateHealthBarCurrentHealth()
        {
            HealthBar.SetHealth(health);
        }

        public void UpdateHealthBarMaxHealth()
        {
            HealthBar.SetMaxHealth(maxHealth);
        }

        public bool IsDeath()
        {
            return health <= 0;
        }

        public void Update()
        {
            UpdateHealthBarCurrentHealth();
            if (IsDeath())
            {
                Destroy(gameObject);
            }
            
        }
    }
}
