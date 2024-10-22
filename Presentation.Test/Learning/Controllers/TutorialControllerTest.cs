using Domain.Learning.Model.Entities;
using Domain.Learning.Model.Queries;
using Domain.Learning.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NSubstitute;
using Presentation.Learning.Controllers;

namespace Presentation.Test.Learning.Controllers;

public class TutorialControllerTest
{
    [Fact]
    public async Task Get_WithoutParams_ReturnsListTutorials()
    {
        //Arrange
        var  tutorialCommandServiceMock = Substitute.For<ITutorialCommandService>();
        var tutorialQueryServiceMock = Substitute.For<ITutorialQueryService>();
       // var tutorialCommandServiceMock = new Mock<ITutorialCommandService>();
        //var tutorialQueryServiceMock = new Mock<ITutorialQueryService>();

        var controller = new TutorialController(tutorialQueryServiceMock, tutorialCommandServiceMock);

        var expectedResult = new List<Tutorial>
        {
            new() { Title = "test1" },
            new() { Title = "test2" }
        } as IEnumerable<Tutorial>;

        var query = new GetAllTutorialsQuery();
       tutorialQueryServiceMock.Handle(query).Returns(Task.FromResult(expectedResult));
       //tutorialQueryServiceMock.Setup(t=>t.Handle(query)).ReturnsAsync(expectedResult);

        //Act}
        var result = await controller.Get();

        //Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Get_Witohparam_ReturnNotFound()
    {
        //Arrange
        var tutorialCommandServiceMock = Substitute.For<ITutorialCommandService>();
        var tutorialQueryServiceMock = Substitute.For<ITutorialQueryService>();

        var controller = new TutorialController(tutorialQueryServiceMock, tutorialCommandServiceMock);

        var expectedResult = new List<Tutorial>() as IEnumerable<Tutorial>;

        var query = new GetAllTutorialsQuery();

        tutorialQueryServiceMock.Handle(query).Returns(Task.FromResult(expectedResult));


        //Act}
        var result = await controller.Get();

        //Assert
        Assert.IsType<NotFoundResult>(result);
    }
}