namespace Main
{
    partial class Merchant
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inventoryTab = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.topAnnoBox = new System.Windows.Forms.TextBox();
            this.HealthPotCount = new System.Windows.Forms.RichTextBox();
            this.HealthPotBuy = new System.Windows.Forms.PictureBox();
            this.BigHealthPotBuy = new System.Windows.Forms.PictureBox();
            this.StrengthPotBuy = new System.Windows.Forms.PictureBox();
            this.HealthPotBigCount = new System.Windows.Forms.RichTextBox();
            this.StrengthPotCount = new System.Windows.Forms.RichTextBox();
            this.winBtn = new System.Windows.Forms.Button();
            this.winCostBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthPotBuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BigHealthPotBuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrengthPotBuy)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventoryTab});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(486, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inventoryTab
            // 
            this.inventoryTab.Name = "inventoryTab";
            this.inventoryTab.Size = new System.Drawing.Size(82, 24);
            this.inventoryTab.Text = "Inventory";
            this.inventoryTab.Click += new System.EventHandler(this.inventoryTab_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Main.Properties.Resources.MerchantShop;
            this.pictureBox1.Location = new System.Drawing.Point(51, 95);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(379, 184);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // topAnnoBox
            // 
            this.topAnnoBox.Location = new System.Drawing.Point(123, 48);
            this.topAnnoBox.Name = "topAnnoBox";
            this.topAnnoBox.ReadOnly = true;
            this.topAnnoBox.Size = new System.Drawing.Size(253, 22);
            this.topAnnoBox.TabIndex = 2;
            // 
            // HealthPotCount
            // 
            this.HealthPotCount.Location = new System.Drawing.Point(93, 191);
            this.HealthPotCount.Name = "HealthPotCount";
            this.HealthPotCount.ReadOnly = true;
            this.HealthPotCount.Size = new System.Drawing.Size(67, 22);
            this.HealthPotCount.TabIndex = 3;
            this.HealthPotCount.Text = "";
            // 
            // HealthPotBuy
            // 
            this.HealthPotBuy.Location = new System.Drawing.Point(93, 119);
            this.HealthPotBuy.Name = "HealthPotBuy";
            this.HealthPotBuy.Size = new System.Drawing.Size(68, 66);
            this.HealthPotBuy.TabIndex = 4;
            this.HealthPotBuy.TabStop = false;
            this.HealthPotBuy.Click += new System.EventHandler(this.HealthPotBuy_Click);
            // 
            // BigHealthPotBuy
            // 
            this.BigHealthPotBuy.Location = new System.Drawing.Point(177, 119);
            this.BigHealthPotBuy.Name = "BigHealthPotBuy";
            this.BigHealthPotBuy.Size = new System.Drawing.Size(68, 66);
            this.BigHealthPotBuy.TabIndex = 5;
            this.BigHealthPotBuy.TabStop = false;
            this.BigHealthPotBuy.Click += new System.EventHandler(this.BigHealthPotBuy_Click);
            // 
            // StrengthPotBuy
            // 
            this.StrengthPotBuy.Location = new System.Drawing.Point(263, 119);
            this.StrengthPotBuy.Name = "StrengthPotBuy";
            this.StrengthPotBuy.Size = new System.Drawing.Size(68, 66);
            this.StrengthPotBuy.TabIndex = 6;
            this.StrengthPotBuy.TabStop = false;
            this.StrengthPotBuy.Click += new System.EventHandler(this.StrengthPotBuy_Click);
            // 
            // HealthPotBigCount
            // 
            this.HealthPotBigCount.Location = new System.Drawing.Point(178, 191);
            this.HealthPotBigCount.Name = "HealthPotBigCount";
            this.HealthPotBigCount.ReadOnly = true;
            this.HealthPotBigCount.Size = new System.Drawing.Size(67, 22);
            this.HealthPotBigCount.TabIndex = 7;
            this.HealthPotBigCount.Text = "";
            // 
            // StrengthPotCount
            // 
            this.StrengthPotCount.Location = new System.Drawing.Point(263, 191);
            this.StrengthPotCount.Name = "StrengthPotCount";
            this.StrengthPotCount.ReadOnly = true;
            this.StrengthPotCount.Size = new System.Drawing.Size(67, 22);
            this.StrengthPotCount.TabIndex = 8;
            this.StrengthPotCount.Text = "";
            // 
            // winBtn
            // 
            this.winBtn.Location = new System.Drawing.Point(337, 124);
            this.winBtn.Name = "winBtn";
            this.winBtn.Size = new System.Drawing.Size(81, 61);
            this.winBtn.TabIndex = 9;
            this.winBtn.Text = "Buy Sacred Treasure";
            this.winBtn.UseVisualStyleBackColor = true;
            this.winBtn.Click += new System.EventHandler(this.winBtn_Click);
            // 
            // winCostBox
            // 
            this.winCostBox.Location = new System.Drawing.Point(337, 190);
            this.winCostBox.Name = "winCostBox";
            this.winCostBox.Size = new System.Drawing.Size(81, 22);
            this.winCostBox.TabIndex = 10;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(263, 219);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(68, 22);
            this.textBox3.TabIndex = 13;
            this.textBox3.Text = "Str+ Pot";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(176, 219);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(68, 22);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "Big Health";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 219);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(68, 22);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Health Pot";
            // 
            // Merchant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Main.Properties.Resources.BattleArea1;
            this.ClientSize = new System.Drawing.Size(486, 318);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.winCostBox);
            this.Controls.Add(this.winBtn);
            this.Controls.Add(this.StrengthPotCount);
            this.Controls.Add(this.HealthPotBigCount);
            this.Controls.Add(this.StrengthPotBuy);
            this.Controls.Add(this.BigHealthPotBuy);
            this.Controls.Add(this.HealthPotBuy);
            this.Controls.Add(this.HealthPotCount);
            this.Controls.Add(this.topAnnoBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Merchant";
            this.Text = "Merchant";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthPotBuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BigHealthPotBuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrengthPotBuy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inventoryTab;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox topAnnoBox;
        private System.Windows.Forms.RichTextBox HealthPotCount;
        private System.Windows.Forms.PictureBox HealthPotBuy;
        private System.Windows.Forms.PictureBox BigHealthPotBuy;
        private System.Windows.Forms.PictureBox StrengthPotBuy;
        private System.Windows.Forms.RichTextBox HealthPotBigCount;
        private System.Windows.Forms.RichTextBox StrengthPotCount;
        private System.Windows.Forms.Button winBtn;
        private System.Windows.Forms.TextBox winCostBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}