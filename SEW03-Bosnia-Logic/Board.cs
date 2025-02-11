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
    public class Board // Eine Klasse Für das Spielbrett  
    {
        private int _row;
        public int Row { get => _row; }
        private int _collum;
        public int Collum { get => _collum; }
        private int _bombcount;
        public int Bombcount { get=> _bombcount;}

        private bool _clicked= false;

        private int[,,] _gameBoard;
        public int[,,] GameBoard { get => _gameBoard;  }
        public Board(int row, int collum, int bombcount, int[,,] gameboard) 
        { 
            this._row = row;
            this._collum = collum;
            this._bombcount = bombcount;
            this._gameBoard = gameboard;

        }

        public void InitializeBoard() // Generiert das Board am Anfang des Spieles
        {
            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _collum; j++)
                {
                    _gameBoard[i, j, 0] = 0;
                }
            }
            

        }

        public void AddMines(int startx, int starty)//Generiert die Minen 
        { 

            int placedBombs = 0;
            Random randomGenerator = new Random();

            while (placedBombs < _bombcount)
            {

                int x = randomGenerator.Next(0, _row);
                int y = randomGenerator.Next(0, _collum);

                if (_gameBoard[x, y, 0] == 0 && x != startx && y != starty)
                {

                    _gameBoard[x, y, 0] = -1;// -1==Mine, 0 == Normales Feld
                    placedBombs++;

                }
                


            }
        }


        public bool Clicked(int x, int y)
        {
            
            if (_clicked == false)// Wenn es der erste Click ist werden die Minen generiert 
            {
                InitializeBoard();
                AddMines(x, y);
                _clicked = true;
            }

            if (_gameBoard[x, y, 0] == -1)
            {
                return false;// Ist eine Mine
            }
            else if(_gameBoard[x, y, 0] == 0)
            {
               
                return true;// Ist keine Mine
            }
            return false;// Standart case wird nicht eintreten
        }

        







    }


}
