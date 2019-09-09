///Christopher Aram Swayne
///(c) 2019-9-9
///All Rights Reserved
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;


namespace BlackAndWhite
{
    class GameBoardSolution
    {
        public int row { get; private set; }
        public int col { get; private set; }
        //Sort to the next step towards the solution
        public UInt32 previous { get; private set; }

        public GameBoardSolution()
        {
            row = 0;
            col = 0;

            //value of the step to the next step.
            //0 signifies there are no more steps.
            previous = 0;
        }

        public GameBoardSolution(int r, int c, UInt32 next)
        {
            row = r;
            col = c;
            previous = next;
        }

    }



    class MainClass
    {

        //Converts the board recieved into a modifiable 2D boolean array.
        public static bool[,] Convert(UInt32 board)
        {
            bool[,] newBoard = new bool[5,5];

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if ((board % 2) == 1)
                        newBoard[row, col] = true;
                    else
                        newBoard[row, col] = false;

                    board /= 2;
                }
            }
            return newBoard;
        }

        /// <summary>
        /// Converts the boolean array back into an Unsigned integer
        /// </summary>
        /// <param name="boardRepresented"></param>
        /// <returns></returns>
        public static UInt32 ConvertBack(bool[,] boardRepresented)
        {
            UInt32 result = 0;
            for (int x = 0; x < 5; x++)
                for (int y = 0; y < 5; y++)
                    if (boardRepresented[x, y])
                        result += (UInt32)Math.Pow(2, (x * 5 + y));
            return result;
        }

        //Flips pieces.
        public static UInt32 Flip(UInt32 board, int row, int col)
        {
            bool[,] newBoard = Convert(board);
            for (int x = 0; x < 5; x++)
            {
                newBoard[x, col]= !newBoard[x,col];
            }
            for (int y = 0; y < 5; y++)
            {
                newBoard[row, y]= !newBoard[row, y];
            }
            newBoard[row, col]= !newBoard[row,col];

            return ConvertBack(newBoard);

        }

        /// <summary>
        /// Iterates through all possible solutions that can be derived by running through the tree of children from the
        /// parent boards.
        /// </summary>
        /// <param name="incomplete"></param>
        /// <param name="gameSolutions"></param>
        public static void IterateSolutions(Dictionary<UInt32, GameBoardSolution> gameSolutions, Queue<UInt32> incomplete)
        {
            UInt32 current;
            while (incomplete.Count() != 0) {
                UInt32 previous = incomplete.Peek();
                incomplete.Dequeue();
                for (int row = 0; row < 5; row++)
                {
                    for (int col = 0; col < 5; col++)
                    {
                        current = Flip(previous, row, col);
                        if (!gameSolutions.ContainsKey(current))
                        {
                            displayBoard(current);
                            gameSolutions[current] = new GameBoardSolution(row, col, previous);
                            incomplete.Enqueue(current);
                        } else
                        {
                            Console.WriteLine(".");
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Prints out the board to the console.
        /// </summary>
        /// <param name="boardValue"></param>
        public static void displayBoard(UInt32 boardValue)
        {
            bool[,] board = new bool[5, 5];
            board = Convert(boardValue);
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (board[row, col])
                        Console.Write('1');
                    else
                        Console.Write('0');
                }
                Console.Write("\n");
            }
            Console.WriteLine("");
        }
        /// <summary>
        /// Searches through the array for the Solution Path.
        /// </summary>
        /// <param name="gameSolutions"></param>
        /// <param name="search"></param>
        public void Find(Dictionary<UInt32, GameBoardSolution> gameSolutions, UInt32 search)
        {
            GameBoardSolution temp = gameSolutions[search];
            while (temp.previous != 0)
            {
                temp = gameSolutions[temp.previous];
            }

        }

        /// <summary>
        /// Main Function
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            UInt32 baseValue = 0;


            Dictionary<UInt32, GameBoardSolution> gameStates = new Dictionary<UInt32, GameBoardSolution>();
            Queue<UInt32> incomplete = new Queue<UInt32>();
            incomplete.Enqueue(baseValue);

            IterateSolutions(gameStates, incomplete);
            Console.WriteLine("Dictionary Size: " + gameStates.Count());
        }
        
    }
}
