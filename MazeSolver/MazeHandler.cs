using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MazeSolver
{
    class MazeHandler
    {
        public static bool[,] ConvertToArray(Bitmap img)
        {
            bool[,] mazeData = new bool[img.Width, img.Height];
            for (int i = 0; i < mazeData.GetLength(1); i++)
            {
                for (int j = 0; j < mazeData.GetLength(0); j++)
                {
                    if (img.GetPixel(j, i).Name == "ff000000")
                    {
                        mazeData[j, i] = false;
                    }
                    else
                    {
                        mazeData[j, i] = true;
                    }
                }
            }

            return mazeData;
        }

        public static bool[,] FloodFillSolve(bool[,] maze)
        {
            bool[,] solvedMaze = maze;


            return solvedMaze;
        }
    }
}
