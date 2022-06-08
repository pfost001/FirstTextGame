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
            Console.WriteLine("Life is Hell");
            Console.WriteLine("What is your name?");
            currentPlayer.Name = Console.ReadLine()??"";
            currentPlayer.SaveCounter = 1;
            Save();
            Console.Clear();
            Console.WriteLine("You wake up and look around. Everything is on fire.");
            Console.WriteLine("People are running and screaming. There are giant winged creatures in the air.");
            Console.WriteLine("'Hello!' someone says from behind you.");
            Console.WriteLine("You turn to see the devil. The actual fucking devil.");
            Console.WriteLine("'Welcome to Hell!' the devil says happily.");
            Console.WriteLine("'You are going to LOVE it here.'");
            Console.WriteLine("You find it impossible to come up with any sort of response. You are too overwhelmed.");
            Console.WriteLine("'Yeah I get that alot. Don't worry you were not that bad a person so you can pretty much do as you please down here. We only have a few rules.'");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("'First of all, you can't really die. If you do, you'll be reborn right back here. Not really a rule I guess...but good to know!'");
            Console.WriteLine("'Secondly, you have to kill people for my entertainment and for gold. They'll try to kill you too so you can call it self defense if you want.'");
            Console.WriteLine("'Finally, I like things bloody. Here is a sword and a shield. There is a shop over there where you can pick up some souvenirs.'");
            Console.WriteLine("'Best of luck to you. I hope you die painfully many many times.'");
            Console.WriteLine("The Devil tosses you a sort of half-ass salute and walks off.");
            Console.ReadKey();
            Console.Clear();
            
            if (currentPlayer.Name == "")
            {
                Console.WriteLine("Your name is really boring.");
            }
            else
            {
                Console.WriteLine("Welcome to hell " + currentPlayer.Name + "!");

            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You look around in disbelief.");
            Console.WriteLine("There is a shop nearby. The sign says Tom's Gift Shop.");
            Console.WriteLine("It is as good a place to start as any.");
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
                Player player = (Player)binForm.Deserialize(file); //use cast to be sure you are opening only a player file. deserialize means load.
                file.Close();
                players.Add(player); //this will add the pfile to the players list
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
                                Console.WriteLine("LOADING");
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