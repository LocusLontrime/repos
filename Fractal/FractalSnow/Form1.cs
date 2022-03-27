using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FractalSnow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            FractalSnowPainter(e);
        }

        public void FractalSnowPainter(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            double squareSize = 3 * 3 * 3 * 3 * 3 * 3;
            double xA = 0, yA = 0;
            double xB = squareSize, yB = 0;
            double xC = 0, yC = squareSize;
            double xD = squareSize, yD = squareSize;

            // initial square painting
            g.DrawRectangle(new Pen(Color.Black), (int)xA, (int)yA, 1, 1);
            g.DrawRectangle(new Pen(Color.Black), (int)xB, (int)yB, 1, 1);
            g.DrawRectangle(new Pen(Color.Black), (int)xC, (int)yC, 1, 1);
            g.DrawRectangle(new Pen(Color.Black), (int)xD, (int)yD, 1, 1);

            RecursiveFractalPainter(xA, yA, xB, yB, xC, yC, xD, yD, e);   
        }

        public void RecursiveFractalPainter(double xA, double yA, double xB, double yB, double xC, double yC, double xD, double yD, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // here we are calculating four new vertexes

            double xA1 = (2 * xA + xB) / 3;
            double yA1 = yA;

            double xB1 = (xA + 2 * xB) / 3;
            double yB1 = yB;

            double xA2 = xA;
            double yA2 = (2 * yA + yC) / 3;

            double xB2 = xB;
            double yB2 = (2 * yB + yD) / 3;

            double xC2 = xC;
            double yC2 = (yA + 2 * yC) / 3;

            double xD2 = xD;
            double yD2 = (yB + 2 * yD) / 3;

            double xC1 = (2 * xC + xD) / 3;
            double yC1 = yC;

            double xD1 = (xC + 2 * xD) / 3;
            double yD1 = yD;

            double xA3 = (2 * xA + xB) / 3;
            double yA3 = (2 * yA + yC) / 3;

            double xB3 = (xA + 2 * xB) / 3;
            double yB3 = (2 * yB + yD) / 3;

            double xC3 = (2 * xC + xD) / 3;
            double yC3 = (yA + 2 * yC) / 3;

            double xD3 = (xC + 2 * xD) / 3;
            double yD3 = (yB + 2 * yD) / 3;


            if (xA1 - xA >= 1 || xB1 - xA >= 1 || xC1 - xC >= 1 || xD1 - xC >= 1 || yA2 - yA >= 1 || yC2 - yA >= 1 || yB2 - yB >= 1 || yD2 - yB >= 1 ||
            xA3 - xA >= 1 || yA3 - yA >= 1 || xB3 - xA >= 1 || yB3 - yB >= 1 || xC3 - xC >= 1 || yC3 - yA >= 1 || xD3 - xB >= 1 || yD3 - yB >= 1)
            {
                // stop conditional, when new vertexes cannot be calculated and start repeating

                g.DrawRectangle(new Pen(Color.Black), (int)xA1, (int)yA1, 1, 1);
                g.DrawRectangle(new Pen(Color.Black), (int)xB1, (int)yB1, 1, 1);
                g.DrawRectangle(new Pen(Color.Black), (int)xC1, (int)yC1, 1, 1);
                g.DrawRectangle(new Pen(Color.Black), (int)xD1, (int)yD1, 1, 1);

                g.DrawRectangle(new Pen(Color.Black), (int)xA2, (int)yA2, 1, 1);
                g.DrawRectangle(new Pen(Color.Black), (int)xB2, (int)yB2, 1, 1);
                g.DrawRectangle(new Pen(Color.Black), (int)xC2, (int)yC2, 1, 1);
                g.DrawRectangle(new Pen(Color.Black), (int)xD2, (int)yD2, 1, 1);

                g.DrawRectangle(new Pen(Color.Black), (int)xA3, (int)yA3, 1, 1);
                g.DrawRectangle(new Pen(Color.Black), (int)xB3, (int)yB3, 1, 1);
                g.DrawRectangle(new Pen(Color.Black), (int)xC3, (int)yC3, 1, 1);
                g.DrawRectangle(new Pen(Color.Black), (int)xD3, (int)yD3, 1, 1);

                g.DrawRectangle(new Pen(Color.White), (int)xA, (int)yA, 1, 1);
                g.DrawRectangle(new Pen(Color.White), (int)xB, (int)yB, 1, 1);
                g.DrawRectangle(new Pen(Color.White), (int)xC, (int)yC, 1, 1);
                g.DrawRectangle(new Pen(Color.White), (int)xD, (int)yD, 1, 1);


                // in the part below we will be doing three recursive calls of this method and so on...

                // recursivePainter(xAmirrored, yAmirrored, xBmirrored, yBmirrored, xCmirrored, yCmirrored); -> inner triabgle must not be fullfilled

                // RecursiveFractalPainter(xA, yA, xA1, yA1, xA2, yA2, xA3, yA3, e);
                RecursiveFractalPainter(xA1, yA1, xB1, yB1, xA3, yA3, xB3, yB3, e);
                // RecursiveFractalPainter(xB1, yB1, xB, yB, xB3, yB3, xB2, yB2, e);
                RecursiveFractalPainter(xA2, yA2, xA3, yA3, xC2, yC2, xC3, yC3, e);
                RecursiveFractalPainter(xB3, yB3, xB2, yB2, xD3, yD3, xD2, yD2, e);
                // RecursiveFractalPainter(xC2, yC2, xC3, yC3, xC, yC, xC1, yC1, e);
                RecursiveFractalPainter(xC3, yC3, xD3, yD3, xC1, yC1, xD1, yD1, e);
                // RecursiveFractalPainter(xD3, yD3, xD2, yD2, xD1, yD1, xD, yD, e);

                RecursiveFractalPainter(xA3, yA3, xB3, yB3, xC3, yC3, xD3, yD3, e); // -> central square
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
