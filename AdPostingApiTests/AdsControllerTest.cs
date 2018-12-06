using AdPostingApi.Controllers;
using AdPostingApi.Entities;
using AdPostingApi.Models;
using AdPostingApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;


namespace AdPostingApiTests
{
    public class AdsControllerTest
    {
        private Mock<IAdsRepository> _mockRepo;
        private Mock<ILogger<AdsController>> _mockLogger;

        public AdsControllerTest()
        {
            _mockRepo = new Mock<IAdsRepository>();
            _mockLogger = new Mock<ILogger<AdsController>>();
        }

        private AdInfo RepoGetAd()
        {
            return null;
        }

        private List<AdInfo> RepoGetAds()
        {
            return null;
        }

        [Fact]
        public void GetAdFailTest()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetAd(-1)).Returns(RepoGetAd());
            var controller = new AdsController(_mockRepo.Object, _mockLogger.Object);

            // Act
            var result = controller.Get(-1);

            // Assert
            Assert.Equal(JsonConvert.SerializeObject(new NotFoundResult()), JsonConvert.SerializeObject(result.Result));
        }


        [Fact]
        public void PostAdFailTest()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetAds()).Returns(RepoGetAds());

            var controller = new AdsController(_mockRepo.Object, _mockLogger.Object);
            controller.ModelState.AddModelError("Title", "Required");

            var adInfo = new AdInfoDto() { Title = "", Text="text", Category="cat" };

            // Act
            var result = controller.Post(adInfo);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }      

    }

}
