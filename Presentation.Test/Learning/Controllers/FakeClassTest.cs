using Presentation.Learning.Controllers;

namespace Presentation.Test.Learning.Controllers;

public class FakeClassTest
{
    //[Fact]
    [Theory]
    [InlineData(2, 6, 8)]
    [InlineData(2, 0, 2)]
    [InlineData(5, 1, 6)]
    public void Add(int numberA, int numberB, int expected)
    {
        //Arrange
        var fakeClass = new FakeClass();

        //act
        var result = fakeClass.Add(numberA, numberB);

        //Assert
        Assert.Equal(expected, result);
    }
}