using System;
using System.Threading;
using System.Windows.Forms;
using Utilities;
using Table;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Linq;
using System.Text;

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
            var hostFile = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory)
                .Parent
                .Parent
                .Parent
                .GetDirectories()
                .Where(d => d.Name == "TableTCPHost")
                .FirstOrDefault()
                .GetDirectories()
                .Where(d => d.Name == "bin")
                .FirstOrDefault()
                .GetDirectories()
                .Where(d => d.Name == "Debug")
                .FirstOrDefault()
                .GetFiles()
                .Where(f => f.Name == "TableTCPHost.exe")
                .FirstOrDefault();

            if (hostFile.Exists)
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.FileName = hostFile.FullName;
                    myProcess.Start();
                }
            }

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
            var port = 0;
            var input = int.TryParse(ConnectTextBox.Text, out port);
            if (input)
            {
                try
                {
                    IPHostEntry ipHost = Dns.GetHostEntry("localhost");
                    IPAddress ipAdr = ipHost.AddressList[0];
                    IPEndPoint ipPoint = new IPEndPoint(ipAdr, port);

                    Socket socket = new Socket(ipAdr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    // подключаемся к удаленному хосту
                    socket.Connect(ipPoint);
                    string message = "ggwwgwg";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    socket.Send(data);

                    // получаем ответ
                    data = new byte[256]; // буфер для ответа
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байт

                    do
                    {
                        bytes = socket.Receive(data, data.Length, 0);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (socket.Available > 0);
                    label1.Text = builder.ToString();

                    // закрываем сокет
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.Read();
            }
        }
        private void UpdateUserInfo()
        {
            UserNameLabel.Text = user.Name;
            UserMoneyLabel.Text = user.Money.ToString();
        }
    }
}


