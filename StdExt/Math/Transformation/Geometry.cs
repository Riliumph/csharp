using System.Data;
using System.Drawing;

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

        public static Point ProjectPoint2(Size imgSize, Size pbSize)
        {

            var imgAspect = (double)imgSize.Width / imgSize.Height;
            var pbAspect = (double)pbSize.Width / pbSize.Height;
            int drawWidth;
            int drawHeight;
            int offsetX = 0;
            int offsetY = 0;
            bool occuredLetterBox = pbAspect < imgAspect;
            if (occuredLetterBox)
            {
                // 画像が横長の場合はレターボックスが発生
                drawWidth = pbSize.Width;
                // ガイド高を表示領域と画質アス比から算出
                drawHeight = (int)(pbSize.Width / imgAspect);
                // ガイドの表示オフセットを上下均等割りして算出
                offsetY = (pbSize.Height - drawHeight) / 2;
            }
            else
            {
                // 画像が縦長の場合はピラーボックスが発生
                drawHeight = pbSize.Height;
                // ガイド幅を表示領域と画質アス比から算出
                drawWidth = (int)(pbSize.Height * imgAspect);
                // ガイドの表示オフセットを左右均等割りして算出
                offsetX = (pbSize.Width - drawWidth) / 2;
            }
            int marginX = (int)(drawWidth * 2);
            int marginY = (int)(drawHeight * 2);
            var rect = new Rectangle(
                offsetX + marginX,
                offsetY + marginY,
                drawWidth - marginX * 2,
                drawHeight - marginY * 2
            );
            return rect;
        }
    }

}
