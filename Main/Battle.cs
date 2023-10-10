using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Main
{
    public partial class Battle : Form
    {
        public string[] charStats = new string[100]; // Initializing public variables to be used in battle
        public string[] charStatusEffects = new string[100]; 
        public string[] enemyStats = new string[100];
        public string[] enemyStatusEffects = new string[100];
        public string[] inventory = new string[100];
        
        public int momentum = 0;
        Random rnd = new Random();
        public Battle()
        {
            InitializeComponent();
            turnEndBtn.Visible = false;
            using (StreamReader reader = new StreamReader("Inventory.txt")) 
            {
                inventory[0] = reader.ReadLine(); // Coins
                inventory[1] = reader.ReadLine(); // Health Potions
                inventory[2] = reader.ReadLine(); // Dagger
                inventory[3] = reader.ReadLine(); // Strength Potion
            }
            using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
            {
                writer.Flush();
                writer.WriteLine(0); // Attack-
                writer.WriteLine(0); // Attack+
                writer.WriteLine(0); // Defense-
                writer.WriteLine(0); // Defnese+
                writer.WriteLine(0); // Dodge-
                writer.WriteLine(0); // Dodge+
                writer.WriteLine(0); // Bleed
                writer.WriteLine(0); // Stun
                writer.WriteLine(0); // Parry
            }
            using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
            {
                writer.Flush();
                writer.WriteLine(0); // Attack-
                writer.WriteLine(0); // Attack+
                writer.WriteLine(0); // Defense-
                writer.WriteLine(0); // Defnese+
                writer.WriteLine(0); // Dodge-
                writer.WriteLine(0); // Dodge+
                writer.WriteLine(0); // Bleed
                writer.WriteLine(0); // Stun
                writer.WriteLine(0); // Parry
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
            if (charStats[1] == "1") // Check for warrior token
            {
                using (StreamReader sr = new StreamReader("__WarriorIdleBig.gif"))
                {
                    charImageBox.Image = new Bitmap("__WarriorIdleBig.gif");
                }
                attackBtn1.Text = "Slash"; // Set the warrior attacks
                attackBtn2.Text = "Bash";
                attackBtn3.Text = "Heavy Smash";
                attackBtn4.Text = "Parry";
            }
            if (charStats[1] == "2") // Check for archer token
            {
                using (StreamReader sr = new StreamReader("__ArcherIdleBig.gif"))
                {
                    charImageBox.Image = new Bitmap("__ArcherIdleBig.gif");
                }
                attackBtn1.Text = "Piercing Shot"; // Set the archer attacks
                attackBtn2.Text = "Pursuit";
                attackBtn3.Text = "Gouge";
                attackBtn4.Text = "Evade";
            }
            if (charStats[1] == "3") // Check for spear token
            {
                using (StreamReader sr = new StreamReader("__SpearIdleBig.gif")) // RESIZE BIG SPEAR
                {
                    charImageBox.Image = new Bitmap("__SpearIdleBig.gif");
                }
                attackBtn1.Text = "Momentum Strike"; // Set the spear attacks
                attackBtn2.Text = "Sweeping Strike";
                attackBtn3.Text = "Rally";
                attackBtn4.Text = "Flurry";
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
            if (enemyStats[1] == "1") // Set the troll token
            {
                using (StreamReader sr = new StreamReader("__TrollIdleSmall.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__TrollIdleSmall.gif");
                }
            }
            if (enemyStats[1] == "2") // Set the Corrupted Mage token
            {
                using (StreamReader sr = new StreamReader("__CorruptMageIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__CorruptMageIdle.gif");
                }
            }
            if (enemyStats[1] == "3") // Set the skeleton token
            {
                using (StreamReader sr = new StreamReader("__SkeletonIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__SkeletonIdle.gif");
                }
            }
            if (enemyStats[1] == "4") // Set the goblin token
            {
                using (StreamReader sr = new StreamReader("__GoblinIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__GoblinIdle.gif");
                }
            }
            if (enemyStats[1] == "5") // Set the chest token
            {
                using (StreamReader sr = new StreamReader("__MimicIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__MimicIdle.gif");
                }
            }
            if (enemyStats[1] == "6") // Set the mimic token
            {
                using (StreamReader sr = new StreamReader("__MimicIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__MimicIdle.gif");
                }
            }
            battleAnnoBox.Text = "You encounterd a " + enemyStats[0] + "!"; // Initialize top text box and both character and enemey health boxes
            charHealthBox.Text = "Health: " + charStats[5] + "/" + charStats[4];
            enemyHealthBox.Text = "Health: " + enemyStats[5] + "/" + enemyStats[4];
        }

        private void inventoryTab_Click(object sender, EventArgs e)
        {
            Inventory invenPopup = new Inventory(); // Open Inventory Form
            invenPopup.ShowDialog();
        }

        private void exitTab_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Close program
        }

        private void aboutTab_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program was made by students of Mr Moniaga's ICS4U class for you! Hope you enjoy!");
        }

        private void charStatsTab_Click(object sender, EventArgs e)
        {
            CharacterStats charStatsPopup = new CharacterStats(); // Open character stats form
            charStatsPopup.ShowDialog();
        }

        private void enemyStatsTab_Click(object sender, EventArgs e)
        {
            EnemyStats enemyStatsPopup = new EnemyStats(); // Open enemy stats form
            enemyStatsPopup.ShowDialog();
        }

        public static void charWriter(string[] stats, string file) // Writer method to rewrite all the stats into the ClassStats.txt file
        {
            using (StreamWriter writer = new StreamWriter(file)) 
            {
                /* You need to clear the text file before
                 * putting edits every single time because if you didn't
                 * then all the stats would get pushed together and mess up
                 */
                writer.Flush(); // Clear the text file
                writer.WriteLine(stats[0]); // Write each character stat seperately 
                writer.WriteLine(stats[1]); // This is because of the way we are reading the stats from the file
                writer.WriteLine(stats[2]); // So it must be on each individual line
                writer.WriteLine(stats[3]); // Could've used seperators but this is faster
                writer.WriteLine(stats[4]);
                writer.WriteLine(stats[5]);
                writer.WriteLine(stats[6]);
                writer.WriteLine(stats[7]);
                writer.WriteLine(stats[8]);
                writer.WriteLine(stats[9]);
                writer.WriteLine(stats[10]);
                writer.WriteLine(stats[11]);
            }
        }
        public static void enemyWriter(string[] stats, string file) // Writer method to rewrite all the enemy stats into the EnemyStats.txt file
        {
            using (StreamWriter writer = new StreamWriter(file)) 
            {
                writer.Flush(); // Clear the text file
                writer.WriteLine(stats[0]); // Same exact code for charWriter except we skip the third stat because 
                writer.WriteLine(stats[1]); // That represents exp and enemies do not have exp
                writer.WriteLine(stats[2]);
                writer.WriteLine(stats[4]);
                writer.WriteLine(stats[5]);
                writer.WriteLine(stats[6]);
                writer.WriteLine(stats[7]);
                writer.WriteLine(stats[8]);
                writer.WriteLine(stats[9]);
                writer.WriteLine(stats[10]);
                writer.WriteLine(stats[11]);
            }
        }
        private void attackBtn1_Click(object sender, EventArgs e) // Code for clicking the first attack button
        {
            enemyActionBox.Text = ""; // Clearing the enemy's action box for display purposes
            enemyStatusEffectsBox.Text = ""; // Clearing the enemy's status effects box for display purposes
            charStatusEffectsBox.Text = ""; // Clearing the character's status effects box for display purposes
            if (enemyStats[1] == "1") /* Each time this form of check is called it is checking for the token assigned to the enemy you are facing
                This is what we use to generate the enemy's picture and moveset
                 */
            {
                using (StreamReader sr = new StreamReader("__TrollIdleSmall.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__TrollIdleSmall.gif");
                }
            }
            else if (enemyStats[2] == "2")
            {
                using (StreamReader sr = new StreamReader("__CorruptedMageIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__CorruptedMageIdle.gif");
                }
            }
            else if (enemyStats[3] == "3")
            {
                using (StreamReader sr = new StreamReader("__SkeletonIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__SkeletonIdle.gif");
                }
            }
            else if (enemyStats[4] == "4")
            {
                using (StreamReader sr = new StreamReader("__GoblinIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__GoblinIdle.gif");
                }
            }
            else if (enemyStats[5] == "5")
            {
                using (StreamReader sr = new StreamReader("__MimicIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__MimicIdle.gif");
                }
            }
            else if (enemyStats[6] == "6")
            {
                using (StreamReader sr = new StreamReader("__MimicIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__MimicIdle.gif");
                }
            }
            // The following code for status effects checking is repeated for all 4 attacks
            // Refer to the comments in this section to understand the status effects
            using (StreamReader reader = new StreamReader("CharStatusEffects.txt")) // Read the character's status effects (we are altering them soon)
            {
                charStatusEffects[0] = reader.ReadLine(); // Attack-
                charStatusEffects[1] = reader.ReadLine(); // Attack+
                charStatusEffects[2] = reader.ReadLine(); // Defense-
                charStatusEffects[3] = reader.ReadLine(); // Defense+
                charStatusEffects[4] = reader.ReadLine(); // Dodge-
                charStatusEffects[5] = reader.ReadLine(); // Dodge+
                charStatusEffects[6] = reader.ReadLine(); // Bleed
                charStatusEffects[7] = reader.ReadLine(); // Stun
                charStatusEffects[8] = reader.ReadLine(); // Parry
            }
            using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt")) // Read the enemy's status effects (Some player moves alter this so it's necessary to have the info)
            {
                enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                enemyStatusEffects[7] = reader.ReadLine(); // Stun
                enemyStatusEffects[8] = reader.ReadLine(); // Parry
            }
            if (int.Parse(charStatusEffects[0]) > 0) // Check for if the player has an Attack- debuff
            {
                charStats[9] = (int.Parse(charStats[6]) / 2) + ""; // Apply the Attack- debuff to the player's active stats
                // Applying it to the active stats let's us revert it afterwards when the Attack- debuff wears off
                charWriter(charStats, "ClassStats.txt"); // Calling charWriter method to save the new stats into the text file
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(int.Parse(charStatusEffects[0]) - 1); // Attack- (1 turn passed)
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt")) // Required to update the character's Status Effects array for how much time each active effect has left on the character
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[0]) == 0) // Reset active attack because turns are over
            {
                charStats[9] = charStats[6];
                charWriter(charStats, "ClassStats.txt"); // Calling charWriter method to rewrite the stats
            }
            if (int.Parse(charStatusEffects[1]) > 0) // Check to see if player has Attack+ buff
            {
                charStats[9] = (int.Parse(charStats[6]) * 2) + ""; // Apply Attack+ buff
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(int.Parse(charStatusEffects[1]) - 1); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[1]) == 0) // Reset Attack when counters hits 0
            {
                charStats[9] = charStats[6];
                charWriter(charStats, "ClassStats.txt"); // Save stats into text file
            }
            if (int.Parse(charStatusEffects[2]) > 0) // Check to see if player has Defense- counters
            {
                charStats[10] = (int.Parse(charStats[7]) / 2) + ""; // Apply Defense- effect to player
                charWriter(charStats, "ClassStats.txt"); // Save stats into text file
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(int.Parse(charStatusEffects[2]) - 1); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[2]) == 0) // When Defense- counter hits 0
            {
                charStats[10] = charStats[7]; // Reset defense
                charWriter(charStats, "ClassStats.txt"); // Set stats in text file
            }
            if (int.Parse(charStatusEffects[3]) > 0) // Check for Defense+ 
            {
                charStats[10] = (int.Parse(charStats[7]) * 2) + ""; // Apply Defense+ 
                charWriter(charStats, "ClassStats.txt"); // Set stats in text file
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(int.Parse(charStatusEffects[3]) - 1); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[3]) == 0) // Reset defense
            {
                charStats[10] = charStats[7];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[4]) > 0) // Check for Dodge-
            {
                charStats[11] = (int)Math.Round(int.Parse(charStats[8]) / 1.32) + ""; // Apply Dodge-
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(int.Parse(charStatusEffects[4]) - 1); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[4]) == 0) // Reset Dodge
            {
                charStats[11] = charStats[8];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[5]) > 0) // Check for Dodge+
            {
                charStats[11] = (int)Math.Round(int.Parse(charStats[8]) * 1.32) + ""; // Apply Dodge+
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(int.Parse(charStatusEffects[5]) - 1); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[5]) == 0) // Reset Dodge+
            {
                charStats[11] = charStats[8];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[6]) > 0) // Check for Bleed
            {
                charStats[5] = (int)Math.Round((int.Parse(charStats[5]) * 0.85)) + ""; // https://bit.ly/3rjaXAx <-- Math.Round stuff also this line applies Bleed
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(int.Parse(charStatusEffects[6]) - 1); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[6]) == 0) // If bleed count is empty just do nothing
            {

            }
            if (int.Parse(charStatusEffects[7]) == 0) // Check if player is stunned, it surrounds all abilities because no matter what class you are if you stunned you can't do nothin
            {
                if (charStats[1] == "1")
                {
                    battleAnnoBox.Text = "You used Slash!"; // Warrior's first ability
                    using (StreamReader sr = new StreamReader("__WarriorAttack.gif"))
                    {
                        charImageBox.Image = new Bitmap("__WarriorAttack.gif");
                    }
                    if (int.Parse(enemyStatusEffects[8]) == 0) // Check if enemy is parrying
                    {
                        int hitChance = rnd.Next(0, 100); // Random integer to determine accuracy
                        if (int.Parse(enemyStats[11]) < hitChance) // Apply enemy's dodge to the accuracy check
                        {
                            int crit = rnd.Next(0, 100); // Seperate check for Warrior's crit chance
                            if (crit >= 20)
                            { // Calculations and setting new variables
                                charActionBox.Text = "Critical hit! Double Damage!";
                                enemyStats[5] = int.Parse(enemyStats[5]) - ((int.Parse(charStats[9]) * 2) - int.Parse(enemyStats[10])) + "";
                                enemyHealthBox.Text = "Health: " + enemyStats[5] + "/" + enemyStats[4];
                            }
                            else
                            { // Calculations and setting new variables
                                charActionBox.Text = "Succesful Hit!";
                                enemyStats[5] = int.Parse(enemyStats[5]) - (int.Parse(charStats[9]) - int.Parse(enemyStats[10])) + "";
                                enemyHealthBox.Text = "Health: " + enemyStats[5] + "/" + enemyStats[4];
                            }
                            if (int.Parse(enemyStats[5]) <= 0) // Coin Gain and EXP gain on kill
                            {
                                attackBtn1.Visible = false; // Disables attacks to force player to go to next turn
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                exitbattlebtn.Visible = true; // Made by Evan to exit the battle popup menu
                                enemyHealthBox.Text = "Health: 0/" + enemyStats[4];
                                battleAnnoBox.Text = "You defeated the enemy!";
                                int coinsGain = rnd.Next(50, 100); // Random integer to determine amount of coins gained
                                inventory[0] = (int.Parse(inventory[0]) + coinsGain) + ""; // inventory[0] is where coin count is contained
                                using (StreamWriter writer = new StreamWriter("Inventory.txt")) // Update inventory file with new coin count applied
                                {
                                    writer.Flush();
                                    writer.WriteLine(inventory[0]); // Coins
                                    writer.WriteLine(inventory[1]); // Health Pots
                                    writer.WriteLine(inventory[2]); // Dagger
                                    writer.WriteLine(inventory[3]); // Strength Potion
                                }
                                int expGain = rnd.Next(50, 100); // Random integer to determin amount of exp gained
                                charStats[3] = (int.Parse(charStats[3]) + expGain) + ""; // Set the exp variable
                                if (int.Parse(charStats[3]) >= 100) // Check if you have enough EXP to level up
                                {
                                    charStats[2] = (int.Parse(charStats[2]) + 1) + ""; // Increase player's stats 
                                    charStats[3] = (int.Parse(charStats[3]) - 100) + "";
                                    charStats[4] = (int.Parse(charStats[4]) + 5) + "";
                                    charStats[5] = (int.Parse(charStats[5]) + 5) + "";
                                    charStats[6] = (int.Parse(charStats[6]) + 2) + "";
                                    charStats[7] = (int.Parse(charStats[7]) + 2) + "";
                                    charStats[9] = (int.Parse(charStats[9]) + 2) + "";
                                    charStats[10] = (int.Parse(charStats[10]) + 2) + "";
                                    charWriter(charStats, "ClassStats.txt");
                                }
                                attackBtn1.Visible = false; // Disables attacks to force player to go to next turn
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                            }
                            else
                            {
                                attackBtn1.Visible = false; // Disables attacks to force player to go to next turn
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                turnEndBtn.Visible = true;
                            }
                            enemyWriter(enemyStats, "EnemyStats.txt"); // Set enemy's stats again because health was updated
                        }
                        else
                        {
                            enemyActionBox.Text = "Enemy Dodged!";
                            attackBtn1.Visible = false; // Disables attacks to force player to go to next turn
                            attackBtn2.Visible = false; // If the enemy dodges then that means nothing happened
                            attackBtn3.Visible = false;
                            attackBtn4.Visible = false;
                            turnEndBtn.Visible = true;
                        }
                    }
                    else
                    {
                        enemyActionBox.Text = "Enemy Parried!"; // Parry
                        charStats[5] = int.Parse(charStats[5]) - (int.Parse(enemyStats[9]) / 2) + ""; // Apply Parry Effects
                        using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt")) 
                        {
                            writer.Flush();
                            writer.WriteLine(enemyStatusEffects[0]);
                            writer.WriteLine(enemyStatusEffects[1]);
                            writer.WriteLine(enemyStatusEffects[2]);
                            writer.WriteLine(enemyStatusEffects[3]);
                            writer.WriteLine(enemyStatusEffects[4]);
                            writer.WriteLine(enemyStatusEffects[5]);
                            writer.WriteLine(enemyStatusEffects[6]);
                            writer.WriteLine(enemyStatusEffects[7]);
                            writer.WriteLine(int.Parse(enemyStatusEffects[8]) - 1); // Lower parry count by 1
                        }
                        using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt"))
                        {
                            enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                            enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                            enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                            enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                            enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                            enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                            enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                            enemyStatusEffects[7] = reader.ReadLine(); // Stun
                            enemyStatusEffects[8] = reader.ReadLine(); // Parry
                        }
                        charWriter(charStats, "ClassStats.txt"); // Set character's stats again because health was changed again
                        if (int.Parse(charStats[5]) <= 0) // If dead
                        {
                            charHealthBox.Text = "Health 0/" + charStats[4];
                            MessageBox.Show("You Died! :("); // You died
                            Application.Exit();
                        }
                        else
                        {
                            attackBtn1.Visible = false; // Force player to go to next turn
                            attackBtn2.Visible = false;
                            attackBtn3.Visible = false;
                            attackBtn4.Visible = false;
                            turnEndBtn.Visible = true;
                        }
                    }
                }
                else if (charStats[1] == "2")
                {
                    battleAnnoBox.Text = "You used Piercing Shot!"; // Archer first ability
                    using (StreamReader sr = new StreamReader("__ArcherAttack.gif"))
                    {
                        charImageBox.Image = new Bitmap("__ArcherAttack.gif");
                    }
                    if (int.Parse(enemyStatusEffects[8]) == 0) // Check for parry
                    {
                        int hitChance = rnd.Next(0, 100);
                        if (int.Parse(enemyStats[11]) < hitChance)
                        {
                            charActionBox.Text = "Succesful Hit!";
                            enemyStats[5] = int.Parse(enemyStats[5]) - int.Parse(charStats[9]) + ""; // Not account for defence because that's what Piercing shot does
                            enemyHealthBox.Text = "Health: " + enemyStats[5] + "/" + enemyStats[4];
                            if (int.Parse(enemyStats[5]) <= 0) // Coin Gain and EXP gain on kill
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                exitbattlebtn.Visible = true;
                                enemyHealthBox.Text = "Health: 0/" + enemyStats[4];
                                battleAnnoBox.Text = "You defeated the enemy!";
                                int coinsGain = rnd.Next(50, 100);
                                inventory[0] = (int.Parse(inventory[0]) + coinsGain) + "";
                                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(inventory[0]); // Coins
                                    writer.WriteLine(inventory[1]); // Health Pots
                                    writer.WriteLine(inventory[2]); // Dagger
                                    writer.WriteLine(inventory[3]); // Strength Potion
                                }
                                int expGain = rnd.Next(50, 100);
                                charStats[3] = (int.Parse(charStats[3]) + expGain) + "";
                                if (int.Parse(charStats[3]) >= 100) // Check if you have enough EXP to level up
                                {
                                    charStats[2] = (int.Parse(charStats[2]) + 1) + "";
                                    charStats[3] = (int.Parse(charStats[3]) - 100) + "";
                                    charStats[4] = (int.Parse(charStats[4]) + 5) + "";
                                    charStats[5] = (int.Parse(charStats[5]) + 5) + "";
                                    charStats[6] = (int.Parse(charStats[6]) + 2) + "";
                                    charStats[7] = (int.Parse(charStats[7]) + 2) + "";
                                    charStats[9] = (int.Parse(charStats[9]) + 2) + "";
                                    charStats[10] = (int.Parse(charStats[10]) + 2) + "";
                                    charWriter(charStats, "ClassStats.txt");
                                }
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                            }
                            else
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                turnEndBtn.Visible = true;
                            }
                            enemyWriter(enemyStats, "EnemyStats.txt");
                        }
                        else
                        {
                            enemyActionBox.Text = "Enemy Dodged!";
                            attackBtn1.Visible = false;
                            attackBtn2.Visible = false;
                            attackBtn3.Visible = false;
                            attackBtn4.Visible = false;
                            turnEndBtn.Visible = true;
                        }
                    }
                    else
                    {
                        enemyActionBox.Text = "Enemy Parried!";
                        charStats[5] = int.Parse(charStats[5]) - (int.Parse(enemyStats[9]) / 2) + "";
                        using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                        {
                            writer.Flush();
                            writer.WriteLine(enemyStatusEffects[0]);
                            writer.WriteLine(enemyStatusEffects[1]);
                            writer.WriteLine(enemyStatusEffects[2]);
                            writer.WriteLine(enemyStatusEffects[3]);
                            writer.WriteLine(enemyStatusEffects[4]);
                            writer.WriteLine(enemyStatusEffects[5]);
                            writer.WriteLine(enemyStatusEffects[6]);
                            writer.WriteLine(enemyStatusEffects[7]);
                            writer.WriteLine(int.Parse(enemyStatusEffects[8]) - 1);
                        }
                        using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt"))
                        {
                            enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                            enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                            enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                            enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                            enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                            enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                            enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                            enemyStatusEffects[7] = reader.ReadLine(); // Stun
                            enemyStatusEffects[8] = reader.ReadLine(); // Parry
                        }
                        charWriter(charStats, "ClassStats.txt");
                        if (int.Parse(charStats[5]) <= 0)
                        {
                            charHealthBox.Text = "Health 0/" + charStats[4];
                            MessageBox.Show("You Died! :(");
                            Application.Exit();
                        }
                        else
                        {
                            attackBtn1.Visible = false;
                            attackBtn2.Visible = false;
                            attackBtn3.Visible = false;
                            attackBtn4.Visible = false;
                            turnEndBtn.Visible = true;
                        }
                    }
                }
                else if (charStats[1] == "3")
                {
                    battleAnnoBox.Text = "You used Momentum Strike!"; // Spear first ability
                    using (StreamReader sr = new StreamReader("__SpearAttack.gif"))
                    {
                        charImageBox.Image = new Bitmap("__SpearAttack.gif");
                    }
                    if (int.Parse(enemyStatusEffects[8]) == 0)
                    {
                        int hitChance = rnd.Next(0, 100);
                        if (int.Parse(enemyStats[11]) < hitChance)
                        {
                            charActionBox.Text = "Succesful Hit!";
                            enemyStats[5] = int.Parse(enemyStats[5]) - (int.Parse(charStats[9]) + (momentum * 1) - int.Parse(enemyStats[10])) + ""; // Momentum strike does damage + momentum
                            momentum = momentum + 1; // Increase momentum on succesful strike (that's what this ability does)
                            enemyHealthBox.Text = "Health: " + enemyStats[5] + "/" + enemyStats[4];
                            if (int.Parse(enemyStats[5]) <= 0) // Coin Gain and EXP gain on kill
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                exitbattlebtn.Visible = true;
                                enemyHealthBox.Text = "Health: 0/" + enemyStats[4];
                                battleAnnoBox.Text = "You defeated the enemy!";
                                int coinsGain = rnd.Next(50, 100);
                                inventory[0] = (int.Parse(inventory[0]) + coinsGain) + "";
                                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(inventory[0]); // Coins
                                    writer.WriteLine(inventory[1]); // Health Pots
                                    writer.WriteLine(inventory[2]); // Dagger
                                    writer.WriteLine(inventory[3]); // Strength Potion
                                }
                                int expGain = rnd.Next(50, 100);
                                charStats[3] = (int.Parse(charStats[3]) + expGain) + "";
                                if (int.Parse(charStats[3]) >= 100) // Check if you have enough EXP to level up
                                {
                                    charStats[2] = (int.Parse(charStats[2]) + 1) + "";
                                    charStats[3] = (int.Parse(charStats[3]) - 100) + "";
                                    charStats[4] = (int.Parse(charStats[4]) + 5) + "";
                                    charStats[5] = (int.Parse(charStats[5]) + 5) + "";
                                    charStats[6] = (int.Parse(charStats[6]) + 2) + "";
                                    charStats[7] = (int.Parse(charStats[7]) + 2) + "";
                                    charStats[9] = (int.Parse(charStats[9]) + 2) + "";
                                    charStats[10] = (int.Parse(charStats[10]) + 2) + "";
                                    charWriter(charStats, "ClassStats.txt");
                                }
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                            }
                            else
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                turnEndBtn.Visible = true;
                            }
                            enemyWriter(enemyStats, "EnemyStats.txt");
                        }
                        else
                        {
                            enemyActionBox.Text = "Enemy Dodged!";
                            momentum = 0; // Reset momentum because you missed 
                            attackBtn1.Visible = false;
                            attackBtn2.Visible = false;
                            attackBtn3.Visible = false;
                            attackBtn4.Visible = false;
                            turnEndBtn.Visible = true;
                        }
                    }
                    else
                    {
                        enemyActionBox.Text = "Enemy Parried!";
                        charStats[5] = (int.Parse(charStats[5]) - (int.Parse(enemyStats[9]) / 2)) + "";
                        using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                        {
                            writer.Flush();
                            writer.WriteLine(enemyStatusEffects[0]);
                            writer.WriteLine(enemyStatusEffects[1]);
                            writer.WriteLine(enemyStatusEffects[2]);
                            writer.WriteLine(enemyStatusEffects[3]);
                            writer.WriteLine(enemyStatusEffects[4]);
                            writer.WriteLine(enemyStatusEffects[5]);
                            writer.WriteLine(enemyStatusEffects[6]);
                            writer.WriteLine(enemyStatusEffects[7]);
                            writer.WriteLine(int.Parse(enemyStatusEffects[8]) - 1);
                        }
                        using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt"))
                        {
                            enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                            enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                            enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                            enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                            enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                            enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                            enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                            enemyStatusEffects[7] = reader.ReadLine(); // Stun
                            enemyStatusEffects[8] = reader.ReadLine(); // Parry
                        }
                        charWriter(charStats, "ClassStats.txt");
                        if (int.Parse(charStats[5]) <= 0)
                        {
                            charHealthBox.Text = "Health 0/" + charStats[4];
                            MessageBox.Show("You Died! :(");
                            Application.Exit();
                        }
                        else
                        {
                            attackBtn1.Visible = false;
                            attackBtn2.Visible = false;
                            attackBtn3.Visible = false;
                            attackBtn4.Visible = false;
                            turnEndBtn.Visible = true;
                        }
                    }
                }
            }
            else
            {
                charActionBox.Text = "You are stunned!"; // If you stunned you can't do anything so that's why there's little code here
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(int.Parse(charStatusEffects[7]) - 1); // Stun (Reduce stun count by 1)
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
                attackBtn1.Visible = false;
                attackBtn2.Visible = false;
                attackBtn3.Visible = false;
                attackBtn4.Visible = false;
                turnEndBtn.Visible = true;
            }
            charWriter(charStats, "ClassStats.txt"); // Safeguard to make sure character stats are saving properly
            enemyWriter(enemyStats, "EnemyStats.txt"); // Safeguard to make sure enemy stats are saving properly
            /* Following block of code is to check if there are any status effects on the player
             * or the enemy and if there are they write it in the corresponding status effects box
             * after every turn
             */ 
            if (int.Parse(charStatusEffects[0]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nAttack- (" + charStatusEffects[0] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[0]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nAttack- (" + enemyStatusEffects[0] + " turns)";
            }
            if (int.Parse(charStatusEffects[1]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nAttack+ (" + charStatusEffects[1] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[1]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nAttack+ (" + enemyStatusEffects[1] + " turns)";
            }
            if (int.Parse(charStatusEffects[2]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nDefense- (" + charStatusEffects[2] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[2]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nDefense- (" + enemyStatusEffects[2] + " turns)";
            }
            if (int.Parse(charStatusEffects[3]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nDefense+ (" + charStatusEffects[3] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[3]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nDefense+ (" + enemyStatusEffects[3] + " turns)";
            }
            if (int.Parse(charStatusEffects[4]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nDodge- (" + charStatusEffects[4] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[4]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nDodge- (" + enemyStatusEffects[4] + " turns)";
            }
            if (int.Parse(charStatusEffects[5]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nDodge+ (" + charStatusEffects[5] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[5]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nDodge+ (" + enemyStatusEffects[5] + " turns)";
            }
            if (int.Parse(charStatusEffects[6]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nBleed (" + charStatusEffects[6] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[6]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nBleed (" + enemyStatusEffects[6] + " turns)";
            }
            if (int.Parse(charStatusEffects[7]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nStun (" + charStatusEffects[7] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[7]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nStun (" + enemyStatusEffects[7] + " turns)";
            }
            if (int.Parse(charStatusEffects[8]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nParry (" + charStatusEffects[8] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[8]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nParry (" + enemyStatusEffects[8] + " turns)";
            }
        }

        private void attackBtn2_Click(object sender, EventArgs e) // Second attack button for player
        {
            /* The majority of the following code in this method is explained
             * in attackBtn1_Click go see more over there for details
             * The only things that are different are the abilities which have special comments to display what they do
             * But mostly everyhting you need is in attackBtn1_Click
             */ 
            enemyActionBox.Text = "";
            enemyStatusEffectsBox.Text = "";
            charStatusEffectsBox.Text = "";
            if (enemyStats[1] == "1")
            {
                using (StreamReader sr = new StreamReader("__TrollIdleSmall.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__TrollIdleSmall.gif");
                }
            }
            else if (enemyStats[2] == "2")
            {
                using (StreamReader sr = new StreamReader("__CorruptedMageIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__CorruptedMageIdle.gif");
                }
            }
            else if (enemyStats[3] == "3")
            {
                using (StreamReader sr = new StreamReader("__SkeletonIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__SkeletonIdle.gif");
                }
            }
            else if (enemyStats[4] == "4")
            {
                using (StreamReader sr = new StreamReader("__GoblinIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__GoblinIdle.gif");
                }
            }
            else if (enemyStats[5] == "5")
            {
                using (StreamReader sr = new StreamReader("__MimicIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__MimicIdle.gif");
                }
            }
            else if (enemyStats[6] == "6")
            {
                using (StreamReader sr = new StreamReader("__MimicIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__MimicIdle.gif");
                }
            }
            using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
            {
                charStatusEffects[0] = reader.ReadLine(); // Attack-
                charStatusEffects[1] = reader.ReadLine(); // Attack+
                charStatusEffects[2] = reader.ReadLine(); // Defense-
                charStatusEffects[3] = reader.ReadLine(); // Defense+
                charStatusEffects[4] = reader.ReadLine(); // Dodge-
                charStatusEffects[5] = reader.ReadLine(); // Dodge+
                charStatusEffects[6] = reader.ReadLine(); // Bleed
                charStatusEffects[7] = reader.ReadLine(); // Stun
                charStatusEffects[8] = reader.ReadLine(); // Parry
            }
            using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt"))
            {
                enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                enemyStatusEffects[7] = reader.ReadLine(); // Stun
                enemyStatusEffects[8] = reader.ReadLine(); // Parry
            }
            if (int.Parse(charStatusEffects[0]) > 0)
            {
                charStats[9] = (int.Parse(charStats[6]) / 2) + "";
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(int.Parse(charStatusEffects[0]) - 1); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[0]) == 0)
            {
                charStats[9] = charStats[6];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[1]) > 0)
            {
                charStats[9] = (int.Parse(charStats[6]) * 2) + "";
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(int.Parse(charStatusEffects[1]) - 1); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[1]) == 0)
            {
                charStats[9] = charStats[6];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[2]) > 0)
            {
                charStats[10] = (int.Parse(charStats[7]) / 2) + "";
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(int.Parse(charStatusEffects[2]) - 1); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[2]) == 0)
            {
                charStats[10] = charStats[7];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[3]) > 0)
            {
                charStats[10] = (int.Parse(charStats[7]) * 2) + "";
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(int.Parse(charStatusEffects[3]) - 1); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[3]) == 0)
            {
                charStats[10] = charStats[7];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[4]) > 0)
            {
                charStats[11] = (int)Math.Round(int.Parse(charStats[8]) / 1.32) + "";
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(int.Parse(charStatusEffects[4]) - 1); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[4]) == 0)
            {
                charStats[11] = charStats[8];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[5]) > 0)
            {
                charStats[11] = (int)Math.Round(int.Parse(charStats[8]) * 1.32) + "";
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(int.Parse(charStatusEffects[5]) - 1); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[5]) == 0)
            {
                charStats[11] = charStats[8];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[6]) > 0)
            {
                charStats[5] = (int)Math.Round((int.Parse(charStats[5]) * 0.85)) + ""; // https://bit.ly/3rjaXAx
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(int.Parse(charStatusEffects[6]) - 1); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[6]) == 0)
            {

            }
            if (int.Parse(charStatusEffects[7]) == 0)
            {
                if (charStats[1] == "1")
                {
                    battleAnnoBox.Text = "You used Bash!";
                    using (StreamReader sr = new StreamReader("__WarriorAttack.gif"))
                    {
                        charImageBox.Image = new Bitmap("__WarriorAttack.gif");
                    }
                    if (int.Parse(enemyStatusEffects[8]) == 0)
                    {
                        int hitChance = rnd.Next(0, 100);
                        if (int.Parse(enemyStats[11]) < hitChance)
                        {
                            charActionBox.Text = "Succesful Hit!";
                            enemyStats[5] = (int.Parse(enemyStats[5]) - (int.Parse(charStats[9]) - int.Parse(enemyStats[10]))) + "";
                            enemyHealthBox.Text = "Health: " + enemyStats[5] + "/" + enemyStats[4];
                            using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                            {
                                writer.Flush();
                                writer.WriteLine(enemyStatusEffects[0]); // Attack-
                                writer.WriteLine(enemyStatusEffects[1]); // Attack+
                                writer.WriteLine(int.Parse(enemyStatusEffects[2]) + 2); // Defense- (Apply defense- for 2 turns)
                                writer.WriteLine(enemyStatusEffects[3]); // Defnese+
                                writer.WriteLine(enemyStatusEffects[4]); // Dodge-
                                writer.WriteLine(enemyStatusEffects[5]); // Dodge+
                                writer.WriteLine(enemyStatusEffects[6]); // Bleed
                                writer.WriteLine(enemyStatusEffects[7]); // Stun
                                writer.WriteLine(enemyStatusEffects[8]); // Parry
                            }
                            using (StreamReader sr = new StreamReader("EnemyStatusEffects.txt"))
                            {
                                enemyStatusEffects[0] = sr.ReadLine();
                                enemyStatusEffects[1] = sr.ReadLine();
                                enemyStatusEffects[2] = sr.ReadLine();
                                enemyStatusEffects[3] = sr.ReadLine();
                                enemyStatusEffects[4] = sr.ReadLine();
                                enemyStatusEffects[5] = sr.ReadLine();
                                enemyStatusEffects[6] = sr.ReadLine();
                                enemyStatusEffects[7] = sr.ReadLine();
                                enemyStatusEffects[8] = sr.ReadLine();
                            }
                            if (int.Parse(enemyStats[5]) <= 0) // Coin Gain and EXP gain on kill
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                exitbattlebtn.Visible = true;
                                enemyHealthBox.Text = "Health: 0/" + enemyStats[4];
                                battleAnnoBox.Text = "You defeated the enemy!";
                                int coinsGain = rnd.Next(50, 100);
                                inventory[0] = (int.Parse(inventory[0]) + coinsGain) + "";
                                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(inventory[0]); // Coins
                                    writer.WriteLine(inventory[1]); // Health Pots
                                    writer.WriteLine(inventory[2]); // Dagger
                                    writer.WriteLine(inventory[3]); // Strength Potion
                                }
                                int expGain = rnd.Next(50, 100);
                                charStats[3] = (int.Parse(charStats[3]) + expGain) + "";
                                if (int.Parse(charStats[3]) >= 100) // Check if you have enough EXP to level up
                                {
                                    charStats[2] = (int.Parse(charStats[2]) + 1) + "";
                                    charStats[3] = (int.Parse(charStats[3]) - 100) + "";
                                    charStats[4] = (int.Parse(charStats[4]) + 5) + "";
                                    charStats[5] = (int.Parse(charStats[5]) + 5) + "";
                                    charStats[6] = (int.Parse(charStats[6]) + 2) + "";
                                    charStats[7] = (int.Parse(charStats[7]) + 2) + "";
                                    charStats[9] = (int.Parse(charStats[9]) + 2) + "";
                                    charStats[10] = (int.Parse(charStats[10]) + 2) + "";
                                    charWriter(charStats, "ClassStats.txt");
                                }
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                            }
                            else
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                turnEndBtn.Visible = true;
                            }
                            enemyWriter(enemyStats, "EnemyStats.txt");
                        }
                        else
                        {
                            enemyActionBox.Text = "Enemy Dodged!";
                            attackBtn1.Visible = false;
                            attackBtn2.Visible = false;
                            attackBtn3.Visible = false;
                            attackBtn4.Visible = false;
                            turnEndBtn.Visible = true;
                        }
                    }
                    else
                    {
                        enemyActionBox.Text = "Enemy Parried!";
                        charStats[5] = (int.Parse(enemyStats[5]) - (int.Parse(enemyStats[9]) / 2)) + "";
                        using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                        {
                            writer.Flush();
                            writer.WriteLine(enemyStatusEffects[0]);
                            writer.WriteLine(enemyStatusEffects[1]);
                            writer.WriteLine(enemyStatusEffects[2]);
                            writer.WriteLine(enemyStatusEffects[3]);
                            writer.WriteLine(enemyStatusEffects[4]);
                            writer.WriteLine(enemyStatusEffects[5]);
                            writer.WriteLine(enemyStatusEffects[6]);
                            writer.WriteLine(enemyStatusEffects[7]);
                            writer.WriteLine(int.Parse(enemyStatusEffects[8]) - 1);
                        }
                        using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt"))
                        {
                            enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                            enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                            enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                            enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                            enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                            enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                            enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                            enemyStatusEffects[7] = reader.ReadLine(); // Stun
                            enemyStatusEffects[8] = reader.ReadLine(); // Parry
                        }
                        charWriter(charStats, "ClassStats.txt");
                        if (int.Parse(charStats[5]) <= 0)
                        {
                            charHealthBox.Text = "Health 0/" + charStats[4];
                            MessageBox.Show("You Died! :(");
                            Application.Exit();
                        }
                        else
                        {
                            attackBtn1.Visible = false;
                            attackBtn2.Visible = false;
                            attackBtn3.Visible = false;
                            attackBtn4.Visible = false;
                            turnEndBtn.Visible = true;
                        }
                    }
                }
                else if (charStats[1] == "2")
                {
                    battleAnnoBox.Text = "You used Pursuit!";
                    using (StreamReader sr = new StreamReader("__ArcherAttack.gif"))
                    {
                        charImageBox.Image = new Bitmap("__ArcherAttack.gif");
                    }
                    if (int.Parse(enemyStatusEffects[8]) == 0)
                    {
                        int hitChance = rnd.Next(0, 100);
                        if (int.Parse(enemyStats[11]) < hitChance)
                        {
                            charActionBox.Text = "Succesful Hit!";
                            enemyStats[5] = int.Parse(enemyStats[5]) - (int.Parse(charStats[9]) - int.Parse(enemyStats[10])) + ""; // Normal damage if it's a normal hit
                            enemyHealthBox.Text = "Health: " + enemyStats[5] + "/" + enemyStats[4];
                            if (int.Parse(enemyStats[5]) <= 0) // Coin Gain and EXP gain on kill
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                exitbattlebtn.Visible = true;
                                enemyHealthBox.Text = "Health: 0/" + enemyStats[4];
                                battleAnnoBox.Text = "You defeated the enemy!";
                                int coinsGain = rnd.Next(50, 100);
                                inventory[0] = (int.Parse(inventory[0]) + coinsGain) + "";
                                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(inventory[0]); // Coins
                                    writer.WriteLine(inventory[1]); // Health Pots
                                    writer.WriteLine(inventory[2]); // Dagger
                                    writer.WriteLine(inventory[3]); // Strength Potion
                                }
                                int expGain = rnd.Next(50, 100);
                                charStats[3] = (int.Parse(charStats[3]) + expGain) + "";
                                if (int.Parse(charStats[3]) >= 100) // Check if you have enough EXP to level up
                                {
                                    charStats[2] = (int.Parse(charStats[2]) + 1) + "";
                                    charStats[3] = (int.Parse(charStats[3]) - 100) + "";
                                    charStats[4] = (int.Parse(charStats[4]) + 5) + "";
                                    charStats[5] = (int.Parse(charStats[5]) + 5) + "";
                                    charStats[6] = (int.Parse(charStats[6]) + 2) + "";
                                    charStats[7] = (int.Parse(charStats[7]) + 2) + "";
                                    charStats[9] = (int.Parse(charStats[9]) + 2) + "";
                                    charStats[10] = (int.Parse(charStats[10]) + 2) + "";
                                    charWriter(charStats, "ClassStats.txt");
                                }
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                            }
                            else
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                turnEndBtn.Visible = true;
                            }
                            enemyWriter(enemyStats, "EnemyStats.txt");
                        }
                        else
                        {
                            enemyActionBox.Text = "Enemy Dodged! Bonus Damage!";
                            enemyStats[5] = int.Parse(enemyStats[5]) - ((int.Parse(charStats[9])*2) - int.Parse(enemyStats[10])) + ""; // Bonus damage, enemy dodged
                            enemyHealthBox.Text = "Health: " + enemyStats[5] + "/" + enemyStats[4];
                            if (int.Parse(enemyStats[5]) <= 0) // Coin Gain and EXP gain on kill
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                exitbattlebtn.Visible = true;
                                enemyHealthBox.Text = "Health: 0/" + enemyStats[4];
                                battleAnnoBox.Text = "You defeated the enemy!";
                                int coinsGain = rnd.Next(50, 100);
                                inventory[0] = (int.Parse(inventory[0]) + coinsGain) + "";
                                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(inventory[0]); // Coins
                                    writer.WriteLine(inventory[1]); // Health Pots
                                    writer.WriteLine(inventory[2]); // Dagger
                                    writer.WriteLine(inventory[3]); // Strength Potion
                                }
                                int expGain = rnd.Next(50, 100);
                                charStats[3] = (int.Parse(charStats[3]) + expGain) + "";
                                if (int.Parse(charStats[3]) >= 100) // Check if you have enough EXP to level up
                                {
                                    charStats[2] = (int.Parse(charStats[2]) + 1) + "";
                                    charStats[3] = (int.Parse(charStats[3]) - 100) + "";
                                    charStats[4] = (int.Parse(charStats[4]) + 5) + "";
                                    charStats[5] = (int.Parse(charStats[5]) + 5) + "";
                                    charStats[6] = (int.Parse(charStats[6]) + 2) + "";
                                    charStats[7] = (int.Parse(charStats[7]) + 2) + "";
                                    charStats[9] = (int.Parse(charStats[9]) + 2) + "";
                                    charStats[10] = (int.Parse(charStats[10]) + 2) + "";
                                    charWriter(charStats, "ClassStats.txt");
                                }
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                            }
                            else
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                turnEndBtn.Visible = true;
                            }
                            enemyWriter(enemyStats, "EnemyStats.txt");
                        }
                    }
                    else
                    {
                        enemyActionBox.Text = "Enemy Parried!";
                        charStats[5] = (int.Parse(charStats[5]) - (int.Parse(enemyStats[9]) / 2)) + "";
                        using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                        {
                            writer.Flush();
                            writer.WriteLine(enemyStatusEffects[0]);
                            writer.WriteLine(enemyStatusEffects[1]);
                            writer.WriteLine(enemyStatusEffects[2]);
                            writer.WriteLine(enemyStatusEffects[3]);
                            writer.WriteLine(enemyStatusEffects[4]);
                            writer.WriteLine(enemyStatusEffects[5]);
                            writer.WriteLine(enemyStatusEffects[6]);
                            writer.WriteLine(enemyStatusEffects[7]);
                            writer.WriteLine(int.Parse(enemyStatusEffects[8]) - 1);
                        }
                        using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt"))
                        {
                            enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                            enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                            enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                            enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                            enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                            enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                            enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                            enemyStatusEffects[7] = reader.ReadLine(); // Stun
                            enemyStatusEffects[8] = reader.ReadLine(); // Parry
                        }
                        charWriter(charStats, "ClassStats.txt");
                        if (int.Parse(charStats[5]) <= 0)
                        {
                            charHealthBox.Text = "Health 0/" + charStats[4];
                            MessageBox.Show("You Died! :(");
                            Application.Exit();
                        }
                        else
                        {
                            attackBtn1.Visible = false;
                            attackBtn2.Visible = false;
                            attackBtn3.Visible = false;
                            attackBtn4.Visible = false;
                            turnEndBtn.Visible = true;
                        }
                    }
                }
                else if (charStats[1] == "3")
                {
                    battleAnnoBox.Text = "You used Sweeping Strike!";
                    using (StreamReader sr = new StreamReader("__SpearAttack.gif"))
                    {
                        charImageBox.Image = new Bitmap("__SpearAttack.gif");
                    }
                    if (int.Parse(enemyStatusEffects[8]) == 0)
                    {
                        // No accuracy check here because Sweeping Strike always hits regardless of enemy's dodge level
                            charActionBox.Text = "Succesful Hit!";
                            enemyStats[5] = int.Parse(enemyStats[5]) - (int.Parse(charStats[9]) - int.Parse(enemyStats[10])) + "";
                            enemyHealthBox.Text = "Health: " + enemyStats[5] + "/" + enemyStats[4];
                            if (int.Parse(enemyStats[5]) <= 0) // Coin Gain and EXP gain on kill
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                exitbattlebtn.Visible = true;
                                enemyHealthBox.Text = "Health: 0/" + enemyStats[4];
                                battleAnnoBox.Text = "You defeated the enemy!";
                                int coinsGain = rnd.Next(50, 100);
                                inventory[0] = (int.Parse(inventory[0]) + coinsGain) + "";
                                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(inventory[0]); // Coins
                                    writer.WriteLine(inventory[1]); // Health Pots
                                    writer.WriteLine(inventory[2]); // Dagger
                                    writer.WriteLine(inventory[3]); // Strength Potion
                                }
                                int expGain = rnd.Next(50, 100);
                                charStats[3] = (int.Parse(charStats[3]) + expGain) + "";
                                if (int.Parse(charStats[3]) >= 100) // Check if you have enough EXP to level up
                                {
                                    charStats[2] = (int.Parse(charStats[2]) + 1) + "";
                                    charStats[3] = (int.Parse(charStats[3]) - 100) + "";
                                    charStats[4] = (int.Parse(charStats[4]) + 5) + "";
                                    charStats[5] = (int.Parse(charStats[5]) + 5) + "";
                                    charStats[6] = (int.Parse(charStats[6]) + 2) + "";
                                    charStats[7] = (int.Parse(charStats[7]) + 2) + "";
                                    charStats[9] = (int.Parse(charStats[9]) + 2) + "";
                                    charStats[10] = (int.Parse(charStats[10]) + 2) + "";
                                    charWriter(charStats, "ClassStats.txt");
                                }
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                            }
                            else
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                turnEndBtn.Visible = true;
                            }
                             enemyWriter(enemyStats, "EnemyStats.txt");
                    }
                    else
                    {
                        enemyActionBox.Text = "Enemy Parried!";
                        charStats[5] = (int.Parse(charStats[5]) - (int.Parse(enemyStats[9]) / 2)) + "";
                        using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                        {
                            writer.Flush();
                            writer.WriteLine(enemyStatusEffects[0]);
                            writer.WriteLine(enemyStatusEffects[1]);
                            writer.WriteLine(enemyStatusEffects[2]);
                            writer.WriteLine(enemyStatusEffects[3]);
                            writer.WriteLine(enemyStatusEffects[4]);
                            writer.WriteLine(enemyStatusEffects[5]);
                            writer.WriteLine(enemyStatusEffects[6]);
                            writer.WriteLine(enemyStatusEffects[7]);
                            writer.WriteLine(int.Parse(enemyStatusEffects[8]) - 1);
                        }
                        using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt"))
                        {
                            enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                            enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                            enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                            enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                            enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                            enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                            enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                            enemyStatusEffects[7] = reader.ReadLine(); // Stun
                            enemyStatusEffects[8] = reader.ReadLine(); // Parry
                        }
                        charWriter(charStats, "ClassStats.txt");
                        if (int.Parse(charStats[5]) <= 0)
                        {
                            charHealthBox.Text = "Health 0/" + charStats[4];
                            MessageBox.Show("You Died! :(");
                            Application.Exit();
                        }
                        else
                        {
                            attackBtn1.Visible = false;
                            attackBtn2.Visible = false;
                            attackBtn3.Visible = false;
                            attackBtn4.Visible = false;
                            turnEndBtn.Visible = true;
                        }
                    }
                }
            }
            else
            {
                charActionBox.Text = "You are stunned!";
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(int.Parse(charStatusEffects[7]) - 1); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
                attackBtn1.Visible = false;
                attackBtn2.Visible = false;
                attackBtn3.Visible = false;
                attackBtn4.Visible = false;
                turnEndBtn.Visible = true;
            }
            charWriter(charStats, "ClassStats.txt");
            enemyWriter(enemyStats, "EnemyStats.txt");
            if (int.Parse(charStatusEffects[0]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nAttack- (" + charStatusEffects[0] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[0]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nAttack- (" + enemyStatusEffects[0] + " turns)";
            }
            if (int.Parse(charStatusEffects[1]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nAttack+ (" + charStatusEffects[1] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[1]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nAttack+ (" + enemyStatusEffects[1] + " turns)";
            }
            if (int.Parse(charStatusEffects[2]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nDefense- (" + charStatusEffects[2] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[2]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nDefense- (" + enemyStatusEffects[2] + " turns)";
            }
            if (int.Parse(charStatusEffects[3]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nDefense+ (" + charStatusEffects[3] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[3]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nDefense+ (" + enemyStatusEffects[3] + " turns)";
            }
            if (int.Parse(charStatusEffects[4]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nDodge- (" + charStatusEffects[4] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[4]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nDodge- (" + enemyStatusEffects[4] + " turns)";
            }
            if (int.Parse(charStatusEffects[5]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nDodge+ (" + charStatusEffects[5] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[5]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nDodge+ (" + enemyStatusEffects[5] + " turns)";
            }
            if (int.Parse(charStatusEffects[6]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nBleed (" + charStatusEffects[6] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[6]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nBleed (" + enemyStatusEffects[6] + " turns)";
            }
            if (int.Parse(charStatusEffects[7]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nStun (" + charStatusEffects[7] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[7]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nStun (" + enemyStatusEffects[7] + " turns)";
            }
            if (int.Parse(charStatusEffects[8]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nParry (" + charStatusEffects[8] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[8]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nParry (" + enemyStatusEffects[8] + " turns)";
            }
        }

        private void attackBtn3_Click(object sender, EventArgs e)
        {
            /* The majority of the following code in this method is explained
 * in attackBtn1_Click go see more over there for details
 * The only things that are different are the abilities which have special comments to display what they do
 * But mostly everyhting you need is in attackBtn1_Click
 */
            enemyActionBox.Text = "";
            enemyStatusEffectsBox.Text = "";
            charStatusEffectsBox.Text = "";
            if (enemyStats[1] == "1")
            {
                using (StreamReader sr = new StreamReader("__TrollIdleSmall.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__TrollIdleSmall.gif");
                }
            }
            else if (enemyStats[2] == "2")
            {
                using (StreamReader sr = new StreamReader("__CorruptedMageIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__CorruptedMageIdle.gif");
                }
            }
            else if (enemyStats[3] == "3")
            {
                using (StreamReader sr = new StreamReader("__SkeletonIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__SkeletonIdle.gif");
                }
            }
            else if (enemyStats[4] == "4")
            {
                using (StreamReader sr = new StreamReader("__GoblinIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__GoblinIdle.gif");
                }
            }
            else if (enemyStats[5] == "5")
            {
                using (StreamReader sr = new StreamReader("__MimicIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__MimicIdle.gif");
                }
            }
            else if (enemyStats[6] == "6")
            {
                using (StreamReader sr = new StreamReader("__MimicIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__MimicIdle.gif");
                }
            }
            using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
            {
                charStatusEffects[0] = reader.ReadLine(); // Attack-
                charStatusEffects[1] = reader.ReadLine(); // Attack+
                charStatusEffects[2] = reader.ReadLine(); // Defense-
                charStatusEffects[3] = reader.ReadLine(); // Defense+
                charStatusEffects[4] = reader.ReadLine(); // Dodge-
                charStatusEffects[5] = reader.ReadLine(); // Dodge+
                charStatusEffects[6] = reader.ReadLine(); // Bleed
                charStatusEffects[7] = reader.ReadLine(); // Stun
                charStatusEffects[8] = reader.ReadLine(); // Parry
            }
            using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt"))
            {
                enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                enemyStatusEffects[7] = reader.ReadLine(); // Stun
                enemyStatusEffects[8] = reader.ReadLine(); // Parry
            }
            if (int.Parse(charStatusEffects[0]) > 0)
            {
                charStats[9] = (int.Parse(charStats[6]) / 2) + "";
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(int.Parse(charStatusEffects[0]) - 1); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[0]) == 0)
            {
                charStats[9] = charStats[6];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[1]) > 0)
            {
                charStats[9] = (int.Parse(charStats[6]) * 2) + "";
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(int.Parse(charStatusEffects[1]) - 1); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[1]) == 0)
            {
                charStats[9] = charStats[6];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[2]) > 0)
            {
                charStats[10] = (int.Parse(charStats[7]) / 2) + "";
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(int.Parse(charStatusEffects[2]) - 1); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[2]) == 0)
            {
                charStats[10] = charStats[7];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[3]) > 0)
            {
                charStats[10] = (int.Parse(charStats[7]) * 2) + "";
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(int.Parse(charStatusEffects[3]) - 1); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[3]) == 0)
            {
                charStats[10] = charStats[7];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[4]) > 0)
            {
                charStats[11] = (int)Math.Round(int.Parse(charStats[8]) / 1.32) + "";
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(int.Parse(charStatusEffects[4]) - 1); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[4]) == 0)
            {
                charStats[11] = charStats[8];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[5]) > 0)
            {
                charStats[11] = (int)Math.Round(int.Parse(charStats[8]) * 1.32) + "";
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(int.Parse(charStatusEffects[5]) - 1); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[5]) == 0)
            {
                charStats[11] = charStats[8];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[6]) > 0)
            {
                charStats[5] = (int)Math.Round((int.Parse(charStats[5]) * 0.85)) + ""; // https://bit.ly/3rjaXAx
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(int.Parse(charStatusEffects[6]) - 1); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[6]) == 0)
            {

            }
            if (int.Parse(charStatusEffects[7]) == 0)
            {
                if (charStats[1] == "1")
                {
                    battleAnnoBox.Text = "You used Heavy Smash!";
                    using (StreamReader sr = new StreamReader("__WarriorAttack.gif"))
                    {
                        charImageBox.Image = new Bitmap("__WarriorAttack.gif");
                    }
                    if (int.Parse(enemyStatusEffects[8]) == 0)
                    {
                        int hitChance = rnd.Next(0, 100);
                        if (int.Parse(enemyStats[11]) < hitChance - 25) // Subtracting 25 from hitChance makes it harder for the ability to land hence applying an accuracy lowering modifier
                        {
                            enemyActionBox.Text = "Enemy Hit!";
                            using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                            {
                                writer.Flush();
                                writer.WriteLine(enemyStatusEffects[0]); // Attack-
                                writer.WriteLine(enemyStatusEffects[1]); // Attack+
                                writer.WriteLine(enemyStatusEffects[2]); // Defense-
                                writer.WriteLine(enemyStatusEffects[3]); // Defnese+
                                writer.WriteLine(enemyStatusEffects[4]); // Dodge-
                                writer.WriteLine(enemyStatusEffects[5]); // Dodge+
                                writer.WriteLine(enemyStatusEffects[6]); // Bleed
                                writer.WriteLine(int.Parse(enemyStatusEffects[7]) + 2); // Stun (Apply Stun for 2 turns)
                                writer.WriteLine(enemyStatusEffects[8]); // Parry
                            }
                            using (StreamReader sr = new StreamReader("EnemyStatusEffects.txt"))
                            {
                                enemyStatusEffects[0] = sr.ReadLine();
                                enemyStatusEffects[1] = sr.ReadLine();
                                enemyStatusEffects[2] = sr.ReadLine();
                                enemyStatusEffects[3] = sr.ReadLine();
                                enemyStatusEffects[4] = sr.ReadLine();
                                enemyStatusEffects[5] = sr.ReadLine();
                                enemyStatusEffects[6] = sr.ReadLine();
                                enemyStatusEffects[7] = sr.ReadLine();
                                enemyStatusEffects[8] = sr.ReadLine();
                            }
                            attackBtn1.Visible = false;
                            attackBtn2.Visible = false;
                            attackBtn3.Visible = false;
                            attackBtn4.Visible = false;
                            turnEndBtn.Visible = true;
                        }
                        else
                        {
                            enemyActionBox.Text = "Enemy Dodged!";
                            attackBtn1.Visible = false;
                            attackBtn2.Visible = false;
                            attackBtn3.Visible = false;
                            attackBtn4.Visible = false;
                            turnEndBtn.Visible = true;
                        }
                    }
                    else
                    {
                        enemyActionBox.Text = "Enemy Parried!";
                        charStats[5] = int.Parse(charStats[5]) - (int.Parse(enemyStats[9]) / 2) + "";
                        using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                        {
                            writer.Flush();
                            writer.WriteLine(enemyStatusEffects[0]);
                            writer.WriteLine(enemyStatusEffects[1]);
                            writer.WriteLine(enemyStatusEffects[2]);
                            writer.WriteLine(enemyStatusEffects[3]);
                            writer.WriteLine(enemyStatusEffects[4]);
                            writer.WriteLine(enemyStatusEffects[5]);
                            writer.WriteLine(enemyStatusEffects[6]);
                            writer.WriteLine(enemyStatusEffects[7]);
                            writer.WriteLine(int.Parse(enemyStatusEffects[8]) - 1);
                        }
                        using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt"))
                        {
                            enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                            enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                            enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                            enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                            enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                            enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                            enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                            enemyStatusEffects[7] = reader.ReadLine(); // Stun
                            enemyStatusEffects[8] = reader.ReadLine(); // Parry
                        }
                        charWriter(charStats, "ClassStats.txt");
                        if (int.Parse(charStats[5]) <= 0)
                        {
                            charHealthBox.Text = "Health 0/" + charStats[4];
                            MessageBox.Show("You Died! :(");
                            Application.Exit();
                        }
                        else
                        {
                            attackBtn1.Visible = false;
                            attackBtn2.Visible = false;
                            attackBtn3.Visible = false;
                            attackBtn4.Visible = false;
                            turnEndBtn.Visible = true;
                        }
                    }
                }
                else if (charStats[1] == "2")
                {
                    battleAnnoBox.Text = "You used Gouge!";
                    using (StreamReader sr = new StreamReader("__ArcherAttack.gif"))
                    {
                        charImageBox.Image = new Bitmap("__ArcherAttack.gif");
                    }
                    if (int.Parse(enemyStatusEffects[8]) == 0)
                    {
                        int hitChance = rnd.Next(0, 100);
                        if (int.Parse(enemyStats[11]) < hitChance)
                        {
                            charActionBox.Text = "Succesful Hit!";
                            enemyStats[5] = int.Parse(enemyStats[5]) - (int.Parse(charStats[9]) - int.Parse(enemyStats[10])) + "";
                            enemyHealthBox.Text = "Health: " + enemyStats[5] + "/" + enemyStats[4];
                            using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                            {
                                writer.Flush();
                                writer.WriteLine(enemyStatusEffects[0]); // Attack-
                                writer.WriteLine(enemyStatusEffects[1]); // Attack+
                                writer.WriteLine(enemyStatusEffects[2]); // Defense-
                                writer.WriteLine(enemyStatusEffects[3]); // Defnese+
                                writer.WriteLine(enemyStatusEffects[4]); // Dodge-
                                writer.WriteLine(enemyStatusEffects[5]); // Dodge+
                                writer.WriteLine(int.Parse(enemyStatusEffects[6]) + 2); // Bleed (Apply Bleed for 2 turns)
                                writer.WriteLine(enemyStatusEffects[7]); // Stun
                                writer.WriteLine(enemyStatusEffects[8]); // Parry
                            }
                            using (StreamReader sr = new StreamReader("EnemyStatusEffects.txt"))
                            {
                                enemyStatusEffects[0] = sr.ReadLine();
                                enemyStatusEffects[1] = sr.ReadLine();
                                enemyStatusEffects[2] = sr.ReadLine();
                                enemyStatusEffects[3] = sr.ReadLine();
                                enemyStatusEffects[4] = sr.ReadLine();
                                enemyStatusEffects[5] = sr.ReadLine();
                                enemyStatusEffects[6] = sr.ReadLine();
                                enemyStatusEffects[7] = sr.ReadLine();
                                enemyStatusEffects[8] = sr.ReadLine();
                            }
                            if (int.Parse(enemyStats[5]) <= 0) // Coin Gain and EXP gain on kill
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                exitbattlebtn.Visible = true;
                                enemyHealthBox.Text = "Health: 0/" + enemyStats[4];
                                battleAnnoBox.Text = "You defeated the enemy!";
                                int coinsGain = rnd.Next(50, 100);
                                inventory[0] = (int.Parse(inventory[0]) + coinsGain) + "";
                                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(inventory[0]); // Coins
                                    writer.WriteLine(inventory[1]); // Health Pots
                                    writer.WriteLine(inventory[2]); // Dagger
                                    writer.WriteLine(inventory[3]); // Strength Potion
                                }
                                int expGain = rnd.Next(50, 100);
                                charStats[3] = (int.Parse(charStats[3]) + expGain) + "";
                                if (int.Parse(charStats[3]) >= 100) // Check if you have enough EXP to level up
                                {
                                    charStats[2] = (int.Parse(charStats[2]) + 1) + "";
                                    charStats[3] = (int.Parse(charStats[3]) - 100) + "";
                                    charStats[4] = (int.Parse(charStats[4]) + 5) + "";
                                    charStats[5] = (int.Parse(charStats[5]) + 5) + "";
                                    charStats[6] = (int.Parse(charStats[6]) + 2) + "";
                                    charStats[7] = (int.Parse(charStats[7]) + 2) + "";
                                    charStats[9] = (int.Parse(charStats[9]) + 2) + "";
                                    charStats[10] = (int.Parse(charStats[10]) + 2) + "";
                                    charWriter(charStats, "ClassStats.txt");
                                }
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                            }
                            else
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                turnEndBtn.Visible = true;
                            }
                            enemyWriter(enemyStats, "EnemyStats.txt");
                        }
                        else
                        {
                            enemyActionBox.Text = "Enemy Dodged!";
                            attackBtn1.Visible = false;
                            attackBtn2.Visible = false;
                            attackBtn3.Visible = false;
                            attackBtn4.Visible = false;
                            turnEndBtn.Visible = true;
                        }
                    }
                    else
                    {
                        enemyActionBox.Text = "Enemy Parried!";
                        charStats[5] = (int.Parse(charStats[5]) - (int.Parse(enemyStats[9]) / 2)) + "";
                        using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                        {
                            writer.Flush();
                            writer.WriteLine(enemyStatusEffects[0]);
                            writer.WriteLine(enemyStatusEffects[1]);
                            writer.WriteLine(enemyStatusEffects[2]);
                            writer.WriteLine(enemyStatusEffects[3]);
                            writer.WriteLine(enemyStatusEffects[4]);
                            writer.WriteLine(enemyStatusEffects[5]);
                            writer.WriteLine(enemyStatusEffects[6]);
                            writer.WriteLine(enemyStatusEffects[7]);
                            writer.WriteLine(int.Parse(enemyStatusEffects[8]) - 1);
                        }
                        using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt"))
                        {
                            enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                            enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                            enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                            enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                            enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                            enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                            enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                            enemyStatusEffects[7] = reader.ReadLine(); // Stun
                            enemyStatusEffects[8] = reader.ReadLine(); // Parry
                        }
                        charWriter(charStats, "ClassStats.txt");
                        if (int.Parse(charStats[5]) <= 0)
                        {
                            charHealthBox.Text = "Health 0/" + charStats[4];
                            MessageBox.Show("You Died! :(");
                            Application.Exit();
                        }
                        else
                        {
                            attackBtn1.Visible = false;
                            attackBtn2.Visible = false;
                            attackBtn3.Visible = false;
                            attackBtn4.Visible = false;
                            turnEndBtn.Visible = true;
                        }
                    }
                }
                else if (charStats[1] == "3")
                {
                    battleAnnoBox.Text = "You used Rally!";
                    using (StreamReader sr = new StreamReader("__SpearAttack.gif"))
                    {
                        charImageBox.Image = new Bitmap("__SpearAttack.gif");
                    }
                    charActionBox.Text = "Rally Success!";
                    using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                    {
                        writer.Flush();
                        writer.WriteLine(charStatusEffects[0]); // Attack-
                        writer.WriteLine(int.Parse(charStatusEffects[1]) + 2); // Attack+ (Apply Attack+ for 2 turns)
                        writer.WriteLine(charStatusEffects[2]); // Defense-
                        writer.WriteLine(int.Parse(charStatusEffects[3]) + 1); // Defnese+ (Apply Defense+ for 1 turn)
                        writer.WriteLine(charStatusEffects[4]); // Dodge-
                        writer.WriteLine(charStatusEffects[5]); // Dodge+
                        writer.WriteLine(charStatusEffects[6]); // Bleed
                        writer.WriteLine(charStatusEffects[7]); // Stun
                        writer.WriteLine(charStatusEffects[8]); // Parry
                    }
                    using (StreamReader sr = new StreamReader("CharStatusEffects.txt"))
                    {
                        charStatusEffects[0] = sr.ReadLine();
                        charStatusEffects[1] = sr.ReadLine();
                        charStatusEffects[2] = sr.ReadLine();
                        charStatusEffects[3] = sr.ReadLine();
                        charStatusEffects[4] = sr.ReadLine();
                        charStatusEffects[5] = sr.ReadLine();
                        charStatusEffects[6] = sr.ReadLine();
                        charStatusEffects[7] = sr.ReadLine();
                        charStatusEffects[8] = sr.ReadLine();
                    }
                    attackBtn1.Visible = false;
                    attackBtn2.Visible = false;
                    attackBtn3.Visible = false;
                    attackBtn4.Visible = false;
                    turnEndBtn.Visible = true;
                }
            }
            else
            {
                charActionBox.Text = "You are stunned!";
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(int.Parse(charStatusEffects[7]) - 1); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
                attackBtn1.Visible = false;
                attackBtn2.Visible = false;
                attackBtn3.Visible = false;
                attackBtn4.Visible = false;
                turnEndBtn.Visible = true;
            }
            charWriter(charStats, "ClassStats.txt");
            enemyWriter(enemyStats, "EnemyStats.txt");
            if (int.Parse(charStatusEffects[0]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nAttack- (" + charStatusEffects[0] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[0]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nAttack- (" + enemyStatusEffects[0] + " turns)";
            }
            if (int.Parse(charStatusEffects[1]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nAttack+ (" + charStatusEffects[1] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[1]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nAttack+ (" + enemyStatusEffects[1] + " turns)";
            }
            if (int.Parse(charStatusEffects[2]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nDefense- (" + charStatusEffects[2] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[2]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nDefense- (" + enemyStatusEffects[2] + " turns)";
            }
            if (int.Parse(charStatusEffects[3]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nDefense+ (" + charStatusEffects[3] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[3]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nDefense+ (" + enemyStatusEffects[3] + " turns)";
            }
            if (int.Parse(charStatusEffects[4]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nDodge- (" + charStatusEffects[4] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[4]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nDodge- (" + enemyStatusEffects[4] + " turns)";
            }
            if (int.Parse(charStatusEffects[5]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nDodge+ (" + charStatusEffects[5] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[5]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nDodge+ (" + enemyStatusEffects[5] + " turns)";
            }
            if (int.Parse(charStatusEffects[6]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nBleed (" + charStatusEffects[6] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[6]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nBleed (" + enemyStatusEffects[6] + " turns)";
            }
            if (int.Parse(charStatusEffects[7]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nStun (" + charStatusEffects[7] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[7]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nStun (" + enemyStatusEffects[7] + " turns)";
            }
            if (int.Parse(charStatusEffects[8]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nParry (" + charStatusEffects[8] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[8]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nParry (" + enemyStatusEffects[8] + " turns)";
            }
        }

        private void attackBtn4_Click(object sender, EventArgs e)
        {
            /* The majority of the following code in this method is explained
 * in attackBtn1_Click go see more over there for details
 * The only things that are different are the abilities which have special comments to display what they do
 * But mostly everyhting you need is in attackBtn1_Click
 */
            enemyActionBox.Text = "";
            enemyStatusEffectsBox.Text = "";
            charStatusEffectsBox.Text = "";
            if (enemyStats[1] == "1")
            {
                using (StreamReader sr = new StreamReader("__TrollIdleSmall.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__TrollIdleSmall.gif");
                }
            }
            else if (enemyStats[2] == "2")
            {
                using (StreamReader sr = new StreamReader("__CorruptedMageIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__CorruptedMageIdle.gif");
                }
            }
            else if (enemyStats[3] == "3")
            {
                using (StreamReader sr = new StreamReader("__SkeletonIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__SkeletonIdle.gif");
                }
            }
            else if (enemyStats[4] == "4")
            {
                using (StreamReader sr = new StreamReader("__GoblinIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__GoblinIdle.gif");
                }
            }
            else if (enemyStats[5] == "5")
            {
                using (StreamReader sr = new StreamReader("__MimicIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__MimicIdle.gif");
                }
            }
            else if (enemyStats[6] == "6")
            {
                using (StreamReader sr = new StreamReader("__MimicIdle.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__MimicIdle.gif");
                }
            }
            using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
            {
                charStatusEffects[0] = reader.ReadLine(); // Attack-
                charStatusEffects[1] = reader.ReadLine(); // Attack+
                charStatusEffects[2] = reader.ReadLine(); // Defense-
                charStatusEffects[3] = reader.ReadLine(); // Defense+
                charStatusEffects[4] = reader.ReadLine(); // Dodge-
                charStatusEffects[5] = reader.ReadLine(); // Dodge+
                charStatusEffects[6] = reader.ReadLine(); // Bleed
                charStatusEffects[7] = reader.ReadLine(); // Stun
                charStatusEffects[8] = reader.ReadLine(); // Parry
            }
            using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt"))
            {
                enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                enemyStatusEffects[7] = reader.ReadLine(); // Stun
                enemyStatusEffects[8] = reader.ReadLine(); // Parry
            }
            if (int.Parse(charStatusEffects[0]) > 0)
            {
                charStats[9] = (int.Parse(charStats[6]) / 2) + "";
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(int.Parse(charStatusEffects[0]) - 1); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[0]) == 0)
            {
                charStats[9] = charStats[6];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[1]) > 0)
            {
                charStats[9] = (int.Parse(charStats[6]) * 2) + "";
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(int.Parse(charStatusEffects[1]) - 1); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[1]) == 0)
            {
                charStats[9] = charStats[6];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[2]) > 0)
            {
                charStats[10] = (int.Parse(charStats[7]) / 2) + "";
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(int.Parse(charStatusEffects[2]) - 1); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[2]) == 0)
            {
                charStats[10] = charStats[7];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[3]) > 0)
            {
                charStats[10] = (int.Parse(charStats[7]) * 2) + "";
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(int.Parse(charStatusEffects[3]) - 1); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[3]) == 0)
            {
                charStats[10] = charStats[7];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[4]) > 0)
            {
                charStats[11] = (int)Math.Round(int.Parse(charStats[8]) / 1.32) + "";
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(int.Parse(charStatusEffects[4]) - 1); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[4]) == 0)
            {
                charStats[11] = charStats[8];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[5]) > 0)
            {
                charStats[11] = (int)Math.Round(int.Parse(charStats[8]) * 1.32) + "";
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(int.Parse(charStatusEffects[5]) - 1); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[5]) == 0)
            {
                charStats[11] = charStats[8];
                charWriter(charStats, "ClassStats.txt");
            }
            if (int.Parse(charStatusEffects[6]) > 0)
            {
                charStats[5] = (int)Math.Round((int.Parse(charStats[5]) * 0.85)) + ""; // https://bit.ly/3rjaXAx
                charWriter(charStats, "ClassStats.txt");
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(int.Parse(charStatusEffects[6]) - 1); // Bleed
                    writer.WriteLine(charStatusEffects[7]); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(charStatusEffects[6]) == 0)
            {

            }
            if (int.Parse(charStatusEffects[7]) == 0)
            {
                if (charStats[1] == "1")
                {
                    battleAnnoBox.Text = "You used Parry!";
                    using (StreamReader sr = new StreamReader("__WarriorAttack.gif"))
                    {
                        charImageBox.Image = new Bitmap("__WarriorAttack.gif");
                    }
                        int hitChance = rnd.Next(0, 100);
                        if (int.Parse(enemyStats[11]) < hitChance - 20) // Same trick used for Heavy Smash, just reduce hitChance and that means lower accuracy
                        {
                        charActionBox.Text = "Parry Success!";
                          using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                          {
                              writer.Flush();
                              writer.WriteLine(charStatusEffects[0]); // Attack-
                             writer.WriteLine(charStatusEffects[1]); // Attack+
                             writer.WriteLine(charStatusEffects[2]); // Defense-
                             writer.WriteLine(charStatusEffects[3]); // Defnese+
                             writer.WriteLine(charStatusEffects[4]); // Dodge-
                             writer.WriteLine(charStatusEffects[5]); // Dodge+
                             writer.WriteLine(charStatusEffects[6]); // Bleed
                             writer.WriteLine(charStatusEffects[7]); // Stun
                              writer.WriteLine(int.Parse(charStatusEffects[8]) + 1); // Parry (Apply 1 stack of Parry)
                          }
                        using (StreamReader sr = new StreamReader("CharStatusEffects.txt"))
                        {
                            charStatusEffects[0] = sr.ReadLine();
                            charStatusEffects[1] = sr.ReadLine();
                            charStatusEffects[2] = sr.ReadLine();
                            charStatusEffects[3] = sr.ReadLine();
                            charStatusEffects[4] = sr.ReadLine();
                            charStatusEffects[5] = sr.ReadLine();
                            charStatusEffects[6] = sr.ReadLine();
                            charStatusEffects[7] = sr.ReadLine();
                            charStatusEffects[8] = sr.ReadLine();
                        }
                        attackBtn1.Visible = false;
                        attackBtn2.Visible = false;
                        attackBtn3.Visible = false;
                        attackBtn4.Visible = false;
                        turnEndBtn.Visible = true;
                        }
                        else
                        {
                            charActionBox.Text = "Parry Failed!";
                            attackBtn1.Visible = false;
                            attackBtn2.Visible = false;
                            attackBtn3.Visible = false;
                            attackBtn4.Visible = false;
                            turnEndBtn.Visible = true;
                        }
                }
                else if (charStats[1] == "2")
                {
                    battleAnnoBox.Text = "You used Evade!";
                    using (StreamReader sr = new StreamReader("__ArcherAttack.gif"))
                    {
                        charImageBox.Image = new Bitmap("__ArcherAttack.gif");
                    }
                        int hitChance = rnd.Next(0, 100);
                        if (int.Parse(enemyStats[11]) < hitChance)
                        {
                            charActionBox.Text = "Evade Success!";
                            using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                            {
                                writer.Flush();
                                writer.WriteLine(charStatusEffects[0]); // Attack-
                                writer.WriteLine(charStatusEffects[1]); // Attack+
                                writer.WriteLine(charStatusEffects[2]); // Defense-
                                writer.WriteLine(charStatusEffects[3]); // Defnese+
                                writer.WriteLine(charStatusEffects[4]); // Dodge-
                                writer.WriteLine(int.Parse(charStatusEffects[5]) + 2); // Dodge+ (Apply Dodge+ for 2 turns)
                                writer.WriteLine(charStatusEffects[6]); // Bleed
                                writer.WriteLine(charStatusEffects[7]); // Stun
                                writer.WriteLine(charStatusEffects[8]); // Parry
                            }
                        using (StreamReader sr = new StreamReader("CharStatusEffects.txt"))
                        {
                            charStatusEffects[0] = sr.ReadLine();
                            charStatusEffects[1] = sr.ReadLine();
                            charStatusEffects[2] = sr.ReadLine();
                            charStatusEffects[3] = sr.ReadLine();
                            charStatusEffects[4] = sr.ReadLine();
                            charStatusEffects[5] = sr.ReadLine();
                            charStatusEffects[6] = sr.ReadLine();
                            charStatusEffects[7] = sr.ReadLine();
                            charStatusEffects[8] = sr.ReadLine();
                        }
                        attackBtn1.Visible = false;
                            attackBtn2.Visible = false;
                            attackBtn3.Visible = false;
                            attackBtn4.Visible = false;
                            turnEndBtn.Visible = true;
                        }
                        else
                        {
                            enemyActionBox.Text = "Evade Failed!";
                            attackBtn1.Visible = false;
                            attackBtn2.Visible = false;
                            attackBtn3.Visible = false;
                            attackBtn4.Visible = false;
                            turnEndBtn.Visible = true;
                        }
                }
                else if (charStats[1] == "3")
                {
                    battleAnnoBox.Text = "You used Flurry!";
                    using (StreamReader sr = new StreamReader("__SpearAttack.gif"))
                    {
                        charImageBox.Image = new Bitmap("__SpearAttack.gif");
                    }
                    if (int.Parse(enemyStatusEffects[8]) == 0)
                    {
                        int hitChance = rnd.Next(0, 100);
                        if (int.Parse(enemyStats[11]) < hitChance)
                        {
                            charActionBox.Text = "Succesful Hit!";
                            int hitCount = rnd.Next(2, 6);
                            enemyStats[5] = int.Parse(enemyStats[5]) - ((int.Parse(charStats[9])/3)*hitCount) + ""; // Feature of flurry is that it attacks "multiple" times but there's really only 1 check for accuracy
                            enemyHealthBox.Text = "Health: " + enemyStats[5] + "/" + enemyStats[4];
                            if (int.Parse(enemyStats[5]) <= 0) // Coin Gain and EXP gain on kill
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                exitbattlebtn.Visible = true;
                                enemyHealthBox.Text = "Health: 0/" + enemyStats[4];
                                battleAnnoBox.Text = "You defeated the enemy!";
                                int coinsGain = rnd.Next(50, 100);
                                inventory[0] = (int.Parse(inventory[0]) + coinsGain) + "";
                                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(inventory[0]); // Coins
                                    writer.WriteLine(inventory[1]); // Health Pots
                                    writer.WriteLine(inventory[2]); // Dagger
                                    writer.WriteLine(inventory[3]); // Strength Potion
                                }
                                int expGain = rnd.Next(50, 100);
                                charStats[3] = (int.Parse(charStats[3]) + expGain) + "";
                                if (int.Parse(charStats[3]) >= 100) // Check if you have enough EXP to level up
                                {
                                    charStats[2] = (int.Parse(charStats[2]) + 1) + "";
                                    charStats[3] = (int.Parse(charStats[3]) - 100) + "";
                                    charStats[4] = (int.Parse(charStats[4]) + 5) + "";
                                    charStats[5] = (int.Parse(charStats[5]) + 5) + "";
                                    charStats[6] = (int.Parse(charStats[6]) + 2) + "";
                                    charStats[7] = (int.Parse(charStats[7]) + 2) + "";
                                    charStats[9] = (int.Parse(charStats[9]) + 2) + "";
                                    charStats[10] = (int.Parse(charStats[10]) + 2) + "";
                                    charWriter(charStats, "ClassStats.txt");
                                }
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                            }
                            else
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                turnEndBtn.Visible = true;
                            }
                            enemyWriter(enemyStats, "EnemyStats.txt");
                        }
                        else
                        {
                            enemyActionBox.Text = "Enemy Dodged!";
                            momentum = 1;
                            attackBtn1.Visible = false;
                            attackBtn2.Visible = false;
                            attackBtn3.Visible = false;
                            attackBtn4.Visible = false;
                            turnEndBtn.Visible = true;
                        }
                    }
                    else
                    {
                        enemyActionBox.Text = "Enemy Parried!";
                        charStats[5] = (int.Parse(charStats[5]) - (int.Parse(enemyStats[9]) / 2)) + "";
                        using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                        {
                            writer.Flush();
                            writer.WriteLine(enemyStatusEffects[0]);
                            writer.WriteLine(enemyStatusEffects[1]);
                            writer.WriteLine(enemyStatusEffects[2]);
                            writer.WriteLine(enemyStatusEffects[3]);
                            writer.WriteLine(enemyStatusEffects[4]);
                            writer.WriteLine(enemyStatusEffects[5]);
                            writer.WriteLine(enemyStatusEffects[6]);
                            writer.WriteLine(enemyStatusEffects[7]);
                            writer.WriteLine(int.Parse(enemyStatusEffects[8]) - 1);
                        }
                        using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt"))
                        {
                            enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                            enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                            enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                            enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                            enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                            enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                            enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                            enemyStatusEffects[7] = reader.ReadLine(); // Stun
                            enemyStatusEffects[8] = reader.ReadLine(); // Parry
                        }
                        charWriter(charStats, "ClassStats.txt");
                        if (int.Parse(charStats[5]) <= 0)
                        {
                            charHealthBox.Text = "Health 0/" + charStats[4];
                            MessageBox.Show("You Died! :(");
                            Application.Exit();
                        }
                        else
                        {
                            attackBtn1.Visible = false;
                            attackBtn2.Visible = false;
                            attackBtn3.Visible = false;
                            attackBtn4.Visible = false;
                            turnEndBtn.Visible = true;
                        }
                    }
                }
            }
            else
            {
                charActionBox.Text = "You are stunned!";
                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(charStatusEffects[0]); // Attack-
                    writer.WriteLine(charStatusEffects[1]); // Attack+
                    writer.WriteLine(charStatusEffects[2]); // Defense-
                    writer.WriteLine(charStatusEffects[3]); // Defnese+
                    writer.WriteLine(charStatusEffects[4]); // Dodge-
                    writer.WriteLine(charStatusEffects[5]); // Dodge+
                    writer.WriteLine(charStatusEffects[6]); // Bleed
                    writer.WriteLine(int.Parse(charStatusEffects[7]) - 1); // Stun
                    writer.WriteLine(charStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
                {
                    charStatusEffects[0] = reader.ReadLine(); // Attack-
                    charStatusEffects[1] = reader.ReadLine(); // Attack+
                    charStatusEffects[2] = reader.ReadLine(); // Defense-
                    charStatusEffects[3] = reader.ReadLine(); // Defense+
                    charStatusEffects[4] = reader.ReadLine(); // Dodge-
                    charStatusEffects[5] = reader.ReadLine(); // Dodge+
                    charStatusEffects[6] = reader.ReadLine(); // Bleed
                    charStatusEffects[7] = reader.ReadLine(); // Stun
                    charStatusEffects[8] = reader.ReadLine(); // Parry
                }
                attackBtn1.Visible = false;
                attackBtn2.Visible = false;
                attackBtn3.Visible = false;
                attackBtn4.Visible = false;
                turnEndBtn.Visible = true;
            }
            charWriter(charStats, "ClassStats.txt");
            // enemyWriter(enemyStats, "EnemyStats.txt");
            if (int.Parse(charStatusEffects[0]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nAttack- (" + charStatusEffects[0] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[0]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nAttack- (" + enemyStatusEffects[0] + " turns)";
            }
            if (int.Parse(charStatusEffects[1]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nAttack+ (" + charStatusEffects[1] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[1]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nAttack+ (" + enemyStatusEffects[1] + " turns)";
            }
            if (int.Parse(charStatusEffects[2]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nDefense- (" + charStatusEffects[2] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[2]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nDefense- (" + enemyStatusEffects[2] + " turns)";
            }
            if (int.Parse(charStatusEffects[3]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nDefense+ (" + charStatusEffects[3] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[3]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nDefense+ (" + enemyStatusEffects[3] + " turns)";
            }
            if (int.Parse(charStatusEffects[4]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nDodge- (" + charStatusEffects[4] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[4]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nDodge- (" + enemyStatusEffects[4] + " turns)";
            }
            if (int.Parse(charStatusEffects[5]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nDodge+ (" + charStatusEffects[5] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[5]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nDodge+ (" + enemyStatusEffects[5] + " turns)";
            }
            if (int.Parse(charStatusEffects[6]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nBleed (" + charStatusEffects[6] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[6]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nBleed (" + enemyStatusEffects[6] + " turns)";
            }
            if (int.Parse(charStatusEffects[7]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nStun (" + charStatusEffects[7] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[7]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nStun (" + enemyStatusEffects[7] + " turns)";
            }
            if (int.Parse(charStatusEffects[8]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nParry (" + charStatusEffects[8] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[8]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nParry (" + enemyStatusEffects[8] + " turns)";
            }
        }

        private void turnEndBtn_Click(object sender, EventArgs e)
        {
            /* The majority of the following code in this method is explained
 * in attackBtn1_Click go see more over there for details
 * The only things that are different are that instead of checking the player's status effects it checks the
 * enemy's status effects and applies them. Also enemies have special moves
 */
            turnEndBtn.Visible = false; // Pass the enemy's turn and allows to use player abilities again
            attackBtn1.Visible = true;
            attackBtn2.Visible = true;
            attackBtn3.Visible = true;
            attackBtn4.Visible = true;
            enemyStatusEffectsBox.Text = "";
            charActionBox.Text = "";
            if (charStats[1] == "1")
            {
                using (StreamReader sr = new StreamReader("__WarriorIdleBig.gif"))
                {
                    charImageBox.Image = new Bitmap("__WarriorIdleBig.gif");
                }
            }
            if (charStats[1] == "2")
            {
                using (StreamReader sr = new StreamReader("__ArcherIdleBig.gif"))
                {
                    charImageBox.Image = new Bitmap("__ArcherIdleBig.gif");
                }
            }
            if (charStats[1] == "3")
            {
                using (StreamReader sr = new StreamReader("__SpearIdleBig.gif"))
                {
                    charImageBox.Image = new Bitmap("__SpearIdleBig.gif");
                }
            }
            if (enemyStats[1] == "1")
            {
                using (StreamReader sr = new StreamReader("__TrollAttackSmall.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__TrollAttackSmall.gif");
                }
            }
            if (enemyStats[2] == "2")
            {
                using (StreamReader sr = new StreamReader("__CorruptedMageAttack.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__CorruptedMageAttack.gif");
                }
            }
            if (enemyStats[3] == "3")
            {
                using (StreamReader sr = new StreamReader("__SkeletonAttack.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__SkeletonAttack.gif");
                }
            }
            if (enemyStats[4] == "4")
            {
                using (StreamReader sr = new StreamReader("__GoblinAttack.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__GoblinAttack.gif");
                }
            }
            if (enemyStats[5] == "5")
            {
                using (StreamReader sr = new StreamReader("__MimicRun.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__MimicRun.gif");
                }
            }
            if (enemyStats[6] == "6")
            {
                using (StreamReader sr = new StreamReader("__MimicAttack.gif"))
                {
                    enemyImageBox.Image = new Bitmap("__MimicAttack.gif");
                }
            }
            using (StreamReader reader = new StreamReader("CharStatusEffects.txt"))
            {
                charStatusEffects[0] = reader.ReadLine(); // Attack-
                charStatusEffects[1] = reader.ReadLine(); // Attack+
                charStatusEffects[2] = reader.ReadLine(); // Defense-
                charStatusEffects[3] = reader.ReadLine(); // Defense+
                charStatusEffects[4] = reader.ReadLine(); // Dodge-
                charStatusEffects[5] = reader.ReadLine(); // Dodge+
                charStatusEffects[6] = reader.ReadLine(); // Bleed
                charStatusEffects[7] = reader.ReadLine(); // Stun
                charStatusEffects[8] = reader.ReadLine(); // Parry
            }
            using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt"))
            {
                enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                enemyStatusEffects[7] = reader.ReadLine(); // Stun
                enemyStatusEffects[8] = reader.ReadLine(); // Parry
            }
            if (int.Parse(enemyStatusEffects[0]) > 0)
            {
                enemyStats[9] = (int.Parse(enemyStats[6]) / 2) + "";
                enemyWriter(enemyStats, "EnemyStats.txt");
                using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(int.Parse(enemyStatusEffects[0]) - 1); // Attack-
                    writer.WriteLine(enemyStatusEffects[1]); // Attack+
                    writer.WriteLine(enemyStatusEffects[2]); // Defense-
                    writer.WriteLine(enemyStatusEffects[3]); // Defnese+
                    writer.WriteLine(enemyStatusEffects[4]); // Dodge-
                    writer.WriteLine(enemyStatusEffects[5]); // Dodge+
                    writer.WriteLine(enemyStatusEffects[6]); // Bleed
                    writer.WriteLine(enemyStatusEffects[7]); // Stun
                    writer.WriteLine(enemyStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt"))
                {
                    enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                    enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                    enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                    enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                    enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                    enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                    enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                    enemyStatusEffects[7] = reader.ReadLine(); // Stun
                    enemyStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(enemyStatusEffects[0]) == 0)
            {
                enemyStats[9] = enemyStats[6];
                enemyWriter(enemyStats, "EnemyStats.txt");
            }
            if (int.Parse(enemyStatusEffects[1]) > 0)
            {
                enemyStats[9] = (int.Parse(enemyStats[6]) * 2) + "";
                using (StreamWriter writer = new StreamWriter("EnemyStats.txt"))
                    enemyWriter(enemyStats, "EnemyStats.txt");
                using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(enemyStatusEffects[0]); // Attack-
                    writer.WriteLine(int.Parse(enemyStatusEffects[1]) - 1); // Attack+
                    writer.WriteLine(enemyStatusEffects[2]); // Defense-
                    writer.WriteLine(enemyStatusEffects[3]); // Defnese+
                    writer.WriteLine(enemyStatusEffects[4]); // Dodge-
                    writer.WriteLine(enemyStatusEffects[5]); // Dodge+
                    writer.WriteLine(enemyStatusEffects[6]); // Bleed
                    writer.WriteLine(enemyStatusEffects[7]); // Stun
                    writer.WriteLine(enemyStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt"))
                {
                    enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                    enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                    enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                    enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                    enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                    enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                    enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                    enemyStatusEffects[7] = reader.ReadLine(); // Stun
                    enemyStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(enemyStatusEffects[1]) == 0)
            {
                enemyStats[9] = enemyStats[6];
                enemyWriter(enemyStats, "EnemyStats.txt");
            }
            if (int.Parse(enemyStatusEffects[2]) > 0)
            {
                enemyStats[10] = (int.Parse(enemyStats[7]) / 2) + "";
                enemyWriter(enemyStats, "EnemyStats.txt");
                using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(enemyStatusEffects[0]); // Attack-
                    writer.WriteLine(enemyStatusEffects[1]); // Attack+
                    writer.WriteLine(int.Parse(enemyStatusEffects[2]) - 1); // Defense-
                    writer.WriteLine(enemyStatusEffects[3]); // Defnese+
                    writer.WriteLine(enemyStatusEffects[4]); // Dodge-
                    writer.WriteLine(enemyStatusEffects[5]); // Dodge+
                    writer.WriteLine(enemyStatusEffects[6]); // Bleed
                    writer.WriteLine(enemyStatusEffects[7]); // Stun
                    writer.WriteLine(enemyStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt"))
                {
                    enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                    enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                    enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                    enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                    enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                    enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                    enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                    enemyStatusEffects[7] = reader.ReadLine(); // Stun
                    enemyStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(enemyStatusEffects[2]) == 0)
            {
                enemyStats[10] = enemyStats[7];
                enemyWriter(enemyStats, "EnemyStats.txt");
            }
            if (int.Parse(enemyStatusEffects[3]) > 0)
            {
                enemyStats[10] = (int.Parse(enemyStats[7]) * 2) + "";
                enemyWriter(enemyStats, "EnemyStats.txt");
                using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(enemyStatusEffects[0]); // Attack-
                    writer.WriteLine(enemyStatusEffects[1]); // Attack+
                    writer.WriteLine(enemyStatusEffects[2]); // Defense-
                    writer.WriteLine(int.Parse(enemyStatusEffects[3]) - 1); // Defnese+
                    writer.WriteLine(enemyStatusEffects[4]); // Dodge-
                    writer.WriteLine(enemyStatusEffects[5]); // Dodge+
                    writer.WriteLine(enemyStatusEffects[6]); // Bleed
                    writer.WriteLine(enemyStatusEffects[7]); // Stun
                    writer.WriteLine(enemyStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt"))
                {
                    enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                    enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                    enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                    enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                    enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                    enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                    enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                    enemyStatusEffects[7] = reader.ReadLine(); // Stun
                    enemyStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(enemyStatusEffects[3]) == 0)
            {
                enemyStats[10] = enemyStats[7];
                enemyWriter(enemyStats, "EnemyStats.txt");
            }
            if (int.Parse(enemyStatusEffects[4]) > 0)
            {
                enemyStats[11] = (int)Math.Round(int.Parse(enemyStats[8]) / 1.32) + "";
                enemyWriter(enemyStats, "EnemyStats.txt");
                using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(enemyStatusEffects[0]); // Attack-
                    writer.WriteLine(enemyStatusEffects[1]); // Attack+
                    writer.WriteLine(enemyStatusEffects[2]); // Defense-
                    writer.WriteLine(enemyStatusEffects[3]); // Defnese+
                    writer.WriteLine(int.Parse(enemyStatusEffects[4]) - 1); // Dodge-
                    writer.WriteLine(enemyStatusEffects[5]); // Dodge+
                    writer.WriteLine(enemyStatusEffects[6]); // Bleed
                    writer.WriteLine(enemyStatusEffects[7]); // Stun
                    writer.WriteLine(enemyStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt"))
                {
                    enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                    enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                    enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                    enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                    enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                    enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                    enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                    enemyStatusEffects[7] = reader.ReadLine(); // Stun
                    enemyStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(enemyStatusEffects[4]) == 0)
            {
                enemyStats[11] = enemyStats[8];
                enemyWriter(enemyStats, "EnemyStats.txt");
            }
            if (int.Parse(enemyStatusEffects[5]) > 0)
            {
                enemyStats[11] = (int)Math.Round(int.Parse(enemyStats[8])*1.32) + "";
                enemyWriter(enemyStats, "EnemyStats.txt");
                using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(enemyStatusEffects[0]); // Attack-
                    writer.WriteLine(enemyStatusEffects[1]); // Attack+
                    writer.WriteLine(enemyStatusEffects[2]); // Defense-
                    writer.WriteLine(enemyStatusEffects[3]); // Defnese+
                    writer.WriteLine(enemyStatusEffects[4]); // Dodge-
                    writer.WriteLine(int.Parse(enemyStatusEffects[5]) - 1); // Dodge+
                    writer.WriteLine(enemyStatusEffects[6]); // Bleed
                    writer.WriteLine(enemyStatusEffects[7]); // Stun
                    writer.WriteLine(enemyStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt"))
                {
                    enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                    enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                    enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                    enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                    enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                    enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                    enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                    enemyStatusEffects[7] = reader.ReadLine(); // Stun
                    enemyStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(enemyStatusEffects[5]) == 0)
            {
                enemyStats[11] = enemyStats[8];
                enemyWriter(enemyStats, "EnemyStats.txt");
            }
            if (int.Parse(enemyStatusEffects[6]) > 0)
            {
                enemyStats[5] = (int)Math.Round((int.Parse(enemyStats[5]) * 0.85)) + ""; // https://bit.ly/3rjaXAx
                enemyWriter(enemyStats, "EnemyStats.txt");
                using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(enemyStatusEffects[0]); // Attack-
                    writer.WriteLine(enemyStatusEffects[1]); // Attack+
                    writer.WriteLine(enemyStatusEffects[2]); // Defense-
                    writer.WriteLine(enemyStatusEffects[3]); // Defnese+
                    writer.WriteLine(enemyStatusEffects[4]); // Dodge-
                    writer.WriteLine(enemyStatusEffects[5]); // Dodge+
                    writer.WriteLine(int.Parse(enemyStatusEffects[6]) - 1); // Bleed
                    writer.WriteLine(enemyStatusEffects[7]); // Stun
                    writer.WriteLine(enemyStatusEffects[8]); // Parry
                }
                using (StreamReader reader = new StreamReader("EnemyStatusEffects.txt"))
                {
                    enemyStatusEffects[0] = reader.ReadLine(); // Attack-
                    enemyStatusEffects[1] = reader.ReadLine(); // Attack+
                    enemyStatusEffects[2] = reader.ReadLine(); // Defense-
                    enemyStatusEffects[3] = reader.ReadLine(); // Defense+
                    enemyStatusEffects[4] = reader.ReadLine(); // Dodge-
                    enemyStatusEffects[5] = reader.ReadLine(); // Dodge+
                    enemyStatusEffects[6] = reader.ReadLine(); // Bleed
                    enemyStatusEffects[7] = reader.ReadLine(); // Stun
                    enemyStatusEffects[8] = reader.ReadLine(); // Parry
                }
            }
            else if (int.Parse(enemyStatusEffects[6]) == 0)
            {

            }
            if (int.Parse(enemyStatusEffects[7]) == 0)
            {
                int attackChoice = rnd.Next(1, 3);
                if (attackChoice == 1)
                {
                    if (enemyStats[1] == "1")
                    {
                        battleAnnoBox.Text = "Armored Troll used Rock Throw!";
                        if (int.Parse(charStatusEffects[8]) == 0)
                        {
                            int hitChance = rnd.Next(1, 100);
                            if (hitChance > int.Parse(charStats[11]))
                            {
                                enemyActionBox.Text = "Succesful Hit!";
                                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(charStatusEffects[0]);
                                    writer.WriteLine(charStatusEffects[1]);
                                    writer.WriteLine(charStatusEffects[2]);
                                    writer.WriteLine(charStatusEffects[3]);
                                    writer.WriteLine(charStatusEffects[4]);
                                    writer.WriteLine(charStatusEffects[5]);
                                    writer.WriteLine(charStatusEffects[6]);
                                    writer.WriteLine(int.Parse(charStatusEffects[7]) + 1); // (Applies Stun to the character for 1 turn)
                                    writer.WriteLine(charStatusEffects[8]);
                                }
                                using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(enemyStatusEffects[0]); // Attack-
                                    writer.WriteLine(int.Parse(enemyStatusEffects[1]) + 1); // Attack+ (Applies Attack+ to the troll for 1 turn)
                                    writer.WriteLine(enemyStatusEffects[2]); // Defense-
                                    writer.WriteLine(enemyStatusEffects[3]); // Defnese+
                                    writer.WriteLine(enemyStatusEffects[4]); // Dodge-
                                    writer.WriteLine(enemyStatusEffects[5]); // Dodge+
                                    writer.WriteLine(enemyStatusEffects[6]); // Bleed
                                    writer.WriteLine(enemyStatusEffects[7]); // Stun
                                    writer.WriteLine(enemyStatusEffects[8]); // Parry
                                }
                            }
                            else
                            {
                                charActionBox.Text = "You Dodged!";
                            }
                        }
                        else
                        {
                            charActionBox.Text = "You Parried!";
                            enemyStats[5] = (int.Parse(enemyStats[5]) - (int.Parse(charStats[9]) / 2)) + "";
                            enemyHealthBox.Text = "Health: " + enemyStats[5] + "/" + enemyStats[4]; // You can kill with parry so we need a check to see if we did kill then apply stats boosts directly
                            if (int.Parse(enemyStats[5]) <= 0) // Coin Gain and EXP gain on kill
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                exitbattlebtn.Visible = true;
                                battleAnnoBox.Text = "You defeated the enemy!";
                                enemyHealthBox.Text = "Health: 0/" + enemyStats[4];
                                int coinsGain = rnd.Next(50, 100);
                                inventory[0] = (int.Parse(inventory[0]) + coinsGain) + "";
                                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(inventory[0]);
                                    writer.WriteLine(inventory[1]);
                                    writer.WriteLine(inventory[2]);
                                    writer.WriteLine(inventory[3]);
                                }
                                int expGain = rnd.Next(50, 100);
                                charStats[3] = (int.Parse(charStats[3]) + expGain) + "";
                                if (int.Parse(charStats[3]) >= 100) // Check if you have enough EXP to level up
                                {
                                    charStats[2] = (int.Parse(charStats[2]) + 1) + "";
                                    charStats[3] = (int.Parse(charStats[3]) - 100) + "";
                                    charStats[4] = (int.Parse(charStats[4]) + 5) + "";
                                    charStats[5] = (int.Parse(charStats[5]) + 5) + "";
                                    charStats[6] = (int.Parse(charStats[6]) + 2) + "";
                                    charStats[7] = (int.Parse(charStats[7]) + 2) + "";
                                    charStats[9] = (int.Parse(charStats[9]) + 2) + "";
                                    charStats[10] = (int.Parse(charStats[10]) + 2) + "";
                                    charWriter(charStats, "ClassStats.txt");
                                }
                            }
                            using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                            {
                                writer.Flush();
                                writer.WriteLine(charStatusEffects[0]);
                                writer.WriteLine(charStatusEffects[1]);
                                writer.WriteLine(charStatusEffects[2]);
                                writer.WriteLine(charStatusEffects[3]);
                                writer.WriteLine(charStatusEffects[4]);
                                writer.WriteLine(charStatusEffects[5]);
                                writer.WriteLine(charStatusEffects[6]);
                                writer.WriteLine(charStatusEffects[7]);
                                writer.WriteLine(int.Parse(charStatusEffects[8]) - 1);
                            }
                        }
                    }
                    else if (enemyStats[1] == "2")
                    {
                        battleAnnoBox.Text = "Corrupted Mage used Petrify!";
                        if (int.Parse(charStatusEffects[8]) == 0)
                        {
                            int hitChance = rnd.Next(1, 100);
                            if (hitChance - 45 > int.Parse(charStats[11])) // Same trick as before just subtract from hitChance to lower the accuracy of the move
                            {
                                enemyActionBox.Text = "Succesful Hit!";
                                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(charStatusEffects[0]);
                                    writer.WriteLine(charStatusEffects[1]);
                                    writer.WriteLine(charStatusEffects[2]);
                                    writer.WriteLine(charStatusEffects[3]);
                                    writer.WriteLine(charStatusEffects[4]);
                                    writer.WriteLine(charStatusEffects[5]);
                                    writer.WriteLine(charStatusEffects[6]);
                                    writer.WriteLine(int.Parse(charStatusEffects[7]) + 2); // (Applies 2 turns of stun to the player)
                                    writer.WriteLine(charStatusEffects[8]);
                                }
                            }
                            else
                            {
                                charActionBox.Text = "You Dodged!";
                            }
                        }
                        else
                        {
                            charActionBox.Text = "You Parried!";
                            enemyStats[5] = (int.Parse(enemyStats[5]) - (int.Parse(charStats[9]) / 2)) + "";
                            enemyHealthBox.Text = "Health: " + enemyStats[5] + "/" + enemyStats[4];
                            if (int.Parse(enemyStats[5]) <= 0) // Coin Gain and EXP gain on kill
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                exitbattlebtn.Visible = true;
                                battleAnnoBox.Text = "You defeated the enemy!";
                                enemyHealthBox.Text = "Health: 0/" + enemyStats[4];
                                int coinsGain = rnd.Next(50, 100);
                                inventory[0] = (int.Parse(inventory[0]) + coinsGain) + "";
                                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(inventory[0]);
                                    writer.WriteLine(inventory[1]);
                                    writer.WriteLine(inventory[2]);
                                    writer.WriteLine(inventory[3]);
                                }
                                int expGain = rnd.Next(50, 100);
                                charStats[3] = (int.Parse(charStats[3]) + expGain) + "";
                                if (int.Parse(charStats[3]) >= 100) // Check if you have enough EXP to level up
                                {
                                    charStats[2] = (int.Parse(charStats[2]) + 1) + "";
                                    charStats[3] = (int.Parse(charStats[3]) - 100) + "";
                                    charStats[4] = (int.Parse(charStats[4]) + 5) + "";
                                    charStats[5] = (int.Parse(charStats[5]) + 5) + "";
                                    charStats[6] = (int.Parse(charStats[6]) + 2) + "";
                                    charStats[7] = (int.Parse(charStats[7]) + 2) + "";
                                    charStats[9] = (int.Parse(charStats[9]) + 2) + "";
                                    charStats[10] = (int.Parse(charStats[10]) + 2) + "";
                                    charWriter(charStats, "ClassStats.txt");
                                }
                            }
                            using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                            {
                                writer.Flush();
                                writer.WriteLine(charStatusEffects[0]);
                                writer.WriteLine(charStatusEffects[1]);
                                writer.WriteLine(charStatusEffects[2]);
                                writer.WriteLine(charStatusEffects[3]);
                                writer.WriteLine(charStatusEffects[4]);
                                writer.WriteLine(charStatusEffects[5]);
                                writer.WriteLine(charStatusEffects[6]);
                                writer.WriteLine(charStatusEffects[7]);
                                writer.WriteLine(int.Parse(charStatusEffects[8]) - 1);
                            }
                        }
                    }
                    else if (enemyStats[1] == "3")
                    {
                        battleAnnoBox.Text = "Skeleton Warrior used Parry!";
                        int hitChance = rnd.Next(1, 100);
                        if (hitChance > int.Parse(charStats[11]))
                        {
                            enemyActionBox.Text = "Parry Success!";
                            using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                            {
                                writer.Flush();
                                writer.WriteLine(enemyStatusEffects[0]); // Attack-
                                writer.WriteLine(enemyStatusEffects[1]); // Attack+
                                writer.WriteLine(enemyStatusEffects[2]); // Defense-
                                writer.WriteLine(enemyStatusEffects[3]); // Defnese+
                                writer.WriteLine(enemyStatusEffects[4]); // Dodge-
                                writer.WriteLine(enemyStatusEffects[5]); // Dodge+
                                writer.WriteLine(enemyStatusEffects[6]); // Bleed
                                writer.WriteLine(enemyStatusEffects[7]); // Stun
                                writer.WriteLine(int.Parse(enemyStatusEffects[8]) + 1); // Parry (Applies 1 stack of Parry to the skeleton)
                            }
                        }
                        else
                        {
                            enemyActionBox.Text = "Parry Failed!";
                        }
                    }
                    else if (enemyStats[1] == "4")
                    {
                        battleAnnoBox.Text = "Sneaky Goblin used Evade!";
                        int hitChance = rnd.Next(1, 100);
                        if (hitChance > int.Parse(charStats[11]))
                        {
                            enemyActionBox.Text = "Evade Success!";
                            using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                            {
                                writer.Flush();
                                writer.WriteLine(enemyStatusEffects[0]); // Attack-
                                writer.WriteLine(enemyStatusEffects[1]); // Attack+
                                writer.WriteLine(enemyStatusEffects[2]); // Defense-
                                writer.WriteLine(enemyStatusEffects[3]); // Defnese+
                                writer.WriteLine(enemyStatusEffects[4]); // Dodge-
                                writer.WriteLine(int.Parse(enemyStatusEffects[5]) + 2); // Dodge+ (Applies 2 turns of evade to the goblin)
                                writer.WriteLine(enemyStatusEffects[6]); // Bleed
                                writer.WriteLine(enemyStatusEffects[7]); // Stun
                                writer.WriteLine(enemyStatusEffects[8]); // Parry
                            }
                        }
                        else
                        {
                            enemyActionBox.Text = "Evade Failed!";
                        }
                    }
                    else if (enemyStats[1] == "5")
                    {
                        battleAnnoBox.Text = "Chest? used wobble!";
                        enemyActionBox.Text = "It did nothing!";
                    }
                    else if (enemyStats[1] == "6")
                    {
                        battleAnnoBox.Text = "Chomp";
                        if (int.Parse(charStatusEffects[8]) == 0)
                        {
                            int hitChance = rnd.Next(1, 100);
                            if (hitChance > int.Parse(charStats[11]))
                            {
                                enemyActionBox.Text = "Succesful Hit!";
                                charStats[5] = int.Parse(charStats[5]) - (int.Parse(enemyStats[9]) - int.Parse(charStats[10])) + "";
                                charHealthBox.Text = "Health: " + charStats[5] + "/" + charStats[4];
                                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(charStatusEffects[0]);
                                    writer.WriteLine(charStatusEffects[1]);
                                    writer.WriteLine(charStatusEffects[2]);
                                    writer.WriteLine(charStatusEffects[3]);
                                    writer.WriteLine(charStatusEffects[4]);
                                    writer.WriteLine(charStatusEffects[5]);
                                    writer.WriteLine(int.Parse(charStatusEffects[6]) + 1); // (Applies 1 turn of bleed to the player)
                                    writer.WriteLine(charStatusEffects[7]);
                                    writer.WriteLine(charStatusEffects[8]);
                                }
                                if (int.Parse(charStats[5]) <= 0)
                                {
                                    charHealthBox.Text = "Health 0/" + charStats[4];
                                    MessageBox.Show("You Died! :(");
                                    Application.Exit();
                                }
                                charWriter(charStats, "ClassStats.txt");
                            }
                            else
                            {
                                charActionBox.Text = "You Dodged!";
                            }
                        }
                        else
                        {
                            charActionBox.Text = "You Parried!";
                            enemyStats[5] = (int.Parse(enemyStats[5]) - (int.Parse(charStats[9]) / 2)) + "";
                            enemyHealthBox.Text = "Health: " + enemyStats[5] + "/" + enemyStats[4];
                            if (int.Parse(enemyStats[5]) <= 0) // Coin Gain and EXP gain on kill
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                exitbattlebtn.Visible = true;
                                battleAnnoBox.Text = "You defeated the enemy!";
                                enemyHealthBox.Text = "Health: 0/" + enemyStats[4];
                                int coinsGain = rnd.Next(50, 100);
                                inventory[0] = (int.Parse(inventory[0]) + coinsGain) + "";
                                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(inventory[0]);
                                    writer.WriteLine(inventory[1]);
                                    writer.WriteLine(inventory[2]);
                                    writer.WriteLine(inventory[3]);
                                }
                                int expGain = rnd.Next(50, 100);
                                charStats[3] = (int.Parse(charStats[3]) + expGain) + "";
                                if (int.Parse(charStats[3]) >= 100) // Check if you have enough EXP to level up
                                {
                                    charStats[2] = (int.Parse(charStats[2]) + 1) + "";
                                    charStats[3] = (int.Parse(charStats[3]) - 100) + "";
                                    charStats[4] = (int.Parse(charStats[4]) + 5) + "";
                                    charStats[5] = (int.Parse(charStats[5]) + 5) + "";
                                    charStats[6] = (int.Parse(charStats[6]) + 2) + "";
                                    charStats[7] = (int.Parse(charStats[7]) + 2) + "";
                                    charStats[9] = (int.Parse(charStats[9]) + 2) + "";
                                    charStats[10] = (int.Parse(charStats[10]) + 2) + "";
                                    charWriter(charStats, "ClassStats.txt");
                                }
                            }
                            using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                            {
                                writer.Flush();
                                writer.WriteLine(charStatusEffects[0]);
                                writer.WriteLine(charStatusEffects[1]);
                                writer.WriteLine(charStatusEffects[2]);
                                writer.WriteLine(charStatusEffects[3]);
                                writer.WriteLine(charStatusEffects[4]);
                                writer.WriteLine(charStatusEffects[5]);
                                writer.WriteLine(charStatusEffects[6]);
                                writer.WriteLine(charStatusEffects[7]);
                                writer.WriteLine(int.Parse(charStatusEffects[8]) - 1);
                            }
                        }
                    }
                }
                if (attackChoice == 2)
                {
                    if (enemyStats[1] == "1")
                    {
                        battleAnnoBox.Text = "Armored Troll used Heavy Swipe!";
                        if (int.Parse(charStatusEffects[8]) == 0)
                        {
                            int hitChance = rnd.Next(1, 100);
                            if (hitChance > int.Parse(charStats[11]))
                            {
                                enemyActionBox.Text = "Succesful Hit!";
                                charStats[5] = (int.Parse(charStats[5]) - (int.Parse(enemyStats[9]) - int.Parse(charStats[10]))) + "";
                                charHealthBox.Text = "Health: " + charStats[5] + "/" + charStats[4];
                                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(charStatusEffects[0]);
                                    writer.WriteLine(charStatusEffects[1]);
                                    writer.WriteLine(int.Parse(charStatusEffects[2]) + 2); // (Applies 2 turns of Defense- to the player)
                                    writer.WriteLine(charStatusEffects[3]);
                                    writer.WriteLine(charStatusEffects[4]);
                                    writer.WriteLine(charStatusEffects[5]);
                                    writer.WriteLine(charStatusEffects[6]);
                                    writer.WriteLine(charStatusEffects[7]);
                                    writer.WriteLine(charStatusEffects[8]);
                                }
                                if (int.Parse(charStats[5]) <= 0)
                                {
                                    charHealthBox.Text = "Health 0/" + charStats[4];
                                    MessageBox.Show("You Died! :(");
                                    Application.Exit();
                                }
                                charWriter(charStats, "ClassStats.txt");
                            }
                            else
                            {
                                charActionBox.Text = "You Dodged!";
                            }
                        }
                        else
                        {
                            charActionBox.Text = "You Parried!";
                            enemyStats[5] = (int.Parse(enemyStats[5]) - (int.Parse(charStats[9]) / 2)) + "";
                            enemyHealthBox.Text = "Health: " + enemyStats[5] + "/" + enemyStats[4];
                            if (int.Parse(enemyStats[5]) <= 0) // Coin Gain and EXP gain on kill
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                exitbattlebtn.Visible = true;
                                battleAnnoBox.Text = "You defeated the enemy!";
                                enemyHealthBox.Text = "Health: 0/" + enemyStats[4];
                                int coinsGain = rnd.Next(50, 100);
                                inventory[0] = (int.Parse(inventory[0]) + coinsGain) + "";
                                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(inventory[0]);
                                    writer.WriteLine(inventory[1]);
                                    writer.WriteLine(inventory[2]);
                                    writer.WriteLine(inventory[3]);
                                }
                                int expGain = rnd.Next(50, 100);
                                charStats[3] = (int.Parse(charStats[3]) + expGain) + "";
                                if (int.Parse(charStats[3]) >= 100) // Check if you have enough EXP to level up
                                {
                                    charStats[2] = (int.Parse(charStats[2]) + 1) + "";
                                    charStats[3] = (int.Parse(charStats[3]) - 100) + "";
                                    charStats[4] = (int.Parse(charStats[4]) + 5) + "";
                                    charStats[5] = (int.Parse(charStats[5]) + 5) + "";
                                    charStats[6] = (int.Parse(charStats[6]) + 2) + "";
                                    charStats[7] = (int.Parse(charStats[7]) + 2) + "";
                                    charStats[9] = (int.Parse(charStats[9]) + 2) + "";
                                    charStats[10] = (int.Parse(charStats[10]) + 2) + "";
                                    charWriter(charStats, "ClassStats.txt");
                                }
                            }
                            using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                            {
                                writer.Flush();
                                writer.WriteLine(charStatusEffects[0]);
                                writer.WriteLine(charStatusEffects[1]);
                                writer.WriteLine(charStatusEffects[2]);
                                writer.WriteLine(charStatusEffects[3]);
                                writer.WriteLine(charStatusEffects[4]);
                                writer.WriteLine(charStatusEffects[5]);
                                writer.WriteLine(charStatusEffects[6]);
                                writer.WriteLine(charStatusEffects[7]);
                                writer.WriteLine(int.Parse(charStatusEffects[8]) - 1);
                            }
                        }
                    }
                    else if (enemyStats[1] == "2")
                    {
                        battleAnnoBox.Text = "Corrupted Mage used Defensive Blast!";
                        if (int.Parse(charStatusEffects[8]) == 0)
                        {
                            int hitChance = rnd.Next(1, 100);
                            if (hitChance > int.Parse(charStats[11]))
                            {
                                enemyActionBox.Text = "Succesful Hit!";
                                charStats[5] = int.Parse(charStats[5]) - (int.Parse(enemyStats[9]) - int.Parse(charStats[10])) + "";
                                charHealthBox.Text = "Health: " + charStats[5] + "/" + charStats[4];
                                using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(enemyStatusEffects[0]);
                                    writer.WriteLine(enemyStatusEffects[1]);
                                    writer.WriteLine(enemyStatusEffects[2]);
                                    writer.WriteLine(int.Parse(enemyStatusEffects[3]) + 2); // (Applies 2 turns of Defense+ to the Corrupted Mage)
                                    writer.WriteLine(enemyStatusEffects[4]);
                                    writer.WriteLine(enemyStatusEffects[5]);
                                    writer.WriteLine(enemyStatusEffects[6]);
                                    writer.WriteLine(enemyStatusEffects[7]);
                                    writer.WriteLine(enemyStatusEffects[8]);
                                }
                                if (int.Parse(charStats[5]) <= 0)
                                {
                                    charHealthBox.Text = "Health 0/" + charStats[4];
                                    MessageBox.Show("You Died! :(");
                                    Application.Exit();
                                }
                                charWriter(charStats, "ClassStats.txt");
                            }
                            else
                            {
                                charActionBox.Text = "You Dodged!";
                            }
                        }
                        else
                        {
                            charActionBox.Text = "You Parried!";
                            enemyStats[5] = (int.Parse(enemyStats[5]) - (int.Parse(charStats[9]) / 2)) + "";
                            enemyHealthBox.Text = "Health: " + enemyStats[5] + "/" + enemyStats[4];
                            if (int.Parse(enemyStats[5]) <= 0) // Coin Gain and EXP gain on kill
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                exitbattlebtn.Visible = true;
                                battleAnnoBox.Text = "You defeated the enemy!";
                                enemyHealthBox.Text = "Health: 0/" + enemyStats[4];
                                int coinsGain = rnd.Next(50, 100);
                                inventory[0] = (int.Parse(inventory[0]) + coinsGain) + "";
                                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(inventory[0]);
                                    writer.WriteLine(inventory[1]);
                                    writer.WriteLine(inventory[2]);
                                    writer.WriteLine(inventory[3]);
                                }
                                int expGain = rnd.Next(50, 100);
                                charStats[3] = (int.Parse(charStats[3]) + expGain) + "";
                                if (int.Parse(charStats[3]) >= 100) // Check if you have enough EXP to level up
                                {
                                    charStats[2] = (int.Parse(charStats[2]) + 1) + "";
                                    charStats[3] = (int.Parse(charStats[3]) - 100) + "";
                                    charStats[4] = (int.Parse(charStats[4]) + 5) + "";
                                    charStats[5] = (int.Parse(charStats[5]) + 5) + "";
                                    charStats[6] = (int.Parse(charStats[6]) + 2) + "";
                                    charStats[7] = (int.Parse(charStats[7]) + 2) + "";
                                    charStats[9] = (int.Parse(charStats[9]) + 2) + "";
                                    charStats[10] = (int.Parse(charStats[10]) + 2) + "";
                                    charWriter(charStats, "ClassStats.txt");
                                }
                            }
                            using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                            {
                                writer.Flush();
                                writer.WriteLine(charStatusEffects[0]);
                                writer.WriteLine(charStatusEffects[1]);
                                writer.WriteLine(charStatusEffects[2]);
                                writer.WriteLine(charStatusEffects[3]);
                                writer.WriteLine(charStatusEffects[4]);
                                writer.WriteLine(charStatusEffects[5]);
                                writer.WriteLine(charStatusEffects[6]);
                                writer.WriteLine(charStatusEffects[7]);
                                writer.WriteLine(int.Parse(charStatusEffects[8]) - 1);
                            }
                        }
                    }
                    else if (enemyStats[1] == "3")
                    {
                        battleAnnoBox.Text = "Skeleton Warrior used Lethal Stab!";
                        if (int.Parse(charStatusEffects[8]) == 0)
                        {
                            int hitChance = rnd.Next(1, 100);
                            if (hitChance > int.Parse(charStats[11]))
                            {
                                enemyActionBox.Text = "Succesful Hit!";
                                charStats[5] = int.Parse(charStats[5]) - (int.Parse(enemyStats[9]) - int.Parse(charStats[10])) + "";
                                charHealthBox.Text = "Health: " + charStats[5] + "/" + charStats[4];
                                using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(charStatusEffects[0]);
                                    writer.WriteLine(charStatusEffects[1]);
                                    writer.WriteLine(charStatusEffects[2]);
                                    writer.WriteLine(charStatusEffects[3]);
                                    writer.WriteLine(charStatusEffects[4]);
                                    writer.WriteLine(charStatusEffects[5]);
                                    writer.WriteLine(int.Parse(charStatusEffects[6]) + 1); // (Applies 1 turn of bleed to the player)
                                    writer.WriteLine(charStatusEffects[7]);
                                    writer.WriteLine(charStatusEffects[8]);
                                }
                                if (int.Parse(charStats[5]) <= 0)
                                {
                                    charHealthBox.Text = "Health 0/" + charStats[4];
                                    MessageBox.Show("You Died! :(");
                                    Application.Exit();
                                }
                                charWriter(charStats, "ClassStats.txt");
                            }
                            else
                            {
                                charActionBox.Text = "You Dodged!";
                            }
                        }
                        else
                        {
                            charActionBox.Text = "You Parried!";
                            enemyStats[5] = (int.Parse(enemyStats[5]) - (int.Parse(charStats[9]) / 2)) + "";
                            enemyHealthBox.Text = "Health: " + enemyStats[5] + "/" + enemyStats[4];
                            if (int.Parse(enemyStats[5]) <= 0) // Coin Gain and EXP gain on kill
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                exitbattlebtn.Visible = true;
                                battleAnnoBox.Text = "You defeated the enemy!";
                                enemyHealthBox.Text = "Health: 0/" + enemyStats[4];
                                int coinsGain = rnd.Next(50, 100);
                                inventory[0] = (int.Parse(inventory[0]) + coinsGain) + "";
                                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(inventory[0]);
                                    writer.WriteLine(inventory[1]);
                                    writer.WriteLine(inventory[2]);
                                    writer.WriteLine(inventory[3]);
                                }
                                int expGain = rnd.Next(50, 100);
                                charStats[3] = (int.Parse(charStats[3]) + expGain) + "";
                                if (int.Parse(charStats[3]) >= 100) // Check if you have enough EXP to level up
                                {
                                    charStats[2] = (int.Parse(charStats[2]) + 1) + "";
                                    charStats[3] = (int.Parse(charStats[3]) - 100) + "";
                                    charStats[4] = (int.Parse(charStats[4]) + 5) + "";
                                    charStats[5] = (int.Parse(charStats[5]) + 5) + "";
                                    charStats[6] = (int.Parse(charStats[6]) + 2) + "";
                                    charStats[7] = (int.Parse(charStats[7]) + 2) + "";
                                    charStats[9] = (int.Parse(charStats[9]) + 2) + "";
                                    charStats[10] = (int.Parse(charStats[10]) + 2) + "";
                                    charWriter(charStats, "ClassStats.txt");
                                }
                            }
                            using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                            {
                                writer.Flush();
                                writer.WriteLine(charStatusEffects[0]);
                                writer.WriteLine(charStatusEffects[1]);
                                writer.WriteLine(charStatusEffects[2]);
                                writer.WriteLine(charStatusEffects[3]);
                                writer.WriteLine(charStatusEffects[4]);
                                writer.WriteLine(charStatusEffects[5]);
                                writer.WriteLine(charStatusEffects[6]);
                                writer.WriteLine(charStatusEffects[7]);
                                writer.WriteLine(int.Parse(charStatusEffects[8]) - 1);
                            }
                        }
                    }
                    if (enemyStats[1] == "4")
                    {
                        battleAnnoBox.Text = "Sneaky Goblin used Steal!";
                        if (int.Parse(charStatusEffects[8]) == 0)
                        {
                            int hitChance = rnd.Next(1, 100);
                            if (hitChance > int.Parse(charStats[11]))
                            {
                                enemyActionBox.Text = "Succesful Hit!";
                                charStats[5] = int.Parse(charStats[5]) - (int.Parse(enemyStats[9]) - int.Parse(charStats[10])) + "";
                                charHealthBox.Text = "Health: " + charStats[5] + "/" + charStats[4];
                                inventory[0] = int.Parse(inventory[0]) - (int.Parse(enemyStats[9]) - int.Parse(charStats[10])) + ""; // Goblin steals the same amount of gold as the amount of damage he deals with this attack
                                using (StreamWriter writer = new StreamWriter("Inventory.txt")) // Rewrite new coin count
                                {
                                    writer.Flush();
                                    writer.WriteLine(inventory[0]); // COins
                                    writer.WriteLine(inventory[1]); // Health Pot
                                    writer.WriteLine(inventory[2]); // Dagger
                                    writer.WriteLine(inventory[3]); // Strength Pot
                                }
                                if (int.Parse(charStats[5]) <= 0)
                                {
                                    charHealthBox.Text = "Health 0/" + charStats[4];
                                    MessageBox.Show("You Died! :(");
                                    Application.Exit();
                                }
                                charWriter(charStats, "ClassStats.txt");
                            }
                            else
                            {
                                charActionBox.Text = "You Dodged!";
                            }
                        }
                        else
                        {
                            charActionBox.Text = "You Parried!";
                            enemyStats[5] = (int.Parse(enemyStats[5]) - (int.Parse(charStats[9]) / 2)) + "";
                            enemyHealthBox.Text = "Health: " + enemyStats[5] + "/" + enemyStats[4];
                            if (int.Parse(enemyStats[5]) <= 0) // Coin Gain and EXP gain on kill
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                exitbattlebtn.Visible = true;
                                battleAnnoBox.Text = "You defeated the enemy!";
                                enemyHealthBox.Text = "Health: 0/" + enemyStats[4];
                                int coinsGain = rnd.Next(50, 100);
                                inventory[0] = (int.Parse(inventory[0]) + coinsGain) + "";
                                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(inventory[0]);
                                    writer.WriteLine(inventory[1]);
                                    writer.WriteLine(inventory[2]);
                                    writer.WriteLine(inventory[3]);
                                }
                                int expGain = rnd.Next(50, 100);
                                charStats[3] = (int.Parse(charStats[3]) + expGain) + "";
                                if (int.Parse(charStats[3]) >= 100) // Check if you have enough EXP to level up
                                {
                                    charStats[2] = (int.Parse(charStats[2]) + 1) + "";
                                    charStats[3] = (int.Parse(charStats[3]) - 100) + "";
                                    charStats[4] = (int.Parse(charStats[4]) + 5) + "";
                                    charStats[5] = (int.Parse(charStats[5]) + 5) + "";
                                    charStats[6] = (int.Parse(charStats[6]) + 2) + "";
                                    charStats[7] = (int.Parse(charStats[7]) + 2) + "";
                                    charStats[9] = (int.Parse(charStats[9]) + 2) + "";
                                    charStats[10] = (int.Parse(charStats[10]) + 2) + "";
                                    charWriter(charStats, "ClassStats.txt");
                                }
                            }
                            using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                            {
                                writer.Flush();
                                writer.WriteLine(charStatusEffects[0]);
                                writer.WriteLine(charStatusEffects[1]);
                                writer.WriteLine(charStatusEffects[2]);
                                writer.WriteLine(charStatusEffects[3]);
                                writer.WriteLine(charStatusEffects[4]);
                                writer.WriteLine(charStatusEffects[5]);
                                writer.WriteLine(charStatusEffects[6]);
                                writer.WriteLine(charStatusEffects[7]);
                                writer.WriteLine(int.Parse(charStatusEffects[8]) - 1);
                            }
                        }
                    }
                    else if (enemyStats[1] == "5")
                    {
                        battleAnnoBox.Text = "Chest? used Stare!";
                    }
                    else if (enemyStats[1] == "6")
                    {
                        battleAnnoBox.Text = "Chest Mimic used Bite!";
                        if (int.Parse(charStatusEffects[8]) == 0)
                        {
                            int hitChance = rnd.Next(1, 100);
                            if (hitChance > int.Parse(charStats[11]))
                            {
                                enemyActionBox.Text = "Succesful Hit!";
                                charStats[5] = int.Parse(charStats[5]) - (int.Parse(enemyStats[9]) - int.Parse(charStats[10])) + "";
                                charHealthBox.Text = "Health: " + charStats[5] + "/" + charStats[4];
                                enemyStats[5] = int.Parse(enemyStats[5]) + (int.Parse(enemyStats[9]) - int.Parse(charStats[10])) + "";
                                enemyHealthBox.Text = "Health: " + enemyStats[5] + "/" + enemyStats[4];
                                charWriter(charStats, "ClassStats.txt");
                                if (int.Parse(charStats[5]) <= 0)
                                {
                                    charHealthBox.Text = "Health 0/" + charStats[4];
                                    MessageBox.Show("You Died! :(");
                                    Application.Exit();
                                }
                            }
                            else
                            {
                                charActionBox.Text = "You Dodged!";
                            }
                        }
                        else
                        {
                            charActionBox.Text = "You Parried!";
                            enemyStats[5] = (int.Parse(enemyStats[5]) - (int.Parse(charStats[9]) / 2)) + "";
                            enemyHealthBox.Text = "Health: " + enemyStats[5] + "/" + enemyStats[4];
                            if (int.Parse(enemyStats[5]) <= 0) // Coin Gain and EXP gain on kill
                            {
                                attackBtn1.Visible = false;
                                attackBtn2.Visible = false;
                                attackBtn3.Visible = false;
                                attackBtn4.Visible = false;
                                exitbattlebtn.Visible = true;
                                battleAnnoBox.Text = "You defeated the enemy!";
                                enemyHealthBox.Text = "Health: 0/" + enemyStats[4];
                                int coinsGain = rnd.Next(50, 100);
                                inventory[0] = (int.Parse(inventory[0]) + coinsGain) + "";
                                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                                {
                                    writer.Flush();
                                    writer.WriteLine(inventory[0]);
                                    writer.WriteLine(inventory[1]);
                                    writer.WriteLine(inventory[2]);
                                    writer.WriteLine(inventory[3]);
                                }
                                int expGain = rnd.Next(50, 100);
                                charStats[3] = (int.Parse(charStats[3]) + expGain) + "";
                                if (int.Parse(charStats[3]) >= 100) // Check if you have enough EXP to level up
                                {
                                    charStats[2] = (int.Parse(charStats[2]) + 1) + "";
                                    charStats[3] = (int.Parse(charStats[3]) - 100) + "";
                                    charStats[4] = (int.Parse(charStats[4]) + 5) + "";
                                    charStats[5] = (int.Parse(charStats[5]) + 5) + "";
                                    charStats[6] = (int.Parse(charStats[6]) + 2) + "";
                                    charStats[7] = (int.Parse(charStats[7]) + 2) + "";
                                    charStats[9] = (int.Parse(charStats[9]) + 2) + "";
                                    charStats[10] = (int.Parse(charStats[10]) + 2) + "";
                                    charWriter(charStats, "ClassStats.txt");
                                }
                            }
                            using (StreamWriter writer = new StreamWriter("CharStatusEffects.txt"))
                            {
                                writer.Flush();
                                writer.WriteLine(charStatusEffects[0]);
                                writer.WriteLine(charStatusEffects[1]);
                                writer.WriteLine(charStatusEffects[2]);
                                writer.WriteLine(charStatusEffects[3]);
                                writer.WriteLine(charStatusEffects[4]);
                                writer.WriteLine(charStatusEffects[5]);
                                writer.WriteLine(charStatusEffects[6]);
                                writer.WriteLine(charStatusEffects[7]);
                                writer.WriteLine(int.Parse(charStatusEffects[8]) - 1);
                            }
                        }
                    }
                }
            }
            else
            {
                enemyActionBox.Text = "Enemy is stunned!!";
                using (StreamWriter writer = new StreamWriter("EnemyStatusEffects.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(enemyStatusEffects[0]); // Attack-
                    writer.WriteLine(enemyStatusEffects[1]); // Attack+
                    writer.WriteLine(enemyStatusEffects[2]); // Defense-
                    writer.WriteLine(enemyStatusEffects[3]); // Defnese+
                    writer.WriteLine(enemyStatusEffects[4]); // Dodge-
                    writer.WriteLine(enemyStatusEffects[5]); // Dodge+
                    writer.WriteLine(enemyStatusEffects[6]); // Bleed
                    writer.WriteLine(int.Parse(enemyStatusEffects[7]) - 1); // Stun
                    writer.WriteLine(enemyStatusEffects[8]); // Parry
                }
            }
            using (StreamReader sr = new StreamReader("CharStatusEffects.txt"))
            {
                charStatusEffects[0] = sr.ReadLine();
                charStatusEffects[1] = sr.ReadLine();
                charStatusEffects[2] = sr.ReadLine();
                charStatusEffects[3] = sr.ReadLine();
                charStatusEffects[4] = sr.ReadLine();
                charStatusEffects[5] = sr.ReadLine();
                charStatusEffects[6] = sr.ReadLine();
                charStatusEffects[7] = sr.ReadLine();
                charStatusEffects[8] = sr.ReadLine();
            }
            using (StreamReader sr = new StreamReader("EnemyStatusEffects.txt"))
            {
                enemyStatusEffects[0] = sr.ReadLine();
                enemyStatusEffects[1] = sr.ReadLine();
                enemyStatusEffects[2] = sr.ReadLine();
                enemyStatusEffects[3] = sr.ReadLine();
                enemyStatusEffects[4] = sr.ReadLine();
                enemyStatusEffects[5] = sr.ReadLine();
                enemyStatusEffects[6] = sr.ReadLine();
                enemyStatusEffects[7] = sr.ReadLine();
                enemyStatusEffects[8] = sr.ReadLine();
            }
            charStatusEffectsBox.Text = "";
            enemyStatusEffectsBox.Text = "";
            charWriter(charStats, "ClassStats.txt");
            enemyWriter(enemyStats, "EnemyStats.txt");
            if (int.Parse(charStatusEffects[0]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nAttack- (" + charStatusEffects[0] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[0]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nAttack- (" + enemyStatusEffects[0] + " turns)";
            }
            if (int.Parse(charStatusEffects[1]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nAttack+ (" + charStatusEffects[1] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[1]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nAttack+ (" + enemyStatusEffects[1] + " turns)";
            }
            if (int.Parse(charStatusEffects[2]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nDefense- (" + charStatusEffects[2] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[2]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nDefense- (" + enemyStatusEffects[2] + " turns)";
            }
            if (int.Parse(charStatusEffects[3]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nDefense+ (" + charStatusEffects[3] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[3]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nDefense+ (" + enemyStatusEffects[3] + " turns)";
            }
            if (int.Parse(charStatusEffects[4]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nDodge- (" + charStatusEffects[4] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[4]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nDodge- (" + enemyStatusEffects[4] + " turns)";
            }
            if (int.Parse(charStatusEffects[5]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nDodge+ (" + charStatusEffects[5] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[5]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nDodge+ (" + enemyStatusEffects[5] + " turns)";
            }
            if (int.Parse(charStatusEffects[6]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nBleed (" + charStatusEffects[6] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[6]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nBleed (" + enemyStatusEffects[6] + " turns)";
            }
            if (int.Parse(charStatusEffects[7]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nStun (" + charStatusEffects[7] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[7]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nStun (" + enemyStatusEffects[7] + " turns)";
            }
            if (int.Parse(charStatusEffects[8]) > 0)
            {
                charStatusEffectsBox.Text = charStatusEffectsBox.Text + "\nParry (" + charStatusEffects[8] + " turns)";
            }
            if (int.Parse(enemyStatusEffects[8]) > 0)
            {
                enemyStatusEffectsBox.Text = enemyStatusEffectsBox.Text + "\nParry (" + enemyStatusEffects[8] + " turns)";
            }
        }

        private void tutorialTab_Click(object sender, EventArgs e)
        {
            Tutorial tutorialPopup = new Tutorial();
            tutorialPopup.ShowDialog();
        }

        private void exitbattlebtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
