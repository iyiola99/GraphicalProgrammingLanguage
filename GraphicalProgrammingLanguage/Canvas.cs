using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguage
{
    class Canvas
    {
        Graphics g;
        Pen Pen;

        int xPos, yPos; // pen position

        public Canvas(Graphics g)
        {
            this.g = g;
            xPos = yPos = 0;


        }

        public void DrawLine(Color colour, int toX, int toY)
        {
            Pen = new Pen(colour);
            g.DrawLine(Pen, xPos, yPos, toX, toY);
            xPos = toX;
            yPos = toY;

        }

        public void DrawRectangle(Color colour, int width, int height)
        {
            Pen = new Pen(colour);
            g.DrawRectangle(Pen, xPos, yPos, xPos + width, yPos + height);
        }
        public void DrawCircle(Color colour, int radius)
        {
            Pen = new Pen(colour);
            g.DrawEllipse(Pen, xPos, yPos, radius, radius);
        }

        public void FillCircle(Color colour, int radius)
        {
            SolidBrush SolidBrush = new SolidBrush(colour);
            g.FillEllipse(SolidBrush, xPos, yPos, radius, radius);
        }

        public void DrawTriangle()

        {
            Point[] points = { new Point(xPos, yPos), new Point(100, 10), new Point(50, 100) };

            g.DrawPolygon(Pen, points);
        }

        public void Reset()
        {
            xPos = yPos = 0;
        }

        public void Moveto(int toX, int toY)
        {
            xPos = toX;
            yPos = toY;
        }


        public void Clear()
        {
            g.Clear(Color.Gray);
        }
    }
}
