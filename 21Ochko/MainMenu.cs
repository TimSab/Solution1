using System;
using System.Threading;
using System.Windows.Forms;
using Utilities;
using Table;

namespace UserInterface
{
    public partial class MainMenu : Form
    {
        private const string DefaultUserName = "Игрок";
        private const int DefaultUserMoney = 300;
        private IUserLoader userLoader;
        private User user;

        public MainMenu()
        {
            InitializeComponent();

            userLoader = new RSAFileUserLoader();
            user = new User(DefaultUserName, DefaultUserMoney);
            UpdateUserInfo();
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            var player = new Player(user.Name);
            player.Money = user.Money;
            var game = new Game(player);

            var gameThread = new Thread(() => game.Start());
            gameThread.Start();

            var gameForm = new GameForm(game, player);
            gameForm.Show();

            Hide();
            gameForm.FormClosed += (object s, FormClosedEventArgs ev) => 
            {
                user.Money = player.Money;
                Show();
                game.End();
                gameThread.Abort();
                gameThread.Join();                
                userLoader.Save(user);
                
            };
        }

        private void ChangeNameButton_Click(object sender, EventArgs e)
        {
            var input = PlayerNameTextBox.Text;
            
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Неккоректный ввод!");
                return;
            }

            user.Name = PlayerNameTextBox.Text;
            UpdateUserInfo();

            PlayerNameTextBox.Clear();
        }

        private void LoadUserButton_Click(object sender, EventArgs e)
        {
            var input = PlayerNameTextBox.Text;
            PlayerNameTextBox.Clear();

            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Неккоректный ввод!");
                return;
            }

            var tempUser = userLoader.Load(input);
            if (tempUser == null)
            {
                MessageBox.Show("Пользователь не найден!");
                return;
            }

            user = tempUser;
            UpdateUserInfo();
            
        }

        private void ConnectButten_Click(object sender, EventArgs e)
        {
            var input = ConnectTextBox.Text;
            if (input != null)
            {
                // здесь надо написать поиск и подключение к игре.
            }
        }

        private void UpdateUserInfo()
        {
            UserNameLabel.Text = user.Name;
            UserMoneyLabel.Text = user.Money.ToString();
        }
    }
}
