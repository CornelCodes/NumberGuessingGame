using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGameLibrary.Factories
{
    public class RandomNumberFactory
    {
        private Random random;

        public RandomNumberFactory()
        {
            random = new Random();
        }

        public int GetRandomNumber()
        {
            return random.Next(1, 6);
        }
    }
}
