﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalProgrammingLanguage
{
    public partial class Form1 : Form
    {
        Bitmap bitmap = new Bitmap(640, 480);
        Canvas myCanvas;
        int fill = 0;
        Color color = Color.Black;

        
        public Form1()
        {
            InitializeComponent();

            myCanvas = new Canvas(Graphics.FromImage(bitmap));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true; // prevents flickering

        }

        private void runButton_Click(object sender, EventArgs e)
        {
            Graphics g = displayWindow.CreateGraphics();
            String Command = programWindow.Text;

            char[] vs = new[] { '\r', '\n'};
            String[] vs1 = Command.Split(vs, StringSplitOptions.RemoveEmptyEntries);

            for (int i=0; i<vs1.Length; i++)
            {
                String[] vs2 = vs1[i].Split(' ');

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

                        if (vs2.Length>3 || vs2.Length<3)
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
                        if (vs2.Length>2 || vs2.Length < 2)
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
                        myCanvas.DrawTriangle();
                        break;

                    case"clear":
                            myCanvas.Clear();
                        break;

                    default:
                        MessageBox.Show("Invalid Command " + vs1[i] + "On Line " + (i + 1), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;


                    case "fill":
                        if (vs2.Length>2|| vs2.Length<2)
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
                Refresh();
                    
                    



            }

        }

        private void displayWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(bitmap, 0, 0);
        }

        private void commandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && commandLine.Text != "run")
            {
                // extrating command & parametres from the commandline
                String Command = commandLine.Text; //get rid of spaces and convert to lower case
                String[] vs2 = Command.Split(' ');



                int Integer;

                switch (vs2[0].ToLower())
                {
                    case "moveto":

                        if (vs2.Length > 3 || vs2.Length < 3)
                        {
                            MessageBox.Show("Invalid move parameters ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        }
                        else if (int.TryParse(vs2[1], out Integer) == false)
                        {
                            MessageBox.Show("Move position x-axis should be integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        }
                        else if (int.TryParse(vs2[2], out Integer) == false)
                        {
                            MessageBox.Show("Move position Y-axis should be an integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("Invalid parameters passed, two parsament required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (int.TryParse(vs2[1], out Integer) == false)
                        {
                            MessageBox.Show("Rectangle value must be  an integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (int.TryParse(vs2[2], out Integer) == false)
                        {
                            MessageBox.Show("Rectangle height param must be  an integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {


                            {

                                myCanvas.DrawRectangle(color, Int32.Parse(vs2[1]), Int32.Parse(vs2[2]));

                            }

                        }

                        break;

                    case "circle":
                        if (vs2.Length > 2 || vs2.Length < 2)
                        {
                            MessageBox.Show("Invalid parameters passed, two parsament required", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (int.TryParse(vs2[1], out Integer) == false)
                        {
                            MessageBox.Show("Circle radius value must be  an integer", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("Invalid parameters passed, two parsament required", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (int.TryParse(vs2[1], out Integer) == false)
                        {
                            MessageBox.Show("Draw to end of xaxis asnd pararmenter must be an interger", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (int.TryParse(vs2[2], out Integer) == false)
                        {
                            MessageBox.Show("draw to end of y axix and parameter muste be an interger", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {



                            //  shapes.Add(new Line(Color.FromName(color), Int16.Parse(NewMove[0]), Int16.Parse(NewMove[1])));
                            myCanvas.DrawLine(color, Int32.Parse(vs2[1]), Int32.Parse(vs2[2]));

                            // 

                        }


                        break;

                    case "triangle":


                        myCanvas.DrawTriangle();
                        

                        break;

                    case "clear":

                        myCanvas.Clear();
                        break;

                    default:
                        MessageBox.Show("Invalid command ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;


                    case "fill":

                        if (vs2.Length > 2 || vs2.Length < 2)
                        {
                            MessageBox.Show("Invalid fill parameters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                            MessageBox.Show("Invalid colour parameters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


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

                commandLine.Text = "";
                Refresh();



            }
            else if (e.KeyCode == Keys.Enter && commandLine.Text == "run")
            {
                runButton.PerformClick();
            }
        }


    }
}
