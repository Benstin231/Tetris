//To represent position in cell(grid)
namespace Tetris
{
    public class Position
    {
        public int Row {  get; set; }

        public int Column { get; set; }

        //Constructor
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
