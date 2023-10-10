namespace Main
{
    partial class Tutorial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tutorial));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.enemyStatusEffectsBox = new System.Windows.Forms.RichTextBox();
            this.charStatusEffectsBox = new System.Windows.Forms.RichTextBox();
            this.turnEndBtn = new System.Windows.Forms.Button();
            this.attackBtn4 = new System.Windows.Forms.Button();
            this.attackBtn3 = new System.Windows.Forms.Button();
            this.attackBtn2 = new System.Windows.Forms.Button();
            this.attackBtn1 = new System.Windows.Forms.Button();
            this.enemyHealthBox = new System.Windows.Forms.TextBox();
            this.charHealthBox = new System.Windows.Forms.TextBox();
            this.enemyActionBox = new System.Windows.Forms.TextBox();
            this.charActionBox = new System.Windows.Forms.TextBox();
            this.battleAnnoBox = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(584, 108);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(101, 22);
            this.textBox2.TabIndex = 33;
            this.textBox2.Text = "Status Effects:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(115, 108);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(101, 22);
            this.textBox1.TabIndex = 32;
            this.textBox1.Text = "Status Effects:";
            // 
            // enemyStatusEffectsBox
            // 
            this.enemyStatusEffectsBox.Location = new System.Drawing.Point(584, 145);
            this.enemyStatusEffectsBox.Name = "enemyStatusEffectsBox";
            this.enemyStatusEffectsBox.ReadOnly = true;
            this.enemyStatusEffectsBox.Size = new System.Drawing.Size(190, 95);
            this.enemyStatusEffectsBox.TabIndex = 31;
            this.enemyStatusEffectsBox.Text = "Enemy\'s Active Status Effects";
            // 
            // charStatusEffectsBox
            // 
            this.charStatusEffectsBox.Location = new System.Drawing.Point(26, 145);
            this.charStatusEffectsBox.Name = "charStatusEffectsBox";
            this.charStatusEffectsBox.ReadOnly = true;
            this.charStatusEffectsBox.Size = new System.Drawing.Size(190, 95);
            this.charStatusEffectsBox.TabIndex = 30;
            this.charStatusEffectsBox.Text = "Player\'s Active Status Effects";
            // 
            // turnEndBtn
            // 
            this.turnEndBtn.Location = new System.Drawing.Point(462, 256);
            this.turnEndBtn.Name = "turnEndBtn";
            this.turnEndBtn.Size = new System.Drawing.Size(145, 90);
            this.turnEndBtn.TabIndex = 29;
            this.turnEndBtn.Text = "Enemy\'s Turn";
            this.turnEndBtn.UseVisualStyleBackColor = true;
            // 
            // attackBtn4
            // 
            this.attackBtn4.Location = new System.Drawing.Point(222, 343);
            this.attackBtn4.Name = "attackBtn4";
            this.attackBtn4.Size = new System.Drawing.Size(129, 77);
            this.attackBtn4.TabIndex = 28;
            this.attackBtn4.Text = "Player\'s Fourth Attack";
            this.attackBtn4.UseVisualStyleBackColor = true;
            // 
            // attackBtn3
            // 
            this.attackBtn3.Location = new System.Drawing.Point(37, 343);
            this.attackBtn3.Name = "attackBtn3";
            this.attackBtn3.Size = new System.Drawing.Size(129, 77);
            this.attackBtn3.TabIndex = 27;
            this.attackBtn3.Text = "Player\'s Third Attack";
            this.attackBtn3.UseVisualStyleBackColor = true;
            // 
            // attackBtn2
            // 
            this.attackBtn2.Location = new System.Drawing.Point(222, 246);
            this.attackBtn2.Name = "attackBtn2";
            this.attackBtn2.Size = new System.Drawing.Size(129, 77);
            this.attackBtn2.TabIndex = 26;
            this.attackBtn2.Text = "Player\'s Second Attack";
            this.attackBtn2.UseVisualStyleBackColor = true;
            // 
            // attackBtn1
            // 
            this.attackBtn1.Location = new System.Drawing.Point(37, 246);
            this.attackBtn1.Name = "attackBtn1";
            this.attackBtn1.Size = new System.Drawing.Size(129, 77);
            this.attackBtn1.TabIndex = 25;
            this.attackBtn1.Text = "Player\'s First Attack";
            this.attackBtn1.UseVisualStyleBackColor = true;
            // 
            // enemyHealthBox
            // 
            this.enemyHealthBox.Location = new System.Drawing.Point(423, 130);
            this.enemyHealthBox.Name = "enemyHealthBox";
            this.enemyHealthBox.ReadOnly = true;
            this.enemyHealthBox.Size = new System.Drawing.Size(155, 22);
            this.enemyHealthBox.TabIndex = 24;
            this.enemyHealthBox.Text = "Enemy\'s Health";
            // 
            // charHealthBox
            // 
            this.charHealthBox.Location = new System.Drawing.Point(222, 130);
            this.charHealthBox.Name = "charHealthBox";
            this.charHealthBox.ReadOnly = true;
            this.charHealthBox.Size = new System.Drawing.Size(155, 22);
            this.charHealthBox.TabIndex = 23;
            this.charHealthBox.Text = "Player\'s Health";
            // 
            // enemyActionBox
            // 
            this.enemyActionBox.Location = new System.Drawing.Point(423, 84);
            this.enemyActionBox.Name = "enemyActionBox";
            this.enemyActionBox.ReadOnly = true;
            this.enemyActionBox.Size = new System.Drawing.Size(155, 22);
            this.enemyActionBox.TabIndex = 22;
            this.enemyActionBox.Text = "Enemy\'s Hits / Dodges";
            // 
            // charActionBox
            // 
            this.charActionBox.Location = new System.Drawing.Point(222, 84);
            this.charActionBox.Name = "charActionBox";
            this.charActionBox.ReadOnly = true;
            this.charActionBox.Size = new System.Drawing.Size(155, 22);
            this.charActionBox.TabIndex = 21;
            this.charActionBox.Text = "Player\'s Hits / Dodges";
            // 
            // battleAnnoBox
            // 
            this.battleAnnoBox.Location = new System.Drawing.Point(259, 42);
            this.battleAnnoBox.Name = "battleAnnoBox";
            this.battleAnnoBox.ReadOnly = true;
            this.battleAnnoBox.Size = new System.Drawing.Size(273, 22);
            this.battleAnnoBox.TabIndex = 18;
            this.battleAnnoBox.Text = "Moves for both players are displayed here";
            this.battleAnnoBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(614, 256);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(174, 182);
            this.richTextBox1.TabIndex = 34;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(214, 14);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(371, 22);
            this.textBox3.TabIndex = 35;
            this.textBox3.Text = "Please note that items can only be used outside of battle";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Tutorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.richTextBox1);
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
            this.Controls.Add(this.battleAnnoBox);
            this.Name = "Tutorial";
            this.Text = "Tutorial";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox enemyStatusEffectsBox;
        private System.Windows.Forms.RichTextBox charStatusEffectsBox;
        private System.Windows.Forms.Button turnEndBtn;
        private System.Windows.Forms.Button attackBtn4;
        private System.Windows.Forms.Button attackBtn3;
        private System.Windows.Forms.Button attackBtn2;
        private System.Windows.Forms.Button attackBtn1;
        private System.Windows.Forms.TextBox enemyHealthBox;
        private System.Windows.Forms.TextBox charHealthBox;
        private System.Windows.Forms.TextBox enemyActionBox;
        private System.Windows.Forms.TextBox charActionBox;
        private System.Windows.Forms.TextBox battleAnnoBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox3;
    }
}