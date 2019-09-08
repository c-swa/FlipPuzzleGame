using System;

namespace BlackAndWhite
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            GameBoard gameBoard = new GameBoard();
            Console.Write(gameBoard);
            Console.WriteLine();
            gameBoard.Flip(0, 0);
            Console.Write(gameBoard);

            MainMenu main = new MainMenu();


        }
        
    }
}
