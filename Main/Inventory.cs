using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Main
{
    public partial class Inventory : Form
    {
        //Initializes Strings needs for following code 
        public string[] inventory = new string[100];
        public string[] charStats = new string[100];
        public string[] enemyStats = new string[100];
        Random rnd = new Random();
        public Inventory()
        {
            //Code belows opens txt files and saves them line by line to their respective array 
            InitializeComponent();
            using (StreamReader sr = new StreamReader("Inventory.txt"))
            {
                inventory[0] = sr.ReadLine(); //Coins
                inventory[1] = sr.ReadLine(); //Health
                inventory[2] = sr.ReadLine(); //Dagger
                inventory[3] = sr.ReadLine(); //Strength
            }
            using (StreamReader reader = new StreamReader("ClassStats.txt"))
            {
                charStats[0] = reader.ReadLine(); // Name
                charStats[1] = reader.ReadLine(); // Class
                charStats[2] = reader.ReadLine(); // Level
                charStats[3] = reader.ReadLine(); // EXP
                charStats[4] = reader.ReadLine(); // Health
                charStats[5] = reader.ReadLine(); // Active Health
                charStats[6] = reader.ReadLine(); // Attack
                charStats[7] = reader.ReadLine(); // Defence
                charStats[8] = reader.ReadLine(); // Dodge
                charStats[9] = reader.ReadLine(); // Active Attack
                charStats[10] = reader.ReadLine(); // Active Defence
                charStats[11] = reader.ReadLine(); // Active Dodge
            }
            using (StreamReader reader = new StreamReader("EnemyStats.txt"))
            {
                enemyStats[0] = reader.ReadLine(); // Name
                enemyStats[1] = reader.ReadLine(); // Class
                enemyStats[2] = reader.ReadLine(); // Level
                enemyStats[4] = reader.ReadLine(); // Health
                enemyStats[5] = reader.ReadLine(); // Active Health
                enemyStats[6] = reader.ReadLine(); // Attack
                enemyStats[7] = reader.ReadLine(); // Defence
                enemyStats[8] = reader.ReadLine(); // Dodge
                enemyStats[9] = reader.ReadLine(); // Active Attack
                enemyStats[10] = reader.ReadLine(); // Active Defence
                enemyStats[11] = reader.ReadLine(); // Active Dodge
            }
            HealthPotCount.Text = inventory[1];
            HealthPotBigCount.Text = inventory[2];
            StrengthPotCount.Text = inventory[3];
            coinBox.Text = "Coins: " + inventory[0];
            //Puts images of inventory items into their boxes 
            using (StreamReader reader = new StreamReader("__HealingPot.png"))
            {
                InventorySlot1.Image = new Bitmap("__HealingPot.png");
            }
            using (StreamReader reader = new StreamReader("__HealingPotBig.png"))
            {
                InventorySlot2.Image = new Bitmap("__HealingPotBig.png");
            }
            using (StreamReader reader = new StreamReader("__StrengthPot.png"))
            {
                InventorySlot3.Image = new Bitmap("__StrengthPot.png");
            }
        }

        private void InventorySlot1_Click(object sender, EventArgs e) //if Health pot picture is clicked
        {
            if (int.Parse(inventory[1]) > 0 && int.Parse(charStats[5]) < int.Parse(charStats[4])) //if character still has health and has less health than max 
            {
                int newHP = int.Parse(charStats[5]) + (int)Math.Round(int.Parse(charStats[4])*0.2); //apply healing potion math 
                if (newHP > int.Parse(charStats[4])) //if post potion health is higher than max/starting health
                {
                    newHP = int.Parse(charStats[4]); //give player max / starting health
                }
                else
                {
                    charStats[5] = newHP + ""; //otherwise, apply potion
                }
                using (StreamWriter writer = new StreamWriter("ClassStats.txt")) //Save the new active health under ClassStats.txt file
                {
                    writer.Flush(); //Empties txt file so new values can be saved line by line
                    writer.WriteLine(charStats[0]);
                    writer.WriteLine(charStats[1]);
                    writer.WriteLine(charStats[2]);
                    writer.WriteLine(charStats[3]);
                    writer.WriteLine(charStats[4]);
                    writer.WriteLine(charStats[5]);
                    writer.WriteLine(charStats[6]);
                    writer.WriteLine(charStats[7]);
                    writer.WriteLine(charStats[8]);
                    writer.WriteLine(charStats[9]);
                    writer.WriteLine(charStats[10]);
                    writer.WriteLine(charStats[11]);
                }
                using (StreamReader reader = new StreamReader("ClassStats.txt")) //Opens txt file and saves the new values above into array
                { 
                    charStats[0] = reader.ReadLine(); // Name
                    charStats[1] = reader.ReadLine(); // Class
                    charStats[2] = reader.ReadLine(); // Level
                    charStats[3] = reader.ReadLine(); // EXP
                    charStats[4] = reader.ReadLine(); // Health
                    charStats[5] = reader.ReadLine(); // Active Health
                    charStats[6] = reader.ReadLine(); // Attack
                    charStats[7] = reader.ReadLine(); // Defence
                    charStats[8] = reader.ReadLine(); // Dodge
                    charStats[9] = reader.ReadLine(); // Active Attack
                    charStats[10] = reader.ReadLine(); // Active Defence
                    charStats[11] = reader.ReadLine(); // Active Dodge
                }
                int consumCount = int.Parse(inventory[1]) - 1; //removes one healing potion from player inventory 
                inventory[1] = consumCount + "";
                HealthPotCount.Text = inventory[1];
                using (StreamWriter writer = new StreamWriter("Inventory.txt")) //saves new inventory value after use 
                {
                    writer.Flush(); //Empties txt file so new values can be saved line by line
                    writer.WriteLine(inventory[0]);
                    writer.WriteLine(inventory[1]);
                    writer.WriteLine(inventory[2]);
                    writer.WriteLine(inventory[3]);
                }
                using (StreamReader sr = new StreamReader("Inventory.txt")) //Opens txt file and saves the new values above into array
                {
                    inventory[0] = sr.ReadLine(); //Coins
                    inventory[1] = sr.ReadLine(); //Health
                    inventory[2] = sr.ReadLine(); //Dagger
                    inventory[3] = sr.ReadLine(); //Strength
                }
            }
            else
            {
                MessageBox.Show("You can't use this right now."); //Tells user that they can't use potion because of max health or no potions
            }
        }

        private void InventorySlot2_Click(object sender, EventArgs e) //if dagger picture is clicked 
        {
            if (int.Parse(inventory[2]) > 0 && int.Parse(charStats[5]) < int.Parse(charStats[4])) //enemy has health and player has daggers, runs if block 
            {

                int newHP = int.Parse(charStats[5]) + (int)Math.Round(int.Parse(charStats[4]) * 0.5); //apply healing potion math 
                if (newHP > int.Parse(charStats[4])) //if post potion health is higher than max/starting health
                {
                    newHP = int.Parse(charStats[4]); //give player max / starting health
                }
                else
                {
                    charStats[5] = newHP + ""; //otherwise, apply potion
                }
                using (StreamWriter writer = new StreamWriter("ClassStats.txt")) //Save the new active health under ClassStats.txt file
                {
                    writer.Flush(); //Empties txt file so new values can be saved line by line
                    writer.WriteLine(charStats[0]);
                    writer.WriteLine(charStats[1]);
                    writer.WriteLine(charStats[2]);
                    writer.WriteLine(charStats[3]);
                    writer.WriteLine(charStats[4]);
                    writer.WriteLine(charStats[5]);
                    writer.WriteLine(charStats[6]);
                    writer.WriteLine(charStats[7]);
                    writer.WriteLine(charStats[8]);
                    writer.WriteLine(charStats[9]);
                    writer.WriteLine(charStats[10]);
                    writer.WriteLine(charStats[11]);
                }
                using (StreamReader reader = new StreamReader("ClassStats.txt")) //Opens txt file and saves the new values above into array
                {
                    charStats[0] = reader.ReadLine(); // Name
                    charStats[1] = reader.ReadLine(); // Class
                    charStats[2] = reader.ReadLine(); // Level
                    charStats[3] = reader.ReadLine(); // EXP
                    charStats[4] = reader.ReadLine(); // Health
                    charStats[5] = reader.ReadLine(); // Active Health
                    charStats[6] = reader.ReadLine(); // Attack
                    charStats[7] = reader.ReadLine(); // Defence
                    charStats[8] = reader.ReadLine(); // Dodge
                    charStats[9] = reader.ReadLine(); // Active Attack
                    charStats[10] = reader.ReadLine(); // Active Defence
                    charStats[11] = reader.ReadLine(); // Active Dodge
                }
                int consumCount = int.Parse(inventory[2]) - 1; //Takes one dagger away from player 
                inventory[2] = consumCount + ""; 
                HealthPotBigCount.Text = inventory[2]; //Adds new dagger count to textbox 

                using (StreamWriter writer = new StreamWriter("Inventory.txt")) //saves newly updated dagger count to Inventory.txt file
                {
                    writer.Flush(); //Empties txt file so new values can be saved line by line
                    writer.WriteLine(inventory[0]);
                    writer.WriteLine(inventory[1]);
                    writer.WriteLine(inventory[2]);
                    writer.WriteLine(inventory[3]);
                }
                using (StreamReader sr = new StreamReader("Inventory.txt")) //Opens txt file and saves the new values above into array
                {
                    inventory[0] = sr.ReadLine(); //Coins
                    inventory[1] = sr.ReadLine(); //Health
                    inventory[2] = sr.ReadLine(); //Dagger
                    inventory[3] = sr.ReadLine(); //Strength
                }
            }
            else
            {
                MessageBox.Show("You can't use this right now."); //Tells player they can't use dagger since enemy dead or dagger count = 0; 
            }
        }

        private void InventorySlot3_Click(object sender, EventArgs e) //If strength pot choosen
        {
            if (int.Parse(inventory[3]) > 0) //If player has strength pots 
            {
                int attack = int.Parse(charStats[6]) + 1; //Adds one to player attack (stronger attack)
                charStats[6] = attack + ""; //Makes both attack and active attack this new strong value 
                charStats[9] = attack + "";
                using (StreamWriter writer = new StreamWriter("ClassStats.txt")) //Opens and writes new value into txt file
                {
                    writer.Flush(); //Empties txt file so new values can be saved line by line
                    writer.WriteLine(charStats[0]);
                    writer.WriteLine(charStats[1]);
                    writer.WriteLine(charStats[2]);
                    writer.WriteLine(charStats[3]);
                    writer.WriteLine(charStats[4]);
                    writer.WriteLine(charStats[5]);
                    writer.WriteLine(charStats[6]);
                    writer.WriteLine(charStats[7]);
                    writer.WriteLine(charStats[8]);
                    writer.WriteLine(charStats[9]);
                    writer.WriteLine(charStats[10]);
                    writer.WriteLine(charStats[11]);
                }
                using (StreamReader reader = new StreamReader("ClassStats.txt")) //Opens txt file and saves the new values above into array
                {
                    charStats[0] = reader.ReadLine(); // Name
                    charStats[1] = reader.ReadLine(); // Class
                    charStats[2] = reader.ReadLine(); // Level
                    charStats[3] = reader.ReadLine(); // EXP
                    charStats[4] = reader.ReadLine(); // Health
                    charStats[5] = reader.ReadLine(); // Active Health
                    charStats[6] = reader.ReadLine(); // Attack
                    charStats[7] = reader.ReadLine(); // Defence
                    charStats[8] = reader.ReadLine(); // Dodge
                    charStats[9] = reader.ReadLine(); // Active Attack
                    charStats[10] = reader.ReadLine(); // Active Defence
                    charStats[11] = reader.ReadLine(); // Active Dodge
                }
                int consumCount = int.Parse(inventory[3]) - 1; //Subtracts one strength potion from Inventory 
                inventory[3] = consumCount + "";
                StrengthPotCount.Text = inventory[3]; //Saves new count of strength potions to text box
                using (StreamWriter writer = new StreamWriter("Inventory.txt")) //Saves new Inventory count of strength potion to txt file 
                {
                    writer.Flush(); //Empties txt file so new values can be saved line by line
                    writer.WriteLine(inventory[0]);
                    writer.WriteLine(inventory[1]);
                    writer.WriteLine(inventory[2]);
                    writer.WriteLine(inventory[3]);
                }
                using (StreamReader sr = new StreamReader("Inventory.txt")) //Opens txt file and saves the new values above into array
                {
                    inventory[0] = sr.ReadLine(); //Coins
                    inventory[1] = sr.ReadLine(); //Health
                    inventory[2] = sr.ReadLine(); //Dagger
                    inventory[3] = sr.ReadLine(); //Strength
                }
            }
            else
            {
                MessageBox.Show("You can't use this right now."); //Tells player they don't have enough potions to use desired amount. 
            }
        }
    }
}
