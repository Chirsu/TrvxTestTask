using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrvxTask.Domain.Entities;

namespace TrvxTask.Domain.Interfaces
{
    public interface IPostService
    {
        IEnumerable<Post> GetAll();
        Task<Post> GetAsync(Guid id);
        Task CreateAsync(Post post);
        Task UpdateAsync(Post post);
        Task DeleteAsync(Guid id);
    }
}
