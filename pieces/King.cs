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

        private bool CanMoveTo(Position pos)
        {
            Piece p = Chessboard.Piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[Chessboard.Rows, Chessboard.Collums];

            Position pos = new Position(0, 0);

            void testingPosition(int difLine, int difCollum)
            {
                pos.SetValues(Position.Row + difLine, Position.Collum + difCollum);
                if (Chessboard.IsValidPosition(pos) && CanMoveTo(pos))
                {
                    matrix[pos.Row, pos.Collum] = true;
                }
            }

            testingPosition(-1, 0); //Top
            testingPosition(-1, 1); //Northeast
            testingPosition(0, 1); //Right
            testingPosition(1, 1); //Southeast
            testingPosition(1, 0); //Down
            testingPosition(1, -1); //SouthWeast
            testingPosition(0, -1); //Left
            testingPosition(-1, -1); //Northwest

            return matrix;
        }
    }
}