using SEW03_Bosnia_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SWE03_Bosnia_Logic
{
    public class Board // Eine Klasse Für das Brett  
    {
        private readonly Tile[,] pieces = new Tile[8, 8]; // Ersteltt ein 8x8 undefiniertes Spielstück was dass Brett sein soll

        public Tile this[int row, int col] // Piece wird durch einen Indexer wie ein Array behandelt und kann damit seine Position in der Row und im Collum asl Eigenschaft haben 
        {
            get { return pieces[row, col]; }
            set { pieces[row, col] = value; }
        }

        public Tile this[Position pos]//Piece wird durch einen Indexer wie ein Array behandelt und kann damit seine Position wiedergeben 
        {
            get { return this[pos.Row, pos.Column]; }
            set { this[pos.Row, pos.Column] = value; }
        }

         public static Board Initial() // Generiert das Board am Anfang des Spieles
        {
            Board board = new Board();
            board.AddStartPieces();
            return board;
        }

        private void AddMines()
        {

        }
        
        public static bool IsInside(Position pos) // Schaut ob eine Figur auf der Position von einer anderen ist 
        {
            return pos.Row >= 0 && pos.Row < 8 && pos.Column >= 0 && pos.Column < 8;
        }

        public bool IsEmpty(Position pos)// Schaut ob ein Spielfeld leer ist 
        {
            return this[pos] == null;
        }

        public IEnumerable<Position> PiecePositions()//Gibt die Positionen aller Figuren zurück
        {
            for(int i = 0;i < 8; i++)
            {
                for (int j = 0;j < 8; j++)
                {
                    Position pos = new Position(i, j);

                    if (!IsEmpty(pos))
                    {
                        yield return pos;
                    }
                }
            }
        }

        public IEnumerable<Position> PiecePositionsFor()//Gibt die Position aller Figuren eines Spielers zurück
        {
            return PiecePositions();
        }

       

        

        
    }
}
