using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrvxTask.Domain.Entities;
using TrvxTask.Domain.Interfaces;
using TrvxTask.Domain.Interfaces.Repositories;

namespace TrvxTask.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            if (commentRepository == null)
            {
                throw new ArgumentNullException(nameof(commentRepository));
            }
            _commentRepository = commentRepository;
        }

        public IEnumerable<Comment> GetAll()
        {
            return _commentRepository.GetAll();
        }

        public async Task<Comment> GetAsync(Guid id)
        {
            return await _commentRepository.GetAsync(id);
        }

        public async Task InsertAsync(Comment comment)
        {
            await _commentRepository.InsertAsync(comment);
        }

        public async Task UpdateAsync(Comment comment)
        {
            await _commentRepository.UpdateAsync(comment);
        }

        public async Task DeleteAsync(Comment comment)
        {
            await _commentRepository.DeleteAsync(comment);
        }
    }
}
