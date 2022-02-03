using Dunnhumby.TicTacToe.Application.Games;
using FluentAssertions;
using Xunit;

namespace Dunnhumby.TicTacToe.Application.Tests.Games
{
    public class TicTacToeGameBoardTests
    {
        private TicTacToeGameBoard _ticTacToeGameBoard;
  
        [Fact]
        public void CheckNextPlayer_Returns_Correct_Next_Player()
        {
            // Arrange 
            _ticTacToeGameBoard = new TicTacToeGameBoard();

            // Act
            var playerOne = _ticTacToeGameBoard.NextPlayer();
            var playerTwo = _ticTacToeGameBoard.NextPlayer();
            var playerOneNextRound = _ticTacToeGameBoard.NextPlayer();
            var playerTwoNextRound = _ticTacToeGameBoard.NextPlayer();
            var playerOneExtraRound = _ticTacToeGameBoard.NextPlayer();
            var playerTwoExtraRound = _ticTacToeGameBoard.NextPlayer();

            // Assert 
            playerOne.Should().Be(1);
            playerTwo.Should().Be(2);
            playerOneNextRound.Should().Be(1);
            playerTwoNextRound.Should().Be(2);
            playerOneExtraRound.Should().Be(1);
            playerTwoExtraRound.Should().Be(2);
        }

        [Fact]
        public void GetGameReferenceBoard_Returns_Correct_Board()
        {
            // Arrange 
            _ticTacToeGameBoard = new TicTacToeGameBoard();

            // Act
            var referenceBoard = _ticTacToeGameBoard.GetGameReferenceBoard();

            // Assert 
            var expectedResult = "  1 2 3\r\n  4 5 6\r\n  7 8 9\r\n";
            referenceBoard.Should().Be(expectedResult);
        }

        [Fact]
        public void GetGameBoard_Returns_Correct_Board()
        {
            // Arrange 
            _ticTacToeGameBoard = new TicTacToeGameBoard();

            // Act
            var referenceBoard = _ticTacToeGameBoard.GetGameBoard();

            // Assert 
            var expectedResult = "  - - -\r\n  - - -\r\n  - - -\r\n";
            referenceBoard.Should().Be(expectedResult);
        }

        [Fact]
        public void UpdateBoard_Returns_Correct_Result()
        {
            // Arrange 
            _ticTacToeGameBoard = new TicTacToeGameBoard();

            // Act

            //play the game 
            int currentPlayer;
            for (int i = 1; i <= 9; i++)
            {
                currentPlayer = _ticTacToeGameBoard.NextPlayer();
                _ticTacToeGameBoard.UpdateBoard(currentPlayer, i);
            }
                        
            var finalGameBoard = _ticTacToeGameBoard.GetGameBoard();

            // Assert 
            var expectedResult = "  X O X\r\n  O X O\r\n  X O X\r\n";
            finalGameBoard.Should().Be(expectedResult);
        }

        [Fact]
        public void CheckWin_For_X_Diagonals_Returns_Correct_Result()
        {
            // Arrange 
            _ticTacToeGameBoard = new TicTacToeGameBoard();

            // Act
            _ticTacToeGameBoard.UpdateBoard(1, 1);
            _ticTacToeGameBoard.UpdateBoard(1, 5);
            _ticTacToeGameBoard.UpdateBoard(1, 9);

            var result = _ticTacToeGameBoard.CheckWin();

            // Assert 
            result.Should().Be(true);
        }

        [Fact]
        public void CheckWin_For_0_Diagonals_Returns_Correct_Result()
        {
            // Arrange 
            _ticTacToeGameBoard = new TicTacToeGameBoard();

            // Act
            _ticTacToeGameBoard.UpdateBoard(2, 1);
            _ticTacToeGameBoard.UpdateBoard(2, 5);
            _ticTacToeGameBoard.UpdateBoard(2, 9);

            var result = _ticTacToeGameBoard.CheckWin();

            // Assert 
            result.Should().Be(true);
        }

        //TODO check inverted Diagonals 2 extra unit tests 

        [Fact]
        public void CheckWin_For_X_Rows_Returns_Correct_Result()
        {
            // Arrange 
            _ticTacToeGameBoard = new TicTacToeGameBoard();

            // Act
            _ticTacToeGameBoard.UpdateBoard(1, 1);
            _ticTacToeGameBoard.UpdateBoard(1, 2);
            _ticTacToeGameBoard.UpdateBoard(1, 3);

            var result = _ticTacToeGameBoard.CheckWin();

            // Assert 
            result.Should().Be(true);
        }

        [Fact]
        public void CheckWin_For_0_Rows_Returns_Correct_Result()
        {
            // Arrange 
            _ticTacToeGameBoard = new TicTacToeGameBoard();

            // Act
            _ticTacToeGameBoard.UpdateBoard(2, 1);
            _ticTacToeGameBoard.UpdateBoard(2, 2);
            _ticTacToeGameBoard.UpdateBoard(2, 3);

            var result = _ticTacToeGameBoard.CheckWin();

            // Assert 
            result.Should().Be(true);
        }

        //TODO add more unit test for columns 

    }
}
