public class AddTask3 // Дан массив, состоящий из случайных целых чисел. Дано число M.
                      // Выведите случайное подмножество массива, сумма элементов в котором не превосходит M   
{

    public static List<List<int>> setsList = new List<List<int>>();

    static void Main(string[] args)
    {
        List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16};        

        List<int> randomSubset = AllSubsetsPlusGetRandomOne(list);

        Console.WriteLine("All subsets of the initial Set:");

        foreach (var item in setsList) // printing the results
        {
            foreach (var element in item)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nThe list length = " + setsList.Count);

        Console.Write("\nA random subSet: ");

        foreach (var item in randomSubset)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine("\n");
    }

    public static List<int> GetRandomSubset() 
    { 
        Random rand = new Random();

        int index = rand.Next(0, setsList.Count);

        return setsList[index];
    }

    public static List<int> AllSubsetsPlusGetRandomOne(List<int> set) // the main method
    {
        setsList.Add(new List<int>()); // the empty set

        for (int i = 1; i <= set.Count; i++) // cycling all over the combinations
        {
            CNK(0, new List<int>(), i, set); // combinations method call
        }

        return GetRandomSubset();
    }

    public static void CNK(int startingElement, List<int> currSet, int k, List<int> set) // all the combinations
    {
        if (currSet.Count == k) setsList.Add(new List<int>(currSet)); // if the length of a List is equal to k then we add it to result List of Lists

        for (int i = startingElement; i < set.Count; ++i) // cycling all over the combinations, we're building them in such way that the repeated ones
                                                   // are throwed away automatically 4ex: 123 and 231, there allowed only one permutation where the digits are being increased sequentially
        {
            currSet.Add(set[i]); // adding a new element to it
            CNK(i + 1, currSet, k, set); // making a recursive call with a newCurrentSet and starting with the incremented by 1 first element
            currSet.RemoveAt(currSet.Count - 1); // bactracking
        }
    }
}