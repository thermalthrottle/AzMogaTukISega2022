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
                if (IsPlacementOutsideTheBoard(x,y))
                {
                    throw new ArgumentException("Indexes were outside of the board");
                }
                if (IsPlacementOccupied(x, y))
                {
                    throw new ArgumentException("The cell is occupied");
                }
                board[x, y] = player;
                PlaceStraigthBlockades(x, y);
                PlaceDiagonalBlockades(x, y);
            }
        }

        private void PlaceStraigthBlockades(int xOFPlacement, int yOFPlacement)
        {

            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (!IsPlacementOccupied(i, yOFPlacement))
                {
                    board[i, yOFPlacement] = '*';
                }

            }
            for (int i = 0; i < board.GetLength(1); i++)
            {
                if (!IsPlacementOccupied(xOFPlacement, i))
                {
                    board[xOFPlacement, i] = '*';
                }
            }
        }

        private void PlaceDiagonalBlockades(int xOFPlacement, int yOFPlacement)
        {

        }
             

        private bool IsPlacementOccupied(int x, int y)
        {
            if (board[x,y] != '\0')
            {
                return true;
            }
            return false;
        }

        private bool IsPlacementOutsideTheBoard(int x, int y)
        {
            if (x >= board.GetLength(0) || x < 0 || y >= board.GetLength(1) || y < 0)
            {
                return true;
            }
            return false;
        }

        public bool CheckIFGameFinished()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    if (!IsPlacementOccupied(i,j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
