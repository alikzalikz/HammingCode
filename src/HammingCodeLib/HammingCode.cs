using static System.Math;

namespace HammingCodeLib.Shared;
public class HammingCode
{
    public static bool IsPowerOfTwo(int n) 
    { 
        if(n==0)
        {
            return false; 
        }
    
        return (int)(Ceiling((Log(n) / Log(2)))) == (int)(Floor(((Log(n) / Log(2))))); 
    }

    public static Dictionary<int, int> DicCreator(int[,] bits , int lengh)
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

    public static void ShowData(int[,] bits)
    {
        Dictionary<int, int> bitsDic = DicCreator(bits, bits.Length);

        foreach (KeyValuePair<int, int> bit in bitsDic)
        {
            if (bit.Key == 0 || IsPowerOfTwo(bit.Key))
            {
                
            }
            else
            {
                Write(bit.Value + " ");
            }
        }
    }
    
    public static void ShowBits(int[,] bits)
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

    public static bool CheckData(int[,] bits)
    {
        Dictionary<int, int> bitsDic = DicCreator(bits, bits.Length);

        int countsTrue = 0;

        foreach (KeyValuePair<int, int> bit in bitsDic)
        {
            int key = bit.Key;
            int value = bit.Value;
            if (IsPowerOfTwo(key))
            {
                if (CheckTrue(bitsDic, key, value))
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

    public static bool CheckTrue(Dictionary<int,int> bitsDic, int potKey, int value)
    {
        int bitsOne = 0;
                
        for (int i = potKey; i < bitsDic.Count; i += potKey + potKey)
        {
            for (int j = i; j <= i + (potKey - 1); j++)
            {
                if (bitsDic[j] == 1)
                {
                    bitsOne++;
                }
            }
        }

        if ((bitsOne - value) % 2 == value)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
