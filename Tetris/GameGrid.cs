namespace Tetris
{
    public class GameGrid   //Hold 2 dimensional array
    {
        private readonly int[,] grid;   //declare readonly two-dimensional array of integers named 'grid'

        public int Rows { get; }    //Property屬性, {get;} is a auto-implenented property,
                                    //which means it can only be read and not modified after initialization
        public int Columns { get; }

        public int this[int r, int c]
        {
            //the "=>" is a Lambda Expressions
            get => grid[r, c];  //get { return grid[r, c]; }
            set => grid[r, c] = value;  //set { grid[r, c] = value; }
        }

        //Parameterized Constructor:
        //A constructor that takes parameters,
        //allowing you to initialize an object with specific values at the time of creation.
        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }

        //Check if the given row and column is inside the grid or not
        public bool IsInside(int r, int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        //Check if the given cell is empty or not
        public bool IsEmprty(int r, int c)
        {
            return IsInside(r,c) && grid[r, c] == 0;
        }

        //Check if the entire row is full
        public bool IsRowFull(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if(grid[r, c] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        //Check if the row is empty
        public bool IsRowEmpty(int r)
        {
            for(int c = 0;c < Columns; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        //Clear rows
        private void ClearRow(int r)
        {
            for(int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }

        //Move down rows
        private void MoveRowDown(int r, int numRows)
        {
            for(int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        //Clear full row
        public int ClearFullRows()
        {
            int cleared = 0;

            for(int r = Rows-1; r >= 0; r--)
            {
                if(IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if(cleared>0)
                {
                    MoveRowDown(r,cleared);
                }
            }

            return cleared;
        }
    }
}
