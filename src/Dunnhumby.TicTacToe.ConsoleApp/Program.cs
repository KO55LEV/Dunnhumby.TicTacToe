using Dunnhumby.TicTacToe.Application.Games;

namespace Dunnhumby.TicTacToe.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var gameBoard = new TicTacToeGameBoard();

            Console.WriteLine("Player 1: X and Player 2: O");
            Console.WriteLine("");
            Console.WriteLine("Reference Grid:");
            Console.WriteLine(gameBoard.GetGameReferenceBoard());

            Console.WriteLine("Current Game Board:");
            Console.WriteLine(gameBoard.GetGameBoard());

            int currentPlayer;

            do
            {
                currentPlayer = gameBoard.NextPlayer();
                Console.WriteLine($"Player {currentPlayer} please enter your number:");
                
                
                var getPlayerNumber = int.Parse(Console.ReadLine());

                try
                {
                    gameBoard.UpdateBoard(currentPlayer, getPlayerNumber);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                

                Console.WriteLine(gameBoard.GetGameBoard());

            } while (!gameBoard.CheckWin());

            Console.WriteLine($"Player {currentPlayer} Won!");
            Console.ReadLine();
        }
    }
}