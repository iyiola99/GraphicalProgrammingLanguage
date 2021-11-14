using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GraphicalProgrammingLanguage
{

    class commandParser
    {
        Color color = Color.Black;
        int fill = 0;

        Canvas myCanvas;
        public commandParser(Canvas canvas)
        {
            myCanvas = canvas;
        }
        public void programWindow(string script)
        {
            char[] vs = new[] { '\r', '\n' };
            String[] vs1 = script.Split(vs, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < vs1.Length; i++)
            {
                commandLine(vs1[i], i);


            }


        }





        public void commandLine(string command, int lineNo)
        {
            int i = lineNo;
            String[] vs2 = command.Split(' ');

            int Integer;

             switch (vs2[0].ToLower())
                {
                    case "moveto":
                        if(vs2.Length>3 || vs2.Length < 3)
                        {
                            MessageBox.Show("Invalid Move To Parameter" + (i + 1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (int.TryParse(vs2[1],out Integer) == false)
                        {
                            MessageBox.Show("Move Position X-Axis Should Be An Integer" + (i + 1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (int.TryParse(vs2[2], out Integer) == false)
                        {
                            MessageBox.Show("Move Position Y-Axis Should Be An Integer" + (i + 1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            myCanvas.Moveto(Int32.Parse(vs2[1]), Int32.Parse(vs2[2]));
                        }
                        break;

                case "reset":

                    myCanvas.Reset();

                    break;

                case "rectangle":

                    if (vs2.Length > 3 || vs2.Length < 3)
                    {
                        MessageBox.Show("Invalid Parameter Passed, Two Parament Required" + (i + 1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (int.TryParse(vs2[1], out Integer) == false)
                    {
                        MessageBox.Show("Rectangle Width Parameter Must Be  An Integer" + (i + 1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (int.TryParse(vs2[2], out Integer) == false)
                    {
                        MessageBox.Show("Rectangle Height Parameter Must Be  An Integer" + (i + 1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        {
                            myCanvas.DrawRectangle(color, Int32.Parse(vs2[1]), Int32.Parse(vs2[2]));
                        }
                        break;

                    

                case "circle":
                    if (vs2.Length > 2 || vs2.Length < 2)
                    {
                        MessageBox.Show("Invalid Parameter Passed, One Parameter Required" + (i + 1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (int.TryParse(vs2[1], out Integer) == false)
                    {
                        MessageBox.Show("Circle Radius Value Must Be  An Integer" + (i + 1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (fill == 1)
                        {
                            myCanvas.FillCircle(color, Int32.Parse(vs2[1]));
                        }
                        else
                        {
                            myCanvas.DrawCircle(color, Int32.Parse(vs2[1]));
                        }


                    }

                    
                    break;

                case "drawto":

                    if (vs2.Length > 3 || vs2.Length < 3)
                    {
                        MessageBox.Show("Invalid Parameters Passed, Two Parameter Required" + (i + 1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (int.TryParse(vs2[1], out Integer) == false)
                    {
                        MessageBox.Show("Draw To End of X-Axis and Parameter Must Be An Interger" + (i + 1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (int.TryParse(vs2[2], out Integer) == false)
                    {
                        MessageBox.Show("Draw To End of Y-Axix And Parameter Must Be An Interger" + (i + 1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        myCanvas.DrawLine(color, Int32.Parse(vs2[1]), Int32.Parse(vs2[2]));
                    }
                    break;

                case "triangle":
                    myCanvas.DrawTriangle(color);
                    break;

                case "clear":
                    myCanvas.Clear();
                    break;

                default:
                    MessageBox.Show("Invalid Command " + command + "On Line " + (i + 1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;


                case "fill":
                    if (vs2.Length > 2 || vs2.Length < 2)
                    {
                        MessageBox.Show("Invalid Fill Parameters" + (i + 1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (vs2[1] == "off" || vs2[1] == "off")
                    {
                        fill = 0;
                    }
                    else if (vs2[1] == "on" || vs2[1] == "on")
                    {
                        fill = 1;
                    }
                    break;

                case "colour":
                    if (vs2.Length > 2 || vs2.Length < 2)
                    {
                        MessageBox.Show("Invalid colour parameters" + (i + 1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


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
            }



        }
    }
}
