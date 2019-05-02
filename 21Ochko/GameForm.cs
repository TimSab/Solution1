using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Table;

namespace _21Ochko
{
    public partial class GameForm : Form
    {
        private Game game;
        private Player player;
        private readonly Dictionary<string, Bitmap> bitmaps = new Dictionary<string, Bitmap>();
        private Graphics graphics;

        public GameForm(Game game, Player player, DirectoryInfo imagesDirectory = null)
        {
            InitializeComponent();

            this.game = game;
            this.player = player;

            if (imagesDirectory == null)
                imagesDirectory = new DirectoryInfo("Images");
            foreach (var e in imagesDirectory.GetFiles("*.png"))
                bitmaps[e.Name] = (Bitmap)Image.FromFile(e.FullName);
            foreach (var e in imagesDirectory.GetFiles("*.jpg"))
                bitmaps[e.Name] = (Bitmap)Image.FromFile(e.FullName);
            graphics = CreateGraphics();
        }

        private void Stand_Click(object sender, EventArgs e)
        {
            player.IsStand = true;
            HitButton.Enabled = false;
            StandButton.Enabled = false;
            Thread.Sleep(1000);
            BankerCardsOnPaint();           
        }


        private void Hit_Click(object sender, EventArgs e)
        {
            if (!player.IsStand)
            {
                player.Take(game.banker);
            }
            PlayerCardsOnPaint();
            PaintShirtsUp(game.banker, new Point { X = 275, Y = 50 });            
        }

        private void BetButton_Click(object sender, EventArgs e)
        {
            var result = int.TryParse(BetTextBox.Text, out int bet);
            BetTextBox.Clear();
            if (player.Money < bet || !result || game.banker.Money < bet || bet < 0)
            {
                MessageBox.Show("неккоректный ввод");
            }
            else
            {
                BetLabel.Text = bet.ToString();
                game.CurrentRound.CurrentBatch.Bet = bet;
                HitButton.Enabled = true;
                StandButton.Enabled = true;
                BetButton.Enabled = false;
            }
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    Refresh();
        //}

        private void PlayerCardsOnPaint()
        {
            var x = 275;
            foreach (var card in player.Hand)
            {
                var cardSuit = card.Suit.ToString();
                var cardRank = card.Rank.ToString();
                graphics.DrawImage(bitmaps[$"{cardRank} {cardSuit}.png"], new Point { X = x, Y = 230 });
                x += 15;
            }
        }

        private void BankerCardsOnPaint()
        {
            var x = 275;
            foreach (var card in game.banker.Hand)
            {
                var cardSuit = card.Suit.ToString();
                var cardRank = card.Rank.ToString();
                graphics.DrawImage(bitmaps[$"{cardRank} {cardSuit}.png"], new Point { X = x, Y = 50 });
                x += 15;
            }
        }
        
        private void PaintShirtsUp(IPlayer player, Point point)
        {            
            foreach (var card in player.Hand)
            {                
                graphics.DrawImage(bitmaps["рубашка.jpg"], point);
                point.X += 15;
            }
        }

        private void GameForm_Shown(object sender, EventArgs e)
        {
            PlayerCardsOnPaint();
            PaintShirtsUp(game.banker, new Point { X = 275, Y = 50 });
        }
    }
}
