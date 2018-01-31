using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    class Warrior
    {
        protected string name;
        protected int health;
        protected int maxHealth;
        protected int damage;
        protected int defense;
        protected RollingDie die;
        protected string message;

        public Warrior(string name, int health, int damage, int defense, RollingDie die)
        {
            this.name = name;
            this.health = health;
            this.maxHealth = health;
            this.damage = damage;
            this.defense = defense;
            this.die = die;
        }


        public override string ToString()
        {
            return name;
        }

        public bool Alive()
        {
            return (health > 0);
        }

        public string GraphicalBar(int current, int maximum)
        {
            string s = "[";
            int total = 20;
            double count = Math.Round(((double)current / maximum) * total);

            if ((count == 0) && (Alive()))
                count = 1;
            for (int i = 0; i < count; i++)
            s += "#";
            s = s.PadRight(total + 1);
            s += "]";
            return s;
        }

        public string HealthBar()
        {
            return GraphicalBar(health, maxHealth);
        }

        public void Defend(int hit)
        {
            int injury = hit - (defense + die.Roll());
            if (injury > 0)
            {
                health -= injury;
                message = string.Format("{0} defended against the attack but still lost {1} hp", name, injury);
                if (health <= 0)
                {
                    health = 0;
                    message += " and died";
                }
            }
            else
                message = string.Format("{0} blocked the hit", name);
                SetMessage(message);
            
        }

        public virtual void Attack(Warrior enemy)
        {
            int hit = damage + die.Roll();
            SetMessage(string.Format("{0} attacks with a hit worth {1} hp", name, hit));
            enemy.Defend(hit);
        }


        protected void SetMessage(string message)
        {
            this.message = message;
        }

        public string GetMessage()
        {
            return message;
        }
    }
}
