using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Model
{
    internal class Human
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronomyc { get; set; }
        public int Age { get; set; }

        public Human(string name, string surname, string patronomyc, int age)
        {
            Name = name;
            Surname = surname;
            Patronomyc = patronomyc;
            Age = age;
        }
    }
}
