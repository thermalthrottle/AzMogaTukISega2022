﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameLogic
{
    internal class Board
    {
        private char[,] board;

        public char[,] GameBoard { get => board; }

        public Board(int width, int height)
        {
            board = new char[width, height];
        }

        public void Place(int x, int y, char player)
        {
            if (!CheckIFGameFinished())
            {
                if (!IsPlacementOccupied(x, y))
                {
                    board[y, x] = player;
                    PlaceStraigthBlockades(x, y);
                    PlaceDiagonalBlockades(x, y);
                }
            }
        }

        private void PlaceStraigthBlockades(int xOFPlacement, int yOFPlacement)
        {

            for (int i = 0; i < board.GetLength(1); i++)
            {
                if (!IsPlacementOccupied(i, yOFPlacement))
                {
                    board[yOFPlacement, i] = '*';
                }

            }
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (!IsPlacementOccupied(xOFPlacement, i))
                {
                    board[i, xOFPlacement] = '*';
                }
            }
        }

        private void PlaceDiagonalBlockades(int xOFPlacement, int yOFPlacement)
        {

        }
             

        private bool IsPlacementOccupied(int x, int y)
        {
            if (board[y,x] != '\0')
            {
                return true;
            }
            return false;
        }

        private bool IsPlacementOutsideTheBoard(int x, int y)
        {
            if (x >= board.GetLength(0) || x < 1 || y >= board.GetLength(1) || y < 1)
            {
                return true;
            }
            return false;
        }

        private bool CheckIFGameFinished()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    if (IsPlacementOccupied(i,j))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
