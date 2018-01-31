 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    class Program
    {
        static void Main(string[] args)
        {
            RollingDie die = new RollingDie(10);
            Warrior warrior = new Warrior("U", 100, 20, 10, die);
            Warrior enemy = new Mage("Boo", 100, 20, 10, die, 35, 40);
            Arena arena = new Arena(warrior, enemy, die);

            arena.Fight();
            Console.ReadKey();
        }
    }
}
