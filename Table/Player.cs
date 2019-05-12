using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    public class Player : AbsPlayer
    {
        public object locker = new object();
        private const int ScoreOverflow = 21;

        public override int Score => Hand.Sum(c => c);

        public override bool IsStand { get; set; }

        public Player(string name)
        {
            Hand = new List<Card>();
            Name = name;
        }
        
        public override void Give(AbsPlayer player)
        {
            throw new NotImplementedException();
        }

        public override void Give(AbsPlayer playerTo, int count)
        {
            throw new NotImplementedException();
        }

        public override void Take(AbsPlayer playerTo)
        {
            if (Score < ScoreOverflow)
            {
                playerTo.Give(this);
            }
        }

        public override void Take(AbsPlayer playerFrom, int count)
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
