using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    public interface IPlayer
    {
        List<Card> Hand { get; set; }
        int Score { get;}
        int Money { get; set; }
        bool IsStand { get; set; }


        void Take(IPlayer player);        
        void Take(IPlayer player, int count);
        void Give(IPlayer player);
        void Give(IPlayer player, int count);
    }
}
