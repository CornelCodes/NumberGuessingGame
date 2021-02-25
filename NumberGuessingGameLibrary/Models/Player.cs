using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGameLibrary.Models
{
    public class Player
    {
        public int Score { get; set; }
        public int Lives { get; set; }
        public string Name { get; private set; }

        public Player()
        {
            Lives = 3;
            Score = 0;
        }
    }
}
