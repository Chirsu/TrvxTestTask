using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrvxTask.Api.Models
{
    public class CommentModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Guid PostId { get; set; }
    }
}
