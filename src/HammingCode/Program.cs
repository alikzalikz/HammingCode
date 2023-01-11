using HammingCodeLib.Shared;

int[,] bits1 = new[,]
{
    {0 , 1 , 1 , 1}, 
    {1 , 1 , 0 , 0},
    {0 , 0 , 1 , 0},
    {0 , 1 , 0 , 0}
};

HammingCode.DisplayHC(bits1);