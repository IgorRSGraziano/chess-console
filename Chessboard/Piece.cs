namespace Chess.Board
{
    public abstract class Piece
    {
        public Position? Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementsPerformed { get; protected set; }
        public Chessboard Chessboard { get; protected set; }

        public Piece(Chessboard chessboard, Color color)
        {
            Position = null;
            Chessboard = chessboard;
            Color = color;
            MovementsPerformed = 0;
        }
        public void IncrementMovementsPerformed()
        {
            MovementsPerformed++;
        }

        public abstract bool[,] PossibleMoves();

    }
}