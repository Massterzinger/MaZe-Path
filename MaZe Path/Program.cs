using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaZe_Path
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new MazeGenerator(9);
            var visualizer = new ConsoleMazeVisualizer();

            Console.WriteLine("Press Enter to start, 'q' for exit");
            Console.WriteLine();
            var input = Console.ReadKey();
            while (input.KeyChar != 'q')
            {
                var mazePart = generator.Next();
                visualizer.Display(mazePart);
                input = Console.ReadKey();
            }
        }
    }
}
