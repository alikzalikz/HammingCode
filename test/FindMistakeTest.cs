using HammingCodeLib.Shared;

namespace test;
public class FindMistakeTest
{
    [Fact]
    public void Data1()
    {
        // Arrenge
        int[,] bits = new[,]
        {
            {1 , 1 , 0 , 1}, 
            {1 , 1 , 1 , 0},
            {0 , 0 , 1 , 0},
            {0 , 1 , 0 , 0}
        };
        List<int> expected = new(){2};

        // Act
        List<int> actual = HammingCode.FindMistake(bits);
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Data2()
    {
        // Arrenge
        int[,] bits = new[,]
        {
            {1 , 0 , 1 , 1}, 
            {1 , 1 , 1 , 0},
            {0 , 0 , 1 , 0},
            {0 , 1 , 0 , 0}
        };
        List<int> expected = new(){1};

        // Act
        List<int> actual = HammingCode.FindMistake(bits);
        
        // Assert
        Assert.Equal(expected, actual);
    }
}