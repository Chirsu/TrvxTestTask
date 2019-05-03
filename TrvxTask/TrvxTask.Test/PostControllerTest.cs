using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrvxTask.Api.Controllers;
using TrvxTask.Api.MappingProfiles;
using TrvxTask.Api.Models;
using TrvxTask.Domain.Entities;
using TrvxTask.Domain.Interfaces;
using TrvxTask.Test.Fakes;

namespace TrvxTask.Test
{
    [TestClass]
    public class PostControllerTest
    {
        private readonly PostsController _controller;
        private readonly IPostService _service;

        public PostControllerTest()
        {
            var profile = new PostProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);

            _service = new PostServiceFake();
            _controller = new PostsController(mapper, _service);
        }

        [TestMethod]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var result = _controller.Get();
            
            Assert.IsTrue(result is OkObjectResult);
        }

        [TestMethod]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            var result = _controller.Get() as OkObjectResult;

            Assert.IsNotNull(result);
            var items = result.Value as List<PostModel>;
            Assert.IsNotNull(items);
            Assert.AreEqual(3, items.Count);
        }

        [TestMethod]
        public async Task GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            var result = await _controller.Get(Guid.NewGuid());
            
            Assert.IsTrue(result is NotFoundResult);
        }

        [TestMethod]
        public async Task GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
            
            var result = await _controller.Get(testGuid);
            
            Assert.IsTrue(result is OkObjectResult);
        }

        [TestMethod]
        public async Task GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
            
            var result = await _controller.Get(testGuid) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Value is PostModel);
            Assert.AreEqual(testGuid, (result.Value as PostModel).Id);
        }
    }
}
