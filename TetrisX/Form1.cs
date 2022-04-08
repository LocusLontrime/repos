namespace TetrisX
{
    public partial class Form1 : Form // split tetris -> 2 in 1
    {
        // area size section
        private static int width = 1000;
        private static int height = 1050;       

        private static readonly int cubeSide = 50;

        private static List<Color> colorList;
        private static int colorCounter;

        // playable area section
        private static int[,] binaryGrid;
        private static PictureBox[,] playableArea;

        private static int xMax, yMax;

        // figures in the initial state library
        private static List<List<Point>> figures;

        // current Figure section
        private static List<Point> currentFigure; // -> Figure figure // list of tetroGon coordinates with the center in the rotationPoint
        private static List<PictureBox> currentFigureCells;
        private static Point currentFigureCoords;

        // next Figure section
        private static List<PictureBox> nextFigure;
        private static int nextFigureNumber;

        private static Label label;

        // speed and scores section
        private static int speed = 500;
        private static int scores;
        private static int deletedRowsCounter; // the parameter, wich the current speed of the game depends on

        // timers section
        private static System.Windows.Forms.Timer timer; // for the main update cycle
        private static System.Windows.Forms.Timer timerX; // for the auxiliary features

        private static int animationCounter; // it needs for timerX when animation is being displayed (Method Animate())
        private static int rowToAnimateNumber; // We need to know which exactly row should be animated

        private static List<int> rowsToBeDeleted; // rows fully filled with 1s, that will be deleted soon by invokation of
                                                  // FullRowsRemoving method
        private static bool flag;

        private static Control.ControlCollection form;

        public Form1()
        {
            InitializeComponent();

            flag = true;

            form = this.Controls;
            this.Width = width;
            this.Height = height;

            scores = 0;
            deletedRowsCounter = 0;

            figures = new List<List<Point>>();

            for (int i = 0; i < 7; i++) // 7 figures
            {
                figures.Add(new List<Point>());
            }

            //Color Library
            colorCounter = 0;

            colorList = new List<Color>();

            colorList.Add(Color.DarkRed);
            colorList.Add(Color.DarkBlue);
            colorList.Add(Color.Orange);
            colorList.Add(Color.DarkGreen);
            colorList.Add(Color.Purple);

            //Figures library
            figures[0].Add(new Point(0, 0)); // the first one PIN
            figures[0].Add(new Point(-1, 0));
            figures[0].Add(new Point(0, 1));
            figures[0].Add(new Point(1, 0));

            figures[1].Add(new Point(-1, 0)); // the second one JletterLeft
            figures[1].Add(new Point(-1, 1));
            figures[1].Add(new Point(0, 1));
            figures[1].Add(new Point(1, 1));

            figures[2].Add(new Point(-1, 1)); // the third one JletterRight
            figures[2].Add(new Point(0, 1));
            figures[2].Add(new Point(1, 1));
            figures[2].Add(new Point(1, 0));

            figures[3].Add(new Point(-1, 0)); // the fourth one Stick
            figures[3].Add(new Point(0, 0));
            figures[3].Add(new Point(1, 0));
            figures[3].Add(new Point(2, 0));

            figures[4].Add(new Point(0, 0)); // the fifth one Cube with no rotation!!!!!
            figures[4].Add(new Point(1, 0));
            figures[4].Add(new Point(0, 1));
            figures[4].Add(new Point(1, 1));

            figures[5].Add(new Point(-1, 0)); // the sixth one ZletterTopLeft
            figures[5].Add(new Point(0, 0));
            figures[5].Add(new Point(0, 1));
            figures[5].Add(new Point(1, 1));

            figures[6].Add(new Point(-1, 1)); // the seventh one ZletterTopRight
            figures[6].Add(new Point(0, 1));
            figures[6].Add(new Point(0, 0));
            figures[6].Add(new Point(1, 0));

            label = new Label();
            label.Size = new Size(225, 100);
            label.Location = new Point(751, 0);

            label.Font = new Font(FontFamily.GenericMonospace, 15, FontStyle.Bold);

            label.Text = "\n     Scores: 0" + "\n\n     Next figure: ";

            form.Add(label);

            binaryGrid = new int[height / cubeSide, (width - label.Width) / cubeSide];
            playableArea = new PictureBox[Height / cubeSide, (Width - label.Width) / cubeSide];

            yMax = binaryGrid.GetLength(0);
            xMax = binaryGrid.GetLength(1);

            this.KeyDown += new KeyEventHandler(KeyPressedHandler);

            timer = new System.Windows.Forms.Timer();

            timer.Tick += new EventHandler(Update); // how to pause???
            timer.Interval = speed;
            timer.Start();

            timerX = new System.Windows.Forms.Timer();

            timerX.Tick += new EventHandler(Animate);
            timerX.Interval = speed / 10;
            timerX.Start();
            
            nextFigure = new List<PictureBox>();

            rowsToBeDeleted = new List<int>();

            GenerateGrid(); // here we add a markUp

            GridZeroFill(); // filling grid with nulls
            // GridTestFill(); -> test MODE

            DefineNextFigureNum();
            GenerateNewFigure(); // creates a first figure on the field
        }

        private static void Animate(Object sender, EventArgs args) 
        {
            // here comes an animation of rows removing

            if (!flag) // being invoked while the main update cycle is on the pause (flag = false)
            {
                foreach (int i in rowsToBeDeleted)
                {
                    if (animationCounter <= 7) // as 7 + 1 + 7 = 15 -> width of the Tetris field in cubeSides
                    {
                        playableArea[i, 7 + animationCounter].Image = new Bitmap(@"C:\Users\langr\Downloads\Explosion.bmp", true);
                        playableArea[i, 7 - animationCounter].Image = new Bitmap(@"C:\Users\langr\Downloads\Explosion.bmp", true);
                    }
                    else
                    {
                        // disposing
                        FullRowsRemoving();

                        deletedRowsCounter += rowsToBeDeleted.Count;

                        rowsToBeDeleted.Clear();
                        flag = true;

                        break;
                    }
                }

                animationCounter++;    
            }
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
                case "P": // -> one button improve
                    Pause();
                    break;
                case "O":
                    UnPause();
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

        private static void GridTestFill() // Zero fulfilling of the binary Grid
        {
            for (int j = 0; j < yMax; j++)
            {
                for (int i = 0; i < xMax; i++)
                {
                    if (j <= 6) binaryGrid[j, i] = 0;
                    else
                    {
                        binaryGrid[j, i] = 1;
                        DrawPB(new Point(i, j));
                    }
                }
            }
        }

        private static void DrawPB(Point location)
        {
            PictureBox pb = new PictureBox();

            pb.Size = new Size(cubeSide, cubeSide);
            pb.Location = new Point(location.X * cubeSide, location.Y * cubeSide);
            pb.BackColor = Color.DarkRed;

            playableArea[location.Y, location.X] = pb;

            form.Add(pb);
        }

        private void GenerateGrid() // here we draw the lines...)
        {
            for (int i = 0; i <= height / cubeSide; i++) // horizontal ones
            {
                DrawLine(form, new Point(0, cubeSide * i), new Size(width - label.Width - 25, 1));
            }

            for (int i = 0; i <= (width - label.Width) / cubeSide; i++) // vertical ones
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

        private static void DrawNextFigurePreview() // when the figure hits 1 on the grid the preview starts
                                                    // to change on pressing down button
        {
            int xStart = 850;
            int yStart = 150;

            if (nextFigure.Count > 0) for (int i = 0; i < nextFigure.Count; i++) // removing the old cells
            {
                nextFigure[i].Dispose();
            }

            nextFigure = new List<PictureBox>();

            for (int i = 0; i < 4; i++) // painting the new ones
            {
                PictureBox pb = new PictureBox();
                pb.Size = new Size(cubeSide, cubeSide);
                pb.BackColor = colorList[colorCounter % colorList.Count];
                pb.Location = new Point(xStart + figures[nextFigureNumber][i].X * cubeSide, 
                    yStart + figures[nextFigureNumber][i].Y * cubeSide);

                nextFigure.Add(pb);

                form.Add(pb);
            }
        }

        private static void FindAllOneFilledRows()
        {
            bool result = false; // if there is a row full of 1s

            for (int i = yMax - 1; i > 0; i--)
            {
                for (int l = 0; l <= xMax - 1; l++)
                {
                    result = binaryGrid[i, l] == 1 ? true : false; // Levigin's ternary
                    if (!result)
                    {
                        break;
                    }
                }

                if (result) rowsToBeDeleted.Add(i);
            }
        }

        private static void FullRowsRemoving() // The method based on Levigin's algo
        {
            int deletedRowsCounter = 0;

            int multiplyingCounter = 1; // Cheperis idea

            foreach (int i in rowsToBeDeleted)
            {                                    
                for (int k = i + deletedRowsCounter - 1; k >= 0; k--)
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

                scores += xMax * multiplyingCounter++; // Cheperis' calculations

                label.Text = "\n     Scores: " + scores + "\n\n     Next figure: "; // displaying the scores

                deletedRowsCounter++; // staying at the same row because of the fallen down rows above...             
            }  
        }

        private static PictureBox ClonePB(PictureBox pictureBox) // An accurate cloning of a PictureBox
        {
            PictureBox clone = new PictureBox();

            clone.Size = pictureBox.Size;
            clone.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + cubeSide);
            clone.BackColor = pictureBox.BackColor;

            return clone;
        }

        private static void DefineNextFigureNum() 
        {
            Random random = new Random();

            nextFigureNumber = random.Next(0, 7);       
        }

        private static void GenerateNewFigure() 
        {                    
            Color figureColor;

            figureColor = colorList[colorCounter++ % colorList.Count];

            currentFigure = new List<Point>();
            currentFigure.AddRange(figures[nextFigureNumber]); // cloning

            currentFigureCells = new List<PictureBox>();

            currentFigureCoords = new Point(7, 1);

            if (!IsSpawnAvailable()) GameOver();

            for (int i = 0; i < 4; i++)
            {
                PictureBox cell = new PictureBox();
                cell.Size = new Size(cubeSide, cubeSide);
                cell.BackColor = figureColor;

                cell.Location = new Point((currentFigure[i].X + currentFigureCoords.X) * cubeSide,
                    (currentFigure[i].Y + currentFigureCoords.Y) * cubeSide);

                currentFigureCells.Add(cell);

                form.Add(cell);
            }

            DefineNextFigureNum();

            DrawNextFigurePreview();
        }

        private static void GameOver() // listen to "Баллада о Плюсах"... баллажа!!!
        {
            timer.Stop();

            // end of the game
        }

        private static void Pause() 
        {
            timer.Enabled = false;
        }

        private static void UnPause()
        {
            timer.Enabled = true;
        }


        private static bool IsSpawnAvailable() 
        {           
            for (int k = 0; k < currentFigure.Count; k++) 
            {
                if (binaryGrid[currentFigure[k].Y + currentFigureCoords.Y, currentFigure[k].X + currentFigureCoords.X] == 1) return false;
            }

            return true; 
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

                if (X + currentFigureCoords.X >= 0
                    && X + currentFigureCoords.X < xMax
                    && Y + currentFigureCoords.Y >= 0
                    && Y + currentFigureCoords.Y < yMax
                    && binaryGrid[Y + currentFigureCoords.Y, X + currentFigureCoords.X] != 1) // rotation is not valid, list stays the same
                { 
                    // do nothing
                }
                else
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

        private static void VROTLAN(string s) // ??????
        { 
            
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
            if (flag) { 
                DownShifting();
                FindAllOneFilledRows();

                if (deletedRowsCounter >= 3) // tune this!!!
                {
                    deletedRowsCounter = 0;
                    speed = (int) (speed * 0.9);
                    timer.Interval = speed;
                }

                if (rowsToBeDeleted.Count > 0) {
              
                    animationCounter = 0;

                    flag = false;                                         
                }
            }
        }

        public class Figure
        {
            FigureType type;

            List<Point> figure;
            List<PictureBox> figureCells;

            public Figure()
            { 



            }

            public Figure(FigureType type) : base()
            { 



            }
        }

        public enum FigureType 
        { 
            Square, 
            LetterJ,
            Pin, 
            Stick, 
            LetterZ
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // 1. Меню -> можно ли сделать, кнопки паузы (ели надо) и рестарта игры.
        // 2. ++Подсказка следующей фигуры в цвете, скорректировать расположение
        // 3. ++Красивая анимация уничтожения заполненного ряда 
        // 4. Анимация GameOver и приостановка цикла апдейт до выбора следующей игры
        // 5. Увеличение скорости в процессе игры и начисление очков сообразно множителю скорости
        // 6. Enum class -> что-то сделать???
        // 7. ++Выход ротации за пределы поля -> обработать 
        // 6. -+Тестировка 
    }
}