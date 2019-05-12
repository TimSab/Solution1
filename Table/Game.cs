using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Table
{
    public class Game
    {
        public CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        private CancellationToken token;

        private readonly int InitialBank;
        public Banker banker;
        public List<AbsPlayer> players;
        public int id;
        public Round CurrentRound;

        private bool isEnd;
        private bool BankerBankrupt => banker.Money == 0;
        private bool AllPlayersBankrupt => players.All(p => p.Money <= 0);
        private bool BankerBankTooBig => banker.Money == InitialBank * 3;

        public event Action BatchStart;
        public event Action<string> BatchEnd;

        public Game(AbsPlayer host)
        {
            BatchStart += (() => { });
            BatchEnd += ((s) => { });

            token = cancelTokenSource.Token;

            id = new Random().Next();
            InitialBank = host.Money;

            players = new List<AbsPlayer>();
            players.Add(host);

            banker = new Banker();
            banker.Money = host.Money * 2;
        }
        
        public void Start()
        {
            while(!isEnd && !BankerBankrupt && !AllPlayersBankrupt && !BankerBankTooBig)
            {
                CurrentRound = new Round(players, banker, BatchStart, BatchEnd);
                CurrentRound.Start(token);
            }
        }

        public void End()
        {
            isEnd = true;
        }

        private void ChooseBanker()
        {
            var index = new Random().Next(players.Count);
            banker = (Banker)players[index];
            players.RemoveAt(index);
        }
    }
}
