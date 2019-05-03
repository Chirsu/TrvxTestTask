using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrvxTask.Api.Models
{
    public class CommentModel
    {
        public Guid Id { get; set; }

        [StringLength(500, ErrorMessage = "Text Max Length is 500")]
        public string Text { get; set; }

        public Guid PostId { get; set; }
    }
}
