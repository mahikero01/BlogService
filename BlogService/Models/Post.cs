using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogService.Models
{
    [Table("BS_Posts")]
    public class Post
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Comment { get; set; }

        public Guid PersonId { get; set; }
        public Person Person { get; set; }

        public Post(){
            Id = Guid.NewGuid();
        }
    }
}