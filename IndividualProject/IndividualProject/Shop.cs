using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    public class Shop
    {
        static int armorMod;
        static int weaponMod;
        static int diffMod;

        public static void LoadShop(Player p)
        {
            RunShop(p);
        }
        public static void RunShop(Player p)
        {
            armorMod = p.armorValue;
            weaponMod = p.weaponValue;
            diffMod = p.mods;
            int potionP, armorP, weaponP, diffP, healthP;

            while (true)
            {
                potionP = 25;
                armorP = 100 + 15 * p.armorValue;
                weaponP = 100 + 15 * p.weaponValue;
                diffP = 10 + 5 * p.mods;
                healthP = 25 + 5 * p.health;

                Console.Clear();
                Console.WriteLine("== " + Program.currentPlayer.Name + "'s CURRENT STATS ==");
                Console.WriteLine("Weapon Power = " + Program.currentPlayer.weaponValue);
                Console.WriteLine("Armor Power = " + Program.currentPlayer.armorValue);
                Console.WriteLine("Health = " + Program.currentPlayer.health);
                Console.WriteLine("Difficulty Level = " + Program.currentPlayer.mods);
                Console.WriteLine("Coins = " + Program.currentPlayer.coins);
                Console.WriteLine("");
                Console.WriteLine("========= SHOP =========");
                Console.WriteLine("(H)ealth Increase = " + healthP);
                Console.WriteLine("(P)otion = " + potionP);
                Console.WriteLine("(W)eapon = " + weaponP);
                Console.WriteLine("(A)rmor = " + armorP);
                Console.WriteLine("(D)ifficulty Mods = " + diffP);
                Console.WriteLine("E(x)it the shop");
                Console.WriteLine("(Q)uit the game");
                //need player input
                string input = Console.ReadLine();
                if (input.ToLower() == "p" || input.ToLower() == "potion")
                {
                    TryBuy("potion", potionP, p);
                }
                else if (input.ToLower() == "w" || input.ToLower() == "weapon")
                {
                    TryBuy("weapon", weaponP, p);
                }
                else if (input.ToLower() == "a" || input.ToLower() == "armor")
                {
                    TryBuy("armor", armorP, p);
                }
                else if (input.ToLower() == "d" || input.ToLower() == "difficulty mods" || input.ToLower() == "mod")
                {
                    TryBuy("diffmod", diffP, p);
                }
                else if (input.ToLower() == "h" || input.ToLower() == "health")
                {
                    TryBuy("health", healthP, p);
                }
                else if (input.ToLower() == "x" || input.ToLower() == "exit")
                {
                    break;
                }
                else if (input.ToLower() == "q" || input.ToLower() == "quit")
                {
                    Program.Quit();
                }

            }
            static void TryBuy(string item, int cost, Player p)
            {
                if (p.coins >= cost)
                {
                    if (item == "potion")
                    {
                        p.potion++;
                    }
                    else if (item == "weapon")
                    {
                        p.weaponValue++;
                    }
                    else if (item == "armor")
                    {
                        p.armorValue++;
                    }
                    else if (item == "diffmod")
                    {
                        p.mods++;
                    }
                    else if (item == "health")
                    {
                        p.health++;
                    }
                    p.coins -= cost; //to remove gold for cost
                }
                else
                {
                    Console.WriteLine("You don't have enough gold.");
                    Console.ReadKey();
                }
            }
        }
    }
}
