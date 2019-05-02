using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    public class Card
    {
        public CardRanks Rank { get; set; }
        public CardSuit Suit { get; set; }

        public Card(CardSuit suit, CardRanks value)
        {
            Suit = suit;
            Rank = value;
        }

        public static int operator +(Card card1, Card card2)
        {
            return card1 + card2;
        }

        public static implicit operator int(Card card)
        {
            if ((int)card.Rank < 11) return (int)card.Rank;
            else if (card.Rank == CardRanks.туз) return 11;
            else if (card.Rank == CardRanks.валет) return 2;
            else if (card.Rank == CardRanks.дама) return 3;
            else if (card.Rank == CardRanks.король) return 4;
            throw new Exception("неправильная карта");
        }

        public override string ToString()
        {
            return $"{Rank} {Suit}";
        }

    }

    public enum CardSuit
    {
        пики,
        черви,
        треф,
        буби
        //Diamond,
        //Heart,
        //Spade,
        //Club
    }

    public enum CardRanks 
    {
        //Two = 2,
        //Three,
        //Four,
        //Five,
        //Six,
        //Seven,
        //Eight,
        //Nine,
        //Ten,
        //Jack,
        //Queen,
        //King,
        //Ace,
        шестерка = 6,
        семерка,
        восьмерка,
        девятка,
        десятка,
        валет,
        дама,
        король,
        туз
    }
}
