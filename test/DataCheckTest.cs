using HammingCodeLib.Shared;
namespace test;

public class DataCheckTest
{
    [Fact]
    public void Correct1()
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
    public void Uncorrect1()
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

    [Fact]
    public void Correct2()
    {
        // Arrenge
        int[,] bits = new[,]
        {
            {0 , 1 , 1 , 1}, 
            {0 , 0 , 1 , 0},
            {1 , 1 , 1 , 0},
            {0 , 1 , 0 , 0}
        };
        bool expected = true;

        // Act
        bool actual = HammingCode.DataCheck(bits);
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Uncorrect2()
    {
        // Arrenge
        int[,] bits = new[,]
        {
            {1 , 1 , 1 , 1}, 
            {0 , 0 , 1 , 0},
            {1 , 1 , 1 , 0},
            {0 , 1 , 0 , 0}
        };
        bool expected = false;

        // Act
        bool actual = HammingCode.DataCheck(bits);
        
        // Assert
        Assert.Equal(expected, actual);
    }

}