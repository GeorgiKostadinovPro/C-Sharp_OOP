using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] cards = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            List<Card> validCards = new List<Card>();

            for (int i = 0; i < cards.Length; i++)
            { 
                string[] cardInfo = cards[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string face = cardInfo[0];
                string suit = cardInfo[1];

                try
                {
                    Card card = new Card(face, suit);
                    validCards.Add(card);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(" ", validCards.Select(c => c.ToString())));
        }
    }
}