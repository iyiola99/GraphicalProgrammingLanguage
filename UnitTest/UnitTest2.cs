using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using GraphicalProgrammingLanguage;
using System.IO;

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
        public void testHelp(Action<commandParser>action,Action<System.Drawing.Graphics,System.Drawing.Pen>action1)
        {
            Bitmap bitmap1 = new Bitmap(640, 480);
            Bitmap bitmap2 = new Bitmap(640, 480);

            Graphics graphics1 = Graphics.FromImage(bitmap1);
            Graphics graphics2 = Graphics.FromImage(bitmap2);

            Canvas canvas = new Canvas(graphics2);
            commandParser parser = new commandParser(canvas);

            graphics1.DrawLine(new Pen(Color.Black), new Point(0, 0), new Point(100, 100));
            parser.CommandLine("drawto 100 100", 0);

            CompareBitmapsLazy(bitmap1, bitmap2);
        }

        [TestMethod]
        public void parserClasstest()
        {
            testHelp(parser => { parser.programWindow("drawto 50,50"); },
                (g, pen) =>
                {
                    g.DrawLine(pen,0,0,20,20);
                }
               
                ) ;
        }
      [TestMethod]
      public void whileloopTest()
        {
            void action (commandParser parser)
            {
                using (StreamReader streamReader= File.OpenText("..\\..\\..\\Desktop\\while loop.txt"))
                {
                    string reader = streamReader.ReadToEnd();
                    parser.programWindow(reader);
                }
            }
            void action1(Graphics graphics,Pen pen)
            {
                graphics.DrawEllipse(pen,0,0,50,50);
                graphics.DrawEllipse(pen, 0,0,60,60);
                graphics.DrawEllipse(pen, 0,0,70,70);

            }
            testHelp(action, action1);
        }
        [TestMethod]
        public void movetoTest()
        {
            void action(commandParser parser)
            {
                parser.programWindow("moveto 50,50");
                parser.programWindow("rectangle 10,40");
            }
            void action1(Graphics graphics, Pen pen)
            {
                graphics.DrawEllipse(pen,0,0,70,70);
            }
            testHelp(action,action1);
        }

        [TestMethod]
        public void IfstatementTest()
        {
            void action(commandParser parser)
            {
                using(StreamReader streamReader = File.OpenText("*..\\..\\..\\Desktop\\if.txt"))
                {
                    string reader = streamReader.ReadToEnd();
                    parser.programWindow(reader);


                }
            }
                void action1(Graphics graphics, Pen pen)
            {
                graphics.DrawEllipse(pen, 0, 0, 50, 50);
                pen.Color = Color.Red;
                graphics.DrawEllipse(pen, 0, 0, 50, 100);
            }
            testHelp(action, action1);
        }

        [TestMethod]
        public void VaribleTest()
        {
            void action(commandParser parser)
            {
                using(StreamReader streamReader = File.OpenText("..\\..\\..\\Desktop\\if.txt"))
                {
                    string reader = streamReader.ReadToEnd();
                    parser.programWindow(reader);
                }
            }

            void action1(Graphics graphics,Pen pen)
            {
                graphics.DrawLine(pen,0,0,50,50);
                graphics.DrawRectangle(pen,50,50,70,80);
                pen.Color = Color.FromArgb(50, 50, 200, 200);
                graphics.DrawRectangle(pen,50,60,100,100);
                pen.Color = Color.Red;
                graphics.DrawLine(pen, 100, 100, 200, 200);
            }
            testHelp(action, action1);
        }
        [TestMethod]
        public void ClearTest()
        {
            void action(commandParser parser)
            {
                parser.programWindow("fill on");
                parser.programWindow("circle 100");
                parser.programWindow("drawto 100,100");
                parser.programWindow("clear");

                parser.programWindow("rectangle 100 100");
            }
            void action1(Graphics graphics, Pen pen)
            {
                Brush brush = new SolidBrush(Color.FromArgb(100, 100, 150, 150));
                graphics.FillRectangle(brush, 50, 50, 100, 100);
            }
            testHelp(action, action1);
        }
    }
}
