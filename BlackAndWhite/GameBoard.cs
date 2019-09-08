using System.Text;
using System.IO;

namespace BlackAndWhite
{
    public class GameBoard
    {
        private GamePiece[,] gameBoard = new GamePiece[5, 5];

        /// <summary>
        /// Initialize random game board
        /// </summary>
        public GameBoard()
        {
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    //Assigns default values to each piece.
                    gameBoard[row, col] = new GamePiece();
                }
            }
        }

        /// <summary>
        /// Sets up a board that is either entirely white, or entirely black.
        /// </summary>
        /// <param name="isWhite"></param>
        public GameBoard(bool isWhite)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    //randomly assigns values to each piece.
                    gameBoard[row, col] = new GamePiece(isWhite);
                }
            }
        }

        public bool Equals(GameBoard board)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (this.GetGamePiece(row, col).IsBlack != board.GetGamePiece(row, col).IsBlack)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public GamePiece GetGamePiece(int row, int col)
        {
            if ((row < 5 && row >= 0) || (col >= 0 && col < 5))
                return gameBoard[row, col];
            else
                throw new System.Exception("Row and Column to get GamePiece out of bounds");
        }

        /// <summary>
        /// Method flips the whole row and colum of the selected piece on the board.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void Flip(int row, int col)
        {
            for (int x = 0; x < 5; x++)
            {
                gameBoard[x, col].FlipOver();
            }
            for (int y = 0; y < 5; y++)
            {
                gameBoard[row, y].FlipOver();
            }
            gameBoard[row, col].FlipOver();
        }

        /// <summary>
        /// Returns a string of the array as is stored.
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    bool isBlack = gameBoard[row, col].IsBlack;
                    builder.Append(isBlack ? "1":"0");
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }

        /// <summary>
        /// Writes gameBoard as a string to the file path specified.
        /// </summary>
        public void WriteToFile(string filePath)
        {

            //Variable 'output' will automatically be disposed of when out of scope of the 'using' clause.
            using (StreamWriter output = new StreamWriter(filePath))
            {
                output.Write(ToString());
            }
            
        }

    }
}
