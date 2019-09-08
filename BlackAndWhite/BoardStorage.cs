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

        private List<GameBoard> CompletedBoardList = new List<GameBoard>();

        public BoardStorage()
        {
            
        }




        /// <summary>
        /// Inserts nextBoard into CompletedBoardList
        /// </summary>
        /// <param name="nextBoard"></param>
        public void insertCompletedBoard(GameBoard nextBoard)
        {
            CompletedBoardList.Add(nextBoard);
        }


        /// <summary>
        /// Returns a string of the list as is stored.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (GameBoard boards in CompletedBoardList)
            {
                builder.AppendLine(boards.ToString());
            }

            return builder.ToString();
        }


        /// <summary>
        /// Writes the entire list of boards into to the file path specified.
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
