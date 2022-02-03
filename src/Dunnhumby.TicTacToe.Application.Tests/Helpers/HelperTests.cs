using Dunnhumby.TicTacToe.Application.Helpers;
using Dunnhumby.TicTacToe.Application.Model;
using FluentAssertions;
using Xunit;

namespace Dunnhumby.TicTacToe.Application.Tests.Helpers
{
    public class HelperTests
    {
        string[,] _mockData;
        public HelperTests()
        {
            _mockData =
              new string[3, 3] {
                        {"1","2","3"},
                        {"4","5","6"},
                        {"7","8","9"} };
        }

        #region GetRow unit tests

        [Fact]
        public void GetRow_Row_One_Should_Return_Correct_Items()
        {
            // Arrange 
            var mockData = _mockData;

            // Act
            var row = mockData.GetRow(0);

            // Assert 
            row[0].Should().Be("1");
            row[1].Should().Be("2");
            row[2].Should().Be("3");
        }

        [Fact]
        public void GetRow_Row_Two_Should_Return_Correct_Items()
        {
            // Arrange 
            var mockData = _mockData;
            
            // Act
            var row = mockData.GetRow(1);

            // Assert 
            row[0].Should().Be("4");
            row[1].Should().Be("5");
            row[2].Should().Be("6");
        }
        [Fact]
        public void GetRow_Row_Three_Should_Return_Correct_Items()
        {
            // Arrange 
            var mockData = _mockData;

            // Act
            var row = mockData.GetRow(2);

            // Assert 
            row[0].Should().Be("7");
            row[1].Should().Be("8");
            row[2].Should().Be("9");
        }

        #endregion

        #region GetColumns unit tests

        [Fact]
        public void GetColumns_Column_One_Should_Return_Correct_Items()
        {
            // Arrange 
            var mockData = _mockData;

            // Act
            var row = mockData.GetColumn(0);

            // Assert 
            row[0].Should().Be("1");
            row[1].Should().Be("4");
            row[2].Should().Be("7");
        }

        [Fact]
        public void GetColumns_Column_Two_Should_Return_Correct_Items()
        {
            // Arrange 
            var mockData = _mockData;

            // Act
            var row = mockData.GetColumn(1);

            // Assert 
            row[0].Should().Be("2");
            row[1].Should().Be("5");
            row[2].Should().Be("8");
        }

        [Fact]
        public void GetColumns_Column_Three_Should_Return_Correct_Items()
        {
            // Arrange 
            var mockData = _mockData;

            // Act
            var row = mockData.GetColumn(2);

            // Assert 
            row[0].Should().Be("3");
            row[1].Should().Be("6");
            row[2].Should().Be("9");
        }

        #endregion

        #region GetCoordinatesByValues unit tests 
        
        [Fact]
        public void GetCoordinatesByValues_Row_One_Should_Return_Correct_Items()
        {
            // Arrange 
            var mockData = _mockData;

            // Act
            var result = mockData.GetCoordinatesByValue("1");

            // Assert 
            var expectedResult = new Coordinates() { X = 0, Y = 0 };

            result.Should().BeEquivalentTo(expectedResult);
        }

        #endregion

    }
}
