using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TrvxTask.Domain.Entities;
using TrvxTask.Domain.Interfaces;
#pragma warning disable 1998

namespace TrvxTask.Test.Fakes
{
    internal class PostServiceFake : IPostService
    {
        private readonly List<Post> _posts;

        public PostServiceFake()
        {
            _posts = new List<Post>()
            {
                new Post() { Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Title = "Test post", Text = "Test text" },
                new Post() { Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                    Title = "Title", Text= "Text" },
                new Post() { Id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                    Title = "Lorem ipsum", Text= "Lorem ipsum dolor sit amet, consectetur adipiscing elit" }
            };
        }

        public IEnumerable<Post> GetAll()
        {
            return _posts;
        }

        public async Task<Post> GetAsync(Guid id)
        {
            return _posts.FirstOrDefault(x => x.Id == id);
        }

        public async Task InsertAsync(Post post)
        {
            _posts.Add(post);
        }

        public async Task UpdateAsync(Post post)
        {
            _posts.RemoveAll(x => x.Id == post.Id);
            _posts.Add(post);
        }

        public async Task DeleteAsync(Post post)
        {
            _posts.RemoveAll(x => x.Id == post.Id);
        }
    }
}
