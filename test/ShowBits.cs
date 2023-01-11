using HammingCodeLib.Shared;

namespace test;
public class ShowBitsTest
{
    [Fact]
    public void Data1()
    {
        // Arrenge
        int[,] bits = new[,]
        {
            {0 , 1 , 1 , 1}, 
            {1 , 1 , 1 , 0},
            {0 , 0 , 1 , 0},
            {0 , 1 , 0 , 0}
        };
        string expected = "0 1 1 1 1 1 1 0 0 0 1 0 0 1 0 0 ";

        // Act
        string actual = HammingCode.ShowBits(bits);
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Data2()
    {
        // Arrenge
        int[,] bits = new[,]
        {
            {0 , 1 , 1 , 1}, 
            {0 , 0 , 1 , 0},
            {1 , 1 , 1 , 0},
            {0 , 1 , 0 , 0}
        };
        string expected = "0 1 1 1 0 0 1 0 1 1 1 0 0 1 0 0 ";

        // Act
        string actual = HammingCode.ShowBits(bits);
        
        // Assert
        Assert.Equal(expected, actual);
    }
}