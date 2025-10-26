using StdExt.Drawing;

namespace StdExt.Math.Transformation
{
    public static class Geometry
    {
        /// <summary>
        /// 空間Aから空間Bへ座標をを射影する関数。
        /// </summary>
        /// <param name="targetPoint"></param>
        /// <param name="srcSpace"></param>
        /// <param name="dstSpace"></param>
        /// <returns></returns>
        public static Point ProjectPoint(Point targetPoint, Size srcSpace, Size dstSpace)
        {
            if (srcSpace.Width == 0 || srcSpace.Height == 0)
                return Point.Empty;

            float srcAspect = (float)srcSpace.Width / srcSpace.Height;
            float dstAspect = (float)dstSpace.Width / dstSpace.Height;

            int drawWidth;
            int drawHeight;
            bool occuredLetterBox = dstAspect < srcAspect;
            if (occuredLetterBox)
            {
                drawWidth = dstSpace.Width;
                drawHeight = (int)(dstSpace.Width / srcAspect);
            }
            else // occuredPillarBox
            {
                drawHeight = dstSpace.Height;
                drawWidth = (int)(dstSpace.Height * srcAspect);
            }

            int offsetX = (dstSpace.Width - drawWidth) / 2;
            int offsetY = (dstSpace.Height - drawHeight) / 2;

            float scaleX = (float)srcSpace.Width / drawWidth;
            float scaleY = (float)srcSpace.Height / drawHeight;

            int imgX = (int)((targetPoint.X - offsetX) * scaleX);
            int imgY = (int)((targetPoint.Y - offsetY) * scaleY);

            return new Point(imgX, imgY);
        }
    }
}
