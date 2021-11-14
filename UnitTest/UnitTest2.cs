using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GraphicalProgrammingLanguage;

namespace UnitTest
{
    [TestClass]
   public class UnitTest2
    {
        public bool CompareBitmapsLazy(Bitmap bmp1, Bitmap bmp2)
        {
            if (bmp1 == null || bmp2 == null)
                return false;
            if (object.Equals(bmp1, bmp2))
                return true;
            if (!bmp1.Size.Equals(bmp2.Size) || !bmp1.PixelFormat.Equals(bmp2.PixelFormat))
                return false;

            //Compare bitmaps using GetPixel method
            for (int column = 0; column < bmp1.Width; column++)
            {
                for (int row = 0; row < bmp1.Height; row++)
                {
                    if (!bmp1.GetPixel(column, row).Equals(bmp2.GetPixel(column, row)))
                        return false;
                }
            }

            return true;
        }

        [TestMethod]
        public void test()
        {
            Bitmap bitmap1 = new Bitmap(640, 480);
            Bitmap bitmap2 = new Bitmap(640, 480);

            Graphics graphics1 = Graphics.FromImage(bitmap1);
            Graphics graphics2 = Graphics.FromImage(bitmap2);

            Canvas canvas = new Canvas(graphics2);
            commandParser parser = new commandParser(canvas);

            graphics1.DrawLine(new Pen(Color.Black), new Point(0, 0), new Point(100, 100));
            parser.commandLine("drawto 100 100", 0);

            CompareBitmapsLazy(bitmap1, bitmap2);
        }
    }
}
