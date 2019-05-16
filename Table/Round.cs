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

        //private event Action batchStart;
        //private event Action<string> batchEnd;

        public Batch CurrentBatch { get; private set; }

        public Round(List<AbsPlayer> players, Banker banker) //, Action batchStart, Action<string> batchEnd
        {
            this.players = players;
            this.banker = banker;
            //this.batchStart = batchStart;
            //this.batchEnd = batchEnd;
        }

        public void Start(CancellationToken сancelationToken)
        {
            foreach (var player in players)
            {
                banker.Give(player, 2);
                banker.Give(banker, 2);
                CurrentBatch = new Batch(banker, (Player)player); //, batchStart, batchEnd
                CurrentBatch.Start(сancelationToken);
            }
        }

        public void ReturnBeatenDeckInDeck()
        {
            while(banker.BeatenDeck.Count != 0)
            {
                banker.Deck.Enqueue(banker.BeatenDeck.Last());
            }
        }
    }
}

