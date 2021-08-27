using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransMe
{
    public static class PointExt
    {

        public static double DistanceFrom(this Point p, Point another)
        {
            var dx = p.X - another.X;
            var dy = p.Y - another.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static bool InRect(this Point p, Point rectPoint, Size rectSize)
        {
            var xIn = rectPoint.X < p.X && p.X < rectPoint.X + rectSize.Width;
            var yIn = rectPoint.Y < p.Y && p.Y < rectPoint.Y + rectSize.Height;
            return xIn && yIn;
        }
    }
}
