using System.Diagnostics;
using System.Numerics;

public class AlphabeticAnagrams // accepted on codewars.com
{
    static void Main(string[] args)
    {
        Console.WriteLine(RecFact(2, 1));

        Console.WriteLine("Dictionary:\n");

        SortedDictionary<char, int> freqDict = GetFreqDict("HYUUTTRKSJFJGUTJDJCSSNMHYUUTTRKSJFJGUTJDJCSSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJED" +
            "JCISSMYUUTTRKSJFJGUTJEDJCISSNYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGU" +
            "TJEDJCISSMHYUUTTRKSJFJGUTJEDJCISSNMHUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJ" +
            "JGUTJEDJCISSNMHYUUTTRKSJJGUTJEDJCISSNMHUUTTRKSJFJGUTJEDJCSSNMYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTT" +
            "KSJFJGUTJEDJCISSHYUUTTRKSJFJGUTJEDJCISSNMHUUTTRKSJJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHY" +
            "UUTTKSJFJGUTJEDJCISSNMHYUUTTSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISS" +
            "NMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJ" +
            "ISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJUTJEDJCISSNMHYUUTTRSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUT" +
            "JDJISSNMHYUUTTRSJFJGUTJEDJISSN");

        foreach (var kvp in freqDict) 
        {
            Console.WriteLine($"letter: {kvp.Key}, freq: {kvp.Value}");
        }

        Console.WriteLine(PermutationsWithRepetitions(freqDict, 5, 'f'));

        Stopwatch sw = new Stopwatch();

        sw.Start();

        Console.WriteLine(ListPosition("MHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJED" +
            "JCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGU" +
            "TJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJ" +
            "FJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTT" +
            "RKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHY" +
            "UUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISS" +
            "NMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJ" +
            "CISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSNMHYUUTTRKSJFJGUT" +
            "JEDJCISSNMHYUUTTRKSJFJGUTJEDJCISSN"));

        sw.Stop();

        Console.WriteLine("Time elapsed: " + sw.ElapsedMilliseconds + "ms");
    }

    public static BigInteger ListPosition(string value)
    {
        SortedDictionary<char, int> freqDict = GetFreqDict(value);

        BigInteger positionNumber = 0;

        for (int i = value.Length; i >= 1; i--)
        {
            positionNumber += PermutationsWithRepetitions(freqDict, i, value[value.Length - i]);

            if (freqDict[value[value.Length - i]] > 1)
            {
                freqDict[value[value.Length - i]]--;
            }
            else 
            {
                freqDict.Remove(value[value.Length - i]);
            }
        }

        return positionNumber + 1;
    }

    public static BigInteger PermutationsWithRepetitions(SortedDictionary<char, int> freqDict, int k, char c) 
    {
        BigInteger result = RecFact(k - 1, 1) * GetElementsQuantityBefore(freqDict, c);

        foreach (var kvp in freqDict)
        { 
            result /= RecFact(kvp.Value, 1);
        }

        return result;
    }

    public static SortedDictionary<char, int> GetFreqDict(string s)
    {
        SortedDictionary<char, int> freqDict = new SortedDictionary<char, int>();

        foreach (var item in s) 
        {
            if (freqDict.ContainsKey(item))
            {
                freqDict[item]++;
            }
            else 
            { 
                freqDict.Add(item, 1);
            }
        }

        return freqDict;
    }

    public static int GetElementsQuantityBefore(SortedDictionary<char, int> freqDict, char c) 
    {
        int counter = 0;

        foreach(var kvp in freqDict) 
        {
            if (kvp.Key == c) return counter;
            else counter += kvp.Value;
        }

        return counter;
    }

    public static BigInteger RecFact(int n, BigInteger res) => n == 0 ? res : RecFact(n - 1, res * n);
}