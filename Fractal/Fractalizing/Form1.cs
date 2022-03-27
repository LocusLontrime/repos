using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractalizing
{
    public partial class Form1 : Form
    {
        public static readonly double initialLength = 128;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

       

        public void RecursiveFractalPainter(double x, double y, double length, double angle, PaintEventArgs e) 
        { 
            Graphics g = e.Graphics;

            double newX, newY;

            newX = x + length * Math.Sin(angle * 2.0 * Math.PI / 360.0);
            newY = y + length * Math.Cos(angle * 2.0 * Math.PI / 360.0);
     
            g.DrawLine(new Pen(Color.Black, (float) length / 20), (int) x, panel1.Height - (int) y, (int) newX, panel1.Height - (int) newY);

            if (length >= 1) 
            {
                if (angle <= -30)
                {
                    RecursiveFractalPainter(newX, newY, length / 1.75, angle - 60, e);                   
                }
                else if (angle >= 30)
                {
                    RecursiveFractalPainter(newX, newY, length / 1.75, angle + 60, e);
                }
                else 
                {
                    RecursiveFractalPainter(newX, newY, length / 1.75, angle + 90, e);
                    RecursiveFractalPainter(newX, newY, length / 1.75, angle - 90, e);
                }  

                // RecursiveFractalPainter(newX, newY, length / 1.15, angle, e);
            }          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            RecursiveFractalPainter(panel1.Width / 2.0, 64, initialLength, 0, e);

        }
    }
}
