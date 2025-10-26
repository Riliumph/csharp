using StdExt.Drawing;

namespace StdExt.Test.Drawing
{
    public class SizeExtenderTests
    {
        [Theory]
        [MemberData(nameof(AspectRatioTestData))]
        public void AspectRatio(Size size, double expected)
        {
            var result = size.AspectRatio<double>();
            Assert.Equal(expected, result, 5);
        }

        public static TheoryData<Size, double> AspectRatioTestData()
        {
            return new TheoryData<Size, double>
            {
                { new Size(10, 10), 10.0 / 10 },
                { new Size(1920, 1080), 1920.0 / 1080 },
            };
        }

        [Theory]
        [MemberData(nameof(ScaleRatioTestData))]
        public void ScaleRatio(Size src, Size dst, (double, double) expected)
        {
            var result = src.ScaleRatio<double>(dst);
            Assert.Equal(expected, result);
        }

        public static TheoryData<
            Size,
            Size,
            (double, double)
        > ScaleRatioTestData()
        {
            return new TheoryData<Size, Size, (double, double)>
            {
                { new Size(10, 10), new Size(10, 10), (1.0, 1.0) },
                { new Size(3840, 2160), new Size(1920, 1080), (2, 2) },
            };
        }

        [Theory]
        [MemberData(nameof(ResizeToFitData))]
        public void ResizeToFit(Size src, Size dst, Size expected)
        {
            var result = src.ResizeToFit(dst);
            Assert.Equal(expected, result);
        }

        public static TheoryData<Size, Size, Size> ResizeToFitData()
        {
            return new TheoryData<Size, Size, Size>
            {
                {
                    new Size(3840, 2160),
                    new Size(1920, 1080),
                    new Size(1920, 1080)
                },
                {
                    new Size(3840, 2160),
                    new Size(800, 600),
                    new Size(800, 450)
                },
            };
        }

        [Theory]
        [MemberData(nameof(OffsetAtCenterData))]
        public void OffsetAtCenter(Size src, Size dst, Point expected)
        {
            var result = src.OffsetAtCenter(dst);
            Assert.Equal(expected, result);
        }

        public static TheoryData<Size, Size, Point> OffsetAtCenterData()
        {
            return new TheoryData<Size, Size, Point>
            {
                { new Size(640, 480), new Size(800, 600), new Point(80, 60) },
                { new Size(800, 600), new Size(640, 480), new Point(-80, -60) },
            };
        }
    }
}
