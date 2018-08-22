using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MazeSolver
{
    class Maze
    {
        private bool[,] mazeData;
        private static Point start;
        private static Point end;
        private static List<Node> nodes = new List<Node>();

        public bool[,] MazeData { get => mazeData; set => mazeData = value; }
        public static Point Start { get => start; set => start = value; }
        public static Point End { get => end; set => end = value; }
        internal static List<Node> Nodes { get => nodes; set => nodes = value; }

        public Maze(Bitmap img)
        {
            mazeData = new bool[img.Width, img.Height];
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

            CalcNodes();
        }

        private void CalcNodes()
        {
            Point current = new Point();
            List<Point> possibleMoves = new List<Point>();
            List<Point> visited = new List<Point>();
            List<Point> fallbacks = new List<Point>();

            for (int i = 0; i < mazeData.GetLength(0); i++)
            {
                if (mazeData[i, 0])
                {
                    start = new Point(i,0);
                }

                if (mazeData[i, mazeData.GetLength(1) - 1])
                {
                    end = new Point(i, mazeData.GetLength(1) - 1);
                }
            }

            current = new Point(start.X,start.Y + 1);
            visited.Add(start);

            possibleMoves.Clear();
            int yModifier = 0;
            int xModifier = 1;

            while (current != end)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (mazeData[current.X + xModifier, current.Y + yModifier])
                    {
                        Point potentialMove = new Point(current.X + xModifier, current.Y + yModifier);
                        bool contained = false;
                        foreach (Point point in visited)
                        {
                            if (point == potentialMove)
                            {
                                contained = true;
                            }
                        }

                        if (!contained)
                        {
                            possibleMoves.Add(potentialMove);
                        }

                    }

                    if (yModifier == 0 && xModifier == 1)
                    {
                        xModifier = -1;
                    }
                    else if (yModifier == 0 && xModifier == -1)
                    {
                        yModifier = 1;
                        xModifier = 0;
                    }
                    else if (yModifier == 1 && xModifier == 0)
                    {
                        yModifier = -1;
                    }
                    else if (yModifier == -1 && xModifier == 0)
                    {
                        yModifier = 0;
                        xModifier = 1;
                    }
                }

                visited.Add(current);

                if (possibleMoves.Count != 0)
                {
                    if (possibleMoves.Contains(end))
                    {
                        current = end;
                    }
                    else
                    {
                        current = possibleMoves[0];
                        possibleMoves.RemoveAt(0);
                    }
                    

                    if (possibleMoves.Count > 0)
                    {
                        fallbacks.AddRange(possibleMoves);
                    } 
                }
                else
                {
                    //there are no possible moves so go to a fallback
                    if (fallbacks.Count != 0)
                    {
                        current = fallbacks[0];
                        fallbacks.RemoveAt(0);
                    } 
                }
                possibleMoves.Clear();
            }

            //convert visited nodes into list of Nodes with neighbours
            foreach (Point point in visited)
            { 
                List<Point> neighbours = new List<Point>();

                for (int i = 0; i < 4; i++)
                {
                    if (visited.Contains(new Point(point.X + xModifier, point.Y + yModifier)))
                    {
                        neighbours.Add(point);
                    }
                    if (yModifier == 0 && xModifier == 1)
                    {
                        xModifier = -1;
                    }
                    else if (yModifier == 0 && xModifier == -1)
                    {
                        yModifier = 1;
                        xModifier = 0;
                    }
                    else if (yModifier == 1 && xModifier == 0)
                    {
                        yModifier = -1;
                    }
                    else if (yModifier == -1 && xModifier == 0)
                    {
                        yModifier = 0;
                        xModifier = 1;
                    }
                }

                Node node = new Node() {
                    Location = point,
                    Neighbours = neighbours
                };

                nodes.Add(node);
            }
        }

    }
}
