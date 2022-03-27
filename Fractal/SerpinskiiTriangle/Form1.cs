namespace SerpinskiiTriangle
{
    public partial class Form1 : Form
    {        
        public Form1() => InitializeComponent();
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            TrianglePainter(e);
        }

        public void TrianglePainter(PaintEventArgs e) 
        {
            Graphics g = e.Graphics;

            int triangleSize = 1024; // 100 is the max value of console WIDTH
            double xA = triangleSize, yA = 0; // initial values of vertexes coordinates
            double xB = 0, yB = triangleSize;
            double xC = 2 * triangleSize, yC = triangleSize;

            g.DrawRectangle(new Pen(Color.Black), (int)xA, (int)yA, 1, 1);
            g.DrawRectangle(new Pen(Color.Black), (int)xB, (int)yB, 1, 1);
            g.DrawRectangle(new Pen(Color.Black), (int)xC, (int)yC, 1, 1);

            RecursiveFractalPainter(xA, yA, xB, yB, xC, yC, e);
        }

        public void RecursiveFractalPainter(double xA, double yA, double xB, double yB, double xC, double yC, PaintEventArgs e)
        {
            Graphics g = e.Graphics;          

            double xAmirrored = (xB + xC) / 2; // a particular case (isosceles triangle), in general: xAmirrored = (xB + xC) / 2
            double yAmirrored = (yB + yC) / 2; // a paticular case (isosceles triangle), in general: yAmirrored = (yB + yC) / 2

            double xCmirrored = (xA + xB) / 2;
            double yCmirrored = (yA + yB) / 2;

            double xBmirrored = (xA + xC) / 2;
            double yBmirrored = (yA + yC) / 2;

            if (xCmirrored - xA > 1 || xBmirrored - xA > 1 || yCmirrored - yA > 1 || yBmirrored - yA > 1) 
            { 
                // stop conditional, when new vertexes cannot be calculated and start repeating

                g.DrawRectangle(new Pen(Color.Black), (int)xAmirrored, (int)yAmirrored, 1, 1);
                g.DrawRectangle(new Pen(Color.Black), (int)xBmirrored, (int)yBmirrored, 1, 1);
                g.DrawRectangle(new Pen(Color.Black), (int)xCmirrored, (int)yCmirrored, 1, 1);

                // in the part below we will be doing three recursive calls of this method and so on...

                // recursivePainter(xAmirrored, yAmirrored, xBmirrored, yBmirrored, xCmirrored, yCmirrored); -> inner triabgle must not be fullfilled
                RecursiveFractalPainter(xCmirrored, yCmirrored, xB, yB, xAmirrored, yAmirrored, e); // Bvertex-triangle
                RecursiveFractalPainter(xA, yA, xCmirrored, yCmirrored, xBmirrored, yBmirrored, e); // Avertex-triangle
                RecursiveFractalPainter(xBmirrored, yBmirrored, xAmirrored, yAmirrored, xC, yC, e); // Cvertex-triangle
            }
        }       
    }
}