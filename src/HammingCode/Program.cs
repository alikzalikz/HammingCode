using HammingCodeLib.Shared;

// 16-bit:
// 0 1 1 1 1 1 1 0 0 0 1 0 0 1 0 0

// data:
// 1 1 1 0 0 1 0 0 1 0 0

// binary
/*
    0 1 1 1 
    1 1 1 0 
    0 0 1 0 
    0 1 0 0 
*/

int[,] bits = new[,]
{
    {0 , 1 , 1 , 1}, 
    {1 , 1 , 1 , 0},
    {0 , 0 , 1 , 0},
    {0 , 1 , 0 , 0}
};

HammingCode.CheckData(bits);