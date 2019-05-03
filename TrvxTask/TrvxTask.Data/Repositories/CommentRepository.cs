using System;
using System.Collections.Generic;
using System.Text;
using TrvxTask.Domain.Entities;
using TrvxTask.Domain.Interfaces.Repositories;

namespace TrvxTask.Data.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
 