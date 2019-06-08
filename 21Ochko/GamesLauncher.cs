using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
