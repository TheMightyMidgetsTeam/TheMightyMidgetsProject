using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSite.Models
{
    public class JobPost
    {
        private DateTime expireDate;
        public JobPost()
        {
            PublishDate = DateTime.Now;
        }

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

        [Required(ErrorMessage = "Моля въведи дата")]
        [DataType(DataType.Date)]
        public DateTime ExpireDate
        {
            get
            {
                return this.expireDate;
            }
            set
            {
                if (value < DateTime.Now)
                {
                    //throw new ArgumentOutOfRangeException("Датата не може да бъде по-малка от днес");
                }
                else
                {
                    this.expireDate = value;
                }
            }
        }

        [Required]
        public string Body { get; set; }

        public virtual City City { get; set; }

        public virtual Category Category { get; set; }

    }
}