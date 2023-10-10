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
    public partial class CharacterStats : Form
    {
        public string[] stats = new string[100];
        public CharacterStats()
        {
            InitializeComponent();
            abilityExplainBox.Visible = false; //Makes everything but the character attack descriptions visible
            using (StreamReader reader = new StreamReader("ClassStats.txt"))
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
                stats[9] = reader.ReadLine(); // Active Attack
                stats[10] = reader.ReadLine(); // Active Defence
                stats[11] = reader.ReadLine(); // Active Dodge
            }
            levelBox.Text = "Level: " + stats[2]; //Sets all stat boxes to their appropriate values
            expBox.Text = "Exp: " + stats[3] + "/100";
            healthBox.Text = "Health: " + stats[5] + "/" + stats[4];
            attackBox.Text = "Attack: " + stats[6] + "(" + stats[9] + ")";
            defenceBox.Text = "Defence: " + stats[7] + "(" + stats[10] + ")";
            dodgeBox.Text = "Dodge: " + stats[8] + "(" + stats[11] + ")";
            if (stats[1] == "1") //Sets the idle animation and the names of the attacks depending on the character's class (1 = warrior, 2 = archer, 3 = spear)
            {
                using (StreamReader sr = new StreamReader("__WarriorIdleBig.gif"))
                {
                    charImageBox.Image = new Bitmap("__WarriorIdleBig.gif");
                }
                nameBox.Text = stats[0] + ", the Warrior";
                attackBtn1.Text = "Slash";
                attackBtn2.Text = "Bash";
                attackBtn3.Text = "Heavy Smash";
                attackBtn4.Text = "Parry";
            }
            else if (stats[1] == "2")
            {
                using (StreamReader sr = new StreamReader("__ArcherIdleBig.gif"))
                {
                    charImageBox.Image = new Bitmap("__ArcherIdleBig.gif");
                }
                nameBox.Text = stats[0] + ", the Archer";
                attackBtn1.Text = "Piercing Shot";
                attackBtn2.Text = "Pursuit";
                attackBtn3.Text = "Gouge";
                attackBtn4.Text = "Evade";
            }
            else if (stats[1] == "3")
            {
                using (StreamReader sr = new StreamReader("__SpearIdleBig.gif")) // RESIZE BIG SPEAR
                {
                    charImageBox.Image = new Bitmap("__SpearIdleBig.gif");
                }
                nameBox.Text = stats[0] + ", the Spear";
                attackBtn1.Text = "Momentum Strike";
                attackBtn2.Text = "Sweeping Strike";
                attackBtn3.Text = "Rally";
                attackBtn4.Text = "Flurry";
            }
        }
        private void charImageBox_MouseHover(object sender, EventArgs e) //Depending on the class, it will turn the idle animation to the running animation when hovering over the sprite
        {
            if (stats[1] == "1")
            {
                using (StreamReader sr = new StreamReader("__WarriorRunBig.gif"))
                {
                    charImageBox.Image = new Bitmap("__WarriorRunBig.gif");
                }
            }
            else if (stats[1] == "2")
            {
                using (StreamReader sr = new StreamReader("__ArcherRunBig.gif"))
                {
                    charImageBox.Image = new Bitmap("__ArcherRunBig.gif");
                }
            }
            else if (stats[1] == "3")
            {
                using (StreamReader sr = new StreamReader("__SpearRunBig.gif"))
                {
                    charImageBox.Image = new Bitmap("__SpearRunBig.gif");
                }
            }
        }

        private void charImageBox_MouseLeave(object sender, EventArgs e) //Resets the character sprite back to the idle animation when no longer hovering
        {
            if (stats[1] == "1")
            {
                using (StreamReader sr = new StreamReader("__WarriorIdleBig.gif"))
                {
                    charImageBox.Image = new Bitmap("__WarriorIdleBig.gif");
                }
            }
            else if (stats[1] == "2")
            {
                using (StreamReader sr = new StreamReader("__ArcherIdleBig.gif"))
                {
                    charImageBox.Image = new Bitmap("__ArcherIdleBig.gif");
                }
            }
            else if (stats[1] == "3")
            {
                using (StreamReader sr = new StreamReader("__SpearIdleBig.gif"))
                {
                    charImageBox.Image = new Bitmap("__SpearIdleBig.gif");
                }
            }
        }

        private void attackBtn1_MouseHover(object sender, EventArgs e) //When hovering over the attack, depending on the class, it will give a description of it
        {
            abilityExplainBox.Visible = true; //Makes everything but the description and button visible
            nameBox.Visible = false;
            levelBox.Visible = false;
            expBox.Visible = false;
            healthBox.Visible = false;
            attackBox.Visible = false;
            defenceBox.Visible = false;
            dodgeBox.Visible = false;
            charImageBox.Visible = false;
            if (stats[1] == "1") //Adds description depending on class
            {
                abilityExplainBox.Text = "The Mighty Warrior swings forth with their comically large sword dealing their attack damage to the enemy! \n\n This attack has a 20% chance to deal DOUBLE DAMAGE!";
            }
            else if (stats[1] == "2")
            {
                abilityExplainBox.Text = "The Archer draws back their bow to snipe the enemy in their weak spots! Don't ask me where their weak spots are, I don't know either. \n\n This attack ignores all armor that the enemy has and deals the archer's attack damage to them";
            }
            else if (stats[1] == "3")
            {
                abilityExplainBox.Text = "The Noble Spearperson lunges forward with murderous intent and strikes their enemy very hard. \n\n This attack deals the spear's attack value to the enemy and increases their attack value by 1 point in this encounter for each succesful strike. The bonus returns to 0 if the enemy dodges the attack";
            }
        }

        private void attackBtn1_MouseLeave(object sender, EventArgs e) //When leaving the attack button, it resets the window
        {
            abilityExplainBox.Visible = false;
            nameBox.Visible = true;
            levelBox.Visible = true;
            expBox.Visible = true;
            healthBox.Visible = true;
            attackBox.Visible = true;
            defenceBox.Visible = true;
            dodgeBox.Visible = true;
            charImageBox.Visible = true;
        }

        private void attackBtn2_MouseHover(object sender, EventArgs e) //Repeats earlier code for attack 2
        {
            abilityExplainBox.Visible = true;
            nameBox.Visible = false;
            levelBox.Visible = false;
            expBox.Visible = false;
            healthBox.Visible = false;
            attackBox.Visible = false;
            defenceBox.Visible = false;
            dodgeBox.Visible = false;
            charImageBox.Visible = false;
            if (stats[1] == "1")
            {
                abilityExplainBox.Text = "The Warrior begins to think about the time someone told him to use his head, so thats exactly what the warrior did. Bang. \n\n This attack deals the warrior's damage but also applies 2 turns of Defense- to the enemy";
            }
            else if (stats[1] == "2")
            {
                abilityExplainBox.Text = "The Archer gains a rush of adrenaline causing them to leap forward to attack the enemy in melee range. This shouldn't work. Like at all. But it does. \n\n This attack causes the archer to deal its damage to the enemy but deal 2x more damage if the enemy succesfully dodges the attack";
            }
            else if (stats[1] == "3")
            {
                abilityExplainBox.Text = "The Spear swings their spear in an arc in front of them rapidly. Dang that's a flexible spear. Hey did we want physics in this game? No? Ok then this is fine. \n\n This attack causes the spear to deal their damage to the enemy with a 100% hit chance regardless of the enemy's dodge value";
            }
        }

        private void attackBtn2_MouseLeave(object sender, EventArgs e) //Repeats earlier code for attack 2
        {
            abilityExplainBox.Visible = false;
            nameBox.Visible = true;
            levelBox.Visible = true;
            expBox.Visible = true;
            healthBox.Visible = true;
            attackBox.Visible = true;
            defenceBox.Visible = true;
            dodgeBox.Visible = true;
            charImageBox.Visible = true;
        }

        private void attackBtn3_MouseHover(object sender, EventArgs e) //Repeats earlier code for attack 3
        {
            abilityExplainBox.Visible = true;
            nameBox.Visible = false;
            levelBox.Visible = false;
            expBox.Visible = false;
            healthBox.Visible = false;
            attackBox.Visible = false;
            defenceBox.Visible = false;
            dodgeBox.Visible = false;
            charImageBox.Visible = false;
            if (stats[1] == "1")
            {
                abilityExplainBox.Text = "Hit the enemy hard enough with something that’s not a weapon (for some reason) and daze them for a few turns. Most of the shock comes from why you didn’t stab them though. \n\nApplies 2 turns of stun to the enemy but has a 25% accuracy penalty";
            }
            else if (stats[1] == "2")
            {
                abilityExplainBox.Text = "As many things have blood, you attack with enough precision to make even skeletons bleed. Don’t ask how that works, not even they know.\n\nThe archer deals damage and applies 2 turns of bleed to the enemy";
            }
            else if (stats[1] == "3")
            {
                abilityExplainBox.Text = "Spend the turn hyping yourself up and giving your next few attacks a bonus in damage. You can increase the duration with repeated uses, really getting an unhealthy amount of adrenaline in the body.\n\nThe spear applies 2 turns of attack+ and 1 turn of defense+";
            }
        }
        private void attackBtn3_MouseLeave(object sender, EventArgs e) //Repeats earlier code for attack 3
        {
            abilityExplainBox.Visible = false;
            nameBox.Visible = true;
            levelBox.Visible = true;
            expBox.Visible = true;
            healthBox.Visible = true;
            attackBox.Visible = true;
            defenceBox.Visible = true;
            dodgeBox.Visible = true;
            charImageBox.Visible = true;
        }

        private void attackBtn4_MouseHover(object sender, EventArgs e) //Repeats earlier code for attack 4
        {
            abilityExplainBox.Visible = true;
            nameBox.Visible = false;
            levelBox.Visible = false;
            expBox.Visible = false;
            healthBox.Visible = false;
            attackBox.Visible = false;
            defenceBox.Visible = false;
            dodgeBox.Visible = false;
            charImageBox.Visible = false;
            if (stats[1] == "1")
            {
                abilityExplainBox.Text = "Spend a turn preparing yourself for the next incoming blow a show off your martial abilities… but it doesn’t always work, in which case you look stupid. \n\n Has a 20% accuracy nerf, if it does add the parry buff which blocks the next incoming attack and deals 1/4 damage back to your opponent";
            }
            else if (stats[1] == "2")
            {
                abilityExplainBox.Text = "Spend a turn preparing your defenses and increasing your chance to dodge for the next few turns. A good idea to prevent your fleshy self from being stabbed by a goblin half your height. \n\n Has an 80% chance of success, if it does then it applies the dodge+ boost to your character";
            }
            else if (stats[1] == "3")
            {
                abilityExplainBox.Text = "Realize that no one’s stopping you from attacking more than once in a turn, and send a flurry of spear thrusts at your foe. Of course it’s weaker, but it sure looks much cooler. \n\n The spear attacks (2-6) amount of times each strike doing 1/3 of it's normal damage but penetrating armor";
            }
        }

        private void attackBtn4_MouseLeave(object sender, EventArgs e) //Repeats earlier code for attack 4
        {
            abilityExplainBox.Visible = false;
            nameBox.Visible = true;
            levelBox.Visible = true;
            expBox.Visible = true;
            healthBox.Visible = true;
            attackBox.Visible = true;
            defenceBox.Visible = true;
            dodgeBox.Visible = true;
            charImageBox.Visible = true;
        }
    }
}
