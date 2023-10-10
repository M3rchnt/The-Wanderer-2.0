namespace Main
{
    partial class Inventory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inventoryBox = new System.Windows.Forms.PictureBox();
            this.coinBox = new System.Windows.Forms.TextBox();
            this.HealthPotCount = new System.Windows.Forms.RichTextBox();
            this.HealthPotBigCount = new System.Windows.Forms.RichTextBox();
            this.StrengthPotCount = new System.Windows.Forms.RichTextBox();
            this.InventorySlot1 = new System.Windows.Forms.PictureBox();
            this.InventorySlot2 = new System.Windows.Forms.PictureBox();
            this.InventorySlot3 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventorySlot1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventorySlot2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventorySlot3)).BeginInit();
            this.SuspendLayout();
            // 
            // inventoryBox
            // 
            this.inventoryBox.BackColor = System.Drawing.Color.Sienna;
            this.inventoryBox.Location = new System.Drawing.Point(169, 31);
            this.inventoryBox.Name = "inventoryBox";
            this.inventoryBox.Size = new System.Drawing.Size(524, 188);
            this.inventoryBox.TabIndex = 0;
            this.inventoryBox.TabStop = false;
            // 
            // coinBox
            // 
            this.coinBox.Location = new System.Drawing.Point(21, 129);
            this.coinBox.Name = "coinBox";
            this.coinBox.Size = new System.Drawing.Size(129, 22);
            this.coinBox.TabIndex = 1;
            // 
            // HealthPotCount
            // 
            this.HealthPotCount.Location = new System.Drawing.Point(186, 166);
            this.HealthPotCount.Name = "HealthPotCount";
            this.HealthPotCount.ReadOnly = true;
            this.HealthPotCount.Size = new System.Drawing.Size(67, 22);
            this.HealthPotCount.TabIndex = 2;
            this.HealthPotCount.Text = "";
            // 
            // HealthPotBigCount
            // 
            this.HealthPotBigCount.Location = new System.Drawing.Point(274, 166);
            this.HealthPotBigCount.Name = "HealthPotBigCount";
            this.HealthPotBigCount.ReadOnly = true;
            this.HealthPotBigCount.Size = new System.Drawing.Size(67, 22);
            this.HealthPotBigCount.TabIndex = 3;
            this.HealthPotBigCount.Text = "";
            // 
            // StrengthPotCount
            // 
            this.StrengthPotCount.Location = new System.Drawing.Point(361, 166);
            this.StrengthPotCount.Name = "StrengthPotCount";
            this.StrengthPotCount.ReadOnly = true;
            this.StrengthPotCount.Size = new System.Drawing.Size(67, 22);
            this.StrengthPotCount.TabIndex = 4;
            this.StrengthPotCount.Text = "";
            // 
            // InventorySlot1
            // 
            this.InventorySlot1.BackColor = System.Drawing.Color.Transparent;
            this.InventorySlot1.Location = new System.Drawing.Point(186, 74);
            this.InventorySlot1.Name = "InventorySlot1";
            this.InventorySlot1.Size = new System.Drawing.Size(68, 66);
            this.InventorySlot1.TabIndex = 5;
            this.InventorySlot1.TabStop = false;
            this.InventorySlot1.Click += new System.EventHandler(this.InventorySlot1_Click);
            // 
            // InventorySlot2
            // 
            this.InventorySlot2.BackColor = System.Drawing.Color.Transparent;
            this.InventorySlot2.Location = new System.Drawing.Point(274, 74);
            this.InventorySlot2.Name = "InventorySlot2";
            this.InventorySlot2.Size = new System.Drawing.Size(68, 66);
            this.InventorySlot2.TabIndex = 6;
            this.InventorySlot2.TabStop = false;
            this.InventorySlot2.Click += new System.EventHandler(this.InventorySlot2_Click);
            // 
            // InventorySlot3
            // 
            this.InventorySlot3.BackColor = System.Drawing.Color.Transparent;
            this.InventorySlot3.Location = new System.Drawing.Point(361, 74);
            this.InventorySlot3.Name = "InventorySlot3";
            this.InventorySlot3.Size = new System.Drawing.Size(68, 66);
            this.InventorySlot3.TabIndex = 7;
            this.InventorySlot3.TabStop = false;
            this.InventorySlot3.Click += new System.EventHandler(this.InventorySlot3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(186, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(68, 22);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "Health Pot";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(274, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(68, 22);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "Big Health";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(361, 46);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(68, 22);
            this.textBox3.TabIndex = 10;
            this.textBox3.Text = "Str+ Pot";
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Main.Properties.Resources.BackgroundMain;
            this.ClientSize = new System.Drawing.Size(705, 276);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.InventorySlot3);
            this.Controls.Add(this.InventorySlot2);
            this.Controls.Add(this.InventorySlot1);
            this.Controls.Add(this.StrengthPotCount);
            this.Controls.Add(this.HealthPotBigCount);
            this.Controls.Add(this.HealthPotCount);
            this.Controls.Add(this.coinBox);
            this.Controls.Add(this.inventoryBox);
            this.Name = "Inventory";
            this.Text = "Inventory";
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventorySlot1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventorySlot2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventorySlot3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox inventoryBox;
        private System.Windows.Forms.TextBox coinBox;
        private System.Windows.Forms.RichTextBox HealthPotCount;
        private System.Windows.Forms.RichTextBox HealthPotBigCount;
        private System.Windows.Forms.RichTextBox StrengthPotCount;
        private System.Windows.Forms.PictureBox InventorySlot1;
        private System.Windows.Forms.PictureBox InventorySlot2;
        private System.Windows.Forms.PictureBox InventorySlot3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}