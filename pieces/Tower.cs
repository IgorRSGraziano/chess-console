using Chess.Board;

namespace Chess.Pieces
{
    class Tower : Piece
    {
        public Tower(Chessboard board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "T";
        }
    }
}