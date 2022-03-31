using System.Collections;
using System.Linq;
using System.Media;
using Windows.Media.Playback;

namespace SnakeOrFake
{
    public partial class Form1 : Form // 3669789 xFT
    {
        private int directionX, directionY; // directions

        private int pathTraversed; // for incrementation of the speed and difficulty

        private readonly int height = 1080; // working field
        private readonly int width = 1920;
        private static readonly int cubeSide = 50; // cube linear size

        private int speed = 175; // initial snake's speed

        private int multiplier; // for speed ups scores incrementation

        private List<Fruit> fruitList;  // list of fruits, located on the grid at the current moment of time    

        private int maxFruitsNumber = 5; // the max number of fruits that can be located on the greed simultaniously

        private static List<SnakeCell> snake; // the snake

        private List<Bomb> bombs; // bombs list

        private Label info; // label section -> show some usefull info during the game process
        private Label labelScores;
        private Label labelSpeed;

        private int scores; // current scores

        private int count; // for spawning bombs correctly
        private int bombSpawningTreshHold = 25;

        private int[,] grid; // for wave-spreading algo working

        SoundPlayer soundPlayer; // SoundPlayer section
        SoundPlayer bombExplosion;
        SoundPlayer alarm;
        SoundPlayer explosionTsar;
        SoundPlayer fruitPickUp;
        SoundPlayer bumpIntoWall;
        SoundPlayer explode;
        SoundPlayer selfBite;
        SoundPlayer gameOver;

        MediaPlayer player; // ???

        Control.ControlCollection form; // for convenience

        public Form1()
        {
            InitializeComponent();

            form = this.Controls;

            soundPlayer = new SoundPlayer(@"C:\Users\langr\Downloads\BitShifter.wav"); // sounds loading

            explosionTsar = new SoundPlayer(@"C:\Users\langr\Downloads\ExplosionTsar.wav");

            alarm = new SoundPlayer(@"C:\Users\langr\Downloads\Alarm.wav");

            soundPlayer.PlayLooping(); // cycling playing of main theme during the play phase

            this.height = height; // play field size
            this.width = width;

            directionX = 1; // default direction (to the right)
            directionY = 0;

            scores = 0; 
            count = 0; // counter for bombs spawning           

            snake = new List<SnakeCell>(); // snake's cells initialization  

            bombs = new List<Bomb>(); // list of Bombs initialization          

            pathTraversed = 0;

            fruitList = new List<Fruit>(); // list of fruits initialization

            GenerateGrid(); // here we are generating the playable grid           

            GenerateFruits(); // random generating of a fruit in the playable area

            AddSnakeCellToList(form, true, new Point(0, 0)); // creation of the snake's head at the start of the game

            info = CreateLabel(form, new Size(250, 50), "Speed: " + speed, new Point(1655, 0)); // labels creation
            labelScores = CreateLabel(form, new Size(250, 50), "Scores: 0", new Point(1655, 100));
            labelSpeed = CreateLabel(form, new Size(250, 50), "Speed: " + speed, new Point(1655, 200));

            timer.Tick += new EventHandler(Update); // here we start the update cycle
            timer.Interval = speed;
            timer.Start();

            this.KeyDown += new KeyEventHandler(KeyPressedHandler); // keys pressed handler
        }

        private static void AddSnakeCellToList(Control.ControlCollection form, bool headOrNot, Point point) // adds a new cell to
                                                                                                            // the snake's cells list
                                                                                                            // can add head or usual cell
        {
            SnakeCell snakeCell = new SnakeCell();
            PictureBox snakeCellBox = new PictureBox();

            snakeCellBox.Location = point;
            snakeCellBox.Size = new Size(cubeSide, cubeSide);

            Bitmap textImg;
            textImg = headOrNot ? new Bitmap(@"C:\Users\langr\Downloads\SnakeHead.bmp", true) :
                new Bitmap(@"C:\Users\langr\Downloads\SnakeCell.bmp", true);

            snakeCellBox.Image = textImg;

            snakeCell.snakeCell = snakeCellBox;

            snake.Add(snakeCell); // snake's Head creation           

            form.Add(snakeCellBox); // painting the cell on the form
        }

        private static Label CreateLabel(Control.ControlCollection form, Size size, string labelText, Point location)
        {
            Label label = new Label();

            label = new Label();
            label.Size = size;
            label.Text = labelText;
            label.Location = location;

            form.Add(label); // painting the cell on the form

            return label;
        }

        private void GenerateBomb() // what does the bomb mean?
        {
            Bomb bomb;         

            bool flag = true;

            int bombX = 0, bombY = 0;

            Random random = new Random();

            while (flag)
            {
                bombX = cubeSide * random.Next(0, (width - 270) / cubeSide - 1);
                bombY = cubeSide * random.Next(0, height / cubeSide - 1);
                flag = IsThereIntersections(bombX, bombY, false) && IsThereAnyTsarBomb();
            }

            Point point = new Point(bombX, bombY);

            int typeOfExplosion = random.Next(0, 5);

            Graphics g;

            switch (typeOfExplosion)
            {
                case 0:
                    bomb = new Bomb(7, 3, TypeOfExplosion.Vertical, point);
                    g = Graphics.FromImage(bomb.cellBox.Image);
                    g.DrawString("V", new Font("Arial", 200), Brushes.Yellow, 3, 10);
                    break;
                case 1:
                    bomb = new Bomb(7, 3, TypeOfExplosion.Horizontal, point);
                    g = Graphics.FromImage(bomb.cellBox.Image);
                    g.DrawString("H", new Font("Arial", 200), Brushes.Yellow, 3, 10);
                    break;
                case 2:
                    bomb = new Bomb(7, 3, TypeOfExplosion.Cross, point);
                    g = Graphics.FromImage(bomb.cellBox.Image);
                    g.DrawString("C", new Font("Arial", 200), Brushes.Yellow, 3, 10);
                    break;
                case 3:
                    bomb = new Bomb(7, 3, TypeOfExplosion.Square, point);
                    g = Graphics.FromImage(bomb.cellBox.Image);
                    g.DrawString("S", new Font("Arial", 200), Brushes.Yellow, 3, 10);
                    break;
                case 4:
                    int ROE = Math.Max(Math.Max(Math.Max(width - 270 - bombX, bombX),
                        height - bombY), bombY) / cubeSide + 1;
                    int TOE = (Math.Abs(snake[0].snakeCell.Location.X - bombX) +
                        Math.Abs(snake[0].snakeCell.Location.Y - bombY)) / cubeSide + 10;

                    bomb = new Bomb(ROE, TOE, TypeOfExplosion.Tsar, point);

                    alarm.Play();
                    break;
               default: bomb = new Bomb(); // RrrrrrrooooaaarrrRRR!!! The trash as it is
                    break;
            }

            bombs.Add(bomb);

            this.Controls.Add(bomb.cellBox);
        }

        private bool IsThereAnyTsarBomb()
        {
            foreach (var item in bombs)
            {
                if (item.typeOfExplosion.Equals(TypeOfExplosion.Tsar)) return true;
            }

            return false;
        }

        private void MoveBomb() // is it really needed???
        { 

            

        }

        private void GenerateRoot() // in which way will it be interract with other objects on the grid?..
        { 



        }

        private void BombEngine()
        {
            for (int i = 0; i < bombs.Count; i++)
            {
                if (bombs[i].flag) // exploding phase
                {
                    if (++bombs[i].currentROE != bombs[i].ROE)
                    {
                        GenerateWaves(bombs[i]); // while currentROE <= ROE -> the bomb is exploding
                    }
                    else
                    {
                        for (int j = 0; j <= bombs[i].currentROE - 2; j++) // removing the remained explosive cells from the grid
                        {
                            foreach (var item in bombs[i].currentBombWaves[j])
                            {
                                item.Dispose();
                            }

                            if (!bombs[i].typeOfExplosion.Equals(TypeOfExplosion.Tsar) &&
                                !bombs[i].typeOfExplosion.Equals(TypeOfExplosion.Square)) bombs[i].cellBox.Dispose(); // the removing of
                                                                                                                      // the bomb icon
                                                                                                                      // after the explosion ended

                            if (bombs[i].typeOfExplosion.Equals(TypeOfExplosion.Tsar)) // audio part of Tsar explosion
                            {
                                explosionTsar.Stop();
                                soundPlayer.PlayLooping();
                            }
                        }
                        bombs.Remove(bombs[i]); // deleting the bomb from the bombs list
                    }                    
                }
                else // time is ticking phase
                {
                    if (bombs[i].TOE-- == 0) // cycling decreasing of TOE
                    {
                        bombs[i].flag = true;
                        if (bombs[i].typeOfExplosion.Equals(TypeOfExplosion.Tsar)) // if the bomb is of a Tsar type
                                                                                   // then the alarm.wav is playing
                        {
                            alarm.Stop();
                            explosionTsar.Play();
                        }
                    }
                }
            }
        }

        private void GenerateWaves(Bomb bomb) 
        {
            TypeOfExplosion type = bomb.typeOfExplosion;

            if (type.Equals(TypeOfExplosion.Square) || type.Equals(TypeOfExplosion.Tsar))
            {
                GenerateSquareWaves(bomb);
            }
            else 
            {
                GenerateSquareWaves(bomb);
            }
        }

        private void GenerateCrossWaves(Bomb bomb)
        {
            TypeOfExplosion type = bomb.typeOfExplosion;


            int centerX = bomb.cellBox.Location.X;
            int centerY = bomb.cellBox.Location.Y;

            int stepCount = bomb.currentROE;

            List<PictureBox> currentWave = new List<PictureBox>();

            if (type.Equals(TypeOfExplosion.Horizontal) || type.Equals(TypeOfExplosion.Cross)) // left-right spreading
            {
                if (centerX - stepCount * cubeSide >= 0)
                {
                    AddExplosiveCellToFront(form, new Point(centerX - stepCount * cubeSide, centerY), bomb, currentWave);
                }

                if (centerX + stepCount * cubeSide < width - 270)
                {
                    AddExplosiveCellToFront(form, new Point(centerX + stepCount * cubeSide, centerY), bomb, currentWave); 
                }
            }

            if (type.Equals(TypeOfExplosion.Vertical) || type.Equals(TypeOfExplosion.Cross)) // top-down spreading
            {
                if (centerY - stepCount * cubeSide >= 0)
                {
                    AddExplosiveCellToFront(form, new Point(centerX, centerY - stepCount * cubeSide), bomb, currentWave);  
                }

                if (centerY + stepCount * cubeSide < height - 55 - cubeSide)
                {
                    AddExplosiveCellToFront(form, new Point(centerX, centerY + stepCount * cubeSide), bomb, currentWave); 
                }
            }

            bomb.currentBombWaves.Add(currentWave);

            TryToExplode(bomb);
        }

        private void GenerateSquareWaves(Bomb bomb) // waveSpreading step of an Explosion (Square Explosion Spreading, SES)
        {
            int centerX = bomb.cellBox.Location.X;
            int centerY = bomb.cellBox.Location.Y;

            int stepCount = bomb.currentROE;

            List<PictureBox> currentWave = new List<PictureBox>();

            if (stepCount == 1) bomb.cellBox.Dispose();

            for (int i = centerX - stepCount * cubeSide; i <= centerX + stepCount * cubeSide; i += cubeSide) // up horizontal
            {
                if (i < 0 || centerY - stepCount * cubeSide < 0 || i > width - 270 - cubeSide ||
                    centerY - stepCount * cubeSide > height - 55 - cubeSide) { }
                else
                {
                    AddExplosiveCellToFront(form, new Point(i, centerY - stepCount * cubeSide), bomb, currentWave);
                }
            }

            for (int i = centerX - stepCount * cubeSide; i <= centerX + stepCount * cubeSide; i += cubeSide) // down horizontal
            {
                if (i < 0 || centerY + stepCount * cubeSide < 0 || i > width - 270 - cubeSide ||
                    centerY + stepCount * cubeSide > height - 55 - cubeSide) { }
                else
                {
                    AddExplosiveCellToFront(form, new Point(i, centerY + stepCount * cubeSide), bomb, currentWave);
                }
            }

            for (int i = centerY - (stepCount - 1) * cubeSide; i < centerY + stepCount * cubeSide; i += cubeSide) // left vertical
            {
                if (centerX - stepCount * cubeSide < 0 || i < 0 || centerX - stepCount * cubeSide > width - 270 - cubeSide ||
                    i > height - 55 - cubeSide) { }
                else
                {
                    AddExplosiveCellToFront(form, new Point(centerX - stepCount * cubeSide, i), bomb, currentWave);
                }
            }

            for (int i = centerY - (stepCount - 1) * cubeSide; i < centerY + stepCount * cubeSide; i += cubeSide) // right vertical
            {
                if (centerX + stepCount * cubeSide < 0 || i < 0 || centerX + stepCount * cubeSide > width - 270 - cubeSide ||
                    i > height - 55 - cubeSide) { }
                else
                {
                    AddExplosiveCellToFront(form, new Point(centerX + stepCount * cubeSide, i), bomb, currentWave);
                }
            }

            bomb.currentBombWaves.Add(currentWave);

            if (stepCount > 1)
            {
                foreach (var item in bomb.currentBombWaves[stepCount - 2])
                {
                    item.Dispose();
                }
            }

            TryToExplode(bomb);
        }

        private void AddExplosiveCellToFront(Control.ControlCollection form, Point point, Bomb bomb, List<PictureBox> currentWave) 
        {
            PictureBox explosiveCell = new PictureBox();
            explosiveCell.Size = new Size(cubeSide, cubeSide);

            Bitmap textImg;

            if (!bomb.typeOfExplosion.Equals(TypeOfExplosion.Tsar)) textImg = new Bitmap(@"C:\Users\langr\Downloads\Explosion.bmp", true);
            else textImg = new Bitmap(@"C:\Users\langr\Downloads\NuclearExplosion.bmp", true);

            explosiveCell.Image = textImg;

            explosiveCell.Location = point;
            currentWave.Add(explosiveCell);

            form.Add(explosiveCell);
        }

        private void TryToExplode(Bomb bomb) // tries to explode snake at the every updating step
        {
            int minIndex = int.MaxValue;
            
            if (bomb.typeOfExplosion.Equals(TypeOfExplosion.Square) || bomb.typeOfExplosion.Equals(TypeOfExplosion.Tsar))
                foreach (var item in bomb.currentBombWaves[bomb.currentROE - 1])
                {
                    // exploding the snake
                    for (int i = 0; i < snake.Count; i++)
                    {
                        if (item.Location.X == snake[i].snakeCell.Location.X && item.Location.Y == snake[i].snakeCell.Location.Y)
                        {
                            minIndex = Math.Min(minIndex, i);
                        }
                    }

                    // exploding fruits
                    for (int i = 0; i < fruitList.Count; i++) 
                    {
                        if (item.Location.X == fruitList[i].fruit.Location.X && item.Location.Y == fruitList[i].fruit.Location.Y) 
                        {
                            fruitList[i].fruit.Dispose();
                            fruitList.Remove(fruitList[i]); 

                            GenerateFruit(); // generating a new one after the previous was destroyed
                        }                       
                    } 
                }
            else // if the bomb is not of a Tsar or Square type
            {
                for (int j = 0; j <= bomb.currentROE - 1; j++)
                {
                    foreach (var item in bomb.currentBombWaves[j])
                    {
                        for (int i = 0; i < snake.Count; i++) // exploding the snake
                        {
                            if (item.Location.X == snake[i].snakeCell.Location.X && item.Location.Y == snake[i].snakeCell.Location.Y)
                            {
                                minIndex = Math.Min(minIndex, i);
                            }
                        }

                        // exploding fruits
                        for (int i = 0; i < fruitList.Count; i++)
                        {
                            if (item.Location.X == fruitList[i].fruit.Location.X && item.Location.Y == fruitList[i].fruit.Location.Y)
                            {
                                fruitList[i].fruit.Dispose();
                                fruitList.Remove(fruitList[i]);

                                GenerateFruit(); // generating a new one after the previous was destroyed
                            }
                        }
                    }
                }
            }

            if (minIndex == 0) // if the snake's head intersects the explosion's wave -> only head remains
            {
                ShortenTheSnake(1, false);
            }
            else if (minIndex != int.MaxValue) // explosion when the snake is near -> shortening of the snake
            {
                ShortenTheSnake(minIndex, false);
            }    
        }

        private bool IsThereIntersections(int x, int y, bool isFruit) // flag = 1 : fruit, flag = 2 : bomb
        {
            foreach (var item in bombs)
            {
                if (item.cellBox.Location.X == x && item.cellBox.Location.Y == y) return true;
            }

            foreach (var item in snake)
            {
                if (item.snakeCell.Location.X == x && item.snakeCell.Location.Y == y) return true;
            }

            if (!isFruit) foreach (var item in fruitList) {
                    if (item.fruit.Location.X == x && item.fruit.Location.Y == y) return true;
                }

            return false;
        }

        private void Update(Object obj, EventArgs args) // the main cycle of the game
        {
            count += 1;
            if (count >= bombSpawningTreshHold) // bomb spawn
            {
                GenerateBomb();
                count = 0;
            }

            DefuseBomb();

            BombEngine();

            TryEatSelf();
            EatFruit();
            MoveSnake();
        }

        private bool IsMovementValid(int x, int y) // checks if the next step of movement is possible or not
        {
            if (x < 0 || y < 0 || x > width - 270 - cubeSide || y > height - 55 - cubeSide) return false;
            return true;
        }

        private void TryEatSelf() // snake tries to eat itself at the every step
        {
            for (int i = 1; i < snake.Count; i++)
            {
                if (snake[i].snakeCell.Location.X == snake[0].snakeCell.Location.X &&
                    snake[i].snakeCell.Location.Y == snake[0].snakeCell.Location.Y)
                {
                    ShortenTheSnake(i, true);
                }
            }
        }

        private void ShortenTheSnake(int indexOfIntersection, bool flag) // if snake eats itself then we use true-flag / if not -> false
        {
            int i = indexOfIntersection;

            while (snake.Count > indexOfIntersection)
            {                
                snake[i].snakeCell.Dispose();
                snake.Remove(snake[i]);
            }

            if (flag) // for the snake self-eating
            {
                timer.Interval = (int)(timer.Interval * 0.95);
                labelSpeed.Text = "Speed: " + timer.Interval;
            }
        }

        private void GenerateGrid() // here we draw the lines...)
        {
            for (int i = 0; i < height / cubeSide; i++) // horizontal ones
            {
                DrawLine(form, new Point(0, cubeSide * i), new Size(width - 270, 1));
            }

            for (int i = 0; i < (width - 270) / cubeSide + 1; i++) // vertical ones
            {
                DrawLine(form, new Point(cubeSide * i, 0), new Size(1, height - 79));        
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

        private void DefuseBomb() // the snake tries to defuse Tsar bomb at the every step
        {
            foreach (Bomb bomb in bombs) 
            {
                if (bomb.typeOfExplosion == TypeOfExplosion.Tsar && !bomb.flag) 
                {
                    if (bomb.cellBox.Location.X == snake[0].snakeCell.Location.X &&
                        bomb.cellBox.Location.Y == snake[0].snakeCell.Location.Y) 
                    {
                        alarm.Stop();
                        soundPlayer.PlayLooping();

                        bomb.cellBox.Dispose();

                        bombs.Remove(bomb);
                        break;
                    }
                }
            }
        }
        private void EatFruit() // here the snake tries to eat fruit in the every cell it reaches
        {
            foreach (Fruit fruit in fruitList) // snake's head can intersects only one fruit in the every moment of time
            {
                if (snake[0].snakeCell.Location.X == fruit.fruit.Location.X && snake[0].snakeCell.Location.Y == fruit.fruit.Location.Y)
                {
                    fruit.fruit.Dispose();
                    fruitList.Remove(fruit);

                    for (int i = 0; i < fruit.vivifyingPower; i++)
                    {
                        AddCellToSnake();
                    }

                    info.Text = "Snake length = " + snake.Count;

                    GenerateFruits();

                    break;
                }
            }
        }

        private void AddCellToSnake() // adds a cell to the snake and increases the current scores by some value
        {
            AddSnakeCellToList(form, false, new Point(snake[snake.Count - 1].snakeCell.Location.X - cubeSide * directionX,
                -cubeSide * directionY + snake[snake.Count - 1].snakeCell.Location.Y));

            scores += snake.Count; // increasing the current scores

            labelScores.Text = "Scores: " + scores;
        }

        private void MoveSnake() // the main method of the snake's movement
        {
            if (IsMovementValid(snake[0].snakeCell.Location.X + directionX * cubeSide, 
                snake[0].snakeCell.Location.Y + directionY * cubeSide))
            {
                for (int i = snake.Count - 1; i >= 1; i--) // every i-th snake's cube excluding the head takes place of (i-1)-th cell
                                                           // and the head moves forward by 1 cell.
                {
                    snake[i].snakeCell.Location = snake[i - 1].snakeCell.Location;
                }

                snake[0].snakeCell.Location = new Point(snake[0].snakeCell.Location.X + directionX * cubeSide,
                    snake[0].snakeCell.Location.Y + directionY * cubeSide);
            }
            else // if the snake bumped into a wall
            {
                int i = 1; // snake counter

                while (snake.Count > 1) // deleting all the snake's cubes excluding the head
                {
                    if (!snake[i].Equals(snake[0]))
                    {
                        // snake[i].BackColor = Color.White;
                        snake[i].snakeCell.Dispose();
                        snake.Remove(snake[i]);
                    }
                }

                directionX = -directionX; // changing the direction of movement
                directionY = -directionY;

                // a first step in the opposite direction the snake came from
                snake[0].snakeCell.Location = new Point(snake[0].snakeCell.Location.X + directionX * cubeSide, 
                    snake[0].snakeCell.Location.Y + directionY * cubeSide);

                info.Text = "Snake length = " + snake.Count;

                scores = 0; // nullifying the scores
                labelScores.Text = "Scores: " + scores;
                timer.Interval = speed;
            }          
        }

        private void GenerateFruits() // creates a couple of fruits
        {
            Random random = new Random();
            int count;

            if (fruitList.Count >= 2) count = random.Next(0, 3);
            else count = random.Next(1, 3);

            for (int i = 0; i < count; i++)
            {
                if (fruitList.Count < maxFruitsNumber) GenerateFruit();
            }
        }
        private void GenerateFruit() // creates one random fruit
        {
            bool flag = true;

            Random random = new Random();

            int vivifyingPower = random.Next(1, 4);

            Fruit fruit = new Fruit(vivifyingPower);

            int fruitX = 0, fruitY = 0;

            while (flag)
            {
                fruitX = cubeSide * random.Next(0, (width - 270) / cubeSide - 1);
                fruitY = cubeSide * random.Next(0, height / cubeSide - 1);
                flag = IsThereIntersections(fruitX, fruitY, true);
            }
            fruit.fruit.Location = new Point(fruitX, fruitY);

            Bitmap textImg;
            textImg = new Bitmap(@"C:\Users\langr\Downloads\Apple1.bmp", true);
            
            fruit.fruit.Image = textImg;
            
            Graphics g = Graphics.FromImage(fruit.fruit.Image);
            g.DrawString(vivifyingPower + "", new Font("Arial", 250), Brushes.Black, 10, 5);

            this.Controls.Add(fruit.fruit); 
            
            fruitList.Add(fruit);           
        }

        private void KeyPressedHandler(Object sender, KeyEventArgs args) // define a direction of snake's movement
        {
            switch (args.KeyCode.ToString()) // snake cannot move in the opposite direction it did before
            {
                case "Right":
                    if (directionX != -1 && directionY != 0)
                    {
                        directionX = 1;
                        directionY = 0;
                    }
                    break;
                case "Left":
                    if (directionX != 1 && directionY != 0)
                    {
                        directionX = -1;
                        directionY = 0;
                    }
                    break;
                case "Up":
                    if (directionX != 0 && directionY != 1)
                    {
                        directionY = -1;
                        directionX = 0;
                    }
                    break;
                case "Down":
                    if (directionX != 0 && directionY != -1)
                    {
                        directionY = 1;
                        directionX = 0;
                    }
                    break;
                case "Spacebar": // stoneForm or smth else
                    // ???
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e) // what for?
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private class Cell // ??? what for ???
        {
            public PictureBox cellBox;

            public Cell() 
            { 
                cellBox = new PictureBox();
                cellBox.Size = new Size(cubeSide, cubeSide);               
            }

            public Cell(Control.ControlCollection form, Point point, Bitmap bmp) : this()
            { 
                cellBox.Location = point;
                cellBox.Image = bmp;

                form.Add(cellBox);
            }
        }

        private class SnakeCell : Cell
        {
            public PictureBox snakeCell;

            public bool isDestroyable;

            public bool isTemporal;

            public int addedAtStep;
        }

        private class Bomb : Cell
        {
            public Bomb() : base()
            {
                currentBombWaves = new List<List<PictureBox>>();
            }

            public Bomb(int ROE, int TOE, TypeOfExplosion typeOfExplosion, Point point) 
            {
                // handle this point!!!                
                cellBox = new PictureBox();
                cellBox.Size = new Size(cubeSide, cubeSide);

                currentBombWaves = new List<List<PictureBox>>();

                this.ROE = ROE;
                this.TOE = TOE;

                currentROE = 0; // initial currentROE value equals 0, bombs starts exploding beginning from the epicenter
                flag = false; // initially the bomb is in the "time is ticking" phase

                this.typeOfExplosion = typeOfExplosion;
                cellBox.Location = point;

                Bitmap textImg;

                if (typeOfExplosion.Equals(TypeOfExplosion.Tsar)) textImg = new Bitmap(@"C:\Users\langr\Downloads\NuclearBomb.bmp", true);
                else textImg = new Bitmap(@"C:\Users\langr\Downloads\Bomb.bmp", true);

                cellBox.Image = textImg;
            }

            public TypeOfExplosion typeOfExplosion;       

            public int ROE, TOE; // Radius and Time of Explosion respectively

            public int currentROE; // only for convenience itself

            public bool flag; // if true -> bomb is in an exploding state / if not -> the time is ticking

            public List<List<PictureBox>> currentBombWaves; // lists of waves to be deleted (disposed)
        }

        private class ExplosiveCell : Cell
        {
            public PictureBox cell;

            public bool isNuclear;

            public int lifeTime;

            // public TypeOfExplosion typeOfExpl;
        }

        private class Fruit : Cell 
        {
            public Fruit()           
            {
                this.fruit = new PictureBox();               
                this.fruit.Size = new Size(cubeSide, cubeSide);
            }

            public Fruit(int vivifyingPower) : this()
            {                
                this.vivifyingPower = vivifyingPower;
            }

            public PictureBox fruit;

            public int vivifyingPower;
        }

        private enum TypeOfExplosion { Vertical, Horizontal, Cross, Square, Tsar } // enum class for all bombs types

        //Plan:
        //1. Аномалии с дебаффами внутри и на выходе на некоторое время (плохая видимость,
        // инверсия лева права относительно движения вперед, повышение скорости (возможно рывками))
        //2. Бомбы с радиусом взрыва и в количестве в зависимости от сложности
        //3. Иконки головы, хвоста, бобм и яблок (с цифрами)
        //4. Спаун яблок в локальной окрестности головы змеи
        //5. Яблоко не сожет заспавнится в бомбе, и змее и в яблоке (+-)
        //6. Улучшить лейблы (инфо)
        //7. Таблица лидеров с записью в файл
        //8. Exe файл и готовое приложение с установкой
        //9. Очистка поля от аномалий и бомб и замедление скорости и планомерный рост мин скорости
        //10. Градиентная заливка змеи (На плюсах это сделать легко! default case in the every switch)
        //11. Бомбы стены и матрица памяти (чтоб не залазили друг на друга)
        //12. Баффы типо замедления, очистки от бомб, бессмертия, доп жизнь, броня и тп. (системы жизней???)
        //13. След взрыва (черный дым) -> все же на плюсах так легко...(
        //14. Взрывы ограничены стенками
        //15. Подумать над количеством пикчерБоксов и над четкостью анимации взрыва
        //16. Через стены бомб не проходят взрывы
        //17. Волновой алгоритм Ли для обхода препятствий
        //18. Когда голова змеи попадает в бомбу нужно заканчивать игру
        //19. Пауза
        //20. Система звуков
        //21. Стартовое меню
        //22. Грамотное отображение информации касательно игровых состояний на лейблах
        //23. Система окончания игры и запись очков в лидерборд
        //24. Статистика игровых достижений за уровень, система ачивок
        //25. Система сложности
        //26. Кампания (квесты и тп)...

        //27. Каменная форма (способность) -> спасение от любых бомб
        //28. Разворот головы змеи

        // Что если змея наехала на бомбу (не царскую)?

        //Баги:
        //++ 1. При первом съедении всегда добавляется 1 клетка к змее
        //++ 2. Длинна змеи определяется неверно
        //   Очки набираются криво, как будто длинна всегда растет с каждым яблоком, даже если она сбрасывается на ноль
        // Слишком частое появление Царь-Бомб, сбои в воспроизведении музыки
        // Остальные бомбы не должны спауниться в окрестности своего радиуса (плюс дельта) от Царь-Бомбы
        // Бомба не наносит урона в эпицентре
    }
}