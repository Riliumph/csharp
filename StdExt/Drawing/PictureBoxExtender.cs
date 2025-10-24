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

            int drawWidth;
            int drawHeight;
            bool occuredLetterBox = boxAspect < imgAspect;
            if (occuredLetterBox)
            {
                drawWidth = canvas.Width;
                drawHeight = (int)(canvas.Width / imgAspect);
            }
            else
            {
                drawWidth = (int)(canvas.Height * imgAspect);
                drawHeight = canvas.Height;
            }

            int offsetX = (canvas.Width - drawWidth) / 2;
            int offsetY = (canvas.Height - drawHeight) / 2;

            return new Rectangle(offsetX, offsetY, drawWidth, drawHeight);
        }
    }
}
