using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrvxTask.Domain.Entities;

namespace TrvxTask.Domain.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetAll();
        Task<Comment> GetAsync(Guid id);
        Task CreateAsync(Comment comment);
        Task UpdateAsync(Comment comment);
        Task DeleteAsync(Guid id);
    }
}
