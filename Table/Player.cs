using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    public class Player : IPlayer
    {
        private const int ScoreOverflow = 21;

        public List<Card> Hand { get; set; }

        public string Name { get; set; }
        public int Score => Hand.Sum(c => c);
        public int Money { get; set; }
        public bool IsStand { get; set; }
       
        public Player(string name)
        {
            Hand = new List<Card>();
            Name = name;
        }
        
        void IPlayer.Give(IPlayer player)
        {
            throw new NotImplementedException();
        }

        void IPlayer.Give(IPlayer playerTo, int count)
        {
            throw new NotImplementedException();
        }

        public void Take(IPlayer playerTo)
        {
            if (Score < ScoreOverflow)
            {
                playerTo.Give(this);
            }
        }

        public void Take(IPlayer playerFrom, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Take(playerFrom);
            }
        }

        public bool TryConnect(Game game)
        {
            if (game == null)
            {
                return false;
            }
            game.players.Add(this);
            return true;
        }
    }
}
