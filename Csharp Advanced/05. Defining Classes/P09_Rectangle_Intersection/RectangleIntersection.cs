using System;
using System.Linq;
using System.Collections.Generic;


namespace P09_Rectangle_Intersection
{
   public class RectangleIntersection
    {
       public static void Main(string[] args)
        {
            var numberOfRectanglesAndIntersections = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numberOfRectangles = numberOfRectanglesAndIntersections[0];
            var numberOfIntersections = numberOfRectanglesAndIntersections[1];
            var allRectangles = new List<Rectangle>();

            for (int i = 0; i < numberOfRectangles; i++)
            {
                var properties = Console.ReadLine().Split().ToArray();

                var rectangle = new Rectangle
                {
                    ID = properties[0],
                    Width = double.Parse(properties[1]),
                    Height =double.Parse(properties[2]),
                    CoordinateX = double.Parse(properties[3]),
                    CoordinateY = double.Parse(properties[4])
                };

                allRectangles.Add(rectangle);
            }

            for (int i = 0; i < numberOfIntersections; i++)
            {
                var rectangleIDs = Console.ReadLine().Split();
                var firstID = rectangleIDs[0];
                var secondID = rectangleIDs[1];

                var firstRectangle = allRectangles.FirstOrDefault(x => x.ID == firstID);
                var secondRectangle = allRectangles.FirstOrDefault(x => x.ID == secondID);

                Console.WriteLine(firstRectangle.Intersect(secondRectangle) ? "true" : "false");
            }


        }
    }
}
