using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    public class Round
    {
        private Queue<IPlayer> players;
        public Batch CurrentBatch { get; set; }
        private Banker banker;

        public Round(List<IPlayer> players, Banker banker)
        {
            this.players = new Queue<IPlayer>();
            foreach (var player in players)
            {
                this.players.Enqueue(player);
            }
            this.banker = banker;
        }

        public void Start()
        {
            foreach(var player in players)
            {
                banker.Give(player, 2);
            }
            //foreach (var player in players)
            //{
                banker.Give(banker, 2);
                CurrentBatch = new Batch(banker, (Player)players.First());
                CurrentBatch.Start();
            //}            
        }

        public IPlayer NextPlayer()
        {
            players.Dequeue();
            if (players.Count == 0) return null;
            return players.Peek();
        }

        public IPlayer CurrentPlayer()
        {
            return players.Peek();
        }
    }
}
