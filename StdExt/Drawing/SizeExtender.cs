using System.Numerics;

namespace StdExt.Drawing
{
    public static class SizeExtender
    {
        /// <summary>
        /// Size構造体のアスペクト比を求める関数
        /// </summary>
        /// <param name="size">対象の値</param>
        /// <returns>アスペクト比</returns>
        public static T AspectRatio<T>(this Size size)
            where T : INumber<T>
        {
            // 構造体なのでnullチェックは不要
            if (size.Height == 0)
                return T.Zero;
            var w = T.CreateChecked(size.Width);
            var h = T.CreateChecked(size.Height);
            return w / h;
        }

        /// <summary>
        /// dstのサイズに対してsrcのスケールを求める関数
        /// srcが20x20でdstが10x10なら2,2が求まる。
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <returns></returns>
        public static (T, T) ScaleRatio<T>(this Size src, Size dst)
            where T : INumber<T>
        {
            if (dst.Width == 0 || dst.Height == 0)
                return (T.Zero, T.Zero);
            var srcW = T.CreateChecked(src.Width);
            var dstW = T.CreateChecked(dst.Width);
            var scaleX = srcW / dstW;
            var srcH = T.CreateChecked(src.Height);
            var dstH = T.CreateChecked(dst.Height);
            var scaleY = srcH / dstH;
            return (scaleX, scaleY);
        }
    }
}
