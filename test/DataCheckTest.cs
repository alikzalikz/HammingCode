using HammingCodeLib.Shared;
namespace test;

public class DataCheckTest
{
    [Fact]
    public void TestCorrect16Bits()
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
        bool actual = HammingCode.DataCheck(bits);
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestUncorrect16Bits()
    {
        // Arrenge
        int[,] bits = new[,]
        {
            {1 , 1 , 0 , 1}, 
            {1 , 1 , 1 , 0},
            {0 , 0 , 1 , 0},
            {0 , 1 , 0 , 0}
        };
        bool expected = false;

        // Act
        bool actual = HammingCode.DataCheck(bits);
        
        // Assert
        Assert.Equal(expected, actual);
    }
}