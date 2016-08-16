using System;
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

        //[Required]
        public virtual ApplicationUser UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string Heading { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }

        [Required]
        public string body { get; set; }

        

    }
}