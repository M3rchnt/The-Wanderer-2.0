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
    public partial class EnemyStats : Form
    {
        public string[] stats = new string[100];
        public EnemyStats()
        {
            InitializeComponent();
            abilityExplainBox.Visible = false; //Hides the explaination of the enemy's attack
            using (StreamReader reader = new StreamReader("EnemyStats.txt"))
            {
                stats[0] = reader.ReadLine(); // Name
                stats[1] = reader.ReadLine(); // Class
                stats[2] = reader.ReadLine(); // Level
                stats[4] = reader.ReadLine(); // Health
                stats[5] = reader.ReadLine(); // Active Health
                stats[6] = reader.ReadLine(); // Attack
                stats[7] = reader.ReadLine(); // Defence
                stats[8] = reader.ReadLine(); // Dodge
                stats[9] = reader.ReadLine(); // Active Attack
                stats[10] = reader.ReadLine(); // Active Defence
                stats[11] = reader.ReadLine(); // Active Dodge
            }
            nameBox.Text = stats[0]; //Sets all the boxes to display their appropriate values
            levelBox.Text = "Level: " + stats[2];
            healthBox.Text = "Health: " + stats[5] + "/" + stats[4];
            attackBox.Text = "Attack: " + stats[6] + "(" + stats[9] + ")";
            defenceBox.Text = "Defence: " + stats[7] + "(" + stats[10] + ")";
            dodgeBox.Text = "Dodge: " + stats[8] + "(" + stats[11] + ")";
            if (stats[1] == "1") //Depending on the enemy ID, it will display the enemy's idle sprite and their attacks' names.
            {
                using (StreamReader sr = new StreamReader("__TrollIdleSmall.gif"))
                {
                    charImageBox.Image = new Bitmap("__TrollIdleSmall.gif");
                }
                attackBtn1.Text = "Rock Throw";
                attackBtn2.Text = "Heavy Swipe";
            }
            if (stats[1] == "2")
            {
                using (StreamReader sr = new StreamReader("__CorruptMageIdle.gif"))
                {
                    charImageBox.Image = new Bitmap("__CorruptMageIdle.gif");
                }
                attackBtn1.Text = "Petrify";
                attackBtn2.Text = "Defensive Blast";
            }
            if (stats[1] == "3")
            {
                using (StreamReader sr = new StreamReader("__SkeletonIdle.gif"))
                {
                    charImageBox.Image = new Bitmap("__SkeletonIdle.gif");
                }
                attackBtn1.Text = "Parry";
                attackBtn2.Text = "Lethal Stab";
            }
            if (stats[1] == "4")
            {
                using (StreamReader sr = new StreamReader("__GoblinIdle.gif"))
                {
                    charImageBox.Image = new Bitmap("__GoblinIdle.gif");
                }
                attackBtn1.Text = "Sneak";
                attackBtn2.Text = "Steal";
            }
            if (stats[1] == "5")
            {
                using (StreamReader sr = new StreamReader("__MimicIdle.gif"))
                {
                    charImageBox.Image = new Bitmap("__MimicIdle.gif");
                }
                attackBtn1.Text = "Wobble";
                attackBtn2.Text = "Stare";
            }
            if (stats[1] == "6")
            {
                using (StreamReader sr = new StreamReader("__MimicIdle.gif"))
                {
                    charImageBox.Image = new Bitmap("__MimicIdle.gif");
                }
                attackBtn1.Text = "Chomp";
                attackBtn2.Text = "Bite"; // Similar to Warrior Slash
            }
        }

        private void charImageBox_MouseHover(object sender, EventArgs e)
        { //When hovering over the enemy sprite, it will turn it into the corrosponding enemy's running sprite (1 = troll, 2 = Mage, 3 = Skeleton, 4 = Goblin, 5 = chest, 6 = mimic)
            if (stats[1] == "1")
            {
                using (StreamReader sr = new StreamReader("__TrollRunSmall.gif"))
                {
                    charImageBox.Image = new Bitmap("__TrollRunSmall.gif");
                }
            }
            if (stats[1] == "2")
            {
                using (StreamReader sr = new StreamReader("__CorruptMageAttack.gif"))
                {
                    charImageBox.Image = new Bitmap("__CorruptMageAttack.gif");
                }
            }
            if (stats[1] == "3")
            {
                using (StreamReader sr = new StreamReader("__SkeletonAttack.gif"))
                {
                    charImageBox.Image = new Bitmap("__SkeletonAttack.gif");
                }
            }
            if (stats[1] == "4")
            {
                using (StreamReader sr = new StreamReader("__GoblinRun.gif"))
                {
                    charImageBox.Image = new Bitmap("__GoblinRun.gif");
                }
            }
            if (stats[1] == "5")
            {
                using (StreamReader sr = new StreamReader("__ChestOpen.gif"))
                {
                    charImageBox.Image = new Bitmap("__ChestOpen.gif");
                }
            }
            if (stats[1] == "6")
            {
                using (StreamReader sr = new StreamReader("__MimicRun.gif"))
                {
                    charImageBox.Image = new Bitmap("__MimicRun.gif");
                }
            }
        }

        private void charImageBox_MouseLeave(object sender, EventArgs e) //When no longer hovering the enemy sprite, it returns the sprite to the enemy's idle animation  (1 = troll, 2 = Mage, 3 = Skeleton, 4 = Goblin, 5 = chest, 6 = mimic)
        {
            if (stats[1] == "1")
            {
                using (StreamReader sr = new StreamReader("__TrollIdleSmall.gif"))
                {
                    charImageBox.Image = new Bitmap("__TrollIdleSmall.gif");
                }
            }
            if (stats[1] == "2")
            {
                using (StreamReader sr = new StreamReader("__CorruptMageIdle.gif"))
                {
                    charImageBox.Image = new Bitmap("__CorruptMageIdle.gif");
                }
            }
            if (stats[1] == "3")
            {
                using (StreamReader sr = new StreamReader("__SkeletonIdle.gif"))
                {
                    charImageBox.Image = new Bitmap("__SkeletonIdle.gif");
                }
            }
            if (stats[1] == "4")
            {
                using (StreamReader sr = new StreamReader("__GoblinIdle.gif"))
                {
                    charImageBox.Image = new Bitmap("__GoblinIdle.gif");
                }
            }
            if (stats[1] == "5")
            {
                using (StreamReader sr = new StreamReader("__MimicIdle.gif"))
                {
                    charImageBox.Image = new Bitmap("__MimicIdle.gif");
                }
            }
            if (stats[1] == "6")
            {
                using (StreamReader sr = new StreamReader("__MimicIdle.gif"))
                {
                    charImageBox.Image = new Bitmap("__MimicIdle.gif");
                }
            }
        }

        private void attackBtn1_MouseHover(object sender, EventArgs e) //Depending on the enemy, when hoving over the first attack, it will give a description of what it does
        {
            abilityExplainBox.Visible = true; //Makes everything but the explaination box visible
            nameBox.Visible = false;
            levelBox.Visible = false;
            healthBox.Visible = false;
            attackBox.Visible = false;
            defenceBox.Visible = false;
            dodgeBox.Visible = false;
            charImageBox.Visible = false;
            if (stats[1] == "1") //Sets the description depending on the enemy's first attack  (1 = troll, 2 = Mage, 3 = Skeleton, 4 = Goblin, 5 = chest, 6 = mimic)
            {
                abilityExplainBox.Text = "The Armored Troll flexes very hard and decides to pick up the nearest rock and throw it at you instead of just using their sword, not the smartest move but they are a troll after all. \n\nThe armored troll stuns the player for 1 turn and applies Attack+ to the Armored Troll for 1 turn. Has a chance to miss. Deals no damage.";
            }
            else if (stats[1] == "2")
            {
                abilityExplainBox.Text = "The Corrupted Mage uses his magical wand to create a flash of light that leaves you stunned in place! It's not very accurate though. \n\nIf this attack hits it deals damage and applies stun for 2 turns to the player but this ability has a 45% accuracy penalty";
            }
            else if (stats[1] == "3")
            {
                abilityExplainBox.Text = "The Skeleton Warrior remembers his old days of being alive and recreates one of his past abilities. \n\nIf this attack succeeds the Skeleton Warrior gains 1 stack of Parry, though it won't always succeed.";
            }
            else if (stats[1] == "4")
            {
                abilityExplainBox.Text = "The Sneaky Goblin get's really hyper and moves very quickly which increases his dodge for a few turns. \n\nIf this attack succeeds the Sneaky Goblin applies Dodge+ to himself for 2 turns/";
            }
            else if (stats[1] == "5")
            {
                abilityExplainBox.Text = "The chest wobbles ominously in place, what secrets could it possibly hold? \n\nThis move does absolutely nothing";
            }
            else if (stats[1] == "6")
            {
                abilityExplainBox.Text = "The Chest Mimic feels very hungry and takes a large bite out of the player's health pool, tasty! \n\nThe Chest Mimic attacks the player dealing damage and healing for a portion of the damage dealt";
            }
        }

        private void attackBtn1_MouseLeave(object sender, EventArgs e) //When moving the mouse off of the button, it resets the window to it's original state 
        {
            abilityExplainBox.Visible = false;
            nameBox.Visible = true;
            levelBox.Visible = true;
            healthBox.Visible = true;
            attackBox.Visible = true;
            defenceBox.Visible = true;
            charImageBox.Visible = true;
        }

        private void attackBtn2_MouseHover(object sender, EventArgs e) //Repeats earlier code for attack 2
        {
            abilityExplainBox.Visible = true;
            nameBox.Visible = false;
            levelBox.Visible = false;
            healthBox.Visible = false;
            attackBox.Visible = false;
            defenceBox.Visible = false;
            dodgeBox.Visible = false;
            charImageBox.Visible = false;
            if (stats[1] == "1")
            {
                abilityExplainBox.Text = "The armored troll swipes forward with a mighty swing of their sword exposing the player's weak points \n\nThis attack deals damage to the player and applies Defence- for 2 turns to the player.";
            }
            else if (stats[1] == "2")
            {
                abilityExplainBox.Text = "The Corrupted Mage attack with a flash of magic that increases his defense! He actually just put on a piece of armour during his attack, what a cheater. \n\nThis attack deals damage to the player and applies Defence+ to the Corrupted Mage for 1 turn.";
            }
            else if (stats[1] == "3")
            {
                abilityExplainBox.Text = "The Skeleton Warrior lunges forward with a mighty swing of their sword that cuts deep into the player. \n\nThis attack deals damage to the player and applies 1 turn of bleed";
            }
            else if (stats[1] == "4")
            {
                abilityExplainBox.Text = "The Sneaky Goblin lunges at the player going after the one thing they treasure most, your money. \n\nThis attack steals gold from the player equal to the amount of damage this attack deals.";
            }
            else if (stats[1] == "5")
            {
                abilityExplainBox.Text = "The Chest stares intently at you, it's too bad it's just a chest... right? \n\nThis attack does absolutely nothing.";
            }
            else if (stats[1] == "6")
            {
                abilityExplainBox.Text = "The Chest Mimic bites the player very violently causing minor physical damage but emotionally you feel cheated. \n\nThe Chest Mimic deals damage and applies 2 turns of bleed to the player";
            }
        }

        private void attackBtn2_MouseLeave(object sender, EventArgs e) //Repeats earlier code for attack 2
        {
            abilityExplainBox.Visible = false;
            nameBox.Visible = true;
            levelBox.Visible = true;
            healthBox.Visible = true;
            attackBox.Visible = true;
            defenceBox.Visible = true;
            charImageBox.Visible = true;
        }
    }
}
