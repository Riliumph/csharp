using StdExt.Drawing;

namespace StdExt.Test.Drawing
{
    public class SizeExtenderTests
    {
        [Theory]
        [MemberData(nameof(AspectRatioTestData))]
        public void AspectRatio(Size size, double expected)
        {
            var result = size.AspectRatio();
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
            var result = src.ScaleRatio(dst);
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
    }
}
