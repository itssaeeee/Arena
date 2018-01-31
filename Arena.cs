using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Arena
{
    class Arena
    {
        private Warrior warrior1;
        private Warrior warrior2;
        private RollingDie die;

        public Arena(Warrior warrior1, Warrior warrior2, RollingDie die)
        {
            this.warrior1 = warrior1;
            this.warrior2 = warrior2;
            this.die = die;
        }

       private void Render()
        {
            Console.Clear();
            Console.WriteLine("-------------- Arena -------------- \n");
            Console.WriteLine("Warriors health: ");
            PrintWarrior(warrior1);
            Console.WriteLine();
            PrintWarrior(warrior2);
            Console.WriteLine();
        }

        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(500);
        }

        public void Fight()
        {
           Warrior w1 = warrior1;
           Warrior w2 = warrior2;

            Console.WriteLine("Welcome to the Arena!");
            Console.WriteLine("Today {0} will battle against {1}! \n", warrior1, warrior2);

            bool warrior2Starts = (die.Roll() <= die.GetSidesCount() / 2);
            if (warrior2Starts)
            {
                w1 = warrior2;
                w2 = warrior1;
            }


            Console.WriteLine("{0} goes first. \nLet the battle begin...", w1);
            Console.ReadKey();

            while (w1.Alive() && w2.Alive())
            {
                w1.Attack(w2);
                Render();
                PrintMessage(w1.GetMessage());
                PrintMessage(w2.GetMessage());

                Console.ReadKey();
                if (w2.Alive())
                {
                    w2.Attack(w1);
                    Render();
                    PrintMessage(w2.GetMessage());
                    PrintMessage(w1.GetMessage());
                    Console.ReadKey();
                }
            }
        }

        private void PrintWarrior(Warrior w)
        {
            Console.WriteLine(w);
            Console.Write("Health: ");
            Console.WriteLine(w.HealthBar());
            if (w is Mage)
            {
                Console.Write("Mana: ");
                Console.WriteLine(((Mage)w).ManaBar());
            }
        }

    }
}
