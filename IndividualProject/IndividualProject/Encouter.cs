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
            Console.WriteLine("You are making your way towards the shop when you hear a voice yelling.");
            Console.WriteLine("'FRESH MEAT!'");
            Console.WriteLine("The person gets directly in your face. Their breath is horrible. Like, really really bad. To the point where it is a distraction");
            Console.WriteLine("They just smile, which is really weird.");
            Console.WriteLine("'I can't wait to kill you.'");
            Console.ReadKey();
            Combat(false, "Doesn't Brush Their Teeth", 1, 4);

        }
        public static void BasicFightEncounter()
        {
            string n = GetName();
            Console.Clear();
            Console.WriteLine("The worst of humanity is trying to assault you! " + n +" charges you, sword raised.");
            Console.ReadKey();
            Console.Clear();
            Combat(true, n, 0, 0);
        }

        public static void FightWithTheDevil()
        {
            Console.Clear();
            Console.WriteLine("The Devil decends upon you.");
            Console.WriteLine("'You are getting a little to uppity for my liking.'");
            Console.WriteLine("The Devil grins and charges you, claws raised!");
            Console.ReadKey();
            Combat(false, "The Devil (Not your ex)", Program.currentPlayer.GetStatPower() * 2, Program.currentPlayer.GetStatHealth() * 5);
        }
            


        // Encounter Tools
        public static void RandomEncounter()
        {
            int fightCheck = rand.Next(0, 1001);
            switch (rand.Next(0, 1000))
            {
                case 0 - 200:
                    BasicFightEncounter();
                    break;
                case 1000:
                    FightWithTheDevil();
                    break;
                case 300 - 999:
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
                        Program.currentPlayer.potion--;
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
            switch (rand.Next(0, 85))
            {
                case 0:
                    return "Slow Driver in the Fast Lane";
                case 1:
                    return "Chews With Mouth Open";
                case 2:
                    return "Movie Talker";
                case 3:
                    return "Wears Too Much Perfume";
                case 4:
                    return "USES ALL CAPS!!!";
                case 5:
                    return "Humblebragger";
                case 6:
                    return "Doesn't Return the Shopping Cart";
                case 7:
                    return "Violent Foot Tapper";
                case 8:
                    return "Take us Two Parking Spaces";
                case 9:
                    return "Eat Other People's Lunch";
                case 10:
                    return "Always Replys All";
                case 11:
                    return "Talks at the Movies";
                case 12:
                    return "Applauds at End of Movie";
                case 13:
                    return "Express Checkout with 30 Items";
                case 14:
                    return "Talks Loudly on Phone at Gym";
                case 15:
                    return "Doesn't Replace the Toilet Paper";
                case 16:
                    return "Booger Eater";
                case 17:
                    return "RSVPs at the Last Minute";
                case 18:
                    return "Leaves Toilet Seat Up";
                case 19:
                    return "Picks Food From Teeth";
                case 20:
                    return "Sniffs Loudly, Doesn't Blow Nose";
                case 21:
                    return "Blows Nose Really Really Loudly";
                case 22:
                    return "Take up Both Armrests on the Plane";
                case 23:
                    return "Surface Shitter";
                case 24:
                    return "Chow Thief";
                case 25:
                    return "Loud Eater";
                case 26:
                    return "Blocks Sidewalk for Selfie";
                case 27:
                    return "Texts While Walking in a Crowd";
                case 28:
                    return "Asks Teacher for More Homework";
                case 29:
                    return "Never Picks up Tab";
                case 30:
                    return "Makes Every Conversation About Themself";
                case 31:
                    return "Cuts In Line";
                case 32:
                    return "Stands Too Close In Line";
                case 33:
                    return "Incessant Pen Clicker";
                case 34:
                    return "Starts Sentences With No Offense";
                case 35:
                    return "Never on Time";
                case 36:
                    return "Snaps Their Chewing Gum";
                case 37:
                    return "Touches Strangers";
                case 38:
                    return "Doesn't Wipe Down Machines at Gym";
                case 39:
                    return "Always Talking About Their Diet";
                case 40:
                    return "Keeps Phones Volume High in Public";
                case 41:
                    return "Never Knows What to Order";
                case 42:
                    return "Doesn't Know How to Merge";
                case 43:
                    return "Can't Shut Up About Their Pet";
                case 44:
                    return "Wears Inappropiate Clothes to Work";
                case 45:
                    return "Calls People Random Nicknames";
                case 46:
                    return "Close Talker";
                case 47:
                    return "The One Upper";
                case 48:
                    return "Nail Biter";
                case 49:
                    return "Knuckle Cracker";
                case 50:
                    return "Violently Cracks Neck in Public";
                case 51:
                    return "Always Interrupts";
                case 52:
                    return "Know it All";
                case 53:
                    return "Never Returns Items";
                case 54:
                    return "Over Sharer";
                case 55:
                    return "Holier Than Thou";
                case 56:
                    return "Everything is a Joke";
                case 57:
                    return "Inconsiderate Jerk";
                case 58:
                    return "Virtue Signaler";
                case 59:
                    return "Doesn't Use Blinker";
                case 60:
                    return "Guilt Tripper";
                case 61:
                    return "Raise by Wolves";
                case 62:
                    return "Will Die Without Phone";
                case 63:
                    return "Drama Queen";
                case 64:
                    return "Cheap Bastard";
                case 65:
                    return "Finishes Your Sentence";
                case 66:
                    return "Ghoster";
                case 67:
                    return "Captain Negative";
                case 68:
                    return "Way Too Happy To Be Here";
                case 69:
                    return "Always Complains";
                case 70:
                    return "Always Has To Be Right";
                case 71:
                    return "Passive Aggressive";
                case 72:
                    return "Really Into Astology";
                case 73:
                    return "Doesn't Know When To Shut Up";
                case 74:
                    return "Doesn't Shower";
                case 75:
                    return "Clickbait";
                case 76:
                    return "That One Prince From Nigeria";
                case 77:
                    return "Rich Only Chiled";
                case 78:
                    return "Politician";
                case 79:
                    return "Meter Maid";
                case 80:
                    return "Liberal Arts Major";
                case 81:
                    return "Spoils Endings";
                case 82:
                    return "Wipes Nose With Hands";
                case 83:
                    return "Doesn't Flush the Toilet";
                case 84:
                    return "Whiner";
                case 85:
                    return "Screams When They Talk";


            }
            return "default enemy name. you shouldn't be able to see this.";
        }
    }
}
