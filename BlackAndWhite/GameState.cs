using System;
using System.Collections.Generic;

namespace BlackAndWhite
{

    public class GameState
    {
        public GameBoard Parent { get; private set; }
        public GameBoard Board { get; private set; }
        public List<GameBoard> Children { get; private set; }  = new List<GameBoard>();

        public GameState(GameBoard board, GameBoard parent=null)
        {
            Board = board;
            Parent = parent;
        }
    }

}
