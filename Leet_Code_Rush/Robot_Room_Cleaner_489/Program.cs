using System.Threading;
public class RobotRoomCleaner489 
{
    public static readonly int[,] dirs = new int[,] { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } }; // directions dictionary -> up, right, down and left
    public static HashSet<KeyValuePair<int, int>> visitedCells = new HashSet<KeyValuePair<int, int>>();
    static Cleaner robot;

    public static void Main(string[] args)
    {
       int[,] grid = new int[,] { 
            { 1, 1, 1, 1, 1, 0, 1, 1 },
            { 1, 1, 1, 1, 1, 0, 1, 1 },
            { 1, 0, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 1, 1 } 
        };

        Cleaner cleaner = new Cleaner(1, 3, grid);

        CleanRoom(cleaner);
    }

    public static void CleanRoom(Cleaner robot)
    {
        RobotRoomCleaner489.robot = robot;

        Backtracking(0, 0, 0); // we consider the starting coordinates of the cleaner-robot to be equal to (0, 0), and
                               // let the robot at first choose the "right" direction
        Console.WriteLine("\nThe room is clear! \nThe cleaner is off...");
    }

    public static void Backtracking(int j, int i, int dir) // coordinates of the cleaner-robot and its direction
    { 
        visitedCells.Add(new KeyValuePair<int, int>(j, i)); // here we add the new cell to the visitedCells set
        robot.clean();

        // foreach (KeyValuePair<int, int> pair in visitedCells) Console.WriteLine("pair: " + pair.Key + " " + pair.Value);

        for (int k = 0; k < 4; k++) // cycling all over the four directions
        {
            int curr_dir = (dir + k) % 4; // new direction
            int curr_j = j + dirs[curr_dir, 0]; // new coordinates after one step in the direction chosen
            int curr_i = i + dirs[curr_dir, 1];
            
            if (!visitedCells.Contains(new KeyValuePair<int, int>(curr_j, curr_i)) && robot.move())
            { 
                Backtracking(curr_j, curr_i, curr_dir); // new Bactracking recursive call
                StepBack(); // the cleaner is returning back if he moved rorward               
            }
            
            robot.turnRight(); // changes the direction (we check all 4 dirs)
        }      
    }

    public static void StepBack() 
    {
        robot.turnRight();
        robot.turnRight();

        robot.move();

        robot.turnRight();
        robot.turnRight();        
    }

    public interface Robot // just for understanding, how the cleaner works
    {
    // Returns true if the cell in front is open and robot moves into the cell.
    // Returns false if the cell in front is blocked and robot stays in the current cell.
    public bool move();
 
    // Robot will stay in the same cell after calling turnLeft/turnRight.
    // Each turn will be 90 degrees.
    public void turnLeft();
    public void turnRight();
 
    // Clean the current cell.
    public void clean();
    }

    public class Cleaner : Robot // cleaner realization
    {
        int j_coord;
        int i_coord;

        int dir;

        int[,] grid;

        public Cleaner() // base constructor
        {
            dir = 0;
        }

        public Cleaner(int j, int i, int[,] grid)
            : this() // default construction invocation
        {
            j_coord = j;
            i_coord = i;

            this.grid = grid;
            Console.WriteLine("The cleaner is on, preparating...");
            Console.Write("Starting from the cell: (" + j_coord + ", " + i_coord + ")");
        }

        public bool move()
        {
            int new_j = j_coord + dirs[dir, 0];
            int new_i = i_coord + dirs[dir, 1];

            if (new_j >= 0 && new_i >= 0 && new_j < grid.GetLength(0) && new_i < grid.GetLength(1) && grid[new_j, new_i] == 1)
            {
                j_coord = new_j;
                i_coord = new_i;

                Console.Write("\nEntering the cell: (" + j_coord + "," + i_coord + ")");

                return true;
            }
            else return false;
        }

        public void clean() {Thread.Sleep(100); Console.Write(", the cell has been cleaned");}

        public void turnRight() => dir = (dir + 1) % 4;
        public void turnLeft() => dir = (dir + 3) % 4;
    }

}

