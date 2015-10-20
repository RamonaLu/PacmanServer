using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacmanREST.Logic;
using PacmanREST.Models;
using System.Collections.Generic;

namespace PacmanREST.Tests
{
    [TestClass]
    public class PolygonFenceCheckingTests
    {
        [TestMethod]
        public void TriangleFence()
        {
            Models.FencePoint point1 = new Models.FencePoint()
            {
                Latitude = 0,
                Longitude = 0
            };
            Models.FencePoint point2 = new Models.FencePoint()
            {
                Latitude = 2,
                Longitude = 0
            };
            Models.FencePoint point3 = new Models.FencePoint()
            {
                Latitude = 0,
                Longitude = 1
            };

            Tuple<Models.FencePoint, Models.FencePoint> side1 = new Tuple<Models.FencePoint, Models.FencePoint>(point1, point2);
            Tuple<Models.FencePoint, Models.FencePoint> side2 = new Tuple<Models.FencePoint, Models.FencePoint>(point2, point3);
            Tuple<Models.FencePoint, Models.FencePoint> side3 = new Tuple<Models.FencePoint, Models.FencePoint>(point3, point1);



            List<Tuple<Models.FencePoint, Models.FencePoint>> sides = new List<Tuple<Models.FencePoint, Models.FencePoint>>();
            sides.Add(side1);
            sides.Add(side2);
            sides.Add(side3);

            Pacman_location_db location = new Pacman_location_db
            {
                coordinates_x = 3,
                coordinates_y = 1
            };

            Assert.IsTrue(!CheckPolygonFence.CheckPointInside(sides, location));
        }

        [TestMethod]
        public void QuadrallateralFence()
        {
            Models.FencePoint point1 = new Models.FencePoint()
            {
                Latitude = 0,
                Longitude = 0
            };
            Models.FencePoint point2 = new Models.FencePoint()
            {
                Latitude = 2,
                Longitude = 0
            };
            Models.FencePoint point3 = new Models.FencePoint()
            {
                Latitude = 0,
                Longitude = 1
            };
            Models.FencePoint point4 = new Models.FencePoint()
            {
                Latitude = 2,
                Longitude = 1
            };

            Tuple<Models.FencePoint, Models.FencePoint> side1 = new Tuple<Models.FencePoint, Models.FencePoint>(point1, point2);
            Tuple<Models.FencePoint, Models.FencePoint> side2 = new Tuple<Models.FencePoint, Models.FencePoint>(point2, point4);
            Tuple<Models.FencePoint, Models.FencePoint> side3 = new Tuple<Models.FencePoint, Models.FencePoint>(point4, point3);
            Tuple<Models.FencePoint, Models.FencePoint> side4 = new Tuple<Models.FencePoint, Models.FencePoint>(point3, point1);



            List<Tuple<Models.FencePoint, Models.FencePoint>> sides = new List<Tuple<Models.FencePoint, Models.FencePoint>>();
            sides.Add(side1);
            sides.Add(side2);
            sides.Add(side3);
            sides.Add(side4);

            Pacman_location_db location = new Pacman_location_db
            {
                coordinates_x = 3,
                coordinates_y = 1
            };

            Assert.IsTrue(!CheckPolygonFence.CheckPointInside(sides, location));
        }

        [TestMethod]
        public void PentagonFence()
        {
            Models.FencePoint point1 = new Models.FencePoint()
            {
                Latitude = 1,
                Longitude = 0
            };
            Models.FencePoint point2 = new Models.FencePoint()
            {
                Latitude = 3,
                Longitude = 0
            };
            Models.FencePoint point3 = new Models.FencePoint()
            {
                Latitude = 4,
                Longitude = 2
            };
            Models.FencePoint point4 = new Models.FencePoint()
            {
                Latitude = 2,
                Longitude = 4
            };
            Models.FencePoint point5 = new Models.FencePoint()
            {
                Latitude = 0,
                Longitude = 2
            };

            Tuple<Models.FencePoint, Models.FencePoint> side1 = new Tuple<Models.FencePoint, Models.FencePoint>(point1, point2);
            Tuple<Models.FencePoint, Models.FencePoint> side2 = new Tuple<Models.FencePoint, Models.FencePoint>(point2, point3);
            Tuple<Models.FencePoint, Models.FencePoint> side3 = new Tuple<Models.FencePoint, Models.FencePoint>(point3, point4);
            Tuple<Models.FencePoint, Models.FencePoint> side4 = new Tuple<Models.FencePoint, Models.FencePoint>(point4, point5);
            Tuple<Models.FencePoint, Models.FencePoint> side5 = new Tuple<Models.FencePoint, Models.FencePoint>(point5, point1);



            List<Tuple<Models.FencePoint, Models.FencePoint>> sides = new List<Tuple<Models.FencePoint, Models.FencePoint>>();
            sides.Add(side1);
            sides.Add(side2);
            sides.Add(side3);
            sides.Add(side4);
            sides.Add(side5);

            Pacman_location_db location = new Pacman_location_db
            {
                coordinates_x = 3,
                coordinates_y = 1
            };

            Assert.IsTrue(CheckPolygonFence.CheckPointInside(sides, location));
        }

        [TestMethod]
        public void HexagonFence()
        {
            Models.FencePoint point1 = new Models.FencePoint()
            {
                Latitude = 1,
                Longitude = 0
            };
            Models.FencePoint point2 = new Models.FencePoint()
            {
                Latitude = 3,
                Longitude = 0
            };
            Models.FencePoint point3 = new Models.FencePoint()
            {
                Latitude = 4,
                Longitude = 2
            };
            Models.FencePoint point4 = new Models.FencePoint()
            {
                Latitude = 3,
                Longitude = 4
            };
            Models.FencePoint point5 = new Models.FencePoint()
            {
                Latitude = 1,
                Longitude = 4
            };
            Models.FencePoint point6 = new Models.FencePoint()
            {
                Latitude = 0,
                Longitude = 2
            };

            Tuple<Models.FencePoint, Models.FencePoint> side1 = new Tuple<Models.FencePoint, Models.FencePoint>(point1, point2);
            Tuple<Models.FencePoint, Models.FencePoint> side2 = new Tuple<Models.FencePoint, Models.FencePoint>(point2, point3);
            Tuple<Models.FencePoint, Models.FencePoint> side3 = new Tuple<Models.FencePoint, Models.FencePoint>(point3, point4);
            Tuple<Models.FencePoint, Models.FencePoint> side4 = new Tuple<Models.FencePoint, Models.FencePoint>(point4, point5);
            Tuple<Models.FencePoint, Models.FencePoint> side5 = new Tuple<Models.FencePoint, Models.FencePoint>(point5, point6);
            Tuple<Models.FencePoint, Models.FencePoint> side6 = new Tuple<Models.FencePoint, Models.FencePoint>(point6, point1);



            List<Tuple<Models.FencePoint, Models.FencePoint>> sides = new List<Tuple<Models.FencePoint, Models.FencePoint>>();
            sides.Add(side1);
            sides.Add(side2);
            sides.Add(side3);
            sides.Add(side4);
            sides.Add(side5);
            sides.Add(side6);

            Pacman_location_db location = new Pacman_location_db
            {
                coordinates_x = 3,
                coordinates_y = 1
            };

            Assert.IsTrue(CheckPolygonFence.CheckPointInside(sides, location));
        }

        [TestMethod]
        public void IrregularConvexFence()
        {
            Models.FencePoint point1 = new Models.FencePoint()
            {
                Latitude = 2,
                Longitude = 2
            };
            Models.FencePoint point2 = new Models.FencePoint()
            {
                Latitude = 6,
                Longitude = 1
            };
            Models.FencePoint point3 = new Models.FencePoint()
            {
                Latitude = 2,
                Longitude = 4
            };
            Models.FencePoint point4 = new Models.FencePoint()
            {
                Latitude = 0,
                Longitude = 4
            };


            Tuple<Models.FencePoint, Models.FencePoint> side1 = new Tuple<Models.FencePoint, Models.FencePoint>(point1, point2);
            Tuple<Models.FencePoint, Models.FencePoint> side2 = new Tuple<Models.FencePoint, Models.FencePoint>(point2, point3);
            Tuple<Models.FencePoint, Models.FencePoint> side3 = new Tuple<Models.FencePoint, Models.FencePoint>(point3, point4);
            Tuple<Models.FencePoint, Models.FencePoint> side4 = new Tuple<Models.FencePoint, Models.FencePoint>(point4, point1);




            List<Tuple<Models.FencePoint, Models.FencePoint>> sides = new List<Tuple<Models.FencePoint, Models.FencePoint>>();
            sides.Add(side1);
            sides.Add(side2);
            sides.Add(side3);
            sides.Add(side4);


            Pacman_location_db location = new Pacman_location_db
            {
                coordinates_x = 4,
                coordinates_y = 3
            };

            Assert.IsTrue(!CheckPolygonFence.CheckPointInside(sides, location));
        }

        [TestMethod]
        public void ConcaveFenceWithThreePointsOnOneLine()
        {
            Models.FencePoint point1 = new Models.FencePoint()
            {
                Latitude = 2,
                Longitude = 0
            };
            Models.FencePoint point2 = new Models.FencePoint()
            {
                Latitude = 4,
                Longitude = 0
            };
            Models.FencePoint point3 = new Models.FencePoint()
            {
                Latitude = 2,
                Longitude = 3
            };
            Models.FencePoint point4 = new Models.FencePoint()
            {
                Latitude = 4,
                Longitude = 6
            };
            Models.FencePoint point5 = new Models.FencePoint()
            {
                Latitude = 0,
                Longitude = 6
            };


            Tuple<Models.FencePoint, Models.FencePoint> side1 = new Tuple<Models.FencePoint, Models.FencePoint>(point1, point2);
            Tuple<Models.FencePoint, Models.FencePoint> side2 = new Tuple<Models.FencePoint, Models.FencePoint>(point2, point3);
            Tuple<Models.FencePoint, Models.FencePoint> side3 = new Tuple<Models.FencePoint, Models.FencePoint>(point3, point4);
            Tuple<Models.FencePoint, Models.FencePoint> side4 = new Tuple<Models.FencePoint, Models.FencePoint>(point4, point5);
            Tuple<Models.FencePoint, Models.FencePoint> side5 = new Tuple<Models.FencePoint, Models.FencePoint>(point5, point1);




            List<Tuple<Models.FencePoint, Models.FencePoint>> sides = new List<Tuple<Models.FencePoint, Models.FencePoint>>();
            sides.Add(side1);
            sides.Add(side2);
            sides.Add(side3);
            sides.Add(side4);
            sides.Add(side5);


            Pacman_location_db location = new Pacman_location_db
            {
                coordinates_x = 4,
                coordinates_y = 3
            };

            Assert.IsTrue(!CheckPolygonFence.CheckPointInside(sides, location));
        }
    }


}
