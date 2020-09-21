using System;

namespace MaZe_Path
{
    internal class ConsoleMazeVisualizer
    {
        public ConsoleMazeVisualizer()
        {
        }

        private string _space = "  ";
        private string _backSpace = "\b\b";

        internal void Display(MazeTileRow mazePart)
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            Console.Write('\r');
            for (int i = 0; i < mazePart.Height; i++)
            {
                for (int j = 0; j < mazePart.Width; j++)
                {
                    WriteBlock(mazePart.IsWallAt(j, i));
                    if (mazePart.IsPathAt(j, i))
                    {
                        WritePath(true);
                    }
                }
                
                for (int j = mazePart.Width - 1; j >= 0; j--)
                {
                    WriteBlock(mazePart.IsWallAt(j, i));
                }
                Console.WriteLine();
            }
        }

        private void WritePath(bool isPath)
        {
            if (isPath)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.Write(_backSpace + _space);
        }

        private void WriteBlock(bool isWall)
        {
            if (isWall)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
            }
            Console.Write(_space);
        }
    }
}