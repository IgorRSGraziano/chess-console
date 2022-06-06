using Chess.Board;

namespace Chess.Pieces
{
    class King : Piece
    {
        public King(Chessboard board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "K";
        }
    }
}