using System;
using System.Data;
using System.Collections.Generic;

namespace eman2004
{
    public class Game
    {
        private readonly Pack pack;

        public Game()
        {
            pack = new Pack();
        }

        public void PlayGame()
        {
            var cards = pack.GetCards(3);

            var answer = AskQuestion(cards);
            var isCorrect = CheckAnswer(cards, answer);

            if (isCorrect)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect.");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey(true);
        }

        private string AskQuestion(List<Card> cards)
        {
            var number1 = cards[0].Number;
            var number2 = cards[1].Number;
            var operation = cards[2].Operator;

            Console.Write($"{number1} {operation} {number2} = ");

            return Console.ReadLine();
        }

        private bool CheckAnswer(List<Card> cards, string answer)
        {
            var number1 = cards[0].Number;
            var number2 = cards[1].Number;
            var operation = cards[2].Operator;

            var expectedAnswer = EvaluateExpression($"{number1} {operation} {number2}");

            return expectedAnswer == answer;
        }

        private string EvaluateExpression(string expression)
        {
            var dataTable = new DataTable();
            return dataTable.Compute(expression, "").ToString();
        }
    }
}
