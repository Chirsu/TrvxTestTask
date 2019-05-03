using System;
using System.Collections.Generic;
using System.Text;
using TrvxTask.Domain.Entities;
using TrvxTask.Domain.Interfaces.Repositories;

namespace TrvxTask.Data.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
