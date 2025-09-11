using StdExt.Math.Transformation;
using System.Drawing;

namespace StdExt.Tests.Math.Transformation
{
    public class GeometryTests
    {
        [Theory]
        [MemberData(nameof(ProjectPointData))]
        public void ProjectPoint(Point t, Size src, Size dst, Point expected)
        {
            var result = Geometry.ProjectPoint(t, src, dst);
            Assert.Equal(expected, result);
        }

        public static TheoryData<Point, Size, Size, Point> ProjectPointData
        ()
        {
            return new TheoryData<Point, Size, Size, Point>
            {
                {new Point(100, 100), new Size(3840, 2160), new Size(800,800), new Point(480,-360)},
                {new Point(100, 100), new Size(3840, 2160), new Size(1920,1080), new Point(200,200)},
            };
        }
    }
}
