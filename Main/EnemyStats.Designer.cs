namespace Main
{
    partial class EnemyStats
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
            this.abilityExplainBox = new System.Windows.Forms.RichTextBox();
            this.charImageBox = new System.Windows.Forms.PictureBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.levelBox = new System.Windows.Forms.TextBox();
            this.healthBox = new System.Windows.Forms.TextBox();
            this.attackBox = new System.Windows.Forms.TextBox();
            this.defenceBox = new System.Windows.Forms.TextBox();
            this.dodgeBox = new System.Windows.Forms.TextBox();
            this.attackBtn1 = new System.Windows.Forms.Button();
            this.attackBtn2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.charImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // abilityExplainBox
            // 
            this.abilityExplainBox.Location = new System.Drawing.Point(13, 13);
            this.abilityExplainBox.Name = "abilityExplainBox";
            this.abilityExplainBox.ReadOnly = true;
            this.abilityExplainBox.Size = new System.Drawing.Size(248, 186);
            this.abilityExplainBox.TabIndex = 14;
            this.abilityExplainBox.Text = "";
            // 
            // charImageBox
            // 
            this.charImageBox.BackColor = System.Drawing.Color.Transparent;
            this.charImageBox.Location = new System.Drawing.Point(157, 85);
            this.charImageBox.Name = "charImageBox";
            this.charImageBox.Size = new System.Drawing.Size(100, 100);
            this.charImageBox.TabIndex = 15;
            this.charImageBox.TabStop = false;
            this.charImageBox.MouseLeave += new System.EventHandler(this.charImageBox_MouseLeave);
            this.charImageBox.MouseHover += new System.EventHandler(this.charImageBox_MouseHover);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(34, 20);
            this.nameBox.Name = "nameBox";
            this.nameBox.ReadOnly = true;
            this.nameBox.Size = new System.Drawing.Size(146, 22);
            this.nameBox.TabIndex = 16;
            // 
            // levelBox
            // 
            this.levelBox.Location = new System.Drawing.Point(34, 48);
            this.levelBox.Name = "levelBox";
            this.levelBox.ReadOnly = true;
            this.levelBox.Size = new System.Drawing.Size(69, 22);
            this.levelBox.TabIndex = 17;
            // 
            // healthBox
            // 
            this.healthBox.Location = new System.Drawing.Point(34, 76);
            this.healthBox.Name = "healthBox";
            this.healthBox.ReadOnly = true;
            this.healthBox.Size = new System.Drawing.Size(117, 22);
            this.healthBox.TabIndex = 19;
            // 
            // attackBox
            // 
            this.attackBox.Location = new System.Drawing.Point(34, 104);
            this.attackBox.Name = "attackBox";
            this.attackBox.ReadOnly = true;
            this.attackBox.Size = new System.Drawing.Size(117, 22);
            this.attackBox.TabIndex = 20;
            // 
            // defenceBox
            // 
            this.defenceBox.Location = new System.Drawing.Point(34, 132);
            this.defenceBox.Name = "defenceBox";
            this.defenceBox.ReadOnly = true;
            this.defenceBox.Size = new System.Drawing.Size(117, 22);
            this.defenceBox.TabIndex = 21;
            // 
            // dodgeBox
            // 
            this.dodgeBox.Location = new System.Drawing.Point(34, 160);
            this.dodgeBox.Name = "dodgeBox";
            this.dodgeBox.ReadOnly = true;
            this.dodgeBox.Size = new System.Drawing.Size(117, 22);
            this.dodgeBox.TabIndex = 22;
            // 
            // attackBtn1
            // 
            this.attackBtn1.Location = new System.Drawing.Point(13, 205);
            this.attackBtn1.Name = "attackBtn1";
            this.attackBtn1.Size = new System.Drawing.Size(121, 95);
            this.attackBtn1.TabIndex = 23;
            this.attackBtn1.Text = "button1";
            this.attackBtn1.UseVisualStyleBackColor = true;
            this.attackBtn1.MouseLeave += new System.EventHandler(this.attackBtn1_MouseLeave);
            this.attackBtn1.MouseHover += new System.EventHandler(this.attackBtn1_MouseHover);
            // 
            // attackBtn2
            // 
            this.attackBtn2.Location = new System.Drawing.Point(140, 205);
            this.attackBtn2.Name = "attackBtn2";
            this.attackBtn2.Size = new System.Drawing.Size(121, 95);
            this.attackBtn2.TabIndex = 24;
            this.attackBtn2.Text = "button2";
            this.attackBtn2.UseVisualStyleBackColor = true;
            this.attackBtn2.MouseLeave += new System.EventHandler(this.attackBtn2_MouseLeave);
            this.attackBtn2.MouseHover += new System.EventHandler(this.attackBtn2_MouseHover);
            // 
            // EnemyStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Main.Properties.Resources.BackgroundMain;
            this.ClientSize = new System.Drawing.Size(269, 312);
            this.Controls.Add(this.attackBtn2);
            this.Controls.Add(this.attackBtn1);
            this.Controls.Add(this.dodgeBox);
            this.Controls.Add(this.defenceBox);
            this.Controls.Add(this.attackBox);
            this.Controls.Add(this.healthBox);
            this.Controls.Add(this.levelBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.charImageBox);
            this.Controls.Add(this.abilityExplainBox);
            this.Name = "EnemyStats";
            this.Text = "EnemyStats";
            ((System.ComponentModel.ISupportInitialize)(this.charImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox abilityExplainBox;
        private System.Windows.Forms.PictureBox charImageBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox levelBox;
        private System.Windows.Forms.TextBox healthBox;
        private System.Windows.Forms.TextBox attackBox;
        private System.Windows.Forms.TextBox defenceBox;
        private System.Windows.Forms.TextBox dodgeBox;
        private System.Windows.Forms.Button attackBtn1;
        private System.Windows.Forms.Button attackBtn2;
    }
}