using SEW03_Bosnia_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SWE03_Bosnia_Logic
{
    public class Board // Eine Klasse Für das Spielbrett  
    {
        private int _row;
        private int _collum;
        private int _bombcount;

        private bool _clicked= false;

        private int[,,] gameBoard = new int [0,0,0];
        public Board(int row, int collum, int bombcount) 
        { 
            this._row = row;
            this._collum = collum;
            this._bombcount = bombcount;
        }

         public void InitializeBoard() // Generiert das Board am Anfang des Spieles
        {
            for (int i = 0; i < _row; i++)
            {
                for(int j =0; j < _collum; j++)
                {
                    gameBoard[i, j, 0] = 0;
                }
            }
            
        }

        private void AddMines(int startx, int starty)//Generiert die Minen 
        { 

            int placedBombs = 0;
            Random randomGenerator = new Random();

            while (placedBombs < _bombcount)
            {

                int x = randomGenerator.Next(0, _row);
                int y = randomGenerator.Next(0, _collum);

                if (gameBoard[x, y, 0] == 0 && x != startx && y != starty)
                {

                    gameBoard[x, y, 0] = 1;// 1==Mine, 0 == Normales Feld
                    placedBombs++;

                }


            }
        }


        public bool Clicked(int x, int y)
        {
            if (_clicked == false)// Wenn es der erste Click ist werden die Minen generiert 
            {
                AddMines(x, y);
                _clicked = true;
            }

            if (gameBoard[x, y, 0] == 1)
            {
                return false;// Ist eine Mine
            }
            else if(gameBoard[x, y, 0] == 0)
            {
               
                return true;// Ist keine Mine
            }
            return true;// Standart case wird nicht eintreten
        }









    }
}
