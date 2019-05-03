using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrvxTask.Api.Models
{
    public class PostModel
    {
        public Guid Id { get; set; }

        [StringLength(160, ErrorMessage = "Title Max Length is 160")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Text Max Length is 500")]
        public string Text { get; set; }
    }
}
