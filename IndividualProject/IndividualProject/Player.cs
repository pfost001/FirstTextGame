using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    [Serializable] //this means the data in here can be serialized and saved. it comes from the system.serialization call in the program. 
    public class Player
    {
        public string Name;
        public int SaveCounter = 0;
        public int coins = 50000;
        public int health = 10;
        public int damage = 1;
        public int armorValue = 0;
        public int potion = 5;
        public int weaponValue = 5;
        public int mods = 1;
        public float playerlocx = 0;
        public float playerlocy = 0;
        public float formerplayerlocx = 0;
        public float formerplayerlocy = 0;
        public bool firstencounter = false;

        public int GetStatPower()
        {
            Random rand = new Random();
            //this is to buy mods to make the game harder
            int upper = (2 * mods + 2);
            int lower = (mods + mods/3);
            return rand.Next(lower, upper);
        }
        public int GetStatHealth()
        {
            Random rand = new Random();
            //this is to buy mods to give monsters more health
            int upper = (3 * mods + 5);
            int lower = (mods);
            return rand.Next(lower, upper);
        }
        public int GetCoin()
        {
            Random rand = new Random();
            int upper = (5 * mods + 9);
            int lower = (mods + 3);
            return rand.Next(lower, upper);
        }
            

    }
}
