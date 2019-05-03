using System;

namespace TrvxTask.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }

        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
