using StdExt.Drawing;

namespace StdExt.Math.Transformation
{
    public static class Geometry
    {
        /// <summary>
        /// 空間Aから空間Bへ座標をを射影する関数。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <returns></returns>
        public static Point ProjectPoint(Point p, Size src, Size dst)
        {
            var resized = src.ResizeToFit(dst);
            var offset = resized.OffsetAtCenter(dst);
            var (scaleX, scaleY) = src.ScaleRatio<float>(resized);

            int imgX = (int)((p.X - offset.X) * scaleX);
            int imgY = (int)((p.Y - offset.Y) * scaleY);

            return new Point(imgX, imgY);
        }
    }
}
