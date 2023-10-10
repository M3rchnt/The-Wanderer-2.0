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
    public partial class Merchant : Form
    {
        public string[] inventory = new string[100];
        public string[] merchantInventory = new string[100];
        public Merchant()
        {
            InitializeComponent();
            using (StreamReader sr = new StreamReader("Inventory.txt"))
            {
                inventory[0] = sr.ReadLine(); //Coins
                inventory[1] = sr.ReadLine(); //Health
                inventory[2] = sr.ReadLine(); //BigHealth 
                inventory[3] = sr.ReadLine(); //Strength
            }
            topAnnoBox.Text = inventory[0];
            using (StreamReader sr = new StreamReader("__HealingPot.png"))
            {
                HealthPotBuy.Image = new Bitmap("__HealingPot.png");
            }
            using (StreamReader sr = new StreamReader("__HealingPotBig.png"))
            {
                BigHealthPotBuy.Image = new Bitmap("__HealingPotBig.png");
            }
            using (StreamReader sr = new StreamReader("__StrengthPot.png"))
            {
                StrengthPotBuy.Image = new Bitmap("__StrengthPot.png");
            }
            HealthPotCount.Text = "$40";
            HealthPotBigCount.Text = "$70";
            StrengthPotCount.Text = "$200";
            winCostBox.Text = "$500";
        }

        private void inventoryTab_Click(object sender, EventArgs e)
        {
            Inventory invenPopup = new Inventory();
            invenPopup.ShowDialog();
        }

        private void HealthPotBuy_Click(object sender, EventArgs e)
        {
            if (int.Parse(inventory[0]) >= 40)
            {
                int gold = int.Parse(inventory[0]) - 40;
                inventory[0] = gold + "";
                int inventoryChance = int.Parse(inventory[1]) + 1;
                inventory[1] = inventoryChance + "";
                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(inventory[0]);
                    writer.WriteLine(inventory[1]);
                    writer.WriteLine(inventory[2]);
                    writer.WriteLine(inventory[3]);
                }
                topAnnoBox.Text = inventory[0];
            }
            else
            {
                MessageBox.Show("Not enough gold.");
            }
        }


        private void StrengthPotBuy_Click(object sender, EventArgs e)
        {
            if (int.Parse(inventory[0]) >= 100)
            {
                int gold = int.Parse(inventory[0]) - 100;
                inventory[0] = gold + "";
                int inventoryChance = int.Parse(inventory[3]) + 1;
                inventory[3] = inventoryChance + "";
                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(inventory[0]);
                    writer.WriteLine(inventory[1]);
                    writer.WriteLine(inventory[2]);
                    writer.WriteLine(inventory[3]);
                }
                topAnnoBox.Text = inventory[0];
            }
            else
            {
                MessageBox.Show("Not enough gold.");
            }
        }

        private void winBtn_Click(object sender, EventArgs e)
        {
            if (int.Parse(inventory[0]) >= 500)
            {
                MessageBox.Show("You won! Feel free to continue playing the game if you'd like!");
                inventory[0] = int.Parse(inventory[0]) - 500 + "";
                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(inventory[0]);
                    writer.WriteLine(inventory[1]);
                    writer.WriteLine(inventory[2]);
                    writer.WriteLine(inventory[3]);
                }
                topAnnoBox.Text = inventory[0];
            }
            else
            {
                MessageBox.Show("Not enough gold.");
            }
        }

        private void BigHealthPotBuy_Click(object sender, EventArgs e)
        {
            if (int.Parse(inventory[0]) >= 70)
            {
                int gold = int.Parse(inventory[0]) - 70;
                inventory[0] = gold + "";
                int inventoryChance = int.Parse(inventory[2]) + 1;
                inventory[2] = inventoryChance + "";
                using (StreamWriter writer = new StreamWriter("Inventory.txt"))
                {
                    writer.Flush();
                    writer.WriteLine(inventory[0]);
                    writer.WriteLine(inventory[1]);
                    writer.WriteLine(inventory[2]);
                    writer.WriteLine(inventory[3]);
                }
                topAnnoBox.Text = inventory[0];
            }
            else
            {
                MessageBox.Show("Not enough gold.");
            }
        }
    }
}
