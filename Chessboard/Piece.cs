namespace Chess.Board
{
    public class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementsPerformed { get; protected set; }
        public Chessboard Chessboard { get; protected set; }

        public Piece(Position position, Chessboard chessboard, Color color)
        {
            Position = position;
            Chessboard = chessboard;
            Color = color;
            MovementsPerformed = 0;
        }

    }
}