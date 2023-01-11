using HammingCodeLib.Shared;

namespace test;
public class BitZeroCheckTest
{
    [Fact]
    public void TestCorrectData()
    {
        // Arrenge
        int[,] bits = new[,]
        {
            {0 , 1 , 1 , 1}, 
            {1 , 1 , 1 , 0},
            {0 , 0 , 1 , 0},
            {0 , 1 , 0 , 0}
        };
        bool expected = true;

        // Act
        bool actual = HammingCode.BitZeroCheck(bits);
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestUncorrectData()
    {
        // Arrenge
        int[,] bits = new[,]
        {
            {0 , 0 , 0 , 0}, 
            {0 , 0 , 0 , 0},
            {0 , 0 , 0 , 0},
            {0 , 0 , 0 , 1}
        };
        bool expected = false;

        // Act
        bool actual = HammingCode.BitZeroCheck(bits);
        
        // Assert
        Assert.Equal(expected, actual);
    }
}