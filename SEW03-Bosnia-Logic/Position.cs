namespace SWE03_Bosnia_Logic
{
    public class Position
    {
        // Klasse welche die Position von einer Figur angibt
        public int Row {  get;  }
        public int Column { get; }
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
       
        public override bool Equals(object obj)//Ermöglicht es zwei Positione zu Vergleichen 
        {
            return obj is Position position &&
                   Row == position.Row &&
                   Column == position.Column;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column);//Gibt den Kombinierten HashCode von der Position zurück
        }

        public static bool operator ==(Position left, Position right)//Überschreibung des = Operators damit man Positionen Vergleichen kann 
        {
            return EqualityComparer<Position>.Default.Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)//Überschreibung des != Operators damit man die Ungleichhait von zwei Positione Ausdrücken kann
        {
            return !(left == right);
        }

        public static Position operator +(Position pos, Position pos2) // Überschreibung des + Operators um zwei Positionen zu addieren 
        {
            return new Position(pos.Row + pos2.Row, pos.Column + pos2.Column);
        }
    }
}
