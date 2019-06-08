using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface;

namespace _21Ochko
{
    public partial class MainMainMenu : Form
    {
        private UserInterface.MainMenu mainMenu;
        public MainMainMenu()
        {
            InitializeComponent();
        }

        private void Ochko21button_Click(object sender, EventArgs e)
        {
            mainMenu = new UserInterface.MainMenu();
            mainMenu.Show();
            Hide();

            mainMenu.FormClosed += (object s, FormClosedEventArgs ev) =>
            {
                Show();
            };
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Filter = "only exe (*.exe)|*.exe";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Process myProcess = new Process();

                try
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = openFileDialog1.FileName;
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.Start();
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
        }
    }
}
