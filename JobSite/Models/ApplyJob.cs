using System;
using System.ComponentModel.DataAnnotations;

namespace JobSite.Models
{
    public class ApplyJob
    {
 
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime ApplyDate { get; set; }

        //[Required]
        public virtual System.Collections.Generic.ICollection<File> Files { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(200)]
        public string Message { get; set; }

        //[Required]
        public virtual ApplicationUser UserId { get; set; }

        //[Required]
        public virtual JobPost JobPostId { get; set; }

    }
}