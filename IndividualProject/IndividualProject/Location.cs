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
                    Console.WriteLine("You are standing in square 0,0. There is stuff here.");
                    Console.WriteLine("====== OPTIONS =====");
                    Console.WriteLine("(N)orth");
                    Console.WriteLine("(S)outh");
                    Console.WriteLine("(E)ast");
                    Console.WriteLine("(W)est");
                    Console.WriteLine("");
                    string input = Console.ReadLine() ?? ""; //?? says take the thing on the left unless its null, then it will put in whats on the right
                    if (input.ToLower() == "n" || input.ToLower() == "north")
                    {
                        Program.currentPlayer.formerplayerlocy = Program.currentPlayer.playerlocy;
                        Program.currentPlayer.playerlocy += 1;

                    }
                    else if (input.ToLower() == "s" || input.ToLower() == "south")
                    {
                        Program.currentPlayer.formerplayerlocy = Program.currentPlayer.playerlocy;
                        Program.currentPlayer.playerlocy -= -1;

                    }
                    else if (input.ToLower() == "e" || input.ToLower() == "east")
                    {
                        Program.currentPlayer.formerplayerlocx = Program.currentPlayer.playerlocx;
                        Program.currentPlayer.playerlocx += 1;

                    }
                    else if (input.ToLower() == "w" || input.ToLower() == "west")
                    {
                        Program.currentPlayer.formerplayerlocx = Program.currentPlayer.playerlocx;
                        Program.currentPlayer.playerlocx -= -1;

                    }
                }
            }
            else if (x == 0 && y == -1)
            {
                Console.Clear();
                Console.WriteLine("You are standing in square 0,-1. There is stuff here.");
                Console.WriteLine("====== OPTIONS =====");
                Console.WriteLine("(N)orth");
                Console.WriteLine("(E)ast");
                Console.WriteLine("(W)est");
                Console.WriteLine("");
                string input = Console.ReadLine() ?? "";
                if (input.ToLower() == "n" || input.ToLower() == "north")
                {
                    Program.currentPlayer.formerplayerlocy = Program.currentPlayer.playerlocy;
                    Program.currentPlayer.playerlocy = Program.currentPlayer.playerlocy + 1;

                }

                else if (input.ToLower() == "e" || input.ToLower() == "east")
                {
                    Program.currentPlayer.formerplayerlocx = Program.currentPlayer.playerlocx;
                    Program.currentPlayer.playerlocx = Program.currentPlayer.playerlocx + 1;

                }
                else if (input.ToLower() == "w" || input.ToLower() == "west")
                {
                    Program.currentPlayer.formerplayerlocx = Program.currentPlayer.playerlocx;
                    Program.currentPlayer.playerlocx = Program.currentPlayer.playerlocx - 1;

                }
            }

            else if (x == 0 && y == 1)
            {
                Console.Clear();
                Console.WriteLine("You are standing in square 0,1. There is stuff here.");
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
                Console.WriteLine("You are standing in square 1,1. There is stuff here.");
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
                Console.WriteLine("You are standing in square 1,-1. There is stuff here.");
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
                Console.WriteLine("You are standing in square 1,0. There is stuff here.");
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
                Console.WriteLine("You are standing in square -1,1. There is stuff here.");
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
                Console.WriteLine("You are standing in square -1,0. There is stuff here.");
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
                Console.WriteLine("You are standing in square -1,-1. There is stuff here.");
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



