using System;
using System.Collections.Generic;
using System.Text;

namespace TrvxTask.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
