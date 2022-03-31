namespace TetrisX
{
    public partial class Form1 : Form // split tetris -> 2 in 1
    {
        private static int width = 1000;
        private static int height = 1050;
        private static int speed = 500;

        private static readonly int cubeSide = 50;

        // playable area section
        private static int[,] binaryGrid;
        private static PictureBox[,] playableArea;

        private static int xMax, yMax;

        // figures in the initial state library
        private static List<List<Point>> figures;

        // current Figure section
        private static List<Point> currentFigure; // list of tetroGon coordinates with the center in the rotationPoint
        private static List<PictureBox> currentFigureCells;
        private static Point currentFigureCoords;

        private static Label label;

        private static int scores;

        private static Control.ControlCollection form;

        public Form1()
        {
            InitializeComponent();

            form = this.Controls;
            this.Width = width;
            this.Height = height;

            scores = 0;
            
            figures = new List<List<Point>>();

            for (int i = 0; i < 7; i++) // 7 figures
            {
                figures.Add(new List<Point>());
            }

            //Figures library
            figures[0].Add(new Point(0, 0)); // the first one
            figures[0].Add(new Point(-1, 0));
            figures[0].Add(new Point(0, - 1));
            figures[0].Add(new Point(1, 0));

            figures[1].Add(new Point(-1, -1)); // the second one
            figures[1].Add(new Point(0, -1));
            figures[1].Add(new Point(1, -1));
            figures[1].Add(new Point(1, 0));

            figures[2].Add(new Point(-1, 1)); // the third one
            figures[2].Add(new Point(0, 1));
            figures[2].Add(new Point(1, 1));
            figures[2].Add(new Point(1, 0));

            figures[3].Add(new Point(-1, 0)); // the fourth one
            figures[3].Add(new Point(0, 0));
            figures[3].Add(new Point(1, 0));
            figures[3].Add(new Point(2, 0));

            figures[4].Add(new Point(0, 0)); // the fifth one (cube) with no rotation!!!!!
            figures[4].Add(new Point(1, 0));
            figures[4].Add(new Point(0, 1));
            figures[4].Add(new Point(1, 1));

            figures[5].Add(new Point(-1, 0)); // the sixth one
            figures[5].Add(new Point(0, 0));
            figures[5].Add(new Point(0, 1));
            figures[5].Add(new Point(1, 1));

            figures[6].Add(new Point(-1, 1)); // the seventh one
            figures[6].Add(new Point(0, 1));
            figures[6].Add(new Point(0, 0));
            figures[6].Add(new Point(1, 0));

            label = new Label();
            label.Size = new Size(225, 1050);
            label.Location = new Point(751, 0);
            label.Text = "Scores: 0";

            form.Add(label);

            binaryGrid = new int[height / cubeSide, (width - label.Width) / cubeSide];
            playableArea = new PictureBox[Height / cubeSide, (Width - label.Width) / cubeSide];

            yMax = binaryGrid.GetLength(0);
            xMax = binaryGrid.GetLength(1);

            this.KeyDown += new KeyEventHandler(KeyPressedHandler);

            timer.Tick += new EventHandler(Update);
            timer.Interval = speed;
            timer.Start();

            GenerateGrid(); // here we add a markUp

            GridZeroFill(); // filling grid with nulls

            GenerateNewFigure(); // creates a first figure on the field
        }

        private static void KeyPressedHandler(Object sender, KeyEventArgs args) 
        {
            switch (args.KeyCode.ToString()) // snake cannot move in the opposite direction it did before
            {
                case "Right": // right figure shift
                    if (IsMovementValid("Right"))
                    {
                        RightMove();
                    }
                    break;
                case "Left": // left figure shift
                    if (IsMovementValid("Left"))
                    {
                       LeftMove();
                    }
                    break;                               
                case "Down":
                    DownShifting();
                    break; 
                case "Space": // rotation
                    Rotate(true); // left
                    break;
            }
        }

        private static void GridZeroFill() // Zero fulfilling of the binary Grid
        {
            for (int j = 0; j < yMax; j++)
            {
                for (int i = 0; i < xMax; i++)
                {
                    binaryGrid[j, i] = 0;
                }
            }            
        }

        private void GenerateGrid() // here we draw the lines...)
        {
            for (int i = 0; i <= height / cubeSide; i++) // horizontal ones
            {
                DrawLine(form, new Point(0, cubeSide * i), new Size(width - label.Width, 1));
            }

            for (int i = 0; i <= (width - label.Width) / cubeSide + 1; i++) // vertical ones
            {
                DrawLine(form, new Point(cubeSide * i, 0), new Size(1, height));
            }
        }

        private void DrawLine(Control.ControlCollection form, Point point, Size size) // auxiliary method for painting the Grid
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.BackColor = Color.Brown;
            pictureBox.Location = point;
            pictureBox.Size = size;
            form.Add(pictureBox);
        }

        private static void FullRowsRemoving() // Levigin method
        {
            bool result = false;

            int multiplyingCounter = 1;

            for (int i = yMax - 1; i > 0; i--)
            {
                for (int l = 0; l < xMax - 1; l++)
                {
                    result = binaryGrid[i, l] == 1 ? true : false;
                    if (!result) 
                    {
                        break; 
                    }
                }
                if (result)
                {
                    for (int k = i - 1; k >= 0; k--)
                    {
                        for (int j = 0; j < xMax; j++)
                        {
                            if (binaryGrid[k + 1, j] == 1) 
                            {
                                playableArea[k + 1, j].Dispose(); // removing the old row
                            }

                            if (binaryGrid[k, j] == 1) 
                            {                            
                                playableArea[k + 1, j] = ClonePB(playableArea[k, j]); // cloning the new row
                                form.Add(playableArea[k + 1, j]);
                            }                        

                            binaryGrid[k + 1, j] = binaryGrid[k, j]; // levigin -> 2!!!                          
                        }
                    }

                    scores += xMax * multiplyingCounter++;

                    label.Text = "Scores: " + scores;

                    i++; // staying at the same row because of the fallen down rows above...
                }
            }          
        }

        private static PictureBox ClonePB(PictureBox pictureBox) 
        { 
            PictureBox clone = new PictureBox();

            clone.Size = pictureBox.Size;
            clone.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + cubeSide);
            clone.BackColor = pictureBox.BackColor;

            return clone;
        }

        private static void GenerateNewFigure() 
        { 
            Random random = new Random();

            int figureNumber = random.Next(0, 7);
            int rotationAngle = random.Next(0, 4); // for now this option is disabled

            currentFigure = figures[figureNumber];

            currentFigureCells = new List<PictureBox>();

            /* for (int i = 0; i < rotationAngle; i++)
            {
                Rotate(true);
            } */

            currentFigureCoords = new Point(8, 2);

            for (int i = 0; i < 4; i++)
            {
                PictureBox cell = new PictureBox();
                cell.Size = new Size(cubeSide, cubeSide);
                cell.BackColor = Color.Red;

                cell.Location = new Point((currentFigure[i].X + currentFigureCoords.X) * cubeSide,
                    (currentFigure[i].Y + currentFigureCoords.Y) * cubeSide);

                currentFigureCells.Add(cell);

                form.Add(cell);
            }
        }

        private static bool IsMovementValid(string s) // checks if side mooving is valid
        {
            switch (s) 
            {
                case "Right":
                    foreach (var item in currentFigure) 
                    { 
                        if (item.X + currentFigureCoords.X + 1 >= xMax) return false; // touching the walls
                        if (binaryGrid[item.Y + currentFigureCoords.Y, // touching the fallen figures
                            item.X + currentFigureCoords.X + 1] == 1) return false;
                    }
                    return true;                   
                case "Left":
                    foreach (var item in currentFigure)
                    {
                        if (item.X + currentFigureCoords.X - 1 < 0) return false; // touching the walls
                        if (binaryGrid[item.Y + currentFigureCoords.Y, // touching the fallen figures
                            item.X + currentFigureCoords.X - 1] == 1) return false;
                    }
                    return true;                  
                default:
                    return true;
            }
        }

        private static bool IsLanded() // work with grid
        {
            foreach (var item in currentFigure) 
            {
                int j = item.Y;
                int i = item.X;               

                if (j + 1 + currentFigureCoords.Y >= binaryGrid.GetLength(0)) return true;
                if (binaryGrid[j + 1 + currentFigureCoords.Y, i + currentFigureCoords.X] == 1) return true;
            }

            return false;
        }
      

        private static void Rotate(bool leftRotation) // flag = true if rotating left, false if right
        {
            List<Point> newList = new List<Point>();
            newList.AddRange(currentFigure);

            int multiple = leftRotation ? 1 : -1;

            for (int i = 0; i < currentFigure.Count; i ++) 
            {
                int X = currentFigure[i].Y * multiple;
                int Y = -currentFigure[i].X * multiple;

                if (binaryGrid[Y + currentFigureCoords.Y, X + currentFigureCoords.X] == 1
                    || X + currentFigureCoords.X < 0 
                    || X + currentFigureCoords.X >= xMax 
                    || Y + currentFigureCoords.Y < 0) // rotation is not valid, list stays the same
                {
                    currentFigure = newList;
                    return;
                }

                currentFigure[i] = new Point(X, Y);
            }

            for (int i = 0; i < currentFigureCells.Count; i++)
            {
                currentFigureCells[i].Location = new Point((currentFigure[i].X + currentFigureCoords.X) * cubeSide, 
                    (currentFigure[i].Y + currentFigureCoords.Y) * cubeSide);
            }
        }      

        private static void DownShifting() 
        {
            if (!IsLanded())
            {
                currentFigureCoords.Y++;               

                for (int i = 0; i < currentFigureCells.Count; i++) 
                {
                    currentFigureCells[i].Location = new Point(currentFigureCells[i].Location.X, 
                        currentFigureCells[i].Location.Y + 1 * cubeSide);
                }                

                // label.Text = "Coordinates: X = " + currentFigureCells[0].Location.X + " Y = " + currentFigureCells[0].Location.Y;
            }
            else 
            {
                AddFigureToGrid();
            }
        }

        private static void AddFigureToGrid()
        {

            for (int i = 0; i < currentFigureCells.Count; i++)
            {
                currentFigureCells[i].Dispose();
            }

            for (int i = 0; i < currentFigure.Count; i++)
            {
                int X = currentFigure[i].X + currentFigureCoords.X;
                int Y = currentFigure[i].Y + currentFigureCoords.Y;

                binaryGrid[Y, X] = 1;

                playableArea[Y, X] = new PictureBox();
                playableArea[Y, X].Size = new Size(cubeSide, cubeSide); 
                playableArea[Y, X].Location = new Point(X * cubeSide, Y * cubeSide);
                playableArea[Y, X].BackColor = currentFigureCells[i].BackColor;

                form.Add(playableArea[Y, X]);
            }

            GenerateNewFigure();
        }

        private static void FallDown() 
        { 

            // is it needed?

        }

        private static void LeftMove() 
        {
            currentFigureCoords.X--;           

            for (int i = 0; i < currentFigureCells.Count; i++)
            {
                currentFigureCells[i].Location = new Point(currentFigureCells[i].Location.X - 1 * cubeSide,
                    currentFigureCells[i].Location.Y);
            }
        }

        private static void RightMove()
        {
            currentFigureCoords.X++;           

            for (int i = 0; i < currentFigureCells.Count; i++)
            {
                currentFigureCells[i].Location = new Point(currentFigureCells[i].Location.X + 1 * cubeSide,
                    currentFigureCells[i].Location.Y);
            }
        }  

        private static void Update(Object sender, EventArgs args) 
        { 
            DownShifting();

            FullRowsRemoving(); // built rows collapsing
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }       
    }
}