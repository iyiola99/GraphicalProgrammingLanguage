using System;
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
                }
                    



            }

        }
    }
}
