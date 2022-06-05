using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    public class Encouter
    {
        static Random rand = new Random();
        // Encounter Generic

        // Encounter
        public static void FirstEncounter()
        {
            Console.WriteLine("You can write some first encounter lead up text here.");
            Console.ReadKey();
            Combat(false, "Enemy Name", 1, 4);

        }
        public static void BasicFightEncounter()
        {
            string n = GetName();
            Console.WriteLine("This is the flavor text for a random encounter with " + n +".");
            Console.ReadKey();
            Console.Clear();
            Combat(true, n, 0, 0);
        }

        public static void WizardEncounter()
        {
            Console.Clear();
            Console.WriteLine("You see a wizard flavor text.");
            Console.ReadKey();
            Combat(false, "Wizard Name", Program.currentPlayer.GetStatPower() + 2, Program.currentPlayer.GetStatHealth() + 5);
        }
            


        // Encounter Tools
        public static void RandomEncounter()
        {
            switch (rand.Next(0, 2))
            {
                case 0:
                    BasicFightEncounter();
                    break;
                case 1:
                    WizardEncounter();
                    break;
            }
        }
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {
                n = name;
                p = Program.currentPlayer.GetStatPower();
                h = Program.currentPlayer.GetStatHealth();
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine("Enemy Power:" + p + " / " + "Enemy Health:" + h);
                Console.WriteLine("====== OPTIONS =====");
                Console.WriteLine("(A)ttack");
                Console.WriteLine("(D)efend");
                Console.WriteLine("(H)eal");
                Console.WriteLine("(R)un");
                Console.WriteLine("");
                Console.WriteLine(Program.currentPlayer.Name + "'s Weapon Power: " + Program.currentPlayer.weaponValue + " / " + Program.currentPlayer.Name + "'s Armor Power: " + Program.currentPlayer.armorValue);
                Console.WriteLine(Program.currentPlayer.Name + "'s Potions: " + Program.currentPlayer.potion +  " / " + Program.currentPlayer.Name + "'s Health: " + Program.currentPlayer.health);
                string input = Console.ReadLine();
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    //attack
                    Console.WriteLine("Attack Flavor Text");
                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    int attack = rand.Next(Program.currentPlayer.mods, Program.currentPlayer.weaponValue + rand.Next(Program.currentPlayer.mods, Program.currentPlayer.mods + 5));
                    Console.WriteLine("You lose " + damage + " health and do " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                    }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //defend
                    Console.WriteLine("Defend Flavor Text");
                    int damage = (p/4) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    int attack = rand.Next(Program.currentPlayer.mods, Program.currentPlayer.weaponValue + rand.Next(Program.currentPlayer.mods, Program.currentPlayer.mods + 5));
                    Console.WriteLine("You lose " + damage + " health and do " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                    }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //run
                    Console.WriteLine("Run Flavor Text");
                    if (rand.Next(0,4) == 0)
                    {
                        Console.WriteLine("You can't run text.");
                        Console.WriteLine("You didn't run and now you took damage flavor text");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Program.currentPlayer.health -= damage;
                        
                    }
                    else
                    {
                        Console.WriteLine("You managed to escape text");
                        Console.ReadLine(); 
                        Shop.LoadShop(Program.currentPlayer);
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //heal
                    if (Program.currentPlayer.potion == 0) //check to see if they have potions
                    {
                        Console.WriteLine("You don't have any potions flavor text");
                        Console.WriteLine("You get hit because you didn't have any potions flavor text");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Program.currentPlayer.health -= damage;
                    }
                    else
                    {
                        Console.WriteLine("you drank a potion flavor text"); //player gains health
                        int potionv = 5;
                        Console.WriteLine("you gain " + potionv + " health");
                        Program.currentPlayer.health += potionv;
                        Console.WriteLine("Flavor text for getting hit while drinking potion.");
                        int damage = (p / 2) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine("You lose " + damage + " health for getting hit while drinking a potion text");
                    }
                    Console.ReadKey();
                    }
                if(Program.currentPlayer.health <= 0)
                {
                    //death code
                    Console.WriteLine("Death flavor text.");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                Console.ReadKey();
                }
            int c = rand.Next(3, 8);
            
            Console.WriteLine("You have won the fight flavor text. you gain " + (c * Program.currentPlayer.mods) + " coins.");
            Program.currentPlayer.GetCoin();            
            Console.ReadKey();
            
            
        }
        public static string GetName()
        {
            switch (rand.Next(0, 4))
            {
                case 0:
                    return "enemy name 1";
                case 1:
                    return "enemy name 2";
                case 2:
                    return "enemy name 3";
                case 3:
                    return "enemy name 4";
            }
            return "default enemy name. you shouldn't be able to see this.";
        }
    }
}
