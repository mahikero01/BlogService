﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogService.Models
{
    public class PostDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
    }
}