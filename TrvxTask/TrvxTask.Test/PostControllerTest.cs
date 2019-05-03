using System;
using System.Collections.Generic;
using System.Linq;
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
using TrvxTask.Domain.Interfaces.Repositories;
using TrvxTask.Services;
using TrvxTask.Test.Fakes;

namespace TrvxTask.Test
{
    [TestClass]
    public class PostControllerTest
    {
        private readonly IPostService _service;

        public PostControllerTest()
        {
            var repository = new PostRepositoryFake();
            _service = new PostService(repository);
        }

        [TestMethod]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var result = _service.GetAll();
            
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            var result = _service.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public async Task GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            var result = await _service.GetAsync(Guid.NewGuid());
            
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
            
            var result = await _service.GetAsync(testGuid);
            
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
            
            var result = await _service.GetAsync(testGuid);

            Assert.IsNotNull(result);
            Assert.AreEqual(testGuid, result.Id);
        }
    }
}
