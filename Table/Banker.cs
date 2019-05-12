using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    public class Banker : AbsPlayer // В ЭТОЙ ИГРЕ БАНКИР ВСЕГДА БОТ.
    {
        private const int ScoreOverflow = 21;
        private const int ScoreStand = 17;

        public Queue<Card> Deck { get; set; }
        public List<Card> BeatenDeck { get; set; }

        public override int Score => Hand.Sum(c => c);
        public override bool IsStand { get => Score >= ScoreStand; set { } }

        public Banker()
        {
            Name = "банкир";
            Hand = new List<Card>();
            BeatenDeck = new List<Card>();
            Deck = new Queue<Card>();
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardRanks value in Enum.GetValues(typeof(CardRanks)))
                {
                    Deck.Enqueue(new Card(suit, value));
                }
            }
            Shuffle();
        }


        public override void Take(AbsPlayer playerFrom)
        {
            if (((Banker)playerFrom).Deck.Count == 0)
            {
                throw new Exception("в колоде нет карт");
            }
            if (Score < ScoreOverflow)
            {
                Hand.Add(((Banker)playerFrom).Deck.Dequeue());
            }
        }

        public override void Take(AbsPlayer playerFrom, int count)
        {
            if (count > ((Banker)playerFrom).Deck.Count)
            {
                throw new Exception($"в колоде нет {count} карт");
            }
            for (int i = 0; i < count; i++)
            {
                Take(playerFrom);
            }
        }

        public override void Give(AbsPlayer playerTo)
        {
            if (Deck.Count == 0)
            {
                throw new Exception("в колоде нет карт");
            }
            playerTo.Hand.Add(Deck.Dequeue());
        }

        public override void Give(AbsPlayer playerTo, int count)
        {
            if (count > Deck.Count)
            {
                throw new Exception($"в колоде нет {count} карт");
            }
            for (int i = 0; i < count; i++)
            {
                Give(playerTo);
            }
        }

        public void Give(List<AbsPlayer> playersTo, int count)
        {
            if (count * playersTo.Count > Deck.Count)
            {
                throw new Exception($"в колоде нет {count} карт");
            }

            foreach (var player in playersTo)
            {
                Give(player, count);
            }
        }

        private void Shuffle()
        {
            var rand = new Random();
            var cardArr = Deck.ToArray();

            for (int i = cardArr.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                Swap(cardArr, i, j);
            }

            Deck.Clear();

            foreach (var card in cardArr)
            {
                Deck.Enqueue(card);
            }
        }

        private void Swap(Array arr, int i, int j)
        {
            var tmp = arr.GetValue(j);
            arr.SetValue(arr.GetValue(i), j);
            arr.SetValue(tmp, i);
        }       
    }
}
