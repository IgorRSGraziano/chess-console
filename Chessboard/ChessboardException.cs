using System;

namespace Chess.Board
{
    public class ChessboardException : Exception
    {
        public ChessboardException(string message) : base(message) { }
    }
}