using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlackAndWhite
{
    public class BoardStorage
    {
        //private GameBoard[,] boardArray = new GameBoard[,];
        /// <summary>
        /// there are exactly 25 boards from the solution.
        /// Thus from two solution states, we have 50 states.
        /// So, now we have the solution states, and states that are exactly one step away.
        /// There are no more directly linked solutions to the board.
        /// Start generating boards that are two steps away.
        /// there are 2^25 states.
        /// </summary>

        private GameBoard whiteGoalState = new GameBoard(true);
        private GameBoard blackGoalState = new GameBoard(false);

        private List<GameBoard> CompletedGameBoards = new List<GameBoard>();
        private List<GameBoard> IncompletedGameBoards = new List<GameBoard>();


        /// <summary>
        /// Initializes the BoardStorage object
        /// </summary>
        public BoardStorage()
        {
            InsertIncompletedBoard(whiteGoalState);
            InsertIncompletedBoard(blackGoalState);
        }


        /// <summary>
        /// Finds the children of the boards and then adds them to a temporary
        /// List while moving through the IncompletedGameBoards List.
        ///
        /// Once it finishes with the Incomplete List- current elements are moved
        /// out into the CompletedGameBoards, and the children in temp are placed
        /// into Incomplete.
        /// </summary>
        public void IterateIncompleteBoards()
        {
            List<GameBoard> temporaryBoards = new List<GameBoard>();
            foreach (GameBoard gameboard in IncompletedGameBoards)
            {
                for (int row = 0; row < 5; row++) {
                    for (int col = 0; col < 5; col++)
                    {
                        gameboard.Flip(row, col);
                        foreach(GameBoard board in CompletedGameBoards)
                        {
                            if (gameboard.Equals(board))
                            {
                                Console.WriteLine("Two Iterative Boards Matched.");
                            }
                            else
                            {
                                temporaryBoards.Add(gameboard);
                            }
                        }
                        
                    }
                }
                CompletedGameBoards.Add(gameboard);
            }
            IncompletedGameBoards.Clear();

            foreach(GameBoard gameBoard in temporaryBoards)
            {
                IncompletedGameBoards.Add(gameBoard);
            }
            temporaryBoards.Clear();
        }

        /// <summary>
        /// Inserts nextBoard into CompletedGameBoards
        /// </summary>
        /// <param name="nextBoard"></param>
        public void InsertIncompletedBoard(GameBoard nextBoard)
        {
            IncompletedGameBoards.Add(nextBoard);
        }

        /// <summary>
        /// Inserts nextBoard into CompletedGameBoards
        /// </summary>
        /// <param name="nextBoard"></param>
        public void InsertCompletedBoard(GameBoard nextBoard)
        {
            CompletedGameBoards.Add(nextBoard);
        }


        /// <summary>
        /// Returns a string of the list of completed boards as is stored.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (GameBoard boards in CompletedGameBoards)
            {
                builder.AppendLine(boards.ToString());
            }

            return builder.ToString();
        }


        /// <summary>
        /// Writes the entire list of completed boards into to the file path specified.
        /// </summary>
        /// <param name="filePath"></param>
        public void WriteToFile(string filePath)
        {

            
            using (StreamWriter output = new StreamWriter(filePath))
            {
                output.Write(ToString());
            }
        }


        /// <summary>
        /// Reads data from a text file as is stored.
        /// </summary>
        /// <param name="filePath"></param>
        public void ReadFromFile(string filePath)
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                
            }
        }
    }
}
