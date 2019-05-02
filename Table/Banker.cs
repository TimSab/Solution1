using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    public class Banker : IPlayer // В ЭТОЙ ИГРЕ БАНКИР ВСЕГДА БОТ.
    {
        private const int ScoreOverflow = 21;

        public List<Card> Hand { get; set; }
        public Queue<Card> Deck { get; set; }
        public List<Card> BeatenDeck { get; set; }

        public int Score => Hand.Sum(c => c);
        public int Money { get; set; }
        public bool IsStand { get => Score > ScoreOverflow; set { } }

        public Banker()
        {
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

        public void Take(IPlayer player)
        {
            if (((Banker)player).Deck.Count == 0)
            {
                throw new Exception("в колоде нет карт");
            }
            if (Score < ScoreOverflow)
            {
                Hand.Add(((Banker)player).Deck.Dequeue());
            }
        }

        public void Take(IPlayer player, int count)
        {
            if (count > ((Banker)player).Deck.Count)
            {
                throw new Exception($"в колоде нет {count} карт");
            }
            for (int i = 0; i < count; i++)
            {
                Take(player);
            }
        }

        public void Give(IPlayer player)
        {
            if (Deck.Count == 0)
            {
                throw new Exception("в колоде нет карт");
            }
            player.Hand.Add(Deck.Dequeue());
        }

        public void Give(IPlayer player, int count)
        {
            if (count > Deck.Count)
            {
                throw new Exception($"в колоде нет {count} карт");
            }
            for (int i = 0; i < count; i++)
            {
                Give(player);
            }
        }

        public void Give(List<IPlayer> players, int count)
        {
            if (count * players.Count > Deck.Count)
            {
                throw new Exception($"в колоде нет {count} карт");
            }

            foreach (var player in players)
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
