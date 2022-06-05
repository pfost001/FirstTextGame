using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace IndividualProject
{
    public class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            if (!Directory.Exists("saves")) //this will check the directory for a folder named saves. it is where the saved files from player.cs will go. Notice the !
            {
                Directory.CreateDirectory("saves"); //this will make the directory if "saves" does not exist.
            }
            Console.WriteLine("(N)ew Game or (L)oad Game?");
            string data = Console.ReadLine() ?? "Please use a valid input";
            if (data.ToLower() == "n")
            {
                NewStart();
            }
            else
            {
                Load();
            }


            while (mainLoop) 
            {
                Location.PlayerLoc(Program.currentPlayer.playerlocx, Program.currentPlayer.playerlocy);
                Encouter.RandomEncounter();
            }
            
         }
        static void NewStart()
        {
            Console.Clear();
            Console.WriteLine("The Maw of Madness");
            Console.WriteLine("What is your name?");
            currentPlayer.Name = Console.ReadLine()??"Please use a valid input";
            currentPlayer.SaveCounter = 1;
            Save();
            Console.Clear();
            Console.WriteLine("This is where you put the intro to the story.");
            Console.WriteLine("You can write more intro story here.");
            if (currentPlayer.Name == "")
            {
                Console.WriteLine("It is too bad you don't have a name for your farm!");
            }
            else
            {
                Console.WriteLine("Welcome to " + currentPlayer.Name + "'s Farm!");
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("This is more story if you need it.");
            Location.PlayerLoc(Program.currentPlayer.playerlocx, Program.currentPlayer.playerlocy); ;
        }
        public static void Save()
        {
            Console.Clear();
            Console.WriteLine("Would you like to (o)verwrite or save a (n)ew file?");
            string input = Console.ReadLine()??"";
            if (input.ToLower() == "o")
            {
                BinaryFormatter binForm = new BinaryFormatter();
                string path = "saves/" + currentPlayer.Name.ToLower() + "_" + Program.currentPlayer.SaveCounter; //sets the filename for saving to. Using current player name. need to format checks on the enter name box.
                FileStream file = File.Open(path, FileMode.OpenOrCreate);
                binForm.Serialize(file, currentPlayer);
                file.Close();                
            }
            else
            {
                Program.currentPlayer.SaveCounter++;
                BinaryFormatter binForm = new BinaryFormatter();
                string path = "saves/" + currentPlayer.Name.ToLower(); //sets the filename for saving to. Using current player name. need to format checks on the enter name box.
                FileStream file = File.Open(path, FileMode.OpenOrCreate);
                binForm.Serialize(file, currentPlayer);
                file.Close();
                
            }
        }

        public static Player Load()
        {
            Console.Clear();
            Console.WriteLine("Choose your saved game");
            string[] paths = Directory.GetFiles("saves"); //this will build an array from all the file names in the "saves" folder
            List<Player> players = new List<Player>(); //creates a new list of the players
            
            BinaryFormatter binForm = new BinaryFormatter();
            foreach (string p in paths)
            {
                FileStream file = File.Open(p, FileMode.Open); //do not use opne or create or it will pull the file as writable
                Player pfile = (Player)binForm.Deserialize(file); //use cast to be sure you are opening only a player file. deserialize means load.
                file.Close();
                players.Add(pfile); //this will add the pfile to the players list
            }
            while (true)
            {
                Console.WriteLine("Current Save Files:");
                foreach (Player p in players)
                {
                    Console.WriteLine("Name: " + p.Name + ", Save Number:" + p.SaveCounter);
                }
                Console.WriteLine("Please input player name.");
                string inputfilename = Console.ReadLine() ?? "Please use a valid input";
                if (inputfilename != null)
                {
                    Console.WriteLine("Please input save number.");
                    string inputsavenum = Console.ReadLine() ?? "Please use a valid input";
                    if (inputsavenum != null && int.TryParse(inputsavenum, out int savenum))
                    {
                        foreach (Player player in players)
                        {
                            if (player.Name == inputfilename && player.SaveCounter == savenum)
                            {
                                return player;
                            }
                            else
                            {
                                Console.WriteLine("FILE NOT FOUND");
                            }
                        }
                    }
                }

            }
        }
        public static void Quit()
        {
            Save();
            Environment.Exit(0);
        }

    }
}