using Nito.Collections;
using System.Numerics;

public class AddTask357 //Необходимо реализовать алгоритм, вычисляющий n-ый член упорядоченного числового ряда,
                        //при факторизации элементов которого могут быть получены только следующие делители: 3, 5 и 7.
{
    static void Main(string[] args)
    {       
        // FindKthMemberOfSeq(912); // method call -> prints all the values that are less than or equals to K-th element
                                 
        List<int> factorsList = new List<int>() { 2, 3, 101 };

        FindKthMemberOfSeq(factorsList, 10000, true);

        Console.WriteLine("\n1000000-th member of a row: " + FindKthMemberOfSeq(factorsList, 10000000, false)); // fast without printing
    }

    public static long FindKthMemberOfSeq(int k) // an easy-peasy version
    {
        if (k <= 0) return -1; // wrong cases

        Deque<long> q3 = new Deque<long>(); // initialization of queues
        Deque<long> q5 = new Deque<long>();
        Deque<long> q7 = new Deque<long>();

        int counter = 1; // counts the iteration

        q3.AddToFront(1); // initial element in the first queue

        long minCurrVal = 0;

        for (int i = 0; i < k; i++) // cycling all over the iterations (< k)
        {
            long currVal3 = q3.Count > 0 ? q3.First() : long.MaxValue; // here we tak the first elements of queues
            long currVal5 = q5.Count > 0 ? q5.First() : long.MaxValue;
            long currVal7 = q7.Count > 0 ? q7.First() : long.MaxValue;

            minCurrVal = Math.Min(currVal3, Math.Min(currVal5, currVal7)); // we find the min element of the three values above

            Console.WriteLine($"{minCurrVal} -> {counter++}-th member of a row");

            if (minCurrVal == currVal3) // we define which queues keeps the currElement
            {
                if (q3.Count > 0) q3.RemoveFromFront(); // at first we removing the current min element
                q3.AddToBack(3 * minCurrVal); // then qe add some new ones
                q5.AddToBack(5 * minCurrVal); // we add q3, q5, q7 if the currElem located in q3
            }
            else if (minCurrVal == currVal5)
            {
                if (q5.Count > 0) q5.RemoveFromFront();
                q5.AddToBack(5 * minCurrVal); // we add q5, q7 if the currElem located in q5
            }
            else 
            { 
                if (q7.Count > 0) q7.RemoveFromFront();
            }

            q7.AddToBack(7 * minCurrVal); // we always add the q7 element, and  we add only q7 if the currElem located in q7
        }

        return minCurrVal; // returning the value found
    }

    public static BigInteger FindKthMemberOfSeq(List<int> primeDevisors, int k, bool printFlag) // a serious one
    { 
        if (primeDevisors.Count == 0) return -1; // wrong case        

        Dictionary<long, Deque<BigInteger>> dequesDictionary = new Dictionary<long, Deque<BigInteger>>(); // dict initialization

        int counter = 1; // counts the iteration

        BigInteger[] currVals = new BigInteger[primeDevisors.Count]; // current values -> the first elements of queques

        foreach (int prime in primeDevisors) // initialization of queues
        { 
            dequesDictionary.Add(prime, new Deque<BigInteger>());
        }
   
        dequesDictionary[primeDevisors[0]].AddToFront(1); // initial element in the first queue

        BigInteger minCurrVal = 0; // the min element among the currVals

        for (int i = 0; i < k; i++) // cycling all over the iterations (< k)
        {
            minCurrVal = long.MaxValue;

            for (int j = 0; j < primeDevisors.Count; j++) // here we take the first elements of all the queues
            { 
                // currVals getting
                currVals[j] = dequesDictionary[primeDevisors[j]].Count > 0 ? dequesDictionary[primeDevisors[j]].First() : long.MaxValue;

                // calculating the minCurrVal
                minCurrVal = j == 0 ? currVals[j] : BigInteger.Min(minCurrVal, currVals[j]); // we find the min element of the values above
            }
          
            if (printFlag) Console.WriteLine($"{minCurrVal} -> {counter++}-th member of a row"); // just printing

            for (int j = 0; j < primeDevisors.Count; j++) // cycling all over the devisors given
            {
                if (minCurrVal == currVals[j]) // here we check wich queue the minCurrVal located in
                {                   
                    if (dequesDictionary[primeDevisors[j]].Count > 0) dequesDictionary[primeDevisors[j]].RemoveFromFront(); // we remove the min current element from
                                                                                                                            // the front of the respective queue

                    for (int r = j; r < primeDevisors.Count - 1; r++) // here for all elements remained (that are larger than the curr one) we are adding
                                                                      // the new values to the respective queues
                    {                       
                        dequesDictionary[primeDevisors[r]].AddToBack(primeDevisors[r] * minCurrVal);
                    }                   
                }
            }

            // we always add the element correponding to the last devisor to the last queque no matter whether it located in the last queue or not           
            dequesDictionary[primeDevisors[primeDevisors.Count - 1]].AddToBack(primeDevisors[primeDevisors.Count - 1] * minCurrVal);   
        }

        return minCurrVal; // returning the value found
    }
}