namespace StdExt.Drawing
{
    public static class SizeExtender
    {
        /// <summary>
        /// Size構造体のアスペクト比を求める関数
        /// </summary>
        /// <param name="size">対象の値</param>
        /// <returns>アスペクト比</returns>
        public static double AspectRatio(this Size size)
        {
            // 構造体なのでnullチェックは不要
            if (size.Height == 0)
                return 0.0;
            return (double)size.Width / size.Height;
        }

        /// <summary>
        /// dstのサイズに対してsrcのスケールを求める関数
        /// srcが20x20でdstが10x10なら2,2が求まる。
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <returns></returns>
        public static (double, double) ScaleRatio(this Size src, Size dst)
        {
            if (dst.Width == 0 || dst.Height == 0)
                return (0.0, 0.0);
            var scaleX = (double)src.Width / dst.Width;
            var scaleY = (double)src.Height / dst.Height;
            return (scaleX, scaleY);
        }
    }
}
