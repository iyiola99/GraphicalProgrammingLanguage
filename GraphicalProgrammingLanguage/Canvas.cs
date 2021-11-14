using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguage
{/// <summary>
/// An area that controls all the drawing element
/// </summary>
    public class Canvas
    {
        Graphics g;
        Pen Pen;

        int xPos, yPos; // pen position

        public Canvas(Graphics g)
        {
            this.g = g;
            xPos = yPos = 0;


        }
        /// <summary>
        /// Draws a line connecting two position specifed by two coordinate pairs
        /// </summary>
        /// <param name="colour">pen colour</param>
        /// <param name="toX"> the first position to connect</param>
        /// <param name="toY">the second postion to connect</param>
        public void DrawLine(Color colour, int toX, int toY)
        {
            Pen = new Pen(colour);
            g.DrawLine(Pen, xPos, yPos, toX, toY);
            xPos = toX;
            yPos = toY;

        }
        /// <summary>
        ///Draws a rectangle specified by coordinate of width and height
        /// 
        /// </summary>
        /// <param name="colour">Pen colour</param>
        /// <param name="width">The width of rectangle</param>
        /// <param name="height">The height of rectangle</param>
        public void DrawRectangle(Color colour, int width, int height)
        {
            Pen = new Pen(colour);
            g.DrawRectangle(Pen, xPos, yPos, xPos + width, yPos + height);
        }
        /// <summary>
        /// Draws a circle specified by radius 
        /// </summary>
        /// <param name="colour">pen colour</param>
        /// <param name="radius">the radius of the circle</param>
        public void DrawCircle(Color colour, int radius)
        {
            Pen = new Pen(colour);
            g.DrawEllipse(Pen, xPos, yPos, radius, radius);
        }
        /// <summary>
        /// Fill the inside of the circle specified by the radius
        /// </summary>
        /// <param name="colour">Brush colour</param>
        /// <param name="radius">Radius of the circle</param>
        public void FillCircle(Color colour, int radius)
        {
            SolidBrush SolidBrush = new SolidBrush(colour);
            g.FillEllipse(SolidBrush, xPos, yPos, radius, radius);
        }
        /// <summary>
        /// Draws a triangle specified by the array of point
        /// </summary>
        /// <param name="colour">Pen colour</param>
        public void DrawTriangle(Color colour)

        {
            Point[] points = { new Point(xPos, yPos), new Point(100, 10), new Point(50, 100) };
            Pen = new Pen(colour);
            g.DrawPolygon(Pen, points);
        }
        /// <summary>
        /// Resets pen postion to the starting point
        /// </summary>
        public void Reset()
        {
            xPos = yPos = 0;
        }
        /// <summary>
        /// Moves pen postion specified by two coordinates
        /// </summary>
        /// <param name="toX">pen position</param>
        /// <param name="toY">pen postion</param>
        public void Moveto(int toX, int toY)
        {
            xPos = toX;
            yPos = toY;
        }

        /// <summary>
        /// clears the display window and fill the background colour with gray
        /// </summary>
        public void Clear()
        {
            g.Clear(Color.Gray);
        }
    }
}
