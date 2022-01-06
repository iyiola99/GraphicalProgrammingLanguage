using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Accord.Math.Geometry;

namespace GraphicalProgrammingLanguage
{

    public class commandParser
    {
        // default pen color is set to  black
        Color color = Color.Black;
        //default fill is set to zero/off
        int fill = 0;
        Canvas myCanvas;
        int Integer;
        // start of array declaration
        List<string> Vname = new List<string>();
        //end of array declaration
        List<int> Vvalue = new List<int>();

        DataTable datatable = new DataTable();

        bool If_flag = true;
        bool While_flag = true;
        public commandParser(Canvas canvas)
        {
            myCanvas = canvas;
        }


        public void programWindow(string script)
        {
            //creates char array called vs
            char[] vs = new[] { '\r', '\n' };
            // splits the scripts string by \r and \n
            String[] vs1 = script.Split(vs, StringSplitOptions.RemoveEmptyEntries);

            int i = 0;
            int Counter = 0;

            //while loop using the length of the splitted string
            while (i < vs1.Length)
            {
                try
                {
                    String line = vs1[i].ToLower();
                    String[] vs2 = line.Split(' ');
                    String command = vs2[0].ToLower();

                    if (command.Equals("line") == true && vs2.Length > 1)
                    {
                        if (If_flag == false || While_flag == false)
                        {
                            i++;
                            continue;
                        }
                        else
                        {
                            string[] parameter = vs2[1].Split(',');
                            if (parameter.Length != 2)
                            {
                                throw new Exception("Invalid Parameter. Line command require 2 Parameter");
                                i++;
                            }
                            else if (int.TryParse(parameter[0], out Integer) == false || int.TryParse(parameter[1], out Integer) == false)
                            {
                                int paramValue1;
                                int paramValue2;
                                if (int.TryParse(parameter[0], out Integer) == false)
                                {
                                    int position1 = Vname.IndexOf(parameter[0].ToLower());
                                    if (position1 > -1)
                                    {
                                        paramValue1 = Vvalue[position1];
                                    }
                                    else
                                    {
                                        throw new Exception("Varible does not exist or Unknown first parameter");
                                        i++;
                                    }
                                }
                                else
                                {
                                    paramValue1 = Int16.Parse(parameter[0]);
                                }
                                if (int.TryParse(parameter[1], out Integer) == false)
                                {
                                    int position2 = Vname.IndexOf(parameter[1].ToLower());
                                    if (position2 > -1)
                                    {
                                        paramValue2 = Vvalue[position2];
                                    }
                                    else
                                    {
                                        throw new Exception("Varible does not exist or Unknown second parameter");
                                        i++;
                                    }
                                }
                                else
                                {
                                    paramValue2 = Int16.Parse(parameter[1]);
                                }
                                if (paramValue1 != 0 && paramValue2 != 0)
                                {
                                    myCanvas.DrawLine(color, paramValue1, paramValue2);
                                    i++;
                                }

                                else
                                {
                                    throw new Exception("Unknown Variable!");
                                    i++;
                                }
                            }
                            else
                            {
                                myCanvas.DrawLine(color, Int16.Parse(parameter[0]), Int16.Parse(parameter[1]));

                                i++;

                            }

                        }
                    }

                    else if (command.Equals("moveto") == true && vs2.Length > 1)
                    {
                        if (If_flag == false || While_flag == false)
                        {
                            i++;
                            continue;
                        }
                        else
                        {
                            string[] parameter = vs2[1].Split(',');
                            if (parameter.Length != 2)
                            {
                                throw new Exception("Invalid Parameter. Moveto command require 2 Parameter");
                                i++;
                            }
                            else if (int.TryParse(parameter[0], out Integer) == false || int.TryParse(parameter[1], out Integer) == false)
                            {
                                int paramValue1;
                                int paramValue2;
                                if (int.TryParse(parameter[0], out Integer) == false)
                                {
                                    int position1 = Vname.IndexOf(parameter[0].ToLower());
                                    if (position1 > -1)
                                    {
                                        paramValue1 = Vvalue[position1];
                                    }
                                    else
                                    {
                                        throw new Exception("Varible does not exist or Unknown first parameter");
                                        i++;
                                    }
                                }
                                else
                                {
                                    paramValue1 = Int16.Parse(parameter[0]);
                                }
                                if (int.TryParse(parameter[1], out Integer) == false)
                                {
                                    int position2 = Vname.IndexOf(parameter[1].ToLower());
                                    if (position2 > -1)
                                    {
                                        paramValue2 = Vvalue[position2];
                                    }
                                    else
                                    {
                                        throw new Exception("Varible does not exist or Unknown second parameter");
                                        i++;
                                    }
                                }
                                else
                                {
                                    paramValue2 = Int16.Parse(parameter[1]);
                                }
                                if (paramValue1 != 0 && paramValue2 != 0)
                                {
                                    myCanvas.Moveto(paramValue1, paramValue2);
                                    i++;
                                }

                                else
                                {
                                    throw new Exception("Unknown Variable!");
                                    i++;
                                }
                            }
                            else
                            {
                                myCanvas.Moveto(Int16.Parse(parameter[0]), Int16.Parse(parameter[1]));

                                i++;

                            }

                        }
                    }
                    else if (command.Equals("rectangle") == true && vs2.Length > 1)
                    {
                        if (If_flag == false || While_flag == false)
                        {
                            i++;
                            continue;
                        }
                        else
                        {
                            string[] parameter = vs2[1].Split(',');
                            if (parameter.Length != 2)
                            {
                                throw new Exception("Invalid Parameter. Ractangle command require 2 Parameter");
                                i++;
                            }
                            else if (int.TryParse(parameter[0], out Integer) == false || int.TryParse(parameter[1], out Integer) == false)
                            {
                                int paramValue1;
                                int paramValue2;
                                if (int.TryParse(parameter[0], out Integer) == false)
                                {
                                    int position1 = Vname.IndexOf(parameter[0].ToLower());
                                    if (position1 > -1)
                                    {
                                        paramValue1 = Vvalue[position1];
                                    }
                                    else
                                    {
                                        throw new Exception("Varible does not exist or Unknown first parameter");
                                        i++;
                                    }
                                }
                                else
                                {
                                    paramValue1 = Int16.Parse(parameter[0]);
                                }
                                if (int.TryParse(parameter[1], out Integer) == false)
                                {
                                    int position2 = Vname.IndexOf(parameter[1].ToLower());
                                    if (position2 > -1)
                                    {
                                        paramValue2 = Vvalue[position2];
                                    }
                                    else
                                    {
                                        throw new Exception("Varible does not exist or Unknown second parameter");
                                        i++;
                                    }
                                }
                                else
                                {
                                    paramValue2 = Int16.Parse(parameter[1]);
                                }
                                if (paramValue1 != 0 && paramValue2 != 0)
                                {
                                    myCanvas.DrawRectangle(color, fill, paramValue1, paramValue2);
                                    i++;
                                }

                                else
                                {
                                    throw new Exception("Unknown Variable!");
                                    i++;
                                }
                            }
                            else
                            {
                                myCanvas.DrawRectangle(color, fill, Int16.Parse(parameter[0]), Int16.Parse(parameter[1]));

                                i++;

                            }

                        }
                    }
                    else if (command.Equals("reset") == true)

                    {
                        if (If_flag == false || While_flag == false)
                        {
                            i++;
                            continue;
                        }
                        else
                        {
                            myCanvas.Reset();
                            i++;
                        }
                    }
                    else if (command.Equals("clear") == true)

                    {
                        if (If_flag == false || While_flag == false)
                        {
                            i++;
                            continue;
                        }
                        else
                        {
                            myCanvas.Clear();
                            i++;
                        }
                    }
                    else if (command.Equals("circle") == true && vs2.Length > 1)
                    {
                        if (If_flag == false || While_flag == false)
                        {
                            i++;
                            continue;
                        }
                        else
                        {
                            if (vs2.Length != 2)
                            {
                                throw new Exception("Invalid Parameter.Ractangle command require 2 Parameter");
                                i++;
                            }
                            else if (int.TryParse(vs2[1], out Integer) == false)
                            {
                                int position1 = Vname.IndexOf(vs2[1].ToLower());

                                if (position1 > -1)
                                {
                                    int paramValue = Vvalue[position1];
                                    myCanvas.DrawCircle(color, fill, paramValue);
                                    i++;
                                }
                            }
                            else
                            {
                                myCanvas.DrawCircle(color, fill, Int16.Parse(vs2[1]));
                                i++;
                            }
                        }
                    }
                    else if (command.Equals("triangle") == true && vs2.Length > 1)
                    {
                        if (If_flag == false || While_flag == false)
                        {
                            i++;
                            continue;
                        }
                        else
                        {
                            string[] parameter = vs2[1].Split(",");

                            if (parameter.Length != 4)
                            {
                                throw new Exception("Invalid parameter. Triangle command requires 4 parameter");
                                i++;
                            }
                            else if (int.TryParse(parameter[0], out Integer) == false || int.TryParse(parameter[1], out Integer) == false || int.TryParse(parameter[2], out Integer) == false || int.TryParse(parameter[3], out Integer) == false)
                            {
                                int paramValue1;
                                int paramValue2;
                                int paramValue3;
                                int paramValue4;

                                if (int.TryParse(parameter[0], out Integer) == false)
                                {
                                    int position1 = Vname.IndexOf(parameter[0].ToLower());
                                    if (position1 > -1)
                                    {
                                        paramValue1 = Vvalue[position1];
                                    }
                                    else
                                    {
                                        throw new Exception("Varible does not exist or Unknown first parameter");
                                        i++;
                                    }
                                }
                                else
                                {
                                    paramValue1 = Int16.Parse(parameter[0]);
                                }

                                if (int.TryParse(parameter[1], out Integer) == false)
                                {
                                    int position2 = Vname.IndexOf(parameter[1].ToLower());
                                    if (position2 > -1)
                                    {
                                        paramValue2 = Vvalue[position2];
                                    }
                                    else
                                    {
                                        throw new Exception("Varible does not exist or Unknown second parameter");
                                        i++;
                                    }
                                }
                                else
                                {
                                    paramValue2 = Int16.Parse(parameter[1]);
                                }

                                if (int.TryParse(parameter[2], out Integer) == false)
                                {
                                    int position3 = Vname.IndexOf(parameter[2].ToLower());
                                    if (position3 > -1)
                                    {
                                        paramValue3 = Vvalue[position3];
                                    }
                                    else
                                    {
                                        throw new Exception("Varible does not exist or Unknown third parameter");
                                        i++;
                                    }
                                }
                                else
                                {
                                    paramValue3 = Int16.Parse(parameter[2]);
                                }

                                if (int.TryParse(parameter[3], out Integer) == false)
                                {
                                    int position4 = Vname.IndexOf(parameter[3].ToLower());
                                    if (position4 > -1)
                                    {
                                        paramValue4 = Vvalue[position4];
                                    }
                                    else
                                    {
                                        throw new Exception("Varible does not exist or Unknown fourth parameter");
                                        i++;
                                    }
                                }
                                else
                                {
                                    paramValue4 = Int16.Parse(parameter[3]);
                                }

                                if (paramValue1 != 0 && paramValue2 != 0 && paramValue3 != 0 && paramValue4 != 0)
                                {
                                    myCanvas.DrawTriangle(color, fill, paramValue1, paramValue2, paramValue3, paramValue4);
                                    i++;
                                }
                                else
                                {
                                    throw new Exception("Unknown variable");
                                    i++;
                                }
                            }

                            else
                            {
                                myCanvas.DrawTriangle(color, fill, Int16.Parse(parameter[0]), Int16.Parse(parameter[1]), Int16.Parse(parameter[2]), Int16.Parse(parameter[3]));
                                i++;

                            }
                        }
                    }
                    else if (command.Equals("colour") == true && vs2.Length > 1)
                    {
                        if (If_flag == false || While_flag == false)
                        {
                            i++;
                            continue;
                        }
                        else
                        {
                            if (vs2.Length != 2)
                            {
                                throw new Exception("Invalid parameter. Colour command required 1 parameter");
                                i++;
                            }
                            else if (vs2[1].ToLower() == "black" || vs2[1].ToLower() == "red" || vs2[1].ToLower() == "blue" || vs2[1].ToLower() == "yellow")
                            {
                                if (vs2[1].ToLower() == "black")
                                {
                                    color = Color.Black;
                                    i++;
                                }

                                if (vs2[1].ToLower() == "red")
                                {
                                    color = Color.Red;
                                    i++;
                                }
                                if (vs2[1].ToLower() == "blue")
                                {
                                    color = Color.Blue;
                                    i++;
                                }
                                if (vs2[1].ToLower() == "yellow")
                                {
                                    color = Color.Yellow;
                                    i++;
                                }
                            }
                            else
                                throw new Exception("Invalid colour. Colour should be red,blue or yellow");
                            i++;
                        }

                    }

                
                      else if (command.Equals("fill") == true && vs2.Length > 1)
                {

                }



                catch (Exception e)
                {
                    MessageBox.Show(string.Format("error on line{0} :{1}", (i + 1), e.Message));
                }
            }

        }
    }
}











