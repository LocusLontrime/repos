using System;
using System.Diagnostics;
public class Task74 {

    static string[] array = new string[] { "a", "b", "c", "d" };

    static void Main(string[] args)
    {
        List<string> list = new List<string>();

        Stopwatch stopWatch = new Stopwatch(); // time checking
        stopWatch.Start();

        recursiveSeeker(6, list, true); // if (flag == false) then we won't print the elements, if not -> we will be printing all the elements found

        stopWatch.Stop();
        // Get the elapsed time as a TimeSpan value.
        TimeSpan ts = stopWatch.Elapsed;

        Console.WriteLine(ts.TotalSeconds);
    }

    public static void recursiveSeeker (int n, List<string> list, bool flag) 
    {

        if (n == 0) // border case
        {
            if (flag) { 
                foreach (string item in list) // printing
                { 
                    Console.WriteLine(item); 
                } 
                return; // here the recursion stops
            }
        }

        List<string> newList = new List<string>(); // new List for 4*x of new elements storage, where x - length of the old list (at the n - 1 rec step)

        if (list.Count == 0) // starting case
        {
            newList.Add("a");
            newList.Add("b");
            newList.Add("c");
            newList.Add("d");
        }
        else
        {
            for (int i = 0; i < list.Count; i++) 
            {
                for (int j = 0; j < 4; j++)
                {
                    newList.Add(array[j] + list[i]); // creating a new list, 4 new elements for every old one                
                }
            }
        }

        recursiveSeeker(n - 1, newList, flag); // next recursive call
    }
}
