using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    public class Location
    {
        //public static void WhereAt()
        //{
        //    PlayerLoc();
        //}
        // USE CTR + K, D to align text & check for how many curly braces are at the end.

        public static void PlayerLoc(float x, float y)

        {
            //float x = Program.currentPlayer.playerlocx;
            //float y = Program.currentPlayer.playerlocy;

            if (x == 0.0 && y == 0.0)
            {
                if (Program.currentPlayer.firstencounter == false)
                {
                    Encouter.FirstEncounter();
                    Program.currentPlayer.firstencounter = true;


                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You are standing in the center of Hell. Tom's Gift Shop is nearby.");
                    Console.WriteLine("====== OPTIONS =====");
                    Console.WriteLine("(N)orth");
                    Console.WriteLine("(S)outh");
                    Console.WriteLine("(E)ast");
                    Console.WriteLine("(W)est");
                    Console.WriteLine("(T)om's Gift Shop");
                    Console.WriteLine("");
                    string input = Console.ReadLine() ?? ""; //?? says take the thing on the left unless its null, then it will put in whats on the right
                    if (input.ToLower() == "n" || input.ToLower() == "north")
                    {
                        Program.currentPlayer.formerplayerlocy = Program.currentPlayer.playerlocy;
                        Program.currentPlayer.playerlocy ++;

                    }
                    else if (input.ToLower() == "s" || input.ToLower() == "south")
                    {
                        Program.currentPlayer.formerplayerlocy = Program.currentPlayer.playerlocy;
                        Program.currentPlayer.playerlocy --;

                    }
                    else if (input.ToLower() == "e" || input.ToLower() == "east")
                    {
                        Program.currentPlayer.formerplayerlocx = Program.currentPlayer.playerlocx;
                        Program.currentPlayer.playerlocx ++;

                    }
                    else if (input.ToLower() == "w" || input.ToLower() == "west")
                    {
                        Program.currentPlayer.formerplayerlocx = Program.currentPlayer.playerlocx;
                        Program.currentPlayer.playerlocx --;
                    }
                    else if (input.ToLower() == "t" || input.ToLower() == "toms")
                    {
                        Shop.LoadShop(Program.currentPlayer);
                    }
                }
            }
            else if (x == 0 && y == -1)
            {
                Console.Clear();
                Console.WriteLine("You are standing at the base of a large granite hill.");
                Console.WriteLine("There is a person pushing a large stone up the mountain.");
                Console.WriteLine();
                Console.WriteLine("As they reach the top of the hill, the stone rolls backwards crushing them.");
                Console.WriteLine("Moments later they are reborn at the base of the hill and begin pushing the stone again.");
                Console.WriteLine();
                Console.WriteLine("====== OPTIONS =====");
                Console.WriteLine("(N)orth");
                Console.WriteLine("(E)ast");
                Console.WriteLine("(W)est");
                Console.WriteLine("");
                string input = Console.ReadLine() ?? "";
                if (input.ToLower() == "n" || input.ToLower() == "north")
                {
                    Program.currentPlayer.formerplayerlocy = Program.currentPlayer.playerlocy;
                    Program.currentPlayer.playerlocy ++;

                }

                else if (input.ToLower() == "e" || input.ToLower() == "east")
                {
                    Program.currentPlayer.formerplayerlocx = Program.currentPlayer.playerlocx;
                    Program.currentPlayer.playerlocx ++;

                }
                else if (input.ToLower() == "w" || input.ToLower() == "west")
                {
                    Program.currentPlayer.formerplayerlocx = Program.currentPlayer.playerlocx;
                    Program.currentPlayer.playerlocx --;

                }
            }

            else if (x == 0 && y == 1)
            {
                Console.Clear();
                Console.WriteLine("You stand near a lake of fire with a crane positioned over it.");
                Console.WriteLine("The crane holds a cage with a person in it.");
                Console.WriteLine();
                Console.WriteLine("The crane slowly lowers the person into the fire and pulls up their burnt corpse");
                Console.WriteLine("The person is quickly reborn inside the cage, only for the process to repeat itself.");
                Console.WriteLine();
                Console.WriteLine("====== OPTIONS =====");
                Console.WriteLine("(S)outh");
                Console.WriteLine("(E)ast");
                Console.WriteLine("(W)est");
                Console.WriteLine("");
                string input = Console.ReadLine();
                if (input.ToLower() == "s" || input.ToLower() == "south")
                {
                    Program.currentPlayer.formerplayerlocy = Program.currentPlayer.playerlocy;
                    Program.currentPlayer.playerlocy--;

                }
                else if (input.ToLower() == "e" || input.ToLower() == "east")
                {
                    Program.currentPlayer.formerplayerlocx = Program.currentPlayer.playerlocx;
                    Program.currentPlayer.playerlocx++;

                }
                else if (input.ToLower() == "w" || input.ToLower() == "west")
                {
                    Program.currentPlayer.formerplayerlocx = Program.currentPlayer.playerlocx;
                    Program.currentPlayer.playerlocx--;

                }
            }

            else if (x == 1 && y == 1)
            {
                Console.Clear();
                Console.WriteLine("You field of people impaled on large spikes.");
                Console.WriteLine("They wail in pain as they continue to slowly die only to be reborn on the spike");
                Console.WriteLine();
                Console.WriteLine("====== OPTIONS =====");
                Console.WriteLine("(S)outh");
                Console.WriteLine("(W)est");
                Console.WriteLine("");
                string input = Console.ReadLine();
                if (input.ToLower() == "s" || input.ToLower() == "south")
                {
                    Program.currentPlayer.formerplayerlocy = Program.currentPlayer.playerlocy;
                    Program.currentPlayer.playerlocy--;

                }
                else if (input.ToLower() == "w" || input.ToLower() == "west")
                {
                    Program.currentPlayer.formerplayerlocx = Program.currentPlayer.playerlocx;
                    Program.currentPlayer.playerlocx--;

                }
            }
            else if (x == 1 && y == -1)
            {
                Console.Clear();
                Console.WriteLine("You stand on the precipice of a large, slow moving meat grinder.");
                Console.WriteLine("People are dropped into the meat grinder from above");
                Console.WriteLine();
                Console.WriteLine("They are the reborn mid-air and perpetually fall back into the grinder");
                Console.WriteLine();
                Console.WriteLine("====== OPTIONS =====");
                Console.WriteLine("(N)orth");
                Console.WriteLine("(W)est");
                Console.WriteLine("");
                string input = Console.ReadLine();
                if (input.ToLower() == "n" || input.ToLower() == "north")
                {
                    Program.currentPlayer.formerplayerlocy = Program.currentPlayer.playerlocy;
                    Program.currentPlayer.playerlocy++;

                }
                else if (input.ToLower() == "w" || input.ToLower() == "west")
                {
                    Program.currentPlayer.formerplayerlocx = Program.currentPlayer.playerlocx;
                    Program.currentPlayer.playerlocx--;

                }
            }
            else if (x == 1 && y == 0)
            {
                Console.Clear();
                Console.WriteLine("You are nearby a large field filled with people tied to posts.");
                Console.WriteLine("There are swarms of ants going from person to person eating them alive");
                Console.WriteLine();
                Console.WriteLine("The people are reborn only to be eaten again");
                Console.WriteLine();
                Console.WriteLine("====== OPTIONS =====");
                Console.WriteLine("(N)orth");
                Console.WriteLine("(S)outh");
                Console.WriteLine("(W)est");
                Console.WriteLine("");
                string input = Console.ReadLine();
                if (input.ToLower() == "n" || input.ToLower() == "north")
                {
                    Program.currentPlayer.formerplayerlocy = Program.currentPlayer.playerlocy;
                    Program.currentPlayer.playerlocy++;

                }
                else if (input.ToLower() == "s" || input.ToLower() == "south")
                {
                    Program.currentPlayer.formerplayerlocy = Program.currentPlayer.playerlocy;
                    Program.currentPlayer.playerlocy--;

                }
                else if (input.ToLower() == "w" || input.ToLower() == "west")
                {
                    Program.currentPlayer.formerplayerlocx = Program.currentPlayer.playerlocx;
                    Program.currentPlayer.playerlocx--;

                }
            }
            else if (x == -1 && y == 1)
            {
                Console.Clear();
                Console.WriteLine("You come across a rocky outcropping overlooking a river of lava.");
                Console.WriteLine("Other than being in hell, it is quite scenic.");
                Console.WriteLine();
                Console.WriteLine("====== OPTIONS =====");
                Console.WriteLine("(S)outh");
                Console.WriteLine("(E)ast");
                Console.WriteLine("");
                string input = Console.ReadLine();
                if (input.ToLower() == "s" || input.ToLower() == "south")
                {
                    Program.currentPlayer.formerplayerlocy = Program.currentPlayer.playerlocy;
                    Program.currentPlayer.playerlocy--;

                }
                else if (input.ToLower() == "e" || input.ToLower() == "east")
                {
                    Program.currentPlayer.formerplayerlocx = Program.currentPlayer.playerlocx;
                    Program.currentPlayer.playerlocx++;

                }
            }
            else if (x == -1 && y == 0)
            {
                Console.Clear();
                Console.WriteLine("You come across row after row of large clear water tanks.");
                Console.WriteLine("The people inside let loose muffles screams and pound the glass as they slowly drown.");
                Console.WriteLine();
                Console.WriteLine("They are reborn again underwater to repeat the process");
                Console.WriteLine();
                Console.WriteLine("====== OPTIONS =====");
                Console.WriteLine("(N)orth");
                Console.WriteLine("(S)outh");
                Console.WriteLine("(E)ast");
                Console.WriteLine("");
                string input = Console.ReadLine();
                if (input.ToLower() == "n" || input.ToLower() == "north")
                {
                    Program.currentPlayer.formerplayerlocy = Program.currentPlayer.playerlocy;
                    Program.currentPlayer.playerlocy++;

                }
                else if (input.ToLower() == "s" || input.ToLower() == "south")
                {
                    Program.currentPlayer.formerplayerlocy = Program.currentPlayer.playerlocy;
                    Program.currentPlayer.playerlocy--;

                }
                else if (input.ToLower() == "e" || input.ToLower() == "east")
                {
                    Program.currentPlayer.formerplayerlocx = Program.currentPlayer.playerlocx;
                    Program.currentPlayer.playerlocx++;

                }
            }
            else if (x == -1 && y == -1)
            {
                Console.Clear();
                Console.WriteLine("You find a person sitting atop a large triangle.");
                Console.WriteLine("Their legs are tied to heavy weights.");
                Console.WriteLine("The force of gravity uses the triangle to very slowly cut them half.");
                Console.WriteLine();
                Console.WriteLine("====== OPTIONS =====");
                Console.WriteLine("(N)orth");
                Console.WriteLine("(E)ast");
                Console.WriteLine("");
                string input = Console.ReadLine();
                if (input.ToLower() == "n" || input.ToLower() == "north")
                {
                    Program.currentPlayer.formerplayerlocy = Program.currentPlayer.playerlocy;
                    Program.currentPlayer.playerlocy++;

                }
                else if (input.ToLower() == "e" || input.ToLower() == "east")
                {
                    Program.currentPlayer.formerplayerlocx = Program.currentPlayer.playerlocx;
                    Program.currentPlayer.playerlocx++;

                }
            }

        }

    }

}



