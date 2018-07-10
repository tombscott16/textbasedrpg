using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bored
{
    class Choices
    {
        Normal aNormal = new Normal();
        public int selectionOption = 0;
        public int characterSelection()
        {
            Console.WriteLine("Welcome to the Bored Game!");
            Console.WriteLine("Enter the character you want to play with");
            Console.WriteLine("1) Wizard Character");
            Console.WriteLine("2) Archer Character");
            Console.WriteLine("3) Paladin Character");
            Console.Write("Selection: ");
            selectionOption = Convert.ToInt32(Console.ReadLine());

            return selectionOption;
        }

        public void decision()
        {
            Console.Clear();
            switch(selectionOption)
            {
                case 1:
                    Wizard aWizard = new Wizard();
                    Console.WriteLine("You have chosen to be a Wizard!");
                    Console.WriteLine("You have 10 Hit Points");
                    aNormal.setHP(10);
                    aNormal.decisionMenu(selectionOption);
                    break;
                case 2:
                    Archer aArcher = new Archer();
                    Console.WriteLine("You have chosen to be an Archer!");
                    Console.WriteLine("You have 20 Hit Points");
                    aNormal.setHP(20);
                    aNormal.decisionMenu(selectionOption);
                    break;
                case 3:
                    Paladin aPaladin = new Paladin();
                    Console.WriteLine("You have chosen to be a Paladin!");
                    Console.WriteLine("You have 15 Hit Points");
                    aNormal.setHP(15);
                    aNormal.decisionMenu(selectionOption);
                    break;
            }
        }
    }
}
