using System.Reflection.Metadata.Ecma335;
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

    public static string ShowData(int[,] bits)
    {
        Dictionary<int, int> bitsDic = DicCreator(bits, bits.Length);
        string str = "";
        foreach (KeyValuePair<int, int> bit in bitsDic)
        {
            if (bit.Key == 0 || IsPowerOfTwo(bit.Key))
            { }
            else
            {
                str += $"{bit.Value} ";
            }
        }
        return str;
    }
    
    public static string ShowBits(int[,] bits)
    {
        string str = "";
        for (int i = 0; i <= bits.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= bits.GetUpperBound(1); j++)
            {
                str += $"{bits[i, j]} ";
            }
            if (i != bits.GetUpperBound(0))
            {
                str += "\n";
            }
        }
        return str;
    }

    public static bool PotKeyCheck(Dictionary<int,int> bitsDic, int potKey, int value)
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

    public static bool BitZeroCheck(int[,] bits)
    {
        int bitsOne = 0;
        foreach (int i in bits)
        {
            if (i == 1)
            {
                bitsOne++;
            }
        }
        if (bitsOne % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool DataCheck(int[,] bits)
    {
        var bitsDic = DicCreator(bits, bits.Length);

        int countsTrue = 0;
        foreach (KeyValuePair<int, int> bit in bitsDic)
        {
            int key = bit.Key;
            int value = bit.Value;
            if (key == 0)
            {
                if (BitZeroCheck(bits))
                {
                    countsTrue++;
                }
            }
            if (IsPowerOfTwo(key))
            {
                if (PotKeyCheck(bitsDic, key, value))
                {
                    countsTrue++;
                }
            }
        }

        if(countsTrue - 2 == bits.GetUpperBound(0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static List<int> RemovePotkey(Dictionary<int,int> bitsDic, List<int> mistakes, int potKey)
    {
        for (int i = potKey; i < bitsDic.Count; i += potKey + potKey)
        {
            for (int j = i; j <= i + (potKey - 1); j++)
            {
                mistakes.Remove(j);
            }
        }
        return mistakes;
    }

    public static List<int> RemoveOther(Dictionary<int,int> bitsDic, List<int> mistakes, int potKey)
    {
        List<int> mistakesList = new();
        for (int i = potKey; i < bitsDic.Count; i += potKey + potKey)
        {
            for (int j = i; j <= i + (potKey - 1); j++)
            {
                if (mistakes.Contains(j))
                {
                    mistakesList.Add(j);
                }
            }
        }
        return mistakesList;
    }

    public static List<int> FindMistake(int[,] bits)
    {
        List<int> mistakes = new();
        int count = 0;
        foreach (int i in bits)
        {
            mistakes.Add(count);
            count++;
        }

        var bitsDic = DicCreator(bits, bits.Length);
        
        foreach (KeyValuePair<int, int> bit in bitsDic)
        {
            int key = bit.Key;
            int value = bit.Value;

            if (key == 0)
            {
                if (BitZeroCheck(bits))
                {
                    mistakes.Remove(key);
                }
            }
            if (IsPowerOfTwo(key))
            {
                if (PotKeyCheck(bitsDic, key, value))
                {
                    mistakes = RemovePotkey(bitsDic, mistakes, key);
                }
                else
                {
                    mistakes = RemoveOther(bitsDic, mistakes, key);
                }
            }
        }

        return mistakes;
    }

    public static void DataEdit(int[,] bits)
    {
        int mistakes = FindMistake(bits).Max();

        int x = mistakes / (bits.GetUpperBound(0) + 1);
        int y = mistakes % (bits.GetUpperBound(0) + 1);

        switch(bits[x,y])
        {
            case 0:
                bits[x,y] = 1;
                break;
            case 1:
                bits[x,y] = 0;
                break;
        }


        foreach (int i in bits)
        {
            Write($"{i} ");
        }
        WriteLine();

        ForegroundColor = ConsoleColor.Red;
        for (int i = 0; i <= bits.Length; i++)
        {
            if (i == mistakes)
            {
                Write("^ edited bit :)");
            }
            else
            {
                Write("  ");
            }
        }
        ResetColor();
        WriteLine();

        for (int i = 0; i <= bits.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= bits.GetUpperBound(1); j++)
            {
                if (i == x && j == y)
                {
                    ForegroundColor = ConsoleColor.Red;
                    Write($"{bits[i,j]} ");
                    ResetColor();
                }
                else
                {
                    Write($"{bits[i,j]} ");
                }
            }
            if (i != bits.GetUpperBound(0))
            {
                WriteLine();
            }
        }
    }

    public static void DisplayHC(int[,] bits)
    {
        WriteLine("Your Data:");
        WriteLine(HammingCode.ShowBits(bits));
        WriteLine("--------------------");

        if (HammingCode.DataCheck(bits))
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine("True Data :)");
            ResetColor();
        }
        else
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Data is not Correct!");
            ResetColor();
            
            HammingCode.DataEdit(bits);
        }
    }
}
