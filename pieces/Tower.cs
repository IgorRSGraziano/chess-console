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
                while (Chessboard.IsValidPosition(pos) && CanMoveTo(pos))
                {
                    matrix[pos.Row, pos.Collum] = true;

                    if (Chessboard.Piece(pos) != null && Chessboard.Piece(pos).Color != Color)
                        break;

                    pos.Row += difLine;
                    pos.Collum += difCollum;

                }
            }

            testingPosition(-1, 0); //Top
            testingPosition(0, 1); //Right
            testingPosition(1, 0); //Down
            testingPosition(0, -1); //Left

            return matrix;
        }
    }
}