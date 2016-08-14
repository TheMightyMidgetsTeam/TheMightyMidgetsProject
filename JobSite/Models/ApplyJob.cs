﻿using System;
using System.ComponentModel.DataAnnotations;

namespace JobSite.Models
{
    public class ApplyJob
    {
        public ApplyJob()
        {
            this.ApplyDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime ApplyDate { get; set; }

        [Required]
        public string CvFile { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        public string Message { get; set; }

        [Required]
        public ApplicationUser UserId { get; set; }

        [Required]
        public JobPost JobPostId { get; set; }

    }
}