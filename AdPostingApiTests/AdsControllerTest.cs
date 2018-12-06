using AdPostingApi.Controllers;
using AdPostingApi.Entities;
using AdPostingApi.Models;
using AdPostingApi.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace AdPostingApiTests
{
    public class AdsControllerTest
    {
        [Fact]
        public void GetAdFailTest()
        {
            // Arrange
            var mockRepo = new Mock<IAdsRepository>();
            var mockLogger = new Mock<ILogger<AdsController>>();
            mockRepo.Setup(repo => repo.GetAd(-1)).Returns(RepoGetAd());
            var controller = new AdsController(mockRepo.Object, mockLogger.Object);

            // Act
            var result = controller.Get(-1);

            // Assert
            Assert.Equal(JsonConvert.SerializeObject(new NotFoundResult()), JsonConvert.SerializeObject(result.Result));
        }

        private AdInfo RepoGetAd()
        {
            return null;
        }

    }

}
