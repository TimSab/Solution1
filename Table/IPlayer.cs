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


        void Take(IPlayer playerFrom);        
        void Take(IPlayer playerFrom, int count);
        void Give(IPlayer playerTo);
        void Give(IPlayer playerTo, int count);
    }
}
