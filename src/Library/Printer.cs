using System;
using System.IO;
using System.Text;
using System.Threading;

namespace PII_Game_Of_Life
{
    public class Printer
    {

        private bool[,] board; //variable que representa el tablero
        private int width; //variabe que representa el ancho del tablero
        private int height; //variabe que representa altura del tablero
         private bool stopPrinting; // Agregar una bandera para detener la impresión
        
        public Printer(bool[,] board, int width, int height)
        {
            this.board = board;
            this.width = width;
            this.height = height;
            this.stopPrinting = false;
        }

        public void Print()
        {
            while (!stopPrinting) // Continuar mientras la bandera sea falsa
            {
                Console.Clear();
                StringBuilder s = new StringBuilder();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (board[x, y])
                        {
                            s.Append("|X|");
                        }
                        else
                        {
                            s.Append("___");
                        }
                    }
                    s.Append("\n");
                }
                Console.WriteLine(s.ToString());

                GameBoard next = new GameBoard(width, height, board);
                next.BoardGeneration();
                board = next.GetBoard;

                // Verificar si el usuario quiere detener la impresión
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true).Key;
                    if (key == ConsoleKey.Escape)
                    {
                        stopPrinting = true;
                    }
                }

                Thread.Sleep(300);
            }
        
        }
    }
}
