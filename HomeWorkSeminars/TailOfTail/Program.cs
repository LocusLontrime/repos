public class TailOfTail 
{

    static void Main(string[] args)
    {
        List <int> list = new List<int>();

        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);
        list.Add(6);

        List<int> result = GetListOfTails(list);
       
        PrintArray(result);
    }

    public static List<int> GetListOfTails(List<int> list) 
    {
        int length = list.Count;

        int tailMultiplication;

        List<int> result = new List<int>();

        for (int i = 0; i < length; i++)
        {
            tailMultiplication = 1;

            for (int j = i; j < length; j++)
            {
                tailMultiplication *= list[j];
            }

            result.Add(tailMultiplication);
        }

        return result;
    }

    public static void PrintArray(List<int> result) 
    {
        foreach (var item in result)
        {
            Console.Write(item + " ");
        }
    }
}
