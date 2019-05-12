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
        public Player Player { get; set; }
        public int Bet { get; set; }

        public event Action batchStart;
        public event Action<string> batchEnd;

        public Batch(Banker banker, Player player, Action batchStart, Action<string> batchEnd)
        {
            this.banker = banker;
            this.Player = player;
            this.batchStart = batchStart;
            this.batchEnd = batchEnd;
        }

        public void Start(CancellationToken cancelationToken)
        {
            while(Bet == 0)
            {
                Thread.Sleep(5);
            }

            batchStart.Invoke();
            PlayerTakes(cancelationToken);
            BankerTakes(cancelationToken);

            var winner = DefineWinner(cancelationToken);

            if (!cancelationToken.IsCancellationRequested)
            {
                batchEnd.Invoke(winner.ToString());
            }

            banker.BeatenDeck.AddRange(Player.Hand);
            Player.Hand.Clear();
            banker.BeatenDeck.AddRange(banker.Hand);
            banker.Hand.Clear();
        }

        public void BankerTakes(CancellationToken cancelationToken)
        {
            while (!banker.IsStand && !cancelationToken.IsCancellationRequested)
            {
                banker.Take(banker);
            }
        }

        public void PlayerTakes(CancellationToken cancelationToken)
        {
            while (!Player.IsStand && !cancelationToken.IsCancellationRequested)
            {
                Thread.Sleep(5);
            }
            lock (Player.locker)
            {
                Player.IsStand = false;
            }
        }

        public AbsPlayer DefineWinner(CancellationToken cancelationToken)
        {
            if (cancelationToken.IsCancellationRequested)
            {
                return BankerWin();
            }

            if (Player.Score > 21)
            {
                return BankerWin();
            }

            if (banker.Score > 21)
            {
                return PlayerWin();
            }

            switch (banker.Score.CompareTo(Player.Score))
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
            Player.Money -= Bet;
            banker.Money += Bet;
            return banker;
        }

        private AbsPlayer PlayerWin()
        {
            banker.Money -= Bet;
            Player.Money += Bet;
            return Player;
        }
    }
}
