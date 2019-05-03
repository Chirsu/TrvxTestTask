using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrvxTask.Api.Models;
using TrvxTask.Domain.Entities;
using TrvxTask.Domain.Interfaces;

namespace TrvxTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPostService _postService;

        public PostsController(IMapper mapper, IPostService postService)
        {
            _mapper = mapper;
            _postService = postService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var res = _postService.GetAll().Select(x => _mapper.Map<PostModel>(x)).ToList();
            return Ok(res);
        }

        // GET api/<controller>/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var post =  await _postService.GetAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<PostModel>(post);
            return Ok(res);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PostModel model)
        {
            var post = _mapper.Map<Post>(model);
            await _postService.InsertAsync(post);
            return Ok();
        }

        // PUT api/<controller>/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]PostModel model)
        {
            var post = _mapper.Map<Post>(model);
            post.Id = id;
            await _postService.UpdateAsync(post);
            return Ok();
        }

        // DELETE api/<controller>/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _postService.DeleteAsync(id);
            return Ok();
        }
    }
}
