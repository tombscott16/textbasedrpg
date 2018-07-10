using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bored
{
    class Enemy
    {
        int HP = 0;
        int armorSelected = 0;
        int weaponSelected = 0;
        int damage = 0;
        public string selectedCharacter = "";
        Random rand = new Random();
        public void setHP()
        {
            int HPmax = 20;
            int HPmin = 10;

            HP = rand.Next(HPmin, HPmax);
        }

        public int getHP()
        {
            return HP;
        }

        public int meleeAttack()
        {
            int meleeMax = 5;
            int meleeMin = 2;

            return rand.Next(meleeMin, meleeMax);
        }

        public int rangedAttack()
        {
            int rangedMax = 5;
            int rangedMin = 2;

            return rand.Next(rangedMin, rangedMax);
        }

        public int magicAttack()
        {
            int magicMax = 5;
            int magicMin = 2;

            return rand.Next(magicMin, magicMax);
        }

        public void characterSelection()
        {
            int max = 3;
            int min = 1;

            int selected = rand.Next(min, max + 1);

            switch (selected)
            {
                case 1:
                    Console.WriteLine("Your enemy is a Wizard");
                    Console.WriteLine("Your enemy Wizard's Magic Attack is increased by 2");
                    selectedCharacter = "Wizard";
                    break;
                case 2:
                    Console.WriteLine("Your enemy is an Archer");
                    Console.WriteLine("Your enemy Archer's Ranged Attack is increased by 2");
                    selectedCharacter = "Archer";
                    break;
                case 3:
                    Console.WriteLine("Your enemy is a Paladin");
                    Console.WriteLine("Your enemy Paladin's Melee Attack is increased by 2");
                    selectedCharacter = "Paladin";
                    break;
            }
        }

        public void armorSelection()
        {
            Armor aArmor = new Armor();
            int armorMax = 3;
            int armorMin = 1;

            armorSelected = rand.Next(armorMin, armorMax);

            switch (armorSelected)
            {
                case 1:
                    Console.WriteLine("The enemy " + selectedCharacter + " grabbed Robe Armor");
                    Console.WriteLine("The Robe Armor decreases " + aArmor.getRobe() + " from your Magic Attack");

                    break;
                case 2:
                    Console.WriteLine("The enemy " + selectedCharacter + " grabbed Rubber Armor");
                    Console.WriteLine("The Rubber Armor decreases " + aArmor.getRubber() + " from your Ranged Attack");
                    break;
                case 3:
                    Console.WriteLine("The enemy " + selectedCharacter + " grabbed Titanium Armor");
                    Console.WriteLine("The Titanium Armor decreases " + aArmor.getTitanium() + " from your Melee Attack");
                    break;
            }
        }

        public int getArmorSelected()
        {
            return armorSelected;
        }

        public int weaponSelection()
        {
            Weapon aWeapon = new Weapon();
            int weaponMax = 3;
            int weaponMin = 1;

            weaponSelected = rand.Next(weaponMin, weaponMax);

            switch (weaponSelected)
            {
                case 1:
                    Console.WriteLine("The enemy " + selectedCharacter + " grabbed a Magic Staff");
                    Console.WriteLine("The Magic Staff adds " + aWeapon.getMagicStaff() + " to the enemy " + selectedCharacter + "'s Magic Attack");
                    break;
                case 2:
                    Console.WriteLine("The enemy " + selectedCharacter + " grabbed a Long Bow");
                    Console.WriteLine("The Long Bow adds " + aWeapon.getLongBow() + " to the enemy " + selectedCharacter + "'s Ranged Attack");
                    break;
                case 3:
                    Console.WriteLine("The enemy " + selectedCharacter + " grabbed a Sword");
                    Console.WriteLine("The Sword adds " + aWeapon.getSword() + " to the enemy " + selectedCharacter + "'s Melee Attack");
                    break;
            }
            return weaponSelected;
        }

        public int getWeaponSelected()
        {
            return weaponSelected;
        }

        public void enemyDecision()
        {
            int option = 0;
            int optionMax = 3;
            int optionMin = 1;
            damage = 0;

            option = rand.Next(optionMin, optionMax + 1);

            Normal aNormal = new Normal();
            Wizard aWizard = new Wizard();
            Archer aArcher = new Archer();
            Paladin aPaladin = new Paladin();
            Armor aArmor = new Armor();
            Weapon aWeapon = new Weapon();

            switch (option)
            {
                case 1:
                    Console.WriteLine("The enemy " + selectedCharacter + " has performed a Magic Attack");
                    if (weaponSelected == 1)
                    {
                        damage = aWeapon.getMagicStaff();
                    }
                    if (aNormal.getArmorSelected() == 1)
                    {
                        damage = damage - aArmor.getRobe();
                    }
                    if (selectedCharacter == "Wizard")
                    {
                        damage = damage + aWizard.getMagicDamage();
                    }
                    else
                    {
                        damage = damage + magicAttack();
                    }
                    break;
                case 2:
                    Console.WriteLine("The enemy " + selectedCharacter + " has performed a Ranged Attack");
                    if (weaponSelected == 2)
                    {
                        damage = aWeapon.getLongBow();
                    }
                    if (aNormal.getArmorSelected() == 2)
                    {
                        damage = damage - aArmor.getRubber();
                    }
                    if (selectedCharacter == "Archer")
                    {
                        damage = damage + aArcher.getRangedDamage();
                    }
                    else
                    {
                        damage = damage + rangedAttack();
                    }
                    break;
                case 3:
                    Console.WriteLine("The enemy " + selectedCharacter + " has performed a Melee Attack");
                    if (weaponSelected == 3)
                    {
                        damage = aWeapon.getSword();
                    }
                    if (aNormal.getArmorSelected() == 3)
                    {
                        damage = damage - aArmor.getTitanium();
                    }
                    if (selectedCharacter == "Paladin")
                    {
                        damage = damage + aPaladin.getMeleeDamage();
                    }
                    else
                    {
                        damage = damage + meleeAttack();
                    }
                    break;
            }
            Console.WriteLine("Your enemy " + selectedCharacter + " caused " + damage + " damage to you");
        }

        public int getDamage()
        {
            return damage;
        }
    }
}
