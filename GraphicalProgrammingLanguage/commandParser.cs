using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphicalProgrammingLanguage
{

    public class commandParser
    {
        Color color = Color.Black;
        int fill = 0;

        Canvas myCanvas;
        public commandParser(Canvas canvas)
        {
            myCanvas = canvas;
        }
        // Execute commands entered by user as a string
        public void commandLine(string command, int lineNo) 
        {
            int i = lineNo;
           // splits the command into nvs2 based on spaces
            String[] vs2 = command.Split(' '); 

            int Integer;

            switch (vs2[0].ToLower())
            {
                case "moveto":
                    // if moveto command does not have 2 paramenter which are both integers, an exception is thrown detailing the syntax error
                    if (vs2.Length > 3 || vs2.Length < 3)
                    {
                        throw new Exception("Invalid Move To Parameter");
                    }
                    else if (int.TryParse(vs2[1], out Integer) == false)
                    {
                        throw new Exception("Move Position X-Axis Should Be An Integer");
                    }
                    else if (int.TryParse(vs2[2], out Integer) == false)
                    {
                        throw new Exception("Move Position Y-Axis Should Be An Integer");
                    }
                    // else the x&yxsis are parsed as an interger and command is executed
                    else
                    {
                        myCanvas.Moveto(Int32.Parse(vs2[1]), Int32.Parse(vs2[2]));
                    }
                    break;

                case "reset":
                    // pen resets to starting postion 0 contained in canvas class
                    myCanvas.Reset();

                    break;

                case "rectangle":
                    // if rectangle command does not have 2 paramenter which are both integers, an exception is thrown detailing the syntax error
                    if (vs2.Length > 3 || vs2.Length < 3)
                    {
                        throw new Exception("Invalid Parameter Passed, Two Parament Required");
                    }
                    else if (int.TryParse(vs2[1], out Integer) == false)
                    {
                        throw new Exception("Rectangle Width Parameter Must Be  An Integer");
                    }
                    else if (int.TryParse(vs2[2], out Integer) == false)
                    {
                        throw new Exception("Rectangle Height Parameter Must Be  An Integer");
                    }
                    // else the height&width are parsed as an interger and command is executed
                    else
                    {
                        myCanvas.DrawRectangle(color, Int32.Parse(vs2[1]), Int32.Parse(vs2[2]));
                    }
                    break;



                case "circle":
                    // if circle radius is not an integer an exception is thrown detailing the syntax error. Exception is also thrown if it has more than one parameter
                    if (vs2.Length > 2 || vs2.Length < 2)
                    {
                        throw new Exception("Invalid Parameter Passed, One Parameter Required");
                    }
                    else if (int.TryParse(vs2[1], out Integer) == false)
                    {
                        throw new Exception("Circle Radius Value Must Be  An Integer");
                    }
                    else
                    {
                        // if fill is on ,the radius are parsed as an interger and command is executed
                        if (fill == 1)
                        {
                            myCanvas.FillCircle(color, Int32.Parse(vs2[1]));
                        }
                        // else if fill is off,  the radius are parsed as an interger and command is executed
                        else
                        {
                            myCanvas.DrawCircle(color, Int32.Parse(vs2[1]));
                        }


                    }


                    break;

                case "drawto":
                    //  if drawto command does not have 2 paramenter which are both integers, an exception is thrown detailing the syntax error

                    if (vs2.Length > 3 || vs2.Length < 3)
                    {
                        throw new Exception("Invalid Parameters Passed, Two Parameter Required");
                    }
                    else if (int.TryParse(vs2[1], out Integer) == false)
                    {
                        throw new Exception("Draw To End of X-Axis and Parameter Must Be An Interger");
                    }
                    else if (int.TryParse(vs2[2], out Integer) == false)
                    {
                        throw new Exception("Draw To End of Y-Axix And Parameter Must Be An Interger");
                    }
                    // else the x&y axis are parsed as an interger and command is executed
                    else
                    { 

                        myCanvas.DrawLine(color, Int32.Parse(vs2[1]), Int32.Parse(vs2[2]));
                    }
                    break;
                    //  triangle command calls method contained in the canvas class
                case "triangle":
                    myCanvas.DrawTriangle(color);
                    break;
                    //  clear command calls  method contained in the canvas class
                case "clear":
                    myCanvas.Clear();
                    break;


                    // fill command takes one argument
                case "fill":
                    if (vs2.Length > 2 || vs2.Length < 2)
                    {
                        throw new Exception("Invalid Fill Parameters");
                    }
                    else if (vs2[1] == "off" || vs2[1] == "off")
                    {
                        fill = 0;
                    }
                    // set the state appropiately
                    else if (vs2[1] == "on" || vs2[1] == "on")
                    {
                        fill = 1;
                    }
                    break;
                    // coolour command takes one argument to specify the color of the pen
                case "colour":
                    if (vs2.Length > 2 || vs2.Length < 2)
                    {
                        throw new Exception("Invalid colour parameters");


                    }
                    else if (vs2[1].ToLower() == "red")

                    {
                        color = Color.Red;


                    }
                    else if (vs2[1].ToLower() == "blue")
                    {
                        color = Color.Blue;
                    }
                    else if (vs2[1].ToLower() == "green")
                    {
                        color = Color.Green;
                    }
                    else
                    {
                        color = Color.Black;
                    }

                    break;
                default:
                    throw new Exception("Invalid Command ");

            }



        }
        // excute script by calling the commandline repeatedly, execution stops if an error is detected
        // and an  error messaged appears with line number 
        public void programWindow(string script)
        {
            char[] vs = new[] { '\r', '\n' };
            String[] vs1 = script.Split(vs, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < vs1.Length; i++)
            {
                try
                {
                    commandLine(vs1[i], i);
                }
                catch (Exception e)
                {
                    MessageBox.Show(string.Format("on line {0} : {1}", i, e.Message));
                    break;
                }
            }


        }
    }
}
