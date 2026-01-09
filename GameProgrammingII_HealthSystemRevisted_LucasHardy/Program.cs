using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgrammingII_HealthSystemRevisted_LucasHardy
{
    internal class Player
    {
        private string _name;
        public string Name
        {
            get { return _name; } 
            private set { _name = value; }
        }

        public Health Health = new Health(100);
        public Health Shield = new Health(100);

        public void TakeDamage(int damageAmount)
        {
            if (damageAmount > Shield.CurrentHealth)
            {
                float spillDamage;

                spillDamage = damageAmount - Shield.CurrentHealth;

                Shield.CurrentHealth = 0;

                Health.TakeDamage(spillDamage);

                

            }
        }
    }
    internal class Health
    {
        public Health(int maxHealth) 
        { 
            _maxHealth = maxHealth;
        }
        private float _currentHealth;

        public float CurrentHealth
        {
            get { return _currentHealth; }
            private set { _currentHealth = value; }
        }

        private float _maxHealth;

        public float MaxHealth
        {
            get { return _maxHealth; }
            private set { _maxHealth = value; }
        }

        public void TakeDamage(float damage)
        {
            if (damage < 0)
            {
                damage = 0;
                Console.WriteLine("Attemted to recieve damage with a negative value");
            }
            if (damage > CurrentHealth)
            {
                CurrentHealth = 0;
                Console.WriteLine("Damage was greater than players health");
                GetHealthStatus();
            }
            else
            {
                CurrentHealth -= damage;
            }
        }

        public void Restore()
        {
            CurrentHealth = MaxHealth;
        }

        public void Heal(int healingAmount)
        {
            if (healingAmount < 0)
            {
                healingAmount = 0;
                Console.WriteLine("Attemted to heal with a negative value");
            }

            if (CurrentHealth == MaxHealth)
            {
                CurrentHealth = MaxHealth;
                Console.WriteLine("Attemted to heal past full health")
                GetHealthStatus();
            }
            else
            {
                CurrentHealth += healingAmount;
            }
        }
        public void GetHealthStatus()
        {
            if (CurrentHealth == 100)
            {
                Console.WriteLine("Character is Healthy");
            }
            if (CurrentHealth < 100)
            {
                Console.WriteLine("Character suffered minor damage");
            }
            if (CurrentHealth < 75)
            {
                Console.WriteLine("Charcter suffered moderate damage");
            }
            if (CurrentHealth < 50)
            {
                Console.WriteLine("Character suffered major damage");
            }
            if (CurrentHealth < 25)
            {
                Console.WriteLine("Character is on their last legs");
            }
            if (CurrentHealth == 0)
            {
                Console.WriteLine("Character is dead");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
