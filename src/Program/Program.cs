using System;

namespace PII_Game_Of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = @"../../assets/board.txt";
            Importer importer = new Importer();
            bool [,] initialBoard = importer.ImportTxt(url);

            int width = initialBoard.GetLength(0);
            int height = initialBoard.GetLength(1);

            GameBoard gameBoard= new GameBoard(width, height, initialBoard);

            Printer printer = new Printer(gameBoard.GetBoard, width, height);
            printer.Print();
        }
    }
}
