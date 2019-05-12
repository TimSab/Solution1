using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Table
{
    public class Round
    {
        private List<AbsPlayer> players;
        private Banker banker;

        public Batch CurrentBatch { get; private set; }

        public Round(List<AbsPlayer> players, Banker banker)
        {
            this.players = players;
            this.banker = banker;
        }

        public void Start(CancellationToken сancelationToken)
        {
            foreach (var player in players)
            {
                banker.Give(player, 2);
                banker.Give(banker, 2);
                CurrentBatch = new Batch(banker, (Player)players.First());
                CurrentBatch.Start(сancelationToken);
            }
        }
    }
}
