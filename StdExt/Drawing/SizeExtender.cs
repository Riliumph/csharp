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

        /// <summary>
        /// あるSizeを別のサイズ枠に収めるためにリサイズする関数
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <returns></returns>
        public static Size ResizeToFit(this Size src, Size dst)
        {
            if (src.Width == 0 || src.Height == 0)
                return Size.Empty;
            var srcAspect = src.AspectRatio<float>();
            var dstAspect = dst.AspectRatio<float>();
            var occuredLetterBox = dstAspect < srcAspect;

            if (occuredLetterBox)
            {
                return new Size(dst.Width, (int)(dst.Width / srcAspect));
            }
            else
            {
                return new Size((int)(dst.Height * srcAspect), dst.Height);
            }
        }

        /// <summary>
        /// 元のサイズを別のサイズ枠の中央に収めた場合のオフセットを付与する関数
        /// オフセットの場所を記録するためSizeではなくRectangleで返す。
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <returns>オフセットを考慮したサイズ</returns>
        public static Point OffsetAtCenter(this Size src, Size dst)
        {
            var offset = Point.Empty;
            offset.X = (dst.Width - src.Width) / 2;
            offset.Y = (dst.Height - src.Height) / 2;
            return offset;
        }
    }
}
