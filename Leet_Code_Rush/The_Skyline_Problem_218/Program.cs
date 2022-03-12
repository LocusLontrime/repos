using System.Linq;
using System.Collections.Generic;
public class TheSkylineProblem218 
{
    public static int[,] buildings;

    static void Main(string[] args)
    {
        List<List<int>> lists = GetSkyline(new int[,] { { 2, 9, 10 },{ 3, 7, 15 },{ 5, 12, 12 },{ 15, 20, 10 },{ 19, 24, 8 } });

        Console.WriteLine("City Skyline: \n");
        foreach (var item in lists) // printing the result
        {
            Console.Write("(" + item[0] + "," + item[1] + ")");
            Console.WriteLine();
        }
    }

    public static List<List<int>> GetSkyline(int[,] buildings)
    {
        TheSkylineProblem218.buildings = buildings; 
        return RecursiveSeeker(0, buildings.GetLength(0) - 1); // recursive call
    }

    public static List<List<int>> RecursiveSeeker(int leftPointer, int rightPointer) 
    {      
        // base cases:
        if (leftPointer == rightPointer) // when only one building remained we can add its silhouette as a minimal Skyline
        { 
            List<List<int>> list = new List<List<int>>();

            List<int> point1 = new List<int>();
            List<int> point2 = new List<int>();

            point1.Add(buildings[leftPointer, 0]); // top-left Skyline point
            point1.Add(buildings[leftPointer, 2]);

            point2.Add(buildings[leftPointer, 1]); // bottom-right Skyline point
            point2.Add(0);

            list.Add(point1); // addition to the final Skyline of a building
            list.Add(point2);

            return list; // returning the result
        }

        int pivotIndex = (leftPointer + rightPointer) / 2; // "divide" section: we define the pivot element as a median of
                                                           // starting and ending array indexes and then
                                                           // divide our array of buildings into two parts     

        return Merge(RecursiveSeeker(leftPointer, pivotIndex), RecursiveSeeker(pivotIndex + 1, rightPointer)); // "conquer" section: 
        // we are merging the parts of city Skyline step by step into the final one
    }
    public static List<List<int>> Merge(List<List<int>> skyLine1, List<List<int>> skyLine2) 
    {         
        List<List<int>> result = new List<List<int>>();              

        int leftMaxIndex = skyLine1.Count, rightMaxIndex = skyLine2.Count;           // now if threre remained some elements in skyLine1 or 

        int leftPointer = 0, rightPointer = 0;
        int currentX;
        int leftHeight = 0, rightHeight = 0, currSkylineHeight = 0;

        while (leftPointer < leftMaxIndex && rightPointer < rightMaxIndex)
        {

            if (skyLine1[leftPointer][0] < skyLine2[rightPointer][0]) // comparison of x coordinates, we want to pick the smallest one
            {
                currentX = skyLine1[leftPointer][0];
                leftHeight = skyLine1[leftPointer][1];
                leftPointer++; // stepping
            }
            else
            {
                currentX = skyLine2[rightPointer][0];
                rightHeight = skyLine2[rightPointer][1];
                rightPointer++; // stepping
            }

            int maxHeight = Math.Max(leftHeight, rightHeight); // choosing the max Height between left Skyline and right Skyline current ones

            if (currSkylineHeight != maxHeight) // adding a new Point to the Merged Skyline
            {
                // addition
                AddPoint(result, currentX, maxHeight);

                currSkylineHeight = maxHeight; // renewing the currSkylineHeight
            }          
        }

        // now if there are remained some elements in skyLine1 or skyLine2 lists -> we will add them to the resulting Skyline

        while (leftPointer < leftMaxIndex) // cycling all over the elements remained in skyline1
        { 
            currentX = skyLine1[leftPointer][0];
            leftHeight = skyLine1[leftPointer][1];
            leftPointer++; // stepping

            if (currSkylineHeight != leftHeight) // adding point
            {
                AddPoint(result, currentX, leftHeight); // if there is some Height change
                currSkylineHeight = leftHeight;
            }
        }

        while (rightPointer < rightMaxIndex) // cycling all over the elements remained in skyline2
        {
            currentX = skyLine2[rightPointer][0];
            rightHeight = skyLine2[rightPointer][1];
            rightPointer++; // stepping

            if (currSkylineHeight != rightHeight) // if there is some Height change
            {
                AddPoint(result, currentX, rightHeight); // adding point
                currSkylineHeight = rightHeight;
            }
        }

        return result;
    }

    public static void AddPoint(List<List<int>> result, int x, int height) // here we add a point to the result Skyline,
                                                                           // this code has multiple invocations during merge phase, therefore, 
                                                                           // it will be convenient for us to implement a method
    {
        if (result.Count == 0 || result[result.Count - 1][0] != x)
        {
            result.Add(new List<int>() { x, height }); // the height to be added is always the max one, so we cannot add a height
                                                       // that is less than the rightmost one in the resulting Skyline
        } else 
        {
            result[result.Count - 1][1] = height; // just renewing the height coz the new one is higher
        }

    }

}