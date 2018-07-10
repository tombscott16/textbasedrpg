using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bored
{
    class Normal
    {
        public int armorSelected = 0;
        public int weaponSelected = 0;
        public int HP = 0;
        public int meleeDamage = 0;
        Enemy aEnemy = new Enemy();
        Random rand = new Random();

        public void setHP(int HP)
        {
            this.HP = HP;
        }

        public int getMeleeDamage(int max, int min)
        {
            int meleeMax = max;
            int meleeMin = min;

            return rand.Next(meleeMin, meleeMax + 1);
        }

        public int getRangedDamage(int max, int min)
        {
            int rangedMax = max;
            int rangedMin = min;

            return rand.Next(rangedMin, rangedMax + 1);
        }

        public int getMagicDamage(int max, int min)
        {
            int magicMax = max;
            int magicMin = min;

            return rand.Next(magicMin, magicMax + 1);
        }

        public int decisionMenu(int selectedCharacter)
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            weaponSelection();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            armorSelection();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Wizard aWizard = new Wizard();
            Archer aArcher = new Archer();
            Paladin aPaladin = new Paladin();
            int option = 0;
            int EnemyHP = 0;
            int damage = 0;
            Weapon aWeapon = new Weapon();
            Armor aArmor = new Armor();
            Console.WriteLine("An enemy is approaching!");
            aEnemy.characterSelection();
            aEnemy.setHP();
            EnemyHP = aEnemy.getHP();
            Console.WriteLine("The enemy " + aEnemy.selectedCharacter + " has " + EnemyHP + " Hit Points");
            aEnemy.weaponSelection();
            aEnemy.armorSelection();
            while ((HP > 0) && (EnemyHP > 0))
            {
                damage = 0;
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1) Magic Attack");
                Console.WriteLine("2) Ranged Attack");
                Console.WriteLine("3) Melee Attack");
                Console.Write("Option: ");
                option = Convert.ToInt32(Console.ReadLine());
                
                switch (option)
                {
                    case 1:
                        Console.WriteLine("You have performed a Magic Attack");
                        if (weaponSelected == 1)
                        {
                            damage = aWeapon.getMagicStaff();
                        }
                        if (selectedCharacter == 1)
                        {
                            damage = damage + aWizard.getMagicDamage();
                        }
                        else
                        {
                            damage = damage + getMagicDamage(3, 2);
                        }
                        if (aEnemy.getArmorSelected() == 1)
                        {
                            damage = damage - aArmor.getRobe();
                        }
                        break;
                    case 2:
                        Console.WriteLine("You have performed a Ranged Attack");
                        if (weaponSelected == 2)
                        {
                            damage = aWeapon.getLongBow();
                        }
                        if (selectedCharacter == 2)
                        {
                            damage = damage + aArcher.getRangedDamage();
                        }
                        else
                        {
                            damage = damage + getRangedDamage(3, 2);
                        }
                        if (aEnemy.getArmorSelected() == 2)
                        {
                            damage = damage - aArmor.getRubber();
                        }
                        break;
                    case 3:
                        Console.WriteLine("You have performed a Melee Attack");
                        if (weaponSelected == 3)
                        {
                            damage = aWeapon.getSword();
                        }
                        if (selectedCharacter == 3)
                        {
                            damage = damage + aPaladin.getMeleeDamage();
                        }
                        else
                        {
                            damage = damage + getMeleeDamage(3, 2);
                        }
                        if (aEnemy.getArmorSelected() == 3)
                        {
                            damage = damage - aArmor.getTitanium();
                        }
                        break;
                }
                Console.WriteLine("You have caused " + damage + " damage to your enemy " + aEnemy.selectedCharacter);
                EnemyHP = EnemyHP - damage;
                if (EnemyHP <= 0)
                {
                    Console.WriteLine("The enemy " + aEnemy.selectedCharacter + "'s Hit Points are 0");
                    Console.WriteLine("You defeated the enemy " + aEnemy.selectedCharacter + "!");
                }
                else
                {
                    Console.WriteLine("Now the enemy " + aEnemy.selectedCharacter + "'s Hit Points are down to " + EnemyHP);
                    Console.WriteLine("Now it is your enemy " + aEnemy.selectedCharacter + "'s turn");
                    aEnemy.enemyDecision();
                    HP = HP - aEnemy.getDamage();
                }
                if(HP <= 0)
                {
                    Console.WriteLine("Now your Hit Points are down to 0");
                    Console.WriteLine("The enemy " + aEnemy.selectedCharacter + " has defeated you!");
                }else if (EnemyHP > 0)
                {
                    Console.WriteLine("Now your Hit Points are down to " + HP);
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            return HP & EnemyHP;
        }

        public void armorSelection()
        {
            Armor aArmor = new Armor();
            Console.WriteLine("Now chose your armor:");
            Console.WriteLine("1) Robe");
            Console.WriteLine("2) Rubber");
            Console.WriteLine("3) Titanium");
            Console.Write("Armor Selected: ");
            armorSelected = Convert.ToInt32(Console.ReadLine());

            switch (armorSelected)
            {
                case 1:
                    Console.WriteLine("You grabbed Robe Armor");
                    Console.WriteLine("The Robe Armor decreases " + aArmor.getRobe() + " from your enemy's Magic Attack");
                    break;
                case 2:
                    Console.WriteLine("You grabbed Rubber Armor");
                    Console.WriteLine("The Rubber Armor decreases " + aArmor.getRubber() + " from your enemy's Ranged Attack");
                    break;
                case 3:
                    Console.WriteLine("You grabbed Titanium Armor");
                    Console.WriteLine("The Titanium Armor decreases " + aArmor.getTitanium() + " from your enemy's Melee Attack");
                    break;
            }
        }

        public int getArmorSelected()
        {
            return armorSelected;
        }

        public void weaponSelection()
        {
            Weapon aWeapon = new Weapon();
            Console.WriteLine("Now chose your weapon:");
            Console.WriteLine("1) Magic Staff");
            Console.WriteLine("2) Long Bow");
            Console.WriteLine("3) Sword");
            Console.Write("Weapon Selected: ");
            weaponSelected = Convert.ToInt32(Console.ReadLine());

            switch (weaponSelected)
            {
                case 1:
                    Console.WriteLine("You grabbed a Magic Staff");
                    Console.WriteLine("The Magic Staff adds " + aWeapon.getMagicStaff() + " to your Magic Attack");
                    break;
                case 2:
                    Console.WriteLine("You grabbed a Long Bow");
                    Console.WriteLine("The Long Bow adds " + aWeapon.getLongBow() + " to your Ranged Attack");
                    break;
                case 3:
                    Console.WriteLine("You grabbed a Sword");
                    Console.WriteLine("The Sword adds " + aWeapon.getSword() + " to your Melee Attack");
                    break;
            }

        }

        public int getWeaponSelected()
        {
            return weaponSelected;
        }
    }
}
