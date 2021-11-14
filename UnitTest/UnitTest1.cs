using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphicalProgrammingLanguage;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public void TestMethod1(string command)
        {
            Form1 form1i = new Form1();
            form1i.programWindow.Text = command;
            form1i.runButton_Click(new object(), new System.EventArgs());
           
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid Coordinate ")]
        public void Invalidmoveto()
        {
            TestMethod1("moveto 100 100");
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
