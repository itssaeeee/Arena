using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    class User
    {
        private int age;
        private string name;

        public User(int age, string name)
        {
            this.age = age;
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
