//可參考https://learn.microsoft.com/zh-tw/dotnet/api/system.collections.generic?view=net-8.0
using System.Collections.Generic;
namespace Tetris
{
    //Abstract Class:抽象類別
    //可參考https://ad57475747.medium.com/c-雜記-介面-interface-抽象-abstract-虛擬-virtual-之我見-dc3c5878bb80
    //1.抽象類別不能實作。因為設計邏輯上屬於一個未完整的類別。
    //2.抽象類別中可以定義抽象方法但不能實作且必須為公開(public)。因為這部份是要開放給子類別複寫的。
    //3.抽象類別可以繼承抽象類別，但是一樣不能實作抽象方法
    //4.繼承抽象類別的子類必須複寫父類的的抽象方法
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }  //Position[][] means array of array

        protected abstract Position StartOffset { get; }    //Decide where the blocks spawn in the grid

        public abstract int Id { get; }    //Blocks' IDs

        private int rotationState;  //Blocks' rotation state
        private Position offset;    //Block's offset state

        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }


        // IEnumerable<Position> represents a collection of Position objects that can be enumerated.
        // It's a common pattern in C# to use IEnumerable<T> to represent collections of items,
        // allowing for generic operations across different types of collections.
        public IEnumerable<Position> TilePositions()
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
                //The "yield return" statement allows the method to return each adjusted Position object one at a time
                //without fully executing the method each time.
            }
        }

        public void RotateCW()  //Rotate clockwise
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        public void RotateCCW() //Rotate counter clockwise
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        public void Move(int rows, int columns) //Move Blocks
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        public void Reset() //Reset rotation and position
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
