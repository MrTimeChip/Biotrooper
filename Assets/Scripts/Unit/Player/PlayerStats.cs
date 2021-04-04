using UnityEngine;

namespace Unit.Player
{
    public class PlayerStats: MonoBehaviour, global::IUnitStats 
    {
        public void Start()
        {
            Health = 3;
            Speed = 3;
            Damage = 3;
            JumpHeight = 5;
        }
        // Start is called before the first frame update
        public int Health { get; set; }
        public int Speed { get; set; }
        public int Damage { get; set; }
        public int JumpHeight { get; set; }
        
        public bool IsDeath()
        {
            return Health <= 0;
        }

        public void Update()
        {
            if (IsDeath())
            {
                Destroy(gameObject);
            }
            
        }
    }
}
