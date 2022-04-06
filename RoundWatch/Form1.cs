using System.Timers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices; // Подключаем новое пространство имён

namespace RoundWatch // 366
{
    public partial class Form1 : Form
    {
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool PostMessage(IntPtr hWnd, uint Msg, uint WParam, uint LParam);

        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool ReleaseCapture();

        private static int centerX, centerY;
        private static int secLength, minLength, hLength;
        private static PictureBox watch = new PictureBox();

        private static Graphics g;

        Control.ControlCollection form;

        int count;

        public Form1()
        {
            InitializeComponent();

            count = 0;

            this.BackColor = Color.AliceBlue;
            this.TransparencyKey = this.BackColor;           

            form = this.Controls;

            secLength = 300;
            minLength = 250;
            hLength = 175;
 
            /* PictureBox watch = new PictureBox();
            watch.Size = new Size(900, 900);
            watch.Location = new Point(350, 50);
            watch.Image = new Bitmap(@"C:\Users\langr\Downloads\WatchOne.bmp", true);   
            
            watch.Dock = DockStyle.Fill;
            watch.SizeMode = PictureBoxSizeMode.Zoom;

            form.Add(watch); */

            // watch.BackColor = Color.White;

            centerX = 900 / 2;
            centerY = 900 / 2;

            g = pictureBox1.CreateGraphics();

            timer.Tick += new EventHandler(TickTime);
            timer.Interval = 1000;
            timer.Start();
        }

        private void TickTime(Object sender, EventArgs args)
        {                   
            int secs = DateTime.Now.Second;
            int mins = DateTime.Now.Minute;
            int hours = DateTime.Now.Hour;

            Point newPsec = SecHandCoords(secs);
            Point newPmin = MinHandCoords(mins, secs);
            Point newPhour = HourHandCoords(hours, mins); 

            g.DrawLine(new Pen(Color.White, 70), new Point(centerX, centerY), newPsec); // removing the old sec hand
            g.DrawLine(new Pen(Color.White, 50), new Point(centerX, centerY), newPmin); // removing the old min hand
            g.DrawLine(new Pen(Color.White, 45), new Point(centerX, centerY), newPhour); // removing the old min hand

            g.DrawLine(new Pen(Color.Black, 3f), new Point(centerX, centerY), newPsec); // draw the new one
            g.DrawLine(new Pen(Color.Black, 6f), new Point(centerX, centerY), newPmin); // draw the new one
            g.DrawLine(new Pen(Color.Black, 10f), new Point(centerX, centerY), newPhour); // draw the new one

            // we need to remove the old hands

            // then we should draw the new ones
        }

        private Point SecHandCoords(int secs) // what about a min one?
        {
            // circle moving?)
            int newY = centerY - (int) (secLength * Math.Cos(Math.PI * secs * 6 / 180));
            int newX = centerX + (int) (secLength * Math.Sin(Math.PI * secs * 6 / 180));

            return new Point(newX, newY);
        }

        private Point MinHandCoords(int mins, int secs) 
        {
            int newY = centerY - (int) (minLength * Math.Cos(Math.PI * (mins * 6 + secs / 10) / 180));
            int newX = centerX + (int) (minLength * Math.Sin(Math.PI * (mins * 6 + secs / 10) / 180));

            return new Point(newX, newY);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            const uint WM_SYSCOMMAND = 0x0112;
            const uint DOMOVE = 0xF012;

            ReleaseCapture();
            PostMessage(this.Handle, WM_SYSCOMMAND, DOMOVE, 0);
        }

        private Point HourHandCoords(int hours, int mins) 
        {
            int newY = centerY - (int) (hLength * Math.Cos(Math.PI * ((hours % 12) * 30 + mins / 2) / 180));
            int newX = centerX + (int) (hLength * Math.Sin(Math.PI * ((hours % 12) * 30 + mins / 2) / 180));

            return new Point(newX, newY);           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}