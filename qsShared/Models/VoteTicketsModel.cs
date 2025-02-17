﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qsShared.Models
{
    public class VoteTicketsModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PointValue { get; set; }
    }
}
