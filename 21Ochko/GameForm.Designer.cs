namespace UserInterface
{
    partial class GameForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.HitButton = new System.Windows.Forms.Button();
            this.StandButton = new System.Windows.Forms.Button();
            this.BetTextBox = new System.Windows.Forms.TextBox();
            this.BetButton = new System.Windows.Forms.Button();
            this.BetLabel = new System.Windows.Forms.Label();
            this.PlayerMoneyLabel = new System.Windows.Forms.Label();
            this.BankerMoneyLabel = new System.Windows.Forms.Label();
            this.PlayerScoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // HitButton
            // 
            this.HitButton.Enabled = false;
            this.HitButton.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HitButton.Location = new System.Drawing.Point(12, 365);
            this.HitButton.Name = "HitButton";
            this.HitButton.Size = new System.Drawing.Size(140, 61);
            this.HitButton.TabIndex = 0;
            this.HitButton.TabStop = false;
            this.HitButton.Text = "Hit";
            this.HitButton.UseVisualStyleBackColor = true;
            this.HitButton.Click += new System.EventHandler(this.Hit_Click);
            // 
            // StandButton
            // 
            this.StandButton.Enabled = false;
            this.StandButton.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StandButton.Location = new System.Drawing.Point(505, 365);
            this.StandButton.Name = "StandButton";
            this.StandButton.Size = new System.Drawing.Size(140, 61);
            this.StandButton.TabIndex = 1;
            this.StandButton.TabStop = false;
            this.StandButton.Text = "Stand";
            this.StandButton.UseVisualStyleBackColor = true;
            this.StandButton.Click += new System.EventHandler(this.Stand_Click);
            // 
            // BetTextBox
            // 
            this.BetTextBox.BackColor = System.Drawing.Color.Honeydew;
            this.BetTextBox.Location = new System.Drawing.Point(263, 339);
            this.BetTextBox.Name = "BetTextBox";
            this.BetTextBox.Size = new System.Drawing.Size(100, 20);
            this.BetTextBox.TabIndex = 2;
            // 
            // BetButton
            // 
            this.BetButton.Location = new System.Drawing.Point(248, 365);
            this.BetButton.Name = "BetButton";
            this.BetButton.Size = new System.Drawing.Size(127, 61);
            this.BetButton.TabIndex = 3;
            this.BetButton.Text = "Bet";
            this.BetButton.UseVisualStyleBackColor = true;
            this.BetButton.Click += new System.EventHandler(this.BetButton_Click);
            // 
            // BetLabel
            // 
            this.BetLabel.AutoSize = true;
            this.BetLabel.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BetLabel.Location = new System.Drawing.Point(268, 9);
            this.BetLabel.Name = "BetLabel";
            this.BetLabel.Size = new System.Drawing.Size(0, 25);
            this.BetLabel.TabIndex = 4;
            // 
            // PlayerMoneyLabel
            // 
            this.PlayerMoneyLabel.AutoSize = true;
            this.PlayerMoneyLabel.Location = new System.Drawing.Point(180, 389);
            this.PlayerMoneyLabel.Name = "PlayerMoneyLabel";
            this.PlayerMoneyLabel.Size = new System.Drawing.Size(35, 13);
            this.PlayerMoneyLabel.TabIndex = 5;
            this.PlayerMoneyLabel.Text = "label1";
            // 
            // BankerMoneyLabel
            // 
            this.BankerMoneyLabel.AutoSize = true;
            this.BankerMoneyLabel.Location = new System.Drawing.Point(191, 21);
            this.BankerMoneyLabel.Name = "BankerMoneyLabel";
            this.BankerMoneyLabel.Size = new System.Drawing.Size(35, 13);
            this.BankerMoneyLabel.TabIndex = 6;
            this.BankerMoneyLabel.Text = "label1";
            // 
            // PlayerScoreLabel
            // 
            this.PlayerScoreLabel.AutoSize = true;
            this.PlayerScoreLabel.Location = new System.Drawing.Point(420, 389);
            this.PlayerScoreLabel.Name = "PlayerScoreLabel";
            this.PlayerScoreLabel.Size = new System.Drawing.Size(35, 13);
            this.PlayerScoreLabel.TabIndex = 7;
            this.PlayerScoreLabel.Text = "label1";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(657, 435);
            this.Controls.Add(this.PlayerScoreLabel);
            this.Controls.Add(this.BankerMoneyLabel);
            this.Controls.Add(this.PlayerMoneyLabel);
            this.Controls.Add(this.BetLabel);
            this.Controls.Add(this.BetButton);
            this.Controls.Add(this.BetTextBox);
            this.Controls.Add(this.StandButton);
            this.Controls.Add(this.HitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игра \"двадцать одно\"";
            this.Shown += new System.EventHandler(this.GameForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button HitButton;
        private System.Windows.Forms.Button StandButton;
        private System.Windows.Forms.TextBox BetTextBox;
        private System.Windows.Forms.Button BetButton;
        private System.Windows.Forms.Label BetLabel;
        private System.Windows.Forms.Label PlayerMoneyLabel;
        private System.Windows.Forms.Label BankerMoneyLabel;
        private System.Windows.Forms.Label PlayerScoreLabel;
    }
}

