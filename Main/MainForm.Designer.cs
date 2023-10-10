namespace Main
{
    partial class MainForm
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
            this.saveTab = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTab = new System.Windows.Forms.ToolStripMenuItem();
            this.charStatsTab = new System.Windows.Forms.ToolStripMenuItem();
            this.titlePictureBox = new System.Windows.Forms.PictureBox();
            this.topAnnoBox = new System.Windows.Forms.TextBox();
            this.charImageBox1 = new System.Windows.Forms.PictureBox();
            this.charImageBox2 = new System.Windows.Forms.PictureBox();
            this.charImageBox3 = new System.Windows.Forms.PictureBox();
            this.nameInputBox = new System.Windows.Forms.TextBox();
            this.confirmNameBtn = new System.Windows.Forms.Button();
            this.charNameBox1 = new System.Windows.Forms.TextBox();
            this.charNameBox2 = new System.Windows.Forms.TextBox();
            this.charNameBox3 = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.titlePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charImageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charImageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charImageBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventoryTab,
            this.fileTab,
            this.charStatsTab});
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
            this.aboutTab,
            this.saveTab,
            this.loadTab});
            this.fileTab.Name = "fileTab";
            this.fileTab.Size = new System.Drawing.Size(44, 24);
            this.fileTab.Text = "File";
            // 
            // exitTab
            // 
            this.exitTab.Name = "exitTab";
            this.exitTab.Size = new System.Drawing.Size(144, 26);
            this.exitTab.Text = "Exit";
            this.exitTab.Click += new System.EventHandler(this.exitTab_Click);
            // 
            // aboutTab
            // 
            this.aboutTab.Name = "aboutTab";
            this.aboutTab.Size = new System.Drawing.Size(144, 26);
            this.aboutTab.Text = "About";
            this.aboutTab.Click += new System.EventHandler(this.aboutTab_Click);
            // 
            // saveTab
            // 
            this.saveTab.Name = "saveTab";
            this.saveTab.Size = new System.Drawing.Size(144, 26);
            this.saveTab.Text = "Save File";
            this.saveTab.Click += new System.EventHandler(this.saveTab_Click);
            // 
            // loadTab
            // 
            this.loadTab.Name = "loadTab";
            this.loadTab.Size = new System.Drawing.Size(144, 26);
            this.loadTab.Text = "Load File";
            this.loadTab.Click += new System.EventHandler(this.loadTab_Click);
            // 
            // charStatsTab
            // 
            this.charStatsTab.Name = "charStatsTab";
            this.charStatsTab.Size = new System.Drawing.Size(97, 24);
            this.charStatsTab.Text = "Player Stats";
            this.charStatsTab.Click += new System.EventHandler(this.charStatsTab_Click);
            // 
            // titlePictureBox
            // 
            this.titlePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.titlePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.titlePictureBox.Location = new System.Drawing.Point(203, 93);
            this.titlePictureBox.Name = "titlePictureBox";
            this.titlePictureBox.Size = new System.Drawing.Size(400, 300);
            this.titlePictureBox.TabIndex = 1;
            this.titlePictureBox.TabStop = false;
            this.titlePictureBox.Click += new System.EventHandler(this.titlePictureBox_Click);
            // 
            // topAnnoBox
            // 
            this.topAnnoBox.Location = new System.Drawing.Point(273, 42);
            this.topAnnoBox.Name = "topAnnoBox";
            this.topAnnoBox.ReadOnly = true;
            this.topAnnoBox.Size = new System.Drawing.Size(273, 22);
            this.topAnnoBox.TabIndex = 2;
            this.topAnnoBox.Text = "Enter Your Character\'s Name:";
            this.topAnnoBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // charImageBox1
            // 
            this.charImageBox1.BackColor = System.Drawing.Color.Transparent;
            this.charImageBox1.Location = new System.Drawing.Point(152, 187);
            this.charImageBox1.Name = "charImageBox1";
            this.charImageBox1.Size = new System.Drawing.Size(45, 64);
            this.charImageBox1.TabIndex = 3;
            this.charImageBox1.TabStop = false;
            this.charImageBox1.Click += new System.EventHandler(this.charImageBox1_Click);
            this.charImageBox1.MouseLeave += new System.EventHandler(this.charImageBox1_MouseLeave);
            this.charImageBox1.MouseHover += new System.EventHandler(this.charImageBox1_MouseHover);
            // 
            // charImageBox2
            // 
            this.charImageBox2.BackColor = System.Drawing.Color.Transparent;
            this.charImageBox2.Location = new System.Drawing.Point(366, 187);
            this.charImageBox2.Name = "charImageBox2";
            this.charImageBox2.Size = new System.Drawing.Size(67, 64);
            this.charImageBox2.TabIndex = 4;
            this.charImageBox2.TabStop = false;
            this.charImageBox2.Click += new System.EventHandler(this.charImageBox2_Click);
            this.charImageBox2.MouseLeave += new System.EventHandler(this.charImageBox2_MouseLeave);
            this.charImageBox2.MouseHover += new System.EventHandler(this.charImageBox2_MouseHover);
            // 
            // charImageBox3
            // 
            this.charImageBox3.BackColor = System.Drawing.Color.Transparent;
            this.charImageBox3.Location = new System.Drawing.Point(596, 174);
            this.charImageBox3.Name = "charImageBox3";
            this.charImageBox3.Size = new System.Drawing.Size(81, 77);
            this.charImageBox3.TabIndex = 5;
            this.charImageBox3.TabStop = false;
            this.charImageBox3.Click += new System.EventHandler(this.charImageBox3_Click);
            this.charImageBox3.MouseLeave += new System.EventHandler(this.charImageBox3_MouseLeave);
            this.charImageBox3.MouseHover += new System.EventHandler(this.charImageBox3_MouseHover);
            // 
            // nameInputBox
            // 
            this.nameInputBox.Location = new System.Drawing.Point(273, 70);
            this.nameInputBox.Name = "nameInputBox";
            this.nameInputBox.Size = new System.Drawing.Size(273, 22);
            this.nameInputBox.TabIndex = 6;
            // 
            // confirmNameBtn
            // 
            this.confirmNameBtn.Location = new System.Drawing.Point(349, 112);
            this.confirmNameBtn.Name = "confirmNameBtn";
            this.confirmNameBtn.Size = new System.Drawing.Size(114, 53);
            this.confirmNameBtn.TabIndex = 7;
            this.confirmNameBtn.Text = "Confirm";
            this.confirmNameBtn.UseVisualStyleBackColor = true;
            this.confirmNameBtn.Click += new System.EventHandler(this.confirmNameBtn_Click);
            // 
            // charNameBox1
            // 
            this.charNameBox1.Location = new System.Drawing.Point(122, 258);
            this.charNameBox1.Name = "charNameBox1";
            this.charNameBox1.ReadOnly = true;
            this.charNameBox1.Size = new System.Drawing.Size(108, 22);
            this.charNameBox1.TabIndex = 9;
            this.charNameBox1.Text = "The Warrior";
            this.charNameBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.charNameBox1.MouseHover += new System.EventHandler(this.charNameBox1_MouseHover);
            // 
            // charNameBox2
            // 
            this.charNameBox2.Location = new System.Drawing.Point(349, 258);
            this.charNameBox2.Name = "charNameBox2";
            this.charNameBox2.ReadOnly = true;
            this.charNameBox2.Size = new System.Drawing.Size(108, 22);
            this.charNameBox2.TabIndex = 10;
            this.charNameBox2.Text = "The Archer";
            this.charNameBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.charNameBox2.MouseHover += new System.EventHandler(this.charNameBox2_MouseHover);
            // 
            // charNameBox3
            // 
            this.charNameBox3.Location = new System.Drawing.Point(580, 258);
            this.charNameBox3.Name = "charNameBox3";
            this.charNameBox3.ReadOnly = true;
            this.charNameBox3.Size = new System.Drawing.Size(108, 22);
            this.charNameBox3.TabIndex = 11;
            this.charNameBox3.Text = "The Spear";
            this.charNameBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.charNameBox3.MouseHover += new System.EventHandler(this.charNameBox3_MouseHover);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(310, 212);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(184, 114);
            this.searchBtn.TabIndex = 12;
            this.searchBtn.Text = "Search Area";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.BackgroundImage = global::Main.Properties.Resources.BackgroundMain;
            this.ClientSize = new System.Drawing.Size(800, 519);
            this.Controls.Add(this.charNameBox3);
            this.Controls.Add(this.charNameBox2);
            this.Controls.Add(this.charNameBox1);
            this.Controls.Add(this.confirmNameBtn);
            this.Controls.Add(this.nameInputBox);
            this.Controls.Add(this.charImageBox3);
            this.Controls.Add(this.charImageBox2);
            this.Controls.Add(this.charImageBox1);
            this.Controls.Add(this.topAnnoBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.titlePictureBox);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "The Wanderer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.titlePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charImageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charImageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charImageBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inventoryTab;
        private System.Windows.Forms.ToolStripMenuItem fileTab;
        private System.Windows.Forms.ToolStripMenuItem exitTab;
        private System.Windows.Forms.ToolStripMenuItem aboutTab;
        private System.Windows.Forms.PictureBox titlePictureBox;
        private System.Windows.Forms.TextBox topAnnoBox;
        private System.Windows.Forms.PictureBox charImageBox1;
        private System.Windows.Forms.PictureBox charImageBox2;
        private System.Windows.Forms.PictureBox charImageBox3;
        private System.Windows.Forms.ToolStripMenuItem charStatsTab;
        private System.Windows.Forms.TextBox nameInputBox;
        private System.Windows.Forms.Button confirmNameBtn;
        private System.Windows.Forms.TextBox charNameBox1;
        private System.Windows.Forms.TextBox charNameBox2;
        private System.Windows.Forms.TextBox charNameBox3;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.ToolStripMenuItem saveTab;
        private System.Windows.Forms.ToolStripMenuItem loadTab;
    }
}

