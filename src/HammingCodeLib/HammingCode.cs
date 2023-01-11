using static System.Math;

namespace HammingCodeLib.Shared;
public class HammingCode
{
    static public bool isPowerOfTwo(int n) 
    { 
        if(n==0)
        {
            return false; 
        }
    
        return (int)(Ceiling((Log(n) / Log(2)))) == (int)(Floor(((Log(n) / Log(2))))); 
    }

    static public Dictionary<int, int> DicCreator(int[,] bits , int lengh)
    {
        var dic = new Dictionary<int, int>(lengh);

        int count = 0;
        foreach (int i in bits)
        {
            dic.Add(count, i);
            count++;
        }
        return dic;
    }

    static public void ShowData(int[,] bits)
    {
        Dictionary<int, int> bitsDic = DicCreator(bits, bits.Length);

        foreach (KeyValuePair<int, int> bit in bitsDic)
        {
            if (bit.Key == 0 || isPowerOfTwo(bit.Key))
            {
                
            }
            else
            {
                Write(bit.Value + " ");
            }
        }
    }
    
    static public void ShowBits(int[,] bits)
    {
        for (int i = 0; i <= bits.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= bits.GetUpperBound(1); j++)
            {
                Write(bits[i, j] + " ");
            }
            WriteLine();
        }
    }
    
    static public bool CheckData(int[,] bits)
    {
        Dictionary<int, int> bitsDic = DicCreator(bits, bits.Length);

        int countsTrue = 0;

        foreach (KeyValuePair<int, int> bit in bitsDic)
        {
            int countsOne = 0;
            int key = bit.Key;
            int value = bit.Value;
            if (isPowerOfTwo(key))
            {
                for (int i = key; i < bitsDic.Count; i += key + key)
                {
                    for (int j = i; j <= i + (key - 1); j++)
                    {
                        if (bitsDic[j] == 1)
                        {
                            countsOne++;
                        }
                    }
                }
                if ((countsOne - value) % 2 == value)
                {
                    countsTrue++;
                }
            }
        }

        if(countsTrue == bits.GetUpperBound(0) + 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
