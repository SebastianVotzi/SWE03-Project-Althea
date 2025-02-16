using SEW03_Bosnia_Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SWE03_Bosnia_Logic 
{
    public class Board : Object// Eine Klasse Für das Spielbrett  in dem auch der Status des Spiels gespeichert wird
    {

        private int _row;
        public int Row { get => _row; }

        private int _collum;
        public int Collum { get => _collum; }

        private int _bombcount;
        public int Bombcount { get=> _bombcount;}

        private bool _clicked= false;// Variable die Speichert ob es der Click auf ein Feld ist
        private bool _gameover = false;// Variable die Speichert ob das Spiel vorbei ist
        public bool Gameover { get => _gameover;}
        private Tile[,] _gameBoard = new Tile[10, 10]; // 2 Dimensionales Array für das Spielfeld

        public Tile[,] GameBoard { get => _gameBoard; }

        private Random randomGenerator = new Random();
        
        public Board(int row, int collum, int bombcount) 
        { 

            this._row = row;
            this._collum = collum;
            this._bombcount = bombcount;
            
        }

        public void InitializeBoard() // Generiert das Board am Anfang des Spieles
        {

            for (int x = 0; x < _row; x++)
            {

                for (int y = 0; y < _collum; y++)
                {

                    _gameBoard[x, y] = new Tile();// Erstellt ein neues leeres Tile Object an jeder Stelle des Spielfeldes

                }

            }
            
        }

        public void AddMines()//Generiert die Minen 
        { 

            int placedBombs = 0;
            
            while (placedBombs < _bombcount)
            {
                // Generiert Zufällige Koordinaten für die Minen
                int x = randomGenerator.Next(0, _row);
                int y = randomGenerator.Next(0, _collum);

                if (!_gameBoard[x, y].IsMine )// Schaut ob dass Feld noch keine Mine hat 
                {

                    _gameBoard[x, y].IsMine = true;
                    placedBombs++;

                }
                
            }

        }

        private void CalculateAdjacentMines()// Berechnet die Anzahl der Minen die um ein Feld sind und speichert die Anzahl in AdjacentMines
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (!_gameBoard[x, y].IsMine)
                    {
                        _gameBoard[x, y].AdjacentMines = CountMinesAround(x, y);
                    }
                }
            }
        }

        private int CountMinesAround(int x, int y)// Zählt die Minen um ein Feld und gibt diese als Integer zurück
        {
            int count = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int newX = x + i;
                    int newY = y + j;
                    if (newX >= 0 && newX < 10 && newY >= 0 && newY < 10 && _gameBoard[newX, newY].IsMine)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public void RevealTile(int x, int y)
        {

            // Überprüft, ob die Koordinaten außerhalb des Spielfelds liegen
            if (x < 0 || x >= 10 || y < 0 || y >= 10)
            {

                return; 

            }

            var tile = _gameBoard[x, y];

            // Überprüft, ob das Feld bereits aufgedeckt ist
            if (tile.IsRevealed)
            {

                return; 

            }

            // Überprüft, ob das Feld eine Mine ist
            if (tile.IsMine)
            {
                
                tile.IsRevealed = true;
                _gameover = true;// Setzt das Spiel auf Gameover
                return;

            }

            // Feld aufdecken
            tile.IsRevealed = true;

            // Wenn das Feld keine benachbarten Minen hat, deckt rekursiv alle benachbarten Felder auf
            if (tile.AdjacentMines == 0)
            {

                for (int i = -1; i <= 1; i++)
                {

                    for (int j = -1; j <= 1; j++)
                    {
                        
                        RevealTile(x + i, y + j);

                    }

                }

            }

        }


        public void Clicked(int x, int y)
        {
            
            if (_clicked == false)// Wenn es der erste Click ist wird das Spielfeld generiert und die Minen hinzugefügt
            {

                InitializeBoard();
                AddMines();
                _clicked = true;

            }
           
            if (!_gameBoard[x, y].IsMine)// Wenn das Feld keine Mine ist wird die Anzahl der benachbarten Minen berechnet
            {

                CalculateAdjacentMines();

            }

            RevealTile(x, y);// Das Feld wird aufgedeckt

        }

    }

}
