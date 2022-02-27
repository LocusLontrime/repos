public class Task75 {

    public static void Main(string[] args)
    {

        int[] data = new int[] { 1, 1, 1, 1, 1, 0, 0, 1}; //{ 0, 1, 1, 1, 1, 0, 0, 0, 1 };
        int[] info = new int[] { 5, 2, 1}; //{ 2, 3, 3, 1 };

        int[] array = translation(data, info);

        foreach(int i in array)
        {
            Console.Write(i +  " ");
        }
    }

    public static int[] translation(int[] data, int[] info) { // easy two pointers

        int[] result = new int[info.Length];

        int dataPointer = 0;

        for (int i = 0; i < info.Length; i ++) { 
        
            int currentLength = info[i];

            for (int j = 0; j < currentLength; j++) {

                result[i] += data[dataPointer + j] * (int) Math.Pow(2, currentLength - j - 1);

            }

            dataPointer += currentLength;

        }

        return result;

    }


}
