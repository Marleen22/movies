﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class SearchViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}
