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
        private AbsPlayer player;
        public int Bet { get; set; }
        public event Action<string> BatchEnd;

        public Batch(Banker banker, AbsPlayer player)
        {
            this.banker = banker;
            this.player = player;
        }

        public void Start()
        {
            PlayerTakes();
            BankerTakes();

            var winner = DefineWinner();
            BatchEnd.Invoke(winner.ToString());

            banker.BeatenDeck.AddRange(player.Hand);
            player.Hand.Clear();
            banker.BeatenDeck.AddRange(banker.Hand);
            banker.Hand.Clear();
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

        public AbsPlayer DefineWinner()
        {
            if (player.Score > 21)
            {
                return BankerWin();
            }

            if (banker.Score > 21)
            {
                return PlayerWin();
            }

            switch (banker.Score.CompareTo(player.Score))
            {
                case -1:
                case 0:
                {
                    return PlayerWin();
                }
                case 1:
                {
                    return BankerWin();
                }
            }
            return null;
        }

        private AbsPlayer BankerWin()
        {
            player.Money -= Bet;
            banker.Money += Bet;
            return banker;
        }

        private AbsPlayer PlayerWin()
        {
            banker.Money -= Bet;
            player.Money += Bet;
            return player;
        }
    }
}
