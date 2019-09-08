using System;
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
        public int gameOptions()
        {
            Console.WriteLine("Please choose the disk you wish to flip: ");
            int input = Console.Read();
            if (true)
            {
                //
            }
            return input;
        }
    }
}
