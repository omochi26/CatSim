using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatSim
{
    internal class Cat
    {
        private int hunger = 0;
        private int happiness = 5;

        public bool IsAlive { get; set; } = true;
        public int Hunger
        {
            get
            {
                return hunger;
            }
            set
            {
                hunger = value;
                if (hunger >= 5)
                {
                    Console.WriteLine(Name + " died of starvation!");
                    IsAlive = false;
                }
                if (hunger <= -5)
                {
                    Console.WriteLine(Name + " got fat and exploded!");
                    IsAlive = false;
                }
            }
        }
        public string Name { get; set; }
        public int Happiness
        {
            get
            {
                return happiness;
            }
            set
            {
                happiness = value;
                if (happiness <= 0)
                {
                    Console.WriteLine(Name + " hates you and ran away!");
                    IsAlive = false;
                }
            }
        }

    }
}
