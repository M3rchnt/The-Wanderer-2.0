namespace Main
{
    partial class Battle
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
            this.fileTab = new System.Windows.Forms.ToolStripMenuItem();
            this.exitTab = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutTab = new System.Windows.Forms.ToolStripMenuItem();
            this.charStatsTab = new System.Windows.Forms.ToolStripMenuItem();
            this.enemyStatsTab = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorialTab = new System.Windows.Forms.ToolStripMenuItem();
            this.battleAnnoBox = new System.Windows.Forms.TextBox();
            this.enemyImageBox = new System.Windows.Forms.PictureBox();
            this.charImageBox = new System.Windows.Forms.PictureBox();
            this.charActionBox = new System.Windows.Forms.TextBox();
            this.enemyActionBox = new System.Windows.Forms.TextBox();
            this.charHealthBox = new System.Windows.Forms.TextBox();
            this.enemyHealthBox = new System.Windows.Forms.TextBox();
            this.attackBtn1 = new System.Windows.Forms.Button();
            this.attackBtn2 = new System.Windows.Forms.Button();
            this.attackBtn3 = new System.Windows.Forms.Button();
            this.attackBtn4 = new System.Windows.Forms.Button();
            this.turnEndBtn = new System.Windows.Forms.Button();
            this.charStatusEffectsBox = new System.Windows.Forms.RichTextBox();
            this.enemyStatusEffectsBox = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.exitbattlebtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enemyImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventoryTab,
            this.fileTab,
            this.charStatsTab,
            this.enemyStatsTab,
            this.tutorialTab});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
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
            // fileTab
            // 
            this.fileTab.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitTab,
            this.aboutTab});
            this.fileTab.Name = "fileTab";
            this.fileTab.Size = new System.Drawing.Size(44, 24);
            this.fileTab.Text = "File";
            // 
            // exitTab
            // 
            this.exitTab.Name = "exitTab";
            this.exitTab.Size = new System.Drawing.Size(125, 26);
            this.exitTab.Text = "Exit";
            this.exitTab.Click += new System.EventHandler(this.exitTab_Click);
            // 
            // aboutTab
            // 
            this.aboutTab.Name = "aboutTab";
            this.aboutTab.Size = new System.Drawing.Size(125, 26);
            this.aboutTab.Text = "About";
            this.aboutTab.Click += new System.EventHandler(this.aboutTab_Click);
            // 
            // charStatsTab
            // 
            this.charStatsTab.Name = "charStatsTab";
            this.charStatsTab.Size = new System.Drawing.Size(97, 24);
            this.charStatsTab.Text = "Player Stats";
            this.charStatsTab.Click += new System.EventHandler(this.charStatsTab_Click);
            // 
            // enemyStatsTab
            // 
            this.enemyStatsTab.Name = "enemyStatsTab";
            this.enemyStatsTab.Size = new System.Drawing.Size(101, 24);
            this.enemyStatsTab.Text = "Enemy Stats";
            this.enemyStatsTab.Click += new System.EventHandler(this.enemyStatsTab_Click);
            // 
            // tutorialTab
            // 
            this.tutorialTab.Name = "tutorialTab";
            this.tutorialTab.Size = new System.Drawing.Size(115, 24);
            this.tutorialTab.Text = "Battle Tutorial";
            this.tutorialTab.Click += new System.EventHandler(this.tutorialTab_Click);
            // 
            // battleAnnoBox
            // 
            this.battleAnnoBox.Location = new System.Drawing.Point(259, 60);
            this.battleAnnoBox.Name = "battleAnnoBox";
            this.battleAnnoBox.ReadOnly = true;
            this.battleAnnoBox.Size = new System.Drawing.Size(273, 22);
            this.battleAnnoBox.TabIndex = 1;
            // 
            // enemyImageBox
            // 
            this.enemyImageBox.BackColor = System.Drawing.Color.LightSeaGreen;
            this.enemyImageBox.Location = new System.Drawing.Point(688, 48);
            this.enemyImageBox.Name = "enemyImageBox";
            this.enemyImageBox.Size = new System.Drawing.Size(100, 100);
            this.enemyImageBox.TabIndex = 3;
            this.enemyImageBox.TabStop = false;
            // 
            // charImageBox
            // 
            this.charImageBox.BackColor = System.Drawing.Color.LightSeaGreen;
            this.charImageBox.Location = new System.Drawing.Point(12, 48);
            this.charImageBox.Name = "charImageBox";
            this.charImageBox.Size = new System.Drawing.Size(100, 100);
            this.charImageBox.TabIndex = 2;
            this.charImageBox.TabStop = false;
            // 
            // charActionBox
            // 
            this.charActionBox.Location = new System.Drawing.Point(222, 102);
            this.charActionBox.Name = "charActionBox";
            this.charActionBox.ReadOnly = true;
            this.charActionBox.Size = new System.Drawing.Size(155, 22);
            this.charActionBox.TabIndex = 4;
            // 
            // enemyActionBox
            // 
            this.enemyActionBox.Location = new System.Drawing.Point(423, 102);
            this.enemyActionBox.Name = "enemyActionBox";
            this.enemyActionBox.ReadOnly = true;
            this.enemyActionBox.Size = new System.Drawing.Size(155, 22);
            this.enemyActionBox.TabIndex = 5;
            // 
            // charHealthBox
            // 
            this.charHealthBox.Location = new System.Drawing.Point(222, 148);
            this.charHealthBox.Name = "charHealthBox";
            this.charHealthBox.ReadOnly = true;
            this.charHealthBox.Size = new System.Drawing.Size(155, 22);
            this.charHealthBox.TabIndex = 6;
            // 
            // enemyHealthBox
            // 
            this.enemyHealthBox.Location = new System.Drawing.Point(423, 148);
            this.enemyHealthBox.Name = "enemyHealthBox";
            this.enemyHealthBox.ReadOnly = true;
            this.enemyHealthBox.Size = new System.Drawing.Size(155, 22);
            this.enemyHealthBox.TabIndex = 7;
            // 
            // attackBtn1
            // 
            this.attackBtn1.Location = new System.Drawing.Point(37, 264);
            this.attackBtn1.Name = "attackBtn1";
            this.attackBtn1.Size = new System.Drawing.Size(129, 77);
            this.attackBtn1.TabIndex = 8;
            this.attackBtn1.Text = "button1";
            this.attackBtn1.UseVisualStyleBackColor = true;
            this.attackBtn1.Click += new System.EventHandler(this.attackBtn1_Click);
            // 
            // attackBtn2
            // 
            this.attackBtn2.Location = new System.Drawing.Point(222, 264);
            this.attackBtn2.Name = "attackBtn2";
            this.attackBtn2.Size = new System.Drawing.Size(129, 77);
            this.attackBtn2.TabIndex = 9;
            this.attackBtn2.Text = "button2";
            this.attackBtn2.UseVisualStyleBackColor = true;
            this.attackBtn2.Click += new System.EventHandler(this.attackBtn2_Click);
            // 
            // attackBtn3
            // 
            this.attackBtn3.Location = new System.Drawing.Point(37, 361);
            this.attackBtn3.Name = "attackBtn3";
            this.attackBtn3.Size = new System.Drawing.Size(129, 77);
            this.attackBtn3.TabIndex = 10;
            this.attackBtn3.Text = "button3";
            this.attackBtn3.UseVisualStyleBackColor = true;
            this.attackBtn3.Click += new System.EventHandler(this.attackBtn3_Click);
            // 
            // attackBtn4
            // 
            this.attackBtn4.Location = new System.Drawing.Point(222, 361);
            this.attackBtn4.Name = "attackBtn4";
            this.attackBtn4.Size = new System.Drawing.Size(129, 77);
            this.attackBtn4.TabIndex = 11;
            this.attackBtn4.Text = "button4";
            this.attackBtn4.UseVisualStyleBackColor = true;
            this.attackBtn4.Click += new System.EventHandler(this.attackBtn4_Click);
            // 
            // turnEndBtn
            // 
            this.turnEndBtn.Location = new System.Drawing.Point(462, 274);
            this.turnEndBtn.Name = "turnEndBtn";
            this.turnEndBtn.Size = new System.Drawing.Size(145, 90);
            this.turnEndBtn.TabIndex = 12;
            this.turnEndBtn.Text = "Next Turn";
            this.turnEndBtn.UseVisualStyleBackColor = true;
            this.turnEndBtn.Click += new System.EventHandler(this.turnEndBtn_Click);
            // 
            // charStatusEffectsBox
            // 
            this.charStatusEffectsBox.Location = new System.Drawing.Point(26, 163);
            this.charStatusEffectsBox.Name = "charStatusEffectsBox";
            this.charStatusEffectsBox.ReadOnly = true;
            this.charStatusEffectsBox.Size = new System.Drawing.Size(190, 95);
            this.charStatusEffectsBox.TabIndex = 13;
            this.charStatusEffectsBox.Text = "";
            // 
            // enemyStatusEffectsBox
            // 
            this.enemyStatusEffectsBox.Location = new System.Drawing.Point(584, 163);
            this.enemyStatusEffectsBox.Name = "enemyStatusEffectsBox";
            this.enemyStatusEffectsBox.ReadOnly = true;
            this.enemyStatusEffectsBox.Size = new System.Drawing.Size(190, 95);
            this.enemyStatusEffectsBox.TabIndex = 14;
            this.enemyStatusEffectsBox.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(115, 126);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(101, 22);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "Status Effects:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(584, 126);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(101, 22);
            this.textBox2.TabIndex = 17;
            this.textBox2.Text = "Status Effects:";
            // 
            // exitbattlebtn
            // 
            this.exitbattlebtn.Location = new System.Drawing.Point(338, 307);
            this.exitbattlebtn.Name = "exitbattlebtn";
            this.exitbattlebtn.Size = new System.Drawing.Size(129, 77);
            this.exitbattlebtn.TabIndex = 18;
            this.exitbattlebtn.Text = "Exit Battle";
            this.exitbattlebtn.UseVisualStyleBackColor = true;
            this.exitbattlebtn.Visible = false;
            this.exitbattlebtn.Click += new System.EventHandler(this.exitbattlebtn_Click);
            // 
            // Battle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Main.Properties.Resources.BattleArea1;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exitbattlebtn);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.enemyStatusEffectsBox);
            this.Controls.Add(this.charStatusEffectsBox);
            this.Controls.Add(this.turnEndBtn);
            this.Controls.Add(this.attackBtn4);
            this.Controls.Add(this.attackBtn3);
            this.Controls.Add(this.attackBtn2);
            this.Controls.Add(this.attackBtn1);
            this.Controls.Add(this.enemyHealthBox);
            this.Controls.Add(this.charHealthBox);
            this.Controls.Add(this.enemyActionBox);
            this.Controls.Add(this.charActionBox);
            this.Controls.Add(this.enemyImageBox);
            this.Controls.Add(this.charImageBox);
            this.Controls.Add(this.battleAnnoBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Battle";
            this.Text = "Battle";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enemyImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inventoryTab;
        private System.Windows.Forms.ToolStripMenuItem fileTab;
        private System.Windows.Forms.TextBox battleAnnoBox;
        private System.Windows.Forms.PictureBox charImageBox;
        private System.Windows.Forms.PictureBox enemyImageBox;
        private System.Windows.Forms.ToolStripMenuItem exitTab;
        private System.Windows.Forms.ToolStripMenuItem aboutTab;
        private System.Windows.Forms.ToolStripMenuItem charStatsTab;
        private System.Windows.Forms.ToolStripMenuItem enemyStatsTab;
        private System.Windows.Forms.TextBox charActionBox;
        private System.Windows.Forms.TextBox enemyActionBox;
        private System.Windows.Forms.TextBox charHealthBox;
        private System.Windows.Forms.TextBox enemyHealthBox;
        private System.Windows.Forms.Button attackBtn1;
        private System.Windows.Forms.Button attackBtn2;
        private System.Windows.Forms.Button attackBtn3;
        private System.Windows.Forms.Button attackBtn4;
        private System.Windows.Forms.Button turnEndBtn;
        private System.Windows.Forms.RichTextBox charStatusEffectsBox;
        private System.Windows.Forms.RichTextBox enemyStatusEffectsBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolStripMenuItem tutorialTab;
        private System.Windows.Forms.Button exitbattlebtn;
    }
}