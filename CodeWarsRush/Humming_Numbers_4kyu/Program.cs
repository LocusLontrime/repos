public class HammingNumbers
{
    static void Main(string[] args) // accepted on codewars.com
    {
        Console.WriteLine(Hamming(5000));
    }

    public static long Hamming(int k)
    {
        // TODO: Program me
        if (k <= 0) return -1; // wrong cases

        Queue<long> q2 = new Queue<long>(); // initialization of queues
        Queue<long> q3 = new Queue<long>();
        Queue<long> q5 = new Queue<long>();

        int counter = 1; // counts the iteration

        q2.Enqueue(1); // initial element in the first queue

        long minCurrVal = 0;

        for (int i = 0; i < k; i++) // cycling all over the iterations (< k)
        {
            long currVal2 = q2.Count > 0 ? q2.First() : long.MaxValue; // here we take the first elements of queues
            long currVal3 = q3.Count > 0 ? q3.First() : long.MaxValue;
            long currVal5 = q5.Count > 0 ? q5.First() : long.MaxValue;

            minCurrVal = Math.Min(currVal2, Math.Min(currVal3, currVal5)); // we find the min element of the three values above

            Console.WriteLine($"{minCurrVal} -> {counter++}-th member of a row");

            if (minCurrVal == currVal2) // we define which queues keeps the currElement
            {
                if (q2.Count > 0) q2.Dequeue(); // at first we removing the current min element
                q2.Enqueue(2 * minCurrVal); // then qe add some new ones
                q3.Enqueue(3 * minCurrVal); // we add q2, q3, q5 if the currElem located in q3
            }
            else if (minCurrVal == currVal3)
            {
                if (q3.Count > 0) q3.Dequeue();
                q3.Enqueue(3 * minCurrVal); // we add q3, q5 if the currElem located in q5
            }
            else
            {
                if (q5.Count > 0) q5.Dequeue();
            }

            q5.Enqueue(5 * minCurrVal); // we always add the q7 element, and  we add only q7 if the currElem located in q7
        }

        return minCurrVal; // returning the value found
    }
}