using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
namespace TestQ.Controllers
{
    public class PokerController : Controller
    {
        public class card
        {
           public string Value { get; set; }
           public string Suit { get; set; }
           
            public card( string value , string suit)
            {
                Suit = suit;
                Value = value;
            }
            
            public override string ToString()
            {
                return Value + Suit;
            }
            
        }

        public ActionResult Index()
        {
            DeckOfCards newDeck = new DeckOfCards();
            newDeck.Shuffle();
            StringBuilder handString = new StringBuilder();
            List<card> pokerHand = new List<card>();
            for (int i = 0; i < 5; i++)
            {
                card newCard = newDeck.DealCard();
                handString.Append(newCard.ToString());
                pokerHand.Add(newCard);
            }
            ViewBag.pair = hasPair(pokerHand);
            ViewBag.pokerHand = handString.ToString();
            
            return View();
        }
        public class DeckOfCards
        {
            private card[] deck;
            private int currentCard;
            private const int NUMBER_OF_CARDS = 52;
            private Random randomNumbers;

            public DeckOfCards()
            {
                string[] faces = { "A", "2", "3", "4", "5", "6",
         "7", "8", "9", "10", "J", "Q", "K" };
                string[] suits = { "h", "d", "c", "s" };

                deck = new card[NUMBER_OF_CARDS];
                currentCard = 0;
                randomNumbers = new Random();

                for (int count = 0; count < deck.Length; count++)
                    deck[count] =
                       new card(faces[count % 13], suits[count / 13]);
            }

            public void Shuffle()
            {
                currentCard = 0;

                for (int first = 0; first < deck.Length; first++)
                {
                    int second = randomNumbers.Next(NUMBER_OF_CARDS);

                    card temp = deck[first];
                    deck[first] = deck[second];
                    deck[second] = temp;
                }
            }

            public card DealCard()
            {
                if (currentCard < deck.Length)
                    return deck[currentCard++];
                else
                    return null;
            }
           
        }
        public bool hasPair(List<card> hand)
        {
            Dictionary<string, int> valueDic = new Dictionary<string, int>();
           for(int i = 0; i < 5; i++)
            {
                try
                {
                    valueDic.Add(hand[i].Value, i);
                }
                catch {
                    return true;
                }
            }
           
            return false;
        }
        public bool hasTrips()
        {
            return true;
        }
        public bool hasFourOfAKind()
        {
            return true;
        }
        public bool hasFlush()
        {
            return true;
        }
        public bool hasStraight()
        {
            return true;
        }
    }
}