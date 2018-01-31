using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    class Mage : Warrior
    {
        private int mana;
        private int maxMana;
        private int magicDamage;

        public Mage(string name, int health, int damage, int defense, RollingDie die, int mana, int magicDamage) : base(name, health, damage, defense, die)
        {
            this.mana = mana;
            this.maxMana = mana;
            this.magicDamage = magicDamage;
        }

        public string ManaBar()
        {
            return GraphicalBar(mana, maxMana);
        }

        public override void Attack(Warrior enemy)
        {
            // Mana isn't full
            if (mana < maxMana)
            {
                mana += 10;
                if (mana > maxMana)
                    mana = maxMana;
                base.Attack(enemy);
            }
            else // Magic damage
            {
                int hit = magicDamage + die.Roll();
                SetMessage(String.Format("{0} used magic and took {1} hp off", name, hit));
                enemy.Defend(hit);
                mana = 0;
            }
        }
    }
}
