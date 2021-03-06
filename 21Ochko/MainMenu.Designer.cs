﻿namespace UserInterface
{
    partial class MainMenu
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
            this.StartGameButton = new System.Windows.Forms.Button();
            this.ConnectButten = new System.Windows.Forms.Button();
            this.ConnectTextBox = new System.Windows.Forms.TextBox();
            this.PlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.ChangeNameButton = new System.Windows.Forms.Button();
            this.UserMoneyLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.NewUserNameLabel = new System.Windows.Forms.Label();
            this.LoadUserButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartGameButton
            // 
            this.StartGameButton.Location = new System.Drawing.Point(78, 172);
            this.StartGameButton.Margin = new System.Windows.Forms.Padding(4);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(212, 42);
            this.StartGameButton.TabIndex = 0;
            this.StartGameButton.Text = "Начать игру";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // ConnectButten
            // 
            this.ConnectButten.Location = new System.Drawing.Point(78, 500);
            this.ConnectButten.Margin = new System.Windows.Forms.Padding(4);
            this.ConnectButten.Name = "ConnectButten";
            this.ConnectButten.Size = new System.Drawing.Size(212, 42);
            this.ConnectButten.TabIndex = 1;
            this.ConnectButten.Text = "Подключиться";
            this.ConnectButten.UseVisualStyleBackColor = true;
            this.ConnectButten.Click += new System.EventHandler(this.ConnectButten_Click);
            // 
            // ConnectTextBox
            // 
            this.ConnectTextBox.Location = new System.Drawing.Point(78, 470);
            this.ConnectTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ConnectTextBox.Name = "ConnectTextBox";
            this.ConnectTextBox.Size = new System.Drawing.Size(212, 22);
            this.ConnectTextBox.TabIndex = 2;
            // 
            // PlayerNameTextBox
            // 
            this.PlayerNameTextBox.Location = new System.Drawing.Point(78, 271);
            this.PlayerNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PlayerNameTextBox.Name = "PlayerNameTextBox";
            this.PlayerNameTextBox.Size = new System.Drawing.Size(212, 22);
            this.PlayerNameTextBox.TabIndex = 3;
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserNameLabel.Location = new System.Drawing.Point(75, 54);
            this.UserNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(196, 28);
            this.UserNameLabel.TabIndex = 5;
            this.UserNameLabel.Text = "Имя пользователя";
            // 
            // ChangeNameButton
            // 
            this.ChangeNameButton.Location = new System.Drawing.Point(78, 301);
            this.ChangeNameButton.Margin = new System.Windows.Forms.Padding(4);
            this.ChangeNameButton.Name = "ChangeNameButton";
            this.ChangeNameButton.Size = new System.Drawing.Size(212, 42);
            this.ChangeNameButton.TabIndex = 4;
            this.ChangeNameButton.Text = "Сменить имя";
            this.ChangeNameButton.UseVisualStyleBackColor = true;
            this.ChangeNameButton.Click += new System.EventHandler(this.ChangeNameButton_Click);
            // 
            // UserMoneyLabel
            // 
            this.UserMoneyLabel.AutoSize = true;
            this.UserMoneyLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.UserMoneyLabel.Location = new System.Drawing.Point(75, 102);
            this.UserMoneyLabel.Name = "UserMoneyLabel";
            this.UserMoneyLabel.Size = new System.Drawing.Size(224, 28);
            this.UserMoneyLabel.TabIndex = 6;
            this.UserMoneyLabel.Text = "Деньги пользователя";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(75, 449);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(45, 17);
            this.PortLabel.TabIndex = 7;
            this.PortLabel.Text = "Порт:";
            // 
            // NewUserNameLabel
            // 
            this.NewUserNameLabel.AutoSize = true;
            this.NewUserNameLabel.Location = new System.Drawing.Point(75, 250);
            this.NewUserNameLabel.Name = "NewUserNameLabel";
            this.NewUserNameLabel.Size = new System.Drawing.Size(82, 17);
            this.NewUserNameLabel.TabIndex = 8;
            this.NewUserNameLabel.Text = "Новое имя:";
            // 
            // LoadUserButton
            // 
            this.LoadUserButton.Location = new System.Drawing.Point(78, 350);
            this.LoadUserButton.Name = "LoadUserButton";
            this.LoadUserButton.Size = new System.Drawing.Size(212, 43);
            this.LoadUserButton.TabIndex = 9;
            this.LoadUserButton.Text = "Загрузить";
            this.LoadUserButton.UseVisualStyleBackColor = true;
            this.LoadUserButton.Click += new System.EventHandler(this.LoadUserButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 570);
            this.Controls.Add(this.LoadUserButton);
            this.Controls.Add(this.NewUserNameLabel);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.UserMoneyLabel);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.ChangeNameButton);
            this.Controls.Add(this.PlayerNameTextBox);
            this.Controls.Add(this.ConnectTextBox);
            this.Controls.Add(this.ConnectButten);
            this.Controls.Add(this.StartGameButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainMenu";
            this.Text = "Главное Меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.TextBox ConnectTextBox;
        private System.Windows.Forms.Button ConnectButten;
        private System.Windows.Forms.TextBox PlayerNameTextBox;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Button ChangeNameButton;
        private System.Windows.Forms.Label UserMoneyLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Label NewUserNameLabel;
        private System.Windows.Forms.Button LoadUserButton;
    }
}