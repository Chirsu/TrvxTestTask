using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrvxTask.Api.Models
{
    public class PostModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
