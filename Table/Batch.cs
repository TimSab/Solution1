using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Table
{
    public class Batch
    {
        private Banker banker;
        private IPlayer player;
        public int Bet { get; set; }

        public Batch(Banker banker, IPlayer player)
        {
            this.banker = banker;
            this.player = player;
        }

        public void Start()
        {
            PlayerTakes();
            BankerTakes();
            
            DefineWinner();

            banker.BeatenDeck.AddRange(player.Hand);
            player.Hand.Clear();
            banker.BeatenDeck.AddRange(banker.Hand);
            banker.Hand.Clear();
        }

        private void BankerWin()
        {
            player.Money -= Bet;
            banker.Money += Bet;
        }

        private void PlayerWin()
        {
            banker.Money -= Bet;
            player.Money += Bet;
        }

        public void DefineWinner()
        {
            if (player.Score > 21)
            {
                BankerWin();
                return;
            }

            if (banker.Score > 21)
            {
                PlayerWin();
                return;
            }

            switch (banker.Score.CompareTo(player.Score))
            {
                case -1:
                case 0:
                {
                    PlayerWin();
                    return;
                }
                case 1:
                {
                    BankerWin();
                    return;
                }
            }
        }

        public void BankerTakes()
        {
            while (!banker.IsStand)
            {
                banker.Take(banker);
            }
        }

        public void PlayerTakes()
        {
            while (!player.IsStand)
            {
                Thread.Sleep(5);
            }
            player.IsStand = false;
        }
    }
}
