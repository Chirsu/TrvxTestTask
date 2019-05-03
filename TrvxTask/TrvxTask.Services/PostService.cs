using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrvxTask.Domain.Entities;
using TrvxTask.Domain.Interfaces;
using TrvxTask.Domain.Interfaces.Repositories;

namespace TrvxTask.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository) 
        {
            if (postRepository == null)
            {
                throw new ArgumentNullException(nameof(postRepository));
            }
            _postRepository = postRepository;
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public async Task<Post> GetAsync(Guid id)
        {
            return await _postRepository.GetAsync(id);
        }

        public async Task InsertAsync(Post post)
        {
            await _postRepository.InsertAsync(post);
        }

        public async Task UpdateAsync(Post post)
        {
            await _postRepository.UpdateAsync(post);
        }

        public async Task DeleteAsync(Post post)
        {
            await _postRepository.DeleteAsync(post);
        }
    }
}
