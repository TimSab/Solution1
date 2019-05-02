using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Table;

namespace _21Ochko
{
    public partial class MainMenu : Form
    {
        public IPlayer Player { get; set; } 

        public MainMenu()
        {
            InitializeComponent();
            Player = new Player("undefined");
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            if (((Player)Player).Name == "undefined")
            {
                MessageBox.Show("создайте имя");
            }
            else
            {                                
                var game = new Game(Player);
                var gameThread = new Thread(() => game.Start());
                gameThread.Start();
                var gameForm = new GameForm(game, (Player)Player);
                Hide();
                gameForm.Show();
            }
        }

        private void ChangeNameButton_Click(object sender, EventArgs e)
        {
            var input = PlayerNameTextBox.Text;
            PlayerNameTextBox.Text = string.Empty;
            if (!string.IsNullOrEmpty(input))
            {
                MessageBox.Show($"имя {((Player)Player).Name} изменено на {input}");
                ((Player)Player).Name = PlayerNameTextBox.Text;
                CurrentNameLabel.Text = input;
            }
        }

        private void ConnectButten_Click(object sender, EventArgs e)
        {
            var input = ConnectTextBox.Text;
            if (input != null)
            {
                // здесь надо написать поиск и подключение к игре.
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Player.Money = int.Parse(textBox1.Text);
        }
    }
}
