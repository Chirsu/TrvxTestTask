using System;
using System.Collections.Generic;
using System.Text;

namespace TrvxTask.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
