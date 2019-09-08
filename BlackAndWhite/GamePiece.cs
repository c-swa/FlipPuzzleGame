using System;
namespace BlackAndWhite
{
    public class GamePiece
    {

        /// <summary>
        /// GamePiece Color property
        /// </summary>
        public bool IsBlack { get; private set; }

        private static Random randy = new Random();

        /// <summary>
        /// GamePiece is being constructed when there is no paramter.
        /// </summary>
        public GamePiece()
        {
            int temp = randy.Next(0, 2);
            if (temp == 0)
                IsBlack = true;
            else
                IsBlack = false;
        }

        /// <summary>
        /// GamePiece is being constructed when there is a prequequisite paramter.
        /// </summary>
        /// <param name="isWhite"></param>
        public GamePiece(bool isWhite)
        {
            IsBlack = !isWhite;
        }

        
        /// <summary>
        /// Flips the piece over to the opposite value
        /// </summary>
        public void FlipOver()
        {
            IsBlack = !IsBlack;
        }
    }
}
