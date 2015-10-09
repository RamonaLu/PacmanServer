using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PacmanREST.Models;

namespace PacmanREST.Logic
{
    public class CheckPolygonFence
    {
        private const decimal EPSILON = 2;
        private const decimal INFINITY = decimal.MaxValue;

        public static bool CheckPointInside(IEnumerable<Tuple<FencePoint, FencePoint>> sides, Pacman_location_db point)
        {
            int count = 0;
            foreach (Tuple<FencePoint, FencePoint> side in sides)
            {
                if (RayIntersectsSegment(point, side))
                {
                    count += 1;
                }
            }
            if (IsOdd(count))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsOdd(int count)
        {
            if (count % 2 != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool RayIntersectsSegment(Pacman_location_db point, Tuple<FencePoint, FencePoint> side)
        {
            if ((point.coordinates_y == side.Item1.YCoordinate) || (point.coordinates_y == side.Item2.YCoordinate))
            {
                var newPoint = new Pacman_location_db()
                {
                    coordinates_x = point.coordinates_x,
                    coordinates_y = point.coordinates_y + EPSILON
                };
                point = newPoint;
            }
            if ((point.coordinates_y < side.Item1.YCoordinate) || (point.coordinates_y > side.Item2.YCoordinate))
            {
                return false;
            }
            else if (point.coordinates_x > Math.Max(side.Item1.XCoordinate, side.Item2.XCoordinate))
            {
                return false;
            }
            else
            {
                decimal m_red;
                decimal m_blue;
                if (point.coordinates_x < Math.Min(side.Item1.XCoordinate, side.Item2.XCoordinate))
                {
                    return true;
                }
                else
                {
                    if (side.Item1.XCoordinate != side.Item2.XCoordinate)
                    {
                        m_red = (side.Item2.YCoordinate - side.Item1.YCoordinate) / (side.Item2.XCoordinate - side.Item1.XCoordinate);
                    }
                    else
                    {
                        m_red = INFINITY;
                    }
                    if (side.Item1.XCoordinate != point.coordinates_x)
                    {
                        m_blue = (point.coordinates_y - side.Item1.YCoordinate) / (point.coordinates_x - side.Item1.XCoordinate);
                    }
                    else
                    {
                        m_blue = INFINITY;
                    }
                    if (m_blue >= m_red)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}