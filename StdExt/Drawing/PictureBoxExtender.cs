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
            var resized = canvas.Image.Size.ResizeToFit(canvas.Size);
            var offset = resized.OffsetAtCenter(canvas.Size);
            return new Rectangle(offset, resized);
        }
    }
}
