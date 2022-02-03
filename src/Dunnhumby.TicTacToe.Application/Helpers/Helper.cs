using Dunnhumby.TicTacToe.Application.Model;

namespace Dunnhumby.TicTacToe.Application.Helpers
{
    public static class Helper
    {
        public static T[] GetRow<T>(this T[,] array, int row)
        {
            return Enumerable.Range(0, array.GetLength(1))
                .Select(x => array[row, x])
                .ToArray();
        }

        public static T[] GetColumn<T>(this T[,] array, int column)
        {
            return Enumerable.Range(0, array.GetLength(0))
               .Select(x => array[x, column])
               .ToArray();
        }

        public static Coordinates GetCoordinatesByValue<T>(this T[,] array, string value)
        {
            var returnCoordinates = new Coordinates();

            int w = array.GetLength(0); // width
            int h = array.GetLength(1); // height

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    if (array[x, y].Equals(value))
                        return new Coordinates() { X = x, Y = y };
                }
            }

            return new Coordinates() { X = -1, Y = -1 };
        }
    }

}
