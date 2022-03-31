namespace WaveSpreadingMazeSolverLee // 366
{
    public partial class Form1 : Form
    {
        private readonly int height = 1080; // working field
        private readonly int width = 1920;
        private static readonly int cubeSide = 50; // cube linear size

        private static int speed = 22; // frame speed

        private static int[,] grid; // for wave-spreading algo working

        private static PictureBox[,] waveCells; // for visualizing the wave-spreading process

        private static List<Point> front_wave = new List<Point>(); // keeps the coordinates of cells which constitute the front wave in the current step of algorithm
        private static List<Point> new_front_wave = new List<Point>(); // keeps the new cells found
        private static List<Point> the_way_back = new List<Point>(); // here we will be storing all the cells of the restoring way back

        private static int j_start, i_start; // the starting point of wave-spreading
        private static int j_end, i_end; // the point of final destination

        private static int j_max, i_max;

        private static int wave_steps_counter = 2; // the first step is the initialization of the front wave (point A)

        private static int iP, jP; // auxiliary coordinate variables

        private static bool flagOfWaveSpreadingEnd;
        private static bool pathIsRestored;      

        private static Control.ControlCollection form; // for convenience

        public Form1()
        {
            InitializeComponent();

            form = this.Controls;

            this.height = height; // play field size
            this.width = width;

            grid = new int[height / cubeSide + 1, width / cubeSide + 1];

            j_max = grid.GetLength(0);
            i_max = grid.GetLength(1);

            j_start = 2; 
            i_start = 2;

            j_end = 18;
            i_end = 35;

            flagOfWaveSpreadingEnd = false;
            pathIsRestored = false;

            waveCells = new PictureBox[height / cubeSide + 1, width / cubeSide + 1];

            InitializeGrid();

            GenerateGrid(); // here we are generating the grid   

            GenerateWalls(); // here we are generating the walls in the maze area

            front_wave.Add(new Point(j_start, i_start)); // initialization of the starting front wave
            grid[j_start, i_start] = 1;

            PictureBox startCell = new PictureBox();

            startCell.Location = new Point(i_start * cubeSide, j_start * cubeSide);
            startCell.Size = new Size(cubeSide, cubeSide);
            startCell.Image = new Bitmap(@"C:\Users\langr\Downloads\Apple1.bmp", true);

            waveCells[j_start, i_start] = startCell;
            form.Add(startCell);

            PictureBox endCell = new PictureBox();

            endCell.Location = new Point(i_end * cubeSide, j_end * cubeSide);
            endCell.Size = new Size(cubeSide, cubeSide);
            endCell.Image = new Bitmap(@"C:\Users\langr\Downloads\Bomb.bmp", true);

            waveCells[j_end, i_end] = endCell;
            form.Add(endCell);

            timer.Tick += new EventHandler(Update); // here we start the update cycle
            timer.Interval = speed;
            timer.Start();
        }       

        private static void InitializeGrid() // empty cells are marked with "0", when the walls -> "-1"
        {
            for (int j = 0; j < j_max; j++)
            {
                for (int i = 0; i < i_max; i++)
                {
                    grid[j, i] = 0;
                }
            }
        }

        private void GenerateWalls() // operating with int[,] grid
        {
            CreateVerticalWall(8, 0, 12);
            CreateHorizontalWall(15, 4, 25);
            CreateVerticalWall(18, 8, 16);
            CreateHorizontalWall(13, 0, 6);
            CreateRectangleWall(3, 2, 6, 6);
            CreateRectangleWall(3, 22, 12, 26);
            CreateHorizontalWall(2, 15, 36);
            CreateVerticalWall(30, 8, 21);
            CreateVerticalWall(8, 18, 21);
            CreateVerticalWall(11, 16, 18);
            CreateVerticalWall(13, 12, 15);
            CreateHorizontalWall(9, 0, 4);
            CreateHorizontalWall(12, 30, 34);
            CreateHorizontalWall(15, 33, 37);
            CreateHorizontalWall(8, 12, 19);
            CreateVerticalWall(12, 7, 8);
            CreateHorizontalWall(11, 3, 7);
        }

        private void RandomGenerateWalls() // operating with int[,] grid
        { 
            Random random = new Random();

            // ???

        }

        private void CreateRectangleWall(int startJ, int startI, int endJ, int endI) // endI >= startI && endJ >= startJ
        {
            for (int i = startI; i <= endI; i++)
            {
                CreateVerticalWall(i, startJ, endJ);
            }
        }

        private void CreateVerticalWall(int i, int startIndex, int endIndex) 
        {
            for (int l = startIndex; l <= endIndex; l++)
            {
                DrawPictureBox(new Point(i, l), false);
                grid[l, i] = -1;
            }
        }

        private void CreateHorizontalWall(int j, int startIndex, int endIndex) 
        {
            for (int l = startIndex; l <= endIndex; l++)
            {
                DrawPictureBox(new Point(l, j), false);
                grid[j, l] = -1;
            }
        }

        private void WaveSpreadingStepLee() // using int[,] grid
        {
            if (grid[j_end, i_end] == 0)
            {
                if (front_wave.Count() == 0)
                {
                    Console.WriteLine("The way between A and B does not exist!");
                    flagOfWaveSpreadingEnd = true;
                }
                else
                {
                    foreach (Point p in front_wave)
                    { // four-links scheme of wave spreading

                        jP = p.X;// current coordinates of a cell from the spreading front wave
                        iP = p.Y;

                        if (jP + 1 < j_max && grid[jP + 1, iP] == 0)
                        {
                            grid[jP + 1, iP] = wave_steps_counter;
                            new_front_wave.Add(new Point(jP + 1, iP));
                            if (iP != i_end || jP + 1 != j_end) DrawPictureBox(new Point(iP, jP + 1), true);
                        }

                        if (iP - 1 >= 0 && grid[jP, iP - 1] == 0)
                        {
                            grid[jP, iP - 1] = wave_steps_counter;
                            new_front_wave.Add(new Point(jP, iP - 1));
                            if (iP - 1 != i_end || jP != j_end) DrawPictureBox(new Point(iP - 1, jP), true);
                        }

                        if (jP - 1 >= 0 && grid[jP - 1, iP] == 0)
                        {
                            grid[jP - 1, iP] = wave_steps_counter;
                            new_front_wave.Add(new Point(jP - 1, iP));
                            if (iP != i_end || jP - 1 != j_end) DrawPictureBox(new Point(iP , jP - 1), true);
                        }

                        if (iP + 1 < i_max - 1 && grid[jP, iP + 1] == 0)
                        {
                            grid[jP, iP + 1] = wave_steps_counter;
                            new_front_wave.Add(new Point(jP, iP + 1));
                            if (iP + 1 != i_end || jP != j_end) DrawPictureBox(new Point(iP + 1, jP), true);
                        }
                    }

                    front_wave.Clear();
                    front_wave.AddRange(new_front_wave);
                    new_front_wave.Clear();                   

                    wave_steps_counter++;
                }
            }
            else 
            {           
                waveCells[j_end, i_end].Dispose();
                form.Remove(waveCells[j_end, i_end]);

                waveCells[j_end, i_end] = new PictureBox();
                waveCells[j_end, i_end].Size = new Size(cubeSide, cubeSide);
                waveCells[j_end, i_end].Location = new Point(i_end * cubeSide, j_end * cubeSide);

                waveCells[j_end, i_end].Image = new Bitmap(@"C:\Users\langr\Downloads\NuclearExplosion.bmp", true);
                Graphics g = Graphics.FromImage(waveCells[j_end, i_end].Image);
                g.DrawString((wave_steps_counter - 1) + "", new Font("Arial", 175), Brushes.Black, 3, 10);               

                form.Add(waveCells[j_end, i_end]);

                flagOfWaveSpreadingEnd = true;

                iP = i_end; // End point to the current one for way back restoration
                jP = j_end;
            }         
        }

        private static void DrawPictureBox(Point point, bool isWave) 
        { 
            PictureBox cell = new PictureBox();

            cell.Size = new Size(cubeSide, cubeSide);

            cell.Location = new Point(point.X * cubeSide, point.Y * cubeSide);

            if (isWave) cell.Image = new Bitmap(@"C:\Users\langr\Downloads\Explosion.bmp", true);
            else cell.Image = new Bitmap(@"C:\Users\langr\Downloads\WallBrick.bmp", true);

            Graphics g = Graphics.FromImage(cell.Image);
            if (isWave) g.DrawString(wave_steps_counter + "", new Font("Arial", 175), Brushes.Black, 3, 10);

            // is it needed?
            //if (waveCells[point.Y / cubeSide, point.X / cubeSide] != null) waveCells[point.Y / cubeSide, point.X / cubeSide].Dispose();

            waveCells[point.Y, point.X] = cell;

            form.Add(cell);
        }

        private void WayBackRestorationStepLee() // using int[,] grid
        {
            the_way_back.Add(new Point(jP, iP)); // adding B point to the end of the way back

            bool stopFlag = false;

            if (iP != i_start || jP + 1 != j_start)
            {
                if (jP + 1 < j_max)
                {
                    if (grid[jP, iP] - grid[jP + 1, iP] == 1)
                    {
                        jP++;
                        the_way_back.Add(new Point(jP, iP));
                        waveCells[jP, iP].Image = new Bitmap(@"C:\Users\langr\Downloads\WayBackExplosion.bmp", true);
                        stopFlag = true;
                    }
                }
            }
            else
            {
                the_way_back.Add(new Point(jP + 1, iP));
                // System.out.println("Pass restored");                  
                pathIsRestored = true;
            }

            if (!stopFlag) 
            { 
                if (iP - 1 != i_start || jP != j_start)
                {
                    if (iP - 1 >= 0)
                    {
                        if (grid[jP, iP] - grid[jP, iP - 1] == 1)
                        {
                            iP--;
                            the_way_back.Add(new Point(jP, iP));
                            waveCells[jP, iP].Image = new Bitmap(@"C:\Users\langr\Downloads\WayBackExplosion.bmp", true);
                            stopFlag = true;
                        }
                    }
                }
                else
                {
                    the_way_back.Add(new Point(jP, iP - 1));
                    // System.out.println("Pass restored");
                    pathIsRestored = true;
                } 
            }

            if (!stopFlag)
            {
                if (iP != i_start || jP - 1 != j_start)
                {
                    if (jP - 1 >= 0)
                    {
                        if (grid[jP, iP] - grid[jP - 1, iP] == 1)
                        {
                            jP--;
                            the_way_back.Add(new Point(jP, iP));
                            waveCells[jP, iP].Image = new Bitmap(@"C:\Users\langr\Downloads\WayBackExplosion.bmp", true);
                            stopFlag = true;
                        }
                    }
                }
                else
                {
                    the_way_back.Add(new Point(jP - 1, iP));
                    // System.out.println("Pass restored");
                    pathIsRestored = true;
                }
            }

            if (!stopFlag)
            {
                if (iP + 1 != i_start || jP != j_start)
                {
                    if (iP + 1 < i_max)
                    {
                        if (grid[jP, iP] - grid[jP, iP + 1] == 1)
                        {
                            iP++;
                            the_way_back.Add(new Point(iP, jP));
                            waveCells[jP, iP].Image = new Bitmap(@"C:\Users\langr\Downloads\WayBackExplosion.bmp", true);
                            stopFlag = true;
                        }
                    }
                }
                else
                {
                    the_way_back.Add(new Point(jP, iP + 1));
                    // System.out.println("Pass restored");
                    pathIsRestored = true;
                }
            }
        }

        private void GenerateGrid() // here we draw the lines...)
        {
            for (int i = 0; i <= height / cubeSide; i++) // horizontal ones
            {
                DrawLine(form, new Point(0 + 1, cubeSide * i), new Size(width - 20, 1));
            }

            for (int i = 0; i < (width - 20) / cubeSide + 1; i++) // vertical ones
            {
                DrawLine(form, new Point(cubeSide * i + 1, 0), new Size(1, height - 29));
            }
        }

        private void DrawLine(Control.ControlCollection form, Point point, Size size) // auxiliary method for painting the Grid
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.BackColor = Color.Black;
            pictureBox.Location = point;
            pictureBox.Size = size;
            form.Add(pictureBox);
        }

        private void Update(Object obj, EventArgs args) // the main cycle of the mazeSolver
        {
            if (!flagOfWaveSpreadingEnd)
            {
                WaveSpreadingStepLee();
            }
            else if (!pathIsRestored)
            {
                WayBackRestorationStepLee();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}