using System;
using System.Data;
using System.Collections.Generic;

namespace ConsoleApp2.Main
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

            var (answer, isCorrect, expectedAnswer) = CheckAnswer(cards, AskQuestion(cards));

            if (isCorrect)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine($"Incorrect. The correct answer is {expectedAnswer}.");
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

        private (string answer, bool isCorrect, string expectedAnswer) CheckAnswer(List<Card> cards, string answer)
        {
            var number1 = cards[0].Number;
            var number2 = cards[1].Number;
            var operation = cards[2].Operator;

            var expectedAnswer = EvaluateExpression($"{number1} {operation} {number2}");

            return (answer, expectedAnswer == answer, expectedAnswer);
        }

        private string EvaluateExpression(string expression)
        {
            var dataTable = new DataTable();
            return dataTable.Compute(expression, "").ToString();
        }
    }
}
