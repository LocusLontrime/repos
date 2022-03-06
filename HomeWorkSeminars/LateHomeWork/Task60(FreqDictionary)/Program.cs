public class FreqDictionary {

    static void Main(string[] args)
    {
        Object[,] objMatrix = new object[,] { { 1, 2, 3 }, { 4, 6, 1 }, { 2, 1, 6 } };
        objMatrix = new object[,] { {" " , " ", "str", "st", "str"}, { "k", " ", " ", "k", "k" }, { " ", "k", "s", "s", "k" } };

        foreach (KeyValuePair<Object, int> pair in fillFreqDictionary(objMatrix)) // freq dictionary printing
        {        
            Console.WriteLine("Element <" + (pair.Key.Equals(" ") ? "spacebar" : pair.Key) + "> occurs <" + pair.Value + "> times with Frequency: "
                + String.Format("{0:0.##}", 1.0 * pair.Value / (objMatrix.GetLength(0) * objMatrix.GetLength(1))) + "%");
        }           
    }

    public static SortedDictionary<Object, int> fillFreqDictionary(Object[,] objMatrix)  // freq sorting
    {
        SortedDictionary<Object, int> dictionary = new SortedDictionary<Object, int>();
        int tempValue;

        for (int i = 0; i < objMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < objMatrix.GetLength(1); j++)
            {
                if (dictionary.ContainsKey(objMatrix[i, j]))
                {
                    tempValue = dictionary[objMatrix[i, j]];
                    dictionary.Remove(objMatrix[i, j]);
                    dictionary.Add(objMatrix[i, j], tempValue + 1);
                }
                else dictionary.Add(objMatrix[i, j], 1);
            }
        }
        return dictionary;    
    }
}
