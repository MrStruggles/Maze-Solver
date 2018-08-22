using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MazeSolver
{
    class Node
    {
        private Point location;
        private List<Point> neighbours;
        private int distanceFromStart;

        public Node(Point location, List<Point> neighbours, int distanceFromStart)
        {
            this.Location = location;
            this.Neighbours = neighbours;
            this.DistanceFromStart = distanceFromStart;
        }
        public Node()
        {

        }

        public Point Location { get => location; set => location = value; }
        public List<Point> Neighbours { get => neighbours; set => neighbours = value; }
        public int DistanceFromStart { get => distanceFromStart; set => distanceFromStart = value; }
    }
}
