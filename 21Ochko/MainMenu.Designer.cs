namespace UserInterface
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
            this.ChangeNameButton = new System.Windows.Forms.Button();
            this.CurrentNameLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartGameButton
            // 
            this.StartGameButton.Location = new System.Drawing.Point(45, 67);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(508, 67);
            this.StartGameButton.TabIndex = 0;
            this.StartGameButton.Text = "Start Game";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // ConnectButten
            // 
            this.ConnectButten.Location = new System.Drawing.Point(309, 211);
            this.ConnectButten.Name = "ConnectButten";
            this.ConnectButten.Size = new System.Drawing.Size(244, 64);
            this.ConnectButten.TabIndex = 1;
            this.ConnectButten.Text = "Connect ";
            this.ConnectButten.UseVisualStyleBackColor = true;
            this.ConnectButten.Click += new System.EventHandler(this.ConnectButten_Click);
            // 
            // ConnectTextBox
            // 
            this.ConnectTextBox.Location = new System.Drawing.Point(45, 234);
            this.ConnectTextBox.Name = "ConnectTextBox";
            this.ConnectTextBox.Size = new System.Drawing.Size(258, 20);
            this.ConnectTextBox.TabIndex = 2;
            // 
            // PlayerNameTextBox
            // 
            this.PlayerNameTextBox.Location = new System.Drawing.Point(45, 355);
            this.PlayerNameTextBox.Name = "PlayerNameTextBox";
            this.PlayerNameTextBox.Size = new System.Drawing.Size(258, 20);
            this.PlayerNameTextBox.TabIndex = 3;
            // 
            // ChangeNameButton
            // 
            this.ChangeNameButton.Location = new System.Drawing.Point(309, 327);
            this.ChangeNameButton.Name = "ChangeNameButton";
            this.ChangeNameButton.Size = new System.Drawing.Size(244, 67);
            this.ChangeNameButton.TabIndex = 4;
            this.ChangeNameButton.Text = "ChangeName";
            this.ChangeNameButton.UseVisualStyleBackColor = true;
            this.ChangeNameButton.Click += new System.EventHandler(this.ChangeNameButton_Click);
            // 
            // CurrentNameLabel
            // 
            this.CurrentNameLabel.AutoSize = true;
            this.CurrentNameLabel.Location = new System.Drawing.Point(268, 26);
            this.CurrentNameLabel.Name = "CurrentNameLabel";
            this.CurrentNameLabel.Size = new System.Drawing.Size(54, 13);
            this.CurrentNameLabel.TabIndex = 5;
            this.CurrentNameLabel.Text = "undefined";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(105, 176);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(387, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 465);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CurrentNameLabel);
            this.Controls.Add(this.ChangeNameButton);
            this.Controls.Add(this.PlayerNameTextBox);
            this.Controls.Add(this.ConnectTextBox);
            this.Controls.Add(this.ConnectButten);
            this.Controls.Add(this.StartGameButton);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.TextBox ConnectTextBox;
        private System.Windows.Forms.Button ConnectButten;
        private System.Windows.Forms.TextBox PlayerNameTextBox;
        private System.Windows.Forms.Button ChangeNameButton;
        private System.Windows.Forms.Label CurrentNameLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}