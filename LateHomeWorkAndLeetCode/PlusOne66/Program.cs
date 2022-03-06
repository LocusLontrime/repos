public class PlusOne66 {

    static void Main(string[] args)
    {

        int[] arrayNumber = new int[] { 1, 7, 8, 9, 9, 3, 5, 6, 9, 8, 9, 9, 9, 9 };
        arrayNumber = new int[] { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9};

        foreach (int i in plusOne(arrayNumber)) 
        { 
            Console.Write(i + " ");
        }

    }

    public static int[] plusOne(int[] arrayNumber) 
    {

        int[] newArrayNumber = new int[arrayNumber.Length];

        bool memoryFlag = true;       

        for (int i = arrayNumber.Length - 1; i >= 0; i--) {
            if (memoryFlag && arrayNumber[i] == 9)
            {
                memoryFlag = true;
                newArrayNumber[i] = 0;
            }
            else if (memoryFlag)
            {
                newArrayNumber[i] = arrayNumber[i] + 1;
                memoryFlag = false;
            }
            else 
            {
                newArrayNumber[i] = arrayNumber[i];
            }            
        }





        if (newArrayNumber[0] == 0) 
        {
            newArrayNumber = new int[arrayNumber.Length + 1];
            newArrayNumber[0] = 1;
            return newArrayNumber;
        } else return newArrayNumber;
    }
}