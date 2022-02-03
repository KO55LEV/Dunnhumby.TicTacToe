using Dunnhumby.TicTacToe.Application.Helpers;
using System.Text;
using static Dunnhumby.TicTacToe.Application.Helpers.Helper;

namespace Dunnhumby.TicTacToe.Application.Games
{
    public class TicTacToeGameBoard
    {
        private string[,] referenceGrid = new string[3, 3] {
                                                           {"1","2","3"},
                                                           {"4","5","6"},
                                                           {"7","8","9"}};

        private string[,] gameGrid = new string[3, 3] {
                                                       {"-","-","-"},
                                                       {"-","-","-"},
                                                       {"-","-","-"}};

        private int _player;

        public string[,] GameGrid { get; set; } 

        public TicTacToeGameBoard()
        {
            GameGrid = gameGrid;
            _player = 1;
        }

        public string GetGameBoard()
        {
           return GetBoard(GameGrid);
        }

        public string GetGameReferenceBoard()
        {
            return GetBoard(referenceGrid);
        }

        private string GetBoard(string[,] boardGrid)
        {
            StringBuilder outputBoard = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                var row = boardGrid.GetRow(i);
                outputBoard.AppendLine($"  {row[0]} {row[1]} {row[2]}");
            }
            return outputBoard.ToString();
        }

        public int NextPlayer()
        {
            if (_player % 2 == 0)
            {
                _player = 1;
                return 2;
            }
            else
            {
                _player++;
                return 1;
            }
        }
        
        public void UpdateBoard(int player, int playerNumber)
        {
            if ((playerNumber > 9) || (playerNumber < 1))
            {
                throw new Exception("The Number Out Of The Range");
            }

            // Update current board 
            var currentPlayer = (player == 1) ? "X" : "O";

            var coordinates = referenceGrid.GetCoordinatesByValue(playerNumber.ToString());

            if (gameGrid[coordinates.X, coordinates.Y] != "-")
            {
                throw new Exception($"You could not place {currentPlayer} at this cell");
            }
            else
            {
                gameGrid[coordinates.X, coordinates.Y] = currentPlayer;
            }
        }

        public bool CheckWin()
        {
            //Check Rows for X & O
            if (CheckWinRows("X") || CheckWinRows("O"))  
            {
                return true;
            }

            //Check columns for X and O
            if (CheckWinColumns("X") || CheckWinColumns("O"))
            {
                return true;
            }

            //Check Diagonals for X and O
            if (CheckWinDiagonals("X") || CheckWinDiagonals("O"))
            {
                return true;
            }

            return false;
        }

        private bool CheckWinColumns(string value)
        {
            for (int i = 0; i < 3; i++)
            {
                var column = gameGrid.GetColumn(i);
                if (column[0].Equals(value) && column[1].Equals(value) && column[2].Equals(value)) return true;
            }

            return false;
        }

        private bool CheckWinRows(string value)
        {
            for (int i = 0; i < 3; i++)
            {
                var row = gameGrid.GetRow(i);
                if (row[0].Equals(value) && row[1].Equals(value) && row[2].Equals(value)) return true;
            }

            return false;
        }

        private bool CheckWinDiagonals(string value)
        {
            if (gameGrid[0, 0].Equals(value) && gameGrid[1, 1].Equals(value) && gameGrid[2, 2].Equals(value)) return true;
            if (gameGrid[2, 0].Equals(value) && gameGrid[1, 1].Equals(value) && gameGrid[0, 2].Equals(value)) return true;

            return false;
        }
    }
}
