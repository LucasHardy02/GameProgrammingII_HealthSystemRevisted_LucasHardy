using System;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using static System.Net.Mime.MediaTypeNames;

namespace GameProgrammingII_HealthSystemRevisted_LucasHardy
{

    internal class Player
    {








        public Health Health;
        public Health Shield;

        public Player(string name, int maxHealth, int maxShield)
        {
            _name = name;
            Shield = new Health(maxShield);
            Health = new Health(maxHealth);
        }




        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }




        public void TakeDamage(int damageAmount)
        {
            if (damageAmount > Shield.CurrentHealth)
            {
                float spillDamage;

                spillDamage = damageAmount - Shield.CurrentHealth;
                Shield.TakeDamage(damageAmount);


                if (damageAmount < 0)
                {
                    Console.WriteLine("Attemted to recieve damage with a negative value");
                }
                else
                {
                    Health.TakeDamage(spillDamage);
                }

            }
            else
            {
                Shield.TakeDamage(damageAmount);

            }
        }
       
        public void ShowHUD()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Current Health: {Health.CurrentHealth}");
            Console.WriteLine($"Current Shield: {Shield.CurrentHealth}");
            Console.WriteLine($"Health Status: {Health.HealthStatus()}");
        }
    }
    internal class Health
    {
        private float _maxHealth;

        public Health(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
        }
        private float _currentHealth;

        public float CurrentHealth
        {
            get { return _currentHealth; }
            private set { _currentHealth = value; }
        }


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
            if (CurrentHealth + healingAmount > MaxHealth)
            {
                CurrentHealth = MaxHealth;
                Console.WriteLine("Attemted to heal past full health");
                Console.ReadKey();
            }
           
            else if (healingAmount < 0)
            {
                healingAmount = 0;
                Console.WriteLine("Attemted to heal with a negative value");
                Console.ReadKey();

            }

            else
            {
                CurrentHealth += healingAmount;
            }

        }
        public string HealthStatus()
        {
            if (CurrentHealth == 0)
            {
                return "Character is dead";
            }
            else if (CurrentHealth < 25)
            {
                return "Character is on their last legs";
            }
            else if (CurrentHealth < 50)
            {
                return "Character suffered major damage";
            }
            else if (CurrentHealth < 75)
            {
                return "Charcter suffered moderate damage";
            }
            else if (CurrentHealth < 100)
            {
                return "Character suffered minor damage";
            }
            else
            {
                return "Character is Healthy";
            }
            
        }
    }
    internal class Program
    {
        public string selectedName;
        static bool gameRunning = true;
        static void Main(string[] args)
        {
            Random random = new Random();

            Console.WriteLine("Please input your name");

            string selectedName = Console.ReadLine();
            Console.Clear();

            Player player = new Player(name: selectedName, maxHealth: 100, maxShield: 100);
            while (gameRunning == true)
            {
                

                player.ShowHUD();

                Console.WriteLine("Press D key to take damage or H key to heal");
                ConsoleKeyInfo playerInput = Console.ReadKey(true);

                if (player.Health.CurrentHealth <= 0)
                {
                    Console.WriteLine("You Died, press any key...");
                    Console.ReadKey();
                    gameRunning = false;
                }
                else
                {
                    Console.Clear();
                    if (playerInput.Key == ConsoleKey.D)
                    {
                        
                        int damageAmount = random.Next(21);
                        player.TakeDamage(damageAmount);

                        
                        
                    }
                    else if (playerInput.Key == ConsoleKey.H)
                    {
                        
                        int healingAmount = random.Next(21);
                        player.Health.Heal(healingAmount);

                        
                        
                    }
                    player.ShowHUD();
                    Console.Clear();

                }
            }
            
                
            
            






        }
        
    }
}

