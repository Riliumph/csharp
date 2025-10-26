namespace StdExt.Drawing
{
    public static class PictureBoxExtender
    {
        /// <summary>
        /// PictureBox上の画像領域をPictureBox上の座標で取得する関数
        /// </summary>
        /// <returns>矩形</returns>
        public static Rectangle GetImageArea(this PictureBox canvas)
        {
            if (canvas.Image == null)
                return Rectangle.Empty;

            var imgAspect = (float)canvas.Image.Size.AspectRatio<float>();
            var boxAspect = (float)canvas.Size.AspectRatio<float>();
            bool occuredLetterBox = boxAspect < imgAspect;

            var drawSize = Size.Empty;
            if (occuredLetterBox)
            {
                drawSize.Width = canvas.Width;
                drawSize.Height = (int)(canvas.Width / imgAspect);
            }
            else
            {
                drawSize.Width = (int)(canvas.Height * imgAspect);
                drawSize.Height = canvas.Height;
            }

            var offset = Point.Empty;
            offset.X = (canvas.Width - drawSize.Width) / 2;
            offset.Y = (canvas.Height - drawSize.Height) / 2;

            return new Rectangle(offset, drawSize);
        }
    }
}
