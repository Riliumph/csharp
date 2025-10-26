using StdExt.Drawing;

namespace StdExt.Test.Drawing
{
    public class PictureBoxExtenderTests
    {
        [Theory]
        [MemberData(nameof(GetImageAreaTestData))]
        public void GetImageArea(PictureBox pb, Rectangle expected)
        {
            var result = pb.GetImageArea();
            Assert.Equal(expected, result);
        }

        public static TheoryData<PictureBox, Rectangle> GetImageAreaTestData()
        {
            return new TheoryData<PictureBox, Rectangle>
            {
                {
                    new PictureBox
                    {
                        Width = 300,
                        Height = 200,
                        Image = new Bitmap(100, 100),
                        SizeMode = PictureBoxSizeMode.Zoom,
                    },
                    new Rectangle(50, 0, 200, 200)
                },
            };
        }
    }
}
