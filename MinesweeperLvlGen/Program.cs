using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperLvlGen
{
    static class Program
    {
        static void Main(string[] args)
        {
            int x, y, a; string tmp32;
            Console.WriteLine("Please supply: dimX dimY amount and press enter.");
            tmp32 = Console.ReadLine(); x = int.Parse(tmp32);
            tmp32 = Console.ReadLine(); y = int.Parse(tmp32);
            tmp32 = Console.ReadLine(); a = int.Parse(tmp32);

            Minesweeper game = new Minesweeper(y,x,a);
            bool exit = true; 

            while (exit)
            {
                for (int i = 0; i < game.xSize; i++)
                {
                    for (int j = 0; j < game.ySize; j++)
                    {
                        Console.Write(game.level[i, j]); Console.Write(" ");
                    }
                    Console.Write("\n");
                }

                Console.WriteLine("supply cords to reveal, -1 to exit");
                tmp32 = Console.ReadLine(); x = int.Parse(tmp32);
                tmp32 = Console.ReadLine(); y = int.Parse(tmp32);
                if (x == -1 || y == -1)
                {
                    exit = false;
                    break;
                }
                else
                {
                    game.RevealMap(y,x);
                    Console.WriteLine("showing levelLayer");

                    for (int i = 0; i < game.xSize; i++)
                    {
                        for (int j = 0; j < game.ySize; j++)
                        {
                            Console.Write(game.levelLayer[i, j]); Console.Write(" ");
                        }
                        Console.Write("\n");
                    }
                }
            }

            Console.WriteLine("Press any key to close the app.");
            Console.ReadKey();
        }
    }
}
