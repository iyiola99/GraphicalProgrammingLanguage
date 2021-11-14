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
            (new commandParser(new Canvas(Graphics.FromImage(new Bitmap(500, 500))))).commandLine(command, 0);
           
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid Coordinate ")]
        public void Invalidmoveto()
        {
            TestMethod1("mov");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid Command ")]
        public void Invalidcommandtest()
        {
            TestMethod1(" ");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid Colour ")]
        public void Invalidcolour()
        {
            TestMethod1(" ");
        }
    }
}
