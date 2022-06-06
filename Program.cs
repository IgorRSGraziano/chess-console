using System;

using Chess.Board;

namespace Chess
{
    public class Program
    {
        public static void Main()
        {
            Chessboard board = new Chessboard(8, 8);
            Screen.PrintChessboard(board);
        }
    }
}