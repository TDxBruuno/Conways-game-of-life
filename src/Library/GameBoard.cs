using System;
using System.IO;
using System.Threading;


namespace PII_Game_Of_Life
{
    public class GameBoard
    {
        private bool[,] gameBoard;
        private int width;
        private int height;

        public GameBoard(int width, int height, bool[,] initialBoard)
        {
            this.width = width;  
            this.height = height;
            gameBoard = new bool[width, height];
            Array.Copy(initialBoard, gameBoard, initialBoard.Length);
        }
        public bool[,] GetBoard
        {
            get { return gameBoard; }
        }

        public void BoardGeneration()
        {
            bool[,] cloneboard = new bool[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int aliveNeighbors = CountAliveNeighbors(x,y);
                    if(gameBoard[x,y])
                    {
                        aliveNeighbors--;
                    }
                    if (gameBoard[x,y] && aliveNeighbors < 2)
                    {
                        //Celula muere por baja población
                        cloneboard[x,y] = false;
                    }
                    else if (gameBoard[x,y] && aliveNeighbors > 3)
                    {
                        //Celula muere por sobrepoblación
                        cloneboard[x,y] = false;
                    }
                    else if (!gameBoard[x,y] && aliveNeighbors == 3)
                    {
                        //Celula nace por reproducción
                        cloneboard[x,y] = true;
                    }
                    else
                    {
                        //Celula mantiene el estado que tenía
                        cloneboard[x,y] = gameBoard[x,y];
                    }
                }
            }
            gameBoard = cloneboard;
        }

        private int CountAliveNeighbors(int x, int y)
        {
            int aliveNeighbors = 0;
            for (int i = x-1; i<=x+1;i++)
            {
                for (int j = y-1;j<=y+1;j++) 
                {
                    if(i>=0 && i<width && j>=0 && j < height && gameBoard[i,j])
                    {
                        aliveNeighbors++;
                    }
                }
            }
            return aliveNeighbors;
        }
    }
}