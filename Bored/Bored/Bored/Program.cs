using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bored
{
    class Program
    {
        static void Main(string[] args)
        {
            int playAgain = 1;

            Choices choices = new Choices();
            while (playAgain == 1)
            {
                choices.characterSelection();
                choices.decision();
                Console.Write("Play Again (1 for yes, 0 for no): ");
                playAgain = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
