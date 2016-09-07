using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogService.Models
{
    [Table("BS_Persons")]
    public class Person
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
    }
}