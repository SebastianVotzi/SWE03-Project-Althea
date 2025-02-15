using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEW03_Bosnia_Logic
{
    // Diese Klasse repräsentiert ein einzelnes Feld im Minesweeper-Spiel.
    public class Tile
    {

        public bool IsMine { get; set; } 

        public int AdjacentMines { get; set; } 

        public bool IsRevealed { get; set; } 

    }
}
