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
    public class CommentsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICommentService _commentService;

        public CommentsController(IMapper mapper, ICommentService commentService)
        {
            _mapper = mapper;
            _commentService = commentService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var res = _commentService.GetAll().Select(x => _mapper.Map<CommentModel>(x)).ToList();
            return Ok(res);
        }

        // GET api/<controller>/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var comment = await _commentService.GetAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            var res = _mapper.Map<CommentModel>(comment);
            return Ok(res);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CommentModel model)
        {
            var comment = _mapper.Map<Comment>(model);
            await _commentService.InsertAsync(comment);
            return Ok();
        }

        // PUT api/<controller>/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]CommentModel model)
        {
            var comment = _mapper.Map<Comment>(model);
            comment.Id = id;
            await _commentService.UpdateAsync(comment);
            return Ok();
        }

        // DELETE api/<controller>/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _commentService.DeleteAsync(id);
            return Ok();
        }
    }
}
