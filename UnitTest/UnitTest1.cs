using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage;
using System;
using System.Drawing;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public void TestMethod1(string command)
        {
            //(new commandParser(new Canvas(Graphics.FromImage(new Bitmap(500, 500))))).CommandLine(command, 0);
            Canvas canvas = new Canvas(Graphics.FromImage(new Bitmap(500,500)));
            commandParser parser = new commandParser(canvas);

            parser.programWindow(command);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid Coordinate ")]
        public void Invalidmoveto()
        {
            TestMethod1("moveto r 40");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid Command ")]
        public void Invalidcommandtest()
        {
            TestMethod1("dsfef ");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid Colour ")]
        public void Invalidcolour()
        {
            TestMethod1(" wine ");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid fill state ")]
        public void Invalidfillstate()
        {

            TestMethod1(" fill dffd");

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid clear command ")]
        public void Invalidclear()
        {

            TestMethod1(" clerr");

        }

    }
    
}
