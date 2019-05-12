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
                gameThread.Join();
                user.Money = player.Money;
                UserMoneyLabel.Text = user.Money.ToString();
                Show();
                userLoader.Save(user);
            };

            gameForm.FormClosing += (object s, FormClosingEventArgs ev) =>
            {
                if (ev.CloseReason == CloseReason.UserClosing)
                {
                    if (game.CurrentRound.CurrentBatch.Player.Equals(player))
                    {
                        if (game.CurrentRound.CurrentBatch.Bet != 0)
                        {
                            var msg = "Вашу ставку заберет банкир.Вы уверены что хотите покинуть игру?";
                            var capture = "выход";
                            var result = MessageBox.Show(msg, capture, MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                ev.Cancel = false;                                                              
                            }
                            else
                            {
                                ev.Cancel = true;
                            }
                        }
                    }
                    game.cancelTokenSource.Cancel();
                    game.End();
                }
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
            user.Money = DefaultUserMoney;
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
