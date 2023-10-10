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
    public partial class MainForm : Form
    {
        public string[] stats = new string[100]; //Spare variable to transfer/update main arrays
        public string[] inventory = new string[100];
        public string[] enemyStats = new string[100];
        Random rnd = new Random();
        public MainForm()
        {
            InitializeComponent();
            using (StreamReader sr = new StreamReader("titlePage.png"))
            {
                titlePictureBox.Image = new Bitmap("titlePage.png");
            }
            searchBtn.Visible = false; //The following makes everything but the start button visible
            charNameBox1.Visible = false;
            charNameBox2.Visible = false;
            charNameBox3.Visible = false;
            charStatsTab.Visible = false;
            confirmNameBtn.Visible = false;
            topAnnoBox.Visible = false;
            nameInputBox.Visible = false;
            charImageBox1.Visible = false;
            charImageBox2.Visible = false;
            charImageBox3.Visible = false;
            inventoryTab.Visible = false;
            saveTab.Visible = false;
            loadTab.Visible = false;
        }

        private void exitTab_Click(object sender, EventArgs e) //Allows you to exit the game easily
        {
            Application.Exit();
        }

        private void aboutTab_Click(object sender, EventArgs e)
        { // If you have extra time change this to be a proper form and list all student's names
            MessageBox.Show("This program was made by students of Mr Moniaga's ICS4U class for you! Hope you enjoy!");
        }

        private void titlePictureBox_Click(object sender, EventArgs e) //Makes the name input box and the confirm button visible
        {
            MessageBox.Show("Welcome to The Wanderer 2.0! The goal of this game is to purchase your sacred treasure from the Merchant to win the game! Defeat enemies for Gold to buy items.");
            topAnnoBox.Visible = true;
            nameInputBox.Visible = true;
            confirmNameBtn.Visible = true;
            titlePictureBox.Visible = false;
        }

        private void charImageBox1_MouseHover(object sender, EventArgs e) //Turns warrior sprite into the running animation when hovering over it
        {
            using (StreamReader sr = new StreamReader("__WarriorRun.gif"))
            {
                charImageBox1.Image = new Bitmap("__WarriorRun.gif");
            }
        }

        private void charImageBox1_MouseLeave(object sender, EventArgs e) //Turns warrior sprite back to idle when no longer hovering
        {
            using (StreamReader sr = new StreamReader("__WarriorIdle.gif"))
            {
                charImageBox1.Image = new Bitmap("__WarriorIdle.gif");
            }
        }

        private void confirmNameBtn_Click(object sender, EventArgs e) //When confirmed name
        {
            using (StreamWriter writer = new StreamWriter("ClassStats.txt")) //Updates character name
            {
                writer.WriteLine(nameInputBox.Text);
            }
            if (nameInputBox.Text == "God") //If the character's name is "God", let the player know they put in a cheat code
            {
                MessageBox.Show("You Cheater >:(");
            }
            charNameBox1.Visible = true; //Makes the name of all classes visible
            charNameBox2.Visible = true;
            charNameBox3.Visible = true;
            nameInputBox.Visible = false;
            topAnnoBox.Text = "Choose your character (Click on Icon)"; //Changes top text
            confirmNameBtn.Visible = false; //Hides confirm name box
            titlePictureBox.Visible = false;
            charImageBox1.Visible = true; //Using the proper files, turns all the boxes into their proper sprites
            using (StreamReader sr = new StreamReader("__WarriorIdle.gif"))
            {
                charImageBox1.Image = new Bitmap("__WarriorIdle.gif");
            }
            charImageBox2.Visible = true;
            using (StreamReader sr = new StreamReader("__ArcherIdle.gif"))
            {
                charImageBox2.Image = new Bitmap("__ArcherIdle.gif");
            }
            charImageBox3.Visible = true;
            using (StreamReader sr = new StreamReader("__SpearIdle.gif"))
            {
                charImageBox3.Image = new Bitmap("__SpearIdle.gif");
            }
        }

        private void charStatsTab_Click(object sender, EventArgs e) //Whenever clicking the stats tab, open the character stats page
        {
            CharacterStats charPopup = new CharacterStats();
            charPopup.ShowDialog();
        }

        private void charImageBox1_Click(object sender, EventArgs e) //When the warrior is selected
        {
            saveTab.Visible = true; //Allow player to save/load game
            loadTab.Visible = true;
            using (StreamReader reader = new StreamReader("ClassStats.txt")) //Reads character name
            {
                stats[0] = reader.ReadLine();
            }
            if (stats[0] == "God") //Sets character to cheated stats if name is "God"
            {
                using (StreamWriter writer = new StreamWriter("ClassStats.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(stats[0]);
                    writer.WriteLine("1"); // Character Token
                    writer.WriteLine("99"); // Level
                    writer.WriteLine("0"); // EXP
                    writer.WriteLine("100"); // Health
                    writer.WriteLine("100"); // Active Health
                    writer.WriteLine("100"); // Attack
                    writer.WriteLine("100"); // Defense
                    writer.WriteLine("20"); // Dodge
                    writer.WriteLine("100"); // Active Attack
                    writer.WriteLine("100"); // Active Defense
                    writer.WriteLine("20"); // Active Dodge
                }
                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                {
                    writer.Flush();
                    writer.WriteLine("100000"); //Gold
                    writer.WriteLine("5"); //Health potions
                    writer.WriteLine("5"); //Big Heath potions
                    writer.WriteLine("5"); //Strength+ potions
                }
            }
            else //If using any other name
            {
                using (StreamWriter writer = new StreamWriter("ClassStats.txt")) //Turns all lines (and character stats) into the appropriate warrior stats
                {
                    writer.Flush();
                    writer.WriteLine(stats[0]);
                    writer.WriteLine("1"); // Character Token
                    writer.WriteLine("1"); // Level
                    writer.WriteLine("0"); // EXP
                    writer.WriteLine("35"); // Health
                    writer.WriteLine("35"); // Active Health
                    writer.WriteLine("4"); // Attack
                    writer.WriteLine("3"); // Defense
                    writer.WriteLine("20"); // Dodge
                    writer.WriteLine("4"); // Active Attack
                    writer.WriteLine("3"); // Active Defense
                    writer.WriteLine("20"); // Active Dodge
                }
                using (StreamWriter writer = new StreamWriter("Inventory.txt")) //Sets 
                {
                    writer.WriteLine("0"); // Coins
                    writer.WriteLine("0"); // Health Potion
                    writer.WriteLine("0"); // Dagger
                    writer.WriteLine("0"); // Strength Potion
                }
            }
            charImageBox1.Visible = false;  //Makes everything but the search button, save/load buttons, character stats tab, and inventory tab buttons visible
            charNameBox1.Visible = false;
            charImageBox2.Visible = false;
            charNameBox2.Visible = false;
            charImageBox3.Visible = false;
            charNameBox3.Visible = false;
            searchBtn.Visible = true;
            charStatsTab.Visible = true;
            inventoryTab.Visible = true;
            topAnnoBox.Text = "Click the Search Area button";
        }

        private void charImageBox2_Click(object sender, EventArgs e) //Repeats warrior code for archer
        {
            saveTab.Visible = true;
            loadTab.Visible = true;
            using (StreamReader reader = new StreamReader("ClassStats.txt"))
            {
                stats[0] = reader.ReadLine();
            }
            if (stats[0] == "God")
            {
                using (StreamWriter writer = new StreamWriter("ClassStats.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(stats[0]);
                    writer.WriteLine("2"); // Character Token
                    writer.WriteLine("99"); // Level
                    writer.WriteLine("0"); // EXP
                    writer.WriteLine("100"); // Health
                    writer.WriteLine("100"); // Active Health
                    writer.WriteLine("100"); // Attack
                    writer.WriteLine("100"); // Defense
                    writer.WriteLine("20"); // Dodge
                    writer.WriteLine("100"); // Active Attack
                    writer.WriteLine("100"); // Active Defense
                    writer.WriteLine("20"); // Active Dodge
                }
                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                {
                    writer.Flush();
                    writer.WriteLine("100000");
                    writer.WriteLine("5");
                    writer.WriteLine("5");
                    writer.WriteLine("5");
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter("ClassStats.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(stats[0]);
                    writer.WriteLine("2");
                    writer.WriteLine("1"); // Level
                    writer.WriteLine("0"); // EXP
                    writer.WriteLine("30"); // Health
                    writer.WriteLine("30"); // Active Health
                    writer.WriteLine("5"); // Attack
                    writer.WriteLine("2"); // Defense
                    writer.WriteLine("30"); // Dodge
                    writer.WriteLine("5"); // Active Attack
                    writer.WriteLine("2"); // Active Defense
                    writer.WriteLine("30"); // Active Dodge
                }
                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                {
                    writer.WriteLine("0"); // Coins
                    writer.WriteLine("0"); // Health Potion
                    writer.WriteLine("0"); // Dagger
                    writer.WriteLine("0"); // Strength Potion
                }
            }
            charImageBox1.Visible = false;
            charNameBox1.Visible = false;
            charImageBox2.Visible = false;
            charNameBox2.Visible = false;
            charImageBox3.Visible = false;
            charNameBox3.Visible = false;
            searchBtn.Visible = true;
            charStatsTab.Visible = true;
            inventoryTab.Visible = true;
            topAnnoBox.Text = "Click the Search Area button";
        }

        private void charImageBox3_Click(object sender, EventArgs e)
        {
            saveTab.Visible = true;
            loadTab.Visible = true;
            using (StreamReader reader = new StreamReader("ClassStats.txt"))
            {
                stats[0] = reader.ReadLine();
            }
            if (stats[0] == "God")
            {
                using (StreamWriter writer = new StreamWriter("ClassStats.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(stats[0]);
                    writer.WriteLine("3"); // Character Token
                    writer.WriteLine("99"); // Level
                    writer.WriteLine("0"); // EXP
                    writer.WriteLine("100"); // Health
                    writer.WriteLine("100"); // Active Health
                    writer.WriteLine("100"); // Attack
                    writer.WriteLine("100"); // Defense
                    writer.WriteLine("20"); // Dodge
                    writer.WriteLine("100"); // Active Attack
                    writer.WriteLine("100"); // Active Defense
                    writer.WriteLine("20"); // Active Dodge
                }
                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                {
                    writer.Flush();
                    writer.WriteLine("100000");
                    writer.WriteLine("5");
                    writer.WriteLine("5");
                    writer.WriteLine("5");
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter("ClassStats.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(stats[0]);
                    writer.WriteLine("3");
                    writer.WriteLine("1"); // Level
                    writer.WriteLine("0"); // EXP
                    writer.WriteLine("25"); // Health
                    writer.WriteLine("25"); // Active Health
                    writer.WriteLine("5"); // Attack
                    writer.WriteLine("2"); // Defense
                    writer.WriteLine("25"); // Dodge
                    writer.WriteLine("5"); // Active Attack
                    writer.WriteLine("2"); // Active Defense
                    writer.WriteLine("25"); // Active Dodge
                }
                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                {
                    writer.WriteLine("0"); // Coins
                    writer.WriteLine("0"); // Health Potion
                    writer.WriteLine("0"); // Dagger
                    writer.WriteLine("0"); // Strength Potion
                }
            }
            charImageBox1.Visible = false;
            charNameBox1.Visible = false;
            charImageBox2.Visible = false;
            charNameBox2.Visible = false;
            charImageBox3.Visible = false;
            charNameBox3.Visible = false;
            searchBtn.Visible = true;
            charStatsTab.Visible = true;
            inventoryTab.Visible = true;
            topAnnoBox.Text = "Click the Search Area button";
        }

        private void charImageBox2_MouseHover(object sender, EventArgs e) //Turns idle archer sprite (when selecting classes) into running animation
        {
            using (StreamReader sr = new StreamReader("__ArcherRun.gif"))
            {
                charImageBox2.Image = new Bitmap("__ArcherRun.gif");
            }
        }

        private void charImageBox2_MouseLeave(object sender, EventArgs e) //Turns archer sprite back to idle
        {
            using (StreamReader sr = new StreamReader("__ArcherIdle.gif"))
            {
                charImageBox2.Image = new Bitmap("__ArcherIdle.gif");
            }
        }

        private void charImageBox3_MouseHover(object sender, EventArgs e) //Turns idle spear sprite (when selecting classes) into running animation
        {
            using (StreamReader sr = new StreamReader("__SpearRun.gif"))
            {
                charImageBox3.Image = new Bitmap("__SpearRun.gif");
            }
        }

        private void charImageBox3_MouseLeave(object sender, EventArgs e) //Turns spear sprite back to idle
        {
            using (StreamReader sr = new StreamReader("__SpearIdle.gif"))
            {
                charImageBox3.Image = new Bitmap("__SpearIdle.gif");
            }
        }

        private void charNameBox1_MouseHover(object sender, EventArgs e) //When hovering over the warriors name, set stats temporarily and open character stats preview
        {

            using (StreamReader reader = new StreamReader("ClassStats.txt"))
            {
                stats[0] = reader.ReadLine();
            }
            using (StreamWriter writer = new StreamWriter("ClassStats.txt"))
            {
                writer.Flush();
                writer.WriteLine(stats[0]);
                writer.WriteLine("1"); // Character Token
                writer.WriteLine("1"); // Level
                writer.WriteLine("0"); // EXP
                writer.WriteLine("35"); // Health
                writer.WriteLine("35"); // Active Health
                writer.WriteLine("4"); // Attack
                writer.WriteLine("3"); // Defence
                writer.WriteLine("20"); // Dodge
                writer.WriteLine("4"); // Active Attack
                writer.WriteLine("3"); // Active Defense
                writer.WriteLine("20"); // Active Dodge
            }
            CharacterStats charPopup = new CharacterStats();
            charPopup.ShowDialog(); //Open character stats sheet
        }

        private void charNameBox2_MouseHover(object sender, EventArgs e) //Repeat previous code for archer
        {
            using (StreamReader reader = new StreamReader("ClassStats.txt"))
            {
                stats[0] = reader.ReadLine();
            }
            using (StreamWriter writer = new StreamWriter("ClassStats.txt"))
            {
                writer.Flush();
                writer.WriteLine(stats[0]);
                writer.WriteLine("2"); // Character Token
                writer.WriteLine("1"); // Level
                writer.WriteLine("0"); // EXP
                writer.WriteLine("30"); // Health
                writer.WriteLine("30"); // Active Health
                writer.WriteLine("5"); // Attack
                writer.WriteLine("2"); // Defence
                writer.WriteLine("30"); // Dodge
                writer.WriteLine("5"); // Active Attack
                writer.WriteLine("2"); // Active Defense
                writer.WriteLine("30"); // Active Dodge
            }
            CharacterStats charPopup = new CharacterStats();
            charPopup.ShowDialog();
        }

        private void charNameBox3_MouseHover(object sender, EventArgs e) //Repeat previous code for spear
        {
            using (StreamReader reader = new StreamReader("ClassStats.txt"))
            {
                stats[0] = reader.ReadLine();
            }
            using (StreamWriter writer = new StreamWriter("ClassStats.txt"))
            {
                writer.Flush();
                writer.WriteLine(stats[0]);
                writer.WriteLine("3"); // Character Token
                writer.WriteLine("1"); // Level
                writer.WriteLine("0"); // EXP
                writer.WriteLine("25"); // Health
                writer.WriteLine("25"); // Active Health
                writer.WriteLine("5"); // Attack
                writer.WriteLine("2"); // Defence
                writer.WriteLine("25"); // Dodge
                writer.WriteLine("5"); // Active Attack
                writer.WriteLine("2"); // Active Defense
                writer.WriteLine("25"); // Active Dodge
            }
            CharacterStats charPopup = new CharacterStats();
            charPopup.ShowDialog();
        }

        private void inventoryTab_Click(object sender, EventArgs e) //Opens up inventory when clicked
        {
            Inventory invenPopup = new Inventory();
            invenPopup.ShowDialog();
        }

        private void searchBtn_Click(object sender, EventArgs e) //Randomly generates encounter
        {
            using (StreamReader reader = new StreamReader("ClassStats.txt")) //Sets stats in case of combat
            {
                stats[0] = reader.ReadLine(); // Name
                stats[1] = reader.ReadLine(); // Class
                stats[2] = reader.ReadLine(); // Level
                stats[3] = reader.ReadLine(); // EXP
                stats[4] = reader.ReadLine(); // Health
                stats[5] = reader.ReadLine(); // Active Health
                stats[6] = reader.ReadLine(); // Attack
                stats[7] = reader.ReadLine(); // Defence
                stats[8] = reader.ReadLine(); // Dodge
            }
            int encounter = rnd.Next(0, 100);
            if (encounter <= 25)
            {
                Merchant merchPopup = new Merchant();
                merchPopup.ShowDialog();
            }
            else if (encounter > 25) //If combat is selected
            {
                int enemy = rnd.Next(0, 100);
                if (enemy <= 20)
                { //If enemy is a troll (0-20) randomly generate stats based on player's and update enemy stats
                    int health = rnd.Next(int.Parse(stats[4]) + 5, int.Parse(stats[4]) + 15); // Credit to Mohib for the idea! 
                    int attack = rnd.Next(int.Parse(stats[6]), int.Parse(stats[6]) + 1);
                    int defence = rnd.Next(int.Parse(stats[7]) - 2, int.Parse(stats[7]));
                    int dodge = rnd.Next(int.Parse(stats[8]) - 20, int.Parse(stats[8]) - 5);
                    using (StreamWriter writer = new StreamWriter("EnemyStats.txt"))
                    {
                        writer.Flush();
                        writer.WriteLine("Armored Troll"); // Armored Troll Name
                        writer.WriteLine("1"); // Armored Troll Token
                        writer.WriteLine(stats[2]); // Armored Troll Level
                        writer.WriteLine(health); // Armored Troll Health
                        writer.WriteLine(health); // Armored Troll Active Health
                        writer.WriteLine(attack); // Armored Troll Attack
                        writer.WriteLine(defence); // Armored Troll Defence
                        writer.WriteLine(dodge); // Armored Troll Dodge
                        writer.WriteLine(attack); // Armored Troll Active Attack
                        writer.WriteLine(defence); // Armored Troll Active Defence
                        writer.WriteLine(dodge); // Armored Troll Active Dodge
                    }
                }
                if (enemy <= 40 && enemy > 20) //If enemy is a mage (20-40), randomly generate and update enemy stats
                {
                    int health = rnd.Next(int.Parse(stats[4]), int.Parse(stats[4]) + 5); // Credit to Mohib for the idea!
                    int attack = rnd.Next(int.Parse(stats[6]), int.Parse(stats[6]) + 3);
                    int defence = rnd.Next(int.Parse(stats[7]) - 4, int.Parse(stats[7]));
                    int dodge = rnd.Next(int.Parse(stats[8]) - 5, int.Parse(stats[8]) + 5);
                    using (StreamWriter writer = new StreamWriter("EnemyStats.txt"))
                    {
                        writer.Flush();
                        writer.WriteLine("Corrupted Mage"); // Corrupted Mage Name
                        writer.WriteLine("2"); // Corrupted Mage Token
                        writer.WriteLine(stats[2]); // Corrupted Mage Level
                        writer.WriteLine(health); // Corrupted Mage Health
                        writer.WriteLine(health); // Corrupted Mage Active Health
                        writer.WriteLine(attack); // Corrupted Mage Attack
                        writer.WriteLine(defence); // Corrupted Mage Defence
                        writer.WriteLine(dodge); // Corrupted Mage Dodge
                        writer.WriteLine(attack); // Corrupted Mage Active Attack
                        writer.WriteLine(defence); // Corrupted Mage Active Defence
                        writer.WriteLine(dodge); // Corrupted Mage Active Dodge
                    }
                }
                if (enemy <= 60 && enemy > 40) //If enemy is a skeleton (40-60), randomly generate and update enemy stats
                {
                    int health = rnd.Next(int.Parse(stats[4]) - 5, int.Parse(stats[4]) + 15); // Credit to Mohib for the idea!
                    int attack = rnd.Next(int.Parse(stats[6]), int.Parse(stats[6]) + 2);
                    int defence = rnd.Next(int.Parse(stats[7]) - 4, int.Parse(stats[7]));
                    int dodge = int.Parse(stats[8]);
                    using (StreamWriter writer = new StreamWriter("EnemyStats.txt"))
                    {
                        writer.Flush();
                        writer.WriteLine("Skeleton Warrior"); // Skeleton Warrior Name
                        writer.WriteLine("3"); // Skeleton Warrior Token
                        writer.WriteLine(stats[2]); // Skeleton Warrior Level
                        writer.WriteLine(health); // Skeleton Warrior Health
                        writer.WriteLine(health); // Skeleton Warrior Active Health
                        writer.WriteLine(attack); // Skeleton Warrior Attack
                        writer.WriteLine(defence); // Skeleton Warrior Defence
                        writer.WriteLine(dodge); // Skeleton Warrior Dodge
                        writer.WriteLine(attack); // Skeleton Warrior Active Attack
                        writer.WriteLine(defence); // Skeleton Warrior Active Defence
                        writer.WriteLine(dodge); // Skeleton Warrior Active Dodge
                    }
                }
                if (enemy <= 80 && enemy > 60) //If enemy is a goblin (60-80), randomly generate and update enemy stats
                {
                    int health = rnd.Next(int.Parse(stats[4]) - 10, int.Parse(stats[4])); // Credit to Mohib for the idea!
                    int attack = rnd.Next(int.Parse(stats[6]), int.Parse(stats[6]) + 4);
                    int defence = rnd.Next(int.Parse(stats[7]) - 3, int.Parse(stats[7]));
                    int dodge = rnd.Next(int.Parse(stats[8]), int.Parse(stats[8]) + 10);
                    using (StreamWriter writer = new StreamWriter("EnemyStats.txt"))
                    {
                        writer.Flush();
                        writer.WriteLine("Sneaky Goblin"); // Sneaky Goblin Name
                        writer.WriteLine("4"); // Sneaky Goblin Token
                        writer.WriteLine(stats[2]); // Sneaky Goblin Level
                        writer.WriteLine(health); // Sneaky Goblin Health
                        writer.WriteLine(health); // Sneaky Goblin Active Health
                        writer.WriteLine(attack); // Sneaky Goblin Attack
                        writer.WriteLine(defence); // Sneaky Goblin Defence
                        writer.WriteLine(dodge); // Sneaky Goblin Dodge
                        writer.WriteLine(attack); // Sneaky Goblin Active Attack
                        writer.WriteLine(defence); // Sneaky Goblin Active Defence
                        writer.WriteLine(dodge); // Sneaky Goblin Active Dodge
                    }
                }
                if (enemy <= 100 && enemy > 80) //If enemy is a chest/mimic (80-100), randomly generate and update enemy stats
                {
                    if (enemy <= 90 && enemy > 80) //If enemy is a chest (80-90), randomly generate and update enemy stats
                    {
                        int health = rnd.Next(int.Parse(stats[4]) - 5, int.Parse(stats[4]) + 10); // Credit to Mohib for the idea!
                        using (StreamWriter writer = new StreamWriter("EnemyStats.txt"))
                        {
                            writer.Flush();
                            writer.WriteLine("Chest?"); // Chest Name
                            writer.WriteLine("5"); // Chest Token
                            writer.WriteLine(stats[2]); // Chest Level
                            writer.WriteLine(health); // Chest Health
                            writer.WriteLine(health); // Chest Active Health
                            writer.WriteLine(0); // Chest Attack
                            writer.WriteLine(0); // Chest Defence
                            writer.WriteLine(0); // Chest Dodge
                            writer.WriteLine(0); // Chest Active Attack
                            writer.WriteLine(0); // Chest Active Defence
                            writer.WriteLine(0); // Chest Active Dodge
                        }
                    }
                    else if (enemy <= 100 && enemy > 90) //If enemy is a chest mimic (90-100), randomly generate and update enemy stats
                    {
                        int health = rnd.Next(int.Parse(stats[4]) + 8, int.Parse(stats[4]) + 13); // Credit to Mohib for the idea!
                        int attack = rnd.Next(int.Parse(stats[6]), int.Parse(stats[6]) + 3);
                        int defence = rnd.Next(int.Parse(stats[7]) - 2, int.Parse(stats[7]));
                        int dodge = rnd.Next(int.Parse(stats[8]) + 5, int.Parse(stats[8]) + 10);
                        using (StreamWriter writer = new StreamWriter("EnemyStats.txt"))
                        {
                            writer.Flush();
                            writer.WriteLine("Chest Mimic"); // Chest Mimic Name
                            writer.WriteLine("6"); // Chest Mimic Token
                            writer.WriteLine(stats[2]); // Chest Mimic Level
                            writer.WriteLine(health); // Chest Mimic Health
                            writer.WriteLine(health); // Chest Mimic Active Health
                            writer.WriteLine(attack); // Chest Mimic Attack
                            writer.WriteLine(defence); // Chest Mimic Defence
                            writer.WriteLine(dodge); // Chest Mimic Dodge
                            writer.WriteLine(attack); // Chest Mimic Active Attack
                            writer.WriteLine(defence); // Chest Mimic Active Defence
                            writer.WriteLine(dodge); // Chest Mimic Active Dodge
                        }
                    }
                }
                Battle btlPopup = new Battle(); //Open battle popup 
                btlPopup.ShowDialog();
                using (StreamWriter writer = new StreamWriter("EnemyStats.txt"))
                {
                    writer.Flush();
                }
            }
        }
        private void saveTab_Click(object sender, EventArgs e) //When save is clicked
        {
            using (StreamReader sr = new StreamReader("ClassStats.txt")) //Read character stats from sheet
            {
                stats[0] = sr.ReadLine();
                stats[1] = sr.ReadLine();
                stats[2] = sr.ReadLine();
                stats[3] = sr.ReadLine();
                stats[4] = sr.ReadLine();
                stats[5] = sr.ReadLine();
                stats[6] = sr.ReadLine();
                stats[7] = sr.ReadLine();
                stats[8] = sr.ReadLine();
                stats[9] = sr.ReadLine();
                stats[10] = sr.ReadLine();
                stats[11] = sr.ReadLine();
            }
            using (StreamReader sr = new StreamReader("Inventory.txt")) //Read inventory from sheet
            {
                inventory[0] = sr.ReadLine();
                inventory[1] = sr.ReadLine();
                inventory[2] = sr.ReadLine();
                inventory[3] = sr.ReadLine();
            }
            using (StreamWriter writer = new StreamWriter("CharStatsFile.txt")) //Update save file for character stats to sheet
            {
                writer.Flush();
                writer.WriteLine(stats[0]);
                writer.WriteLine(stats[1]);
                writer.WriteLine(stats[2]);
                writer.WriteLine(stats[3]);
                writer.WriteLine(stats[4]);
                writer.WriteLine(stats[5]);
                writer.WriteLine(stats[6]);
                writer.WriteLine(stats[7]);
                writer.WriteLine(stats[8]);
                writer.WriteLine(stats[9]);
                writer.WriteLine(stats[10]);
                writer.WriteLine(stats[11]);
            }
            using (StreamWriter writer = new StreamWriter("InventoryFile.txt")) //Update save file for inventory to sheet
            {
                writer.Flush();
                writer.WriteLine(inventory[0]);
                writer.WriteLine(inventory[1]);
                writer.WriteLine(inventory[2]);
                writer.WriteLine(inventory[3]);
            }
        }

        private void loadTab_Click(object sender, EventArgs e) //Does the opposite of save, instead reading save file and uploading to main combat one
        {
            using (StreamReader sr = new StreamReader("CharStatsFile.txt"))
            {
                stats[0] = sr.ReadLine();
                stats[1] = sr.ReadLine();
                stats[2] = sr.ReadLine();
                stats[3] = sr.ReadLine();
                stats[4] = sr.ReadLine();
                stats[5] = sr.ReadLine();
                stats[6] = sr.ReadLine();
                stats[7] = sr.ReadLine();
                stats[8] = sr.ReadLine();
                stats[9] = sr.ReadLine();
                stats[10] = sr.ReadLine();
                stats[11] = sr.ReadLine();
            }
            using (StreamReader sr = new StreamReader("InventoryFile.txt"))
            {
                inventory[0] = sr.ReadLine();
                inventory[1] = sr.ReadLine();
                inventory[2] = sr.ReadLine();
                inventory[3] = sr.ReadLine();
            }
            using (StreamWriter writer = new StreamWriter("ClassStats.txt"))
            {
                writer.Flush();
                writer.WriteLine(stats[0]);
                writer.WriteLine(stats[1]);
                writer.WriteLine(stats[2]);
                writer.WriteLine(stats[3]);
                writer.WriteLine(stats[4]);
                writer.WriteLine(stats[5]);
                writer.WriteLine(stats[6]);
                writer.WriteLine(stats[7]);
                writer.WriteLine(stats[8]);
                writer.WriteLine(stats[9]);
                writer.WriteLine(stats[10]);
                writer.WriteLine(stats[11]);
            }
            using (StreamWriter writer = new StreamWriter("Inventory.txt"))
            {
                writer.Flush();
                writer.WriteLine(inventory[0]);
                writer.WriteLine(inventory[1]);
                writer.WriteLine(inventory[2]);
                writer.WriteLine(inventory[3]);
            }
        }

    }
}
