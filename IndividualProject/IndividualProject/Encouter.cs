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
            Console.WriteLine();
            Console.WriteLine("'FRESH MEAT!'");
            Console.WriteLine();
            Console.WriteLine("The person gets directly in your face. Their breath is horrible.");
            Console.WriteLine("They just smile, and their teeth are rotted.");
            Console.WriteLine();
            Console.WriteLine("'I can't wait to kill you.'");
            Console.ReadKey();
            Combat(false, "Doesn't Brush Their Teeth", 1, 4);

        }
        public static void BasicFightEncounter()
        {
            string n = GetName();
            Console.Clear();
            Console.WriteLine("The worst of humanity is trying to assault you!");
            Console.WriteLine("A " + n +" charges you, sword raised.");
            Console.ReadKey();
            Console.Clear();
            Combat(true, n, 0, 0);
        }

        public static void FightWithTheDevil()
        {
            Console.Clear();
            Console.WriteLine("The Devil decends upon you.");
            Console.WriteLine();
            Console.WriteLine("'You are getting a little big for your britches!.'");
            Console.WriteLine("The Devil grins and charges you, claws raised!");
            Console.ReadKey();
            Combat(false, "The Devil (literaly)", Program.currentPlayer.GetStatPower() * 2, Program.currentPlayer.GetStatHealth() * 5);
        }
            


        // Encounter Tools
        public static void RandomEncounter()
        {
            int fightCheck = rand.Next(0, 3);
            switch (fightCheck)
            {
                case 0:
                    BasicFightEncounter();
                    break;
                case 1:
                    FightWithTheDevil();
                    break;
                case 2:
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
            switch (rand.Next(0, 89))
            {
                case 0:
                    return "Person who drives slow in the fast lane";
                case 1:
                    return "Person who chews with their mouth open";
                case 2:
                    return "Person who talks during movies";
                case 3:
                    return "Person who wears too much perfume";
                case 4:
                    return "Person who USES ALL CAPS!!!";
                case 5:
                    return "Humblebragger";
                case 6:
                    return "Person who doesn't return the shopping cart";
                case 7:
                    return "Person who taps their foot violently";
                case 8:
                    return "Person who takes up two parking spaces";
                case 9:
                    return "Person who eats other people's lunch";
                case 10:
                    return "Person who always replys all";
                case 11:
                    return "Person who applauds at the end of a plane trip";
                case 12:
                    return "Person who applauds at the end of a movie";
                case 13:
                    return "Person in the express checkout with too many items";
                case 14:
                    return "Person talking loudly on the phone at the gym";
                case 15:
                    return "Person who doesn't replace the toilet paper";
                case 16:
                    return "Booger Eater";
                case 17:
                    return "Person who RSVPs at the last minute";
                case 18:
                    return "Person who leaves the toilet seat up";
                case 19:
                    return "Person who picks their teeth in public";
                case 20:
                    return "Person who sniffs loudly but never blows their nose";
                case 21:
                    return "Person who blows their nose at maximum volume";
                case 22:
                    return "Person who takes up both armrests on a plane";
                case 23:
                    return "Surface Shitter";
                case 24:
                    return "Chow Thief";
                case 25:
                    return "Loud Eater";
                case 26:
                    return "Person who blocks the sidewalk for their selfies";
                case 27:
                    return "Person who texts while walking in a crowd";
                case 28:
                    return "Person who asks the teacher for more homework";
                case 29:
                    return "Person who never picks up the tab";
                case 30:
                    return "Person who makes every conversation about themselves";
                case 31:
                    return "Habitual Line Cutter";
                case 32:
                    return "Person who stands too close in line";
                case 33:
                    return "Non-stop Pen Clicker";
                case 34:
                    return "Person who starts their sentences with 'No offense'";
                case 35:
                    return "Person who is never on time";
                case 36:
                    return "Person who snaps their chewing gum";
                case 37:
                    return "Overzealous Toucher";
                case 38:
                    return "Person who doesn't wipe down their machines at the gym";
                case 39:
                    return "Person who won't shut up about their diet";
                case 40:
                    return "Person who keeps their phone on full volume";
                case 41:
                    return "Person who never knows what to order";
                case 42:
                    return "Person who doesn't know how to merge";
                case 43:
                    return "Person who can't shut up about their 'fur baby'";
                case 44:
                    return "Person who wears inappropiate clothing to work";
                case 45:
                    return "Person who makes up random nicknames";
                case 46:
                    return "Close Talker";
                case 47:
                    return "One Upper";
                case 48:
                    return "Nail Biter";
                case 49:
                    return "Knuckle Cracker";
                case 50:
                    return "Person who violently cracks their neck in public";
                case 51:
                    return "Person who always interrupts";
                case 52:
                    return "Know it All";
                case 53:
                    return "Person who never returns what they 'borrow'";
                case 54:
                    return "Over Sharer";
                case 55:
                    return "Person who is holier than thou";
                case 56:
                    return "Person who thinks everything is a joke";
                case 57:
                    return "Inconsiderate Jerk";
                case 58:
                    return "Virtue Signaler";
                case 59:
                    return "Person who doesn't use their blinker";
                case 60:
                    return "Guilt Tripper";
                case 61:
                    return "Person who acts like they were raised by wolves";
                case 62:
                    return "Person who will 'literally' die without their phone";
                case 63:
                    return "Drama Queen";
                case 64:
                    return "Cheap Bastard";
                case 65:
                    return "Person who finishes your sentences";
                case 66:
                    return "Ghoster";
                case 67:
                    return "Negative Nancy";
                case 68:
                    return "Person who is way to happy to be here";
                case 69:
                    return "Consistent Complainer";
                case 70:
                    return "Person who always has to be right";
                case 71:
                    return "Passive Aggressive A-hole";
                case 72:
                    return "Person who relates everything to their daily horoscope";
                case 73:
                    return "Person who doesn't know when to shut up";
                case 74:
                    return "Person who doesn't shower";
                case 75:
                    return "Clickbait Ad";
                case 76:
                    return "Prince from Nigeria that wants to give you money";
                case 77:
                    return "Spoiled rich only child";
                case 78:
                    return "Politician";
                case 79:
                    return "Meter Maid";
                case 80:
                    return "Liberal Arts Major";
                case 81:
                    return "Person who spoils movie endings";
                case 82:
                    return "Person who wipes their nose with their hand";
                case 83:
                    return "Person who doesn't flush the toilet";
                case 84:
                    return "Whiner";
                case 85:
                    return "Person who screams when they talk";
                case 86:
                    return "Person who moans at the urinal";
                case 87:
                    return "Sweat Lord";
                case 88:
                    return "Person whose 'long story short' is still long";
                case 89:
                    return "Person with taco breath";


            }
            return "default enemy name. you shouldn't be able to see this.";
        }
    }
}
