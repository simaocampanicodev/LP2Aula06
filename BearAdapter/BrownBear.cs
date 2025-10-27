using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace BearAdapter
{
    public class BrownBear : IBear
    {
        private readonly Random random;
        public bool Hibernating { get; set; }
        private void TryChangeHibernate()
        {
            if (random.NextDouble() < 0.05)
            {
                Hibernating = !Hibernating;
            }
        }

        public void GoTowards(object objectToWalkTowards)
        {
            TryChangeHibernate();
            if (!Hibernating)
                Console.WriteLine($"Bear moves towards {objectToWalkTowards}");
        }

        public void LookAt(object objectToLookAt)
        {
            TryChangeHibernate();
            if (!Hibernating)
                Console.WriteLine($"Bear looks at {objectToLookAt}");
        }

        public void Roar()
        {
            TryChangeHibernate();
            if (!Hibernating)
                Console.WriteLine("Roooooarrr!");
        }

        public bool TryEat(object objectToEat)
        {
            bool eatSuccess = false;
            TryChangeHibernate();
            if (!Hibernating && random.NextDouble() < 0.7)
            {
                Console.WriteLine($"Bear ate {objectToEat}");
                eatSuccess = true;
            }
            return eatSuccess;
        }

        public BrownBear()
        {
            random = new Random();

            Hibernating = random.NextDouble() < 0.2;
        }
    }
}