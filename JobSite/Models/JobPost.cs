﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSite.Models
{
    public class JobPost
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ApplicationUser UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string Heading { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }

        [Required]
        public string body { get; set; }

    }
}