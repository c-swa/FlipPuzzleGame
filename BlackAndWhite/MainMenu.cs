using System;
using System.Threading;

namespace BlackAndWhite
{
    public class MainMenu
    {
        /// <summary>
        /// This object will control the user interface. Printing everything to
        /// the screen, as well as the interaction between the User and the game.
        ///
        /// It will also control the reading and writing to and from input/output
        /// files. Ensuring that the only data passed between the GamePieces,
        /// GameBoards, and BoardStorage(s) is the internal data. Outside information
        /// will be run through here. 
        /// </summary>


        public MainMenu()
        {
            Console.WriteLine("Welcome!");
        }


        /// <summary>
        /// Interacts with the User in controlling the game.
        /// </summary>
        /// <returns>Returns the integer of the User's input.</returns>
        public void gameOptions()
        {
            ConsoleKeyInfo cki;

            do
            {
                Console.WriteLine("Would you like to: \n(f)lip a piece \n(s)olve the board \n(q)uit");

                while (Console.KeyAvailable == false)
                    Thread.Sleep(200); //Loops every .2 seconds until an input is entered.

                cki = Console.ReadKey(true);



            } while (cki.Key != ConsoleKey.Q);
        }
    }
}
