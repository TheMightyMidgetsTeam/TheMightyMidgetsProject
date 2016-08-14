using System.ComponentModel.DataAnnotations;


namespace JobSite.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string RoleName { get; set; }

    }
}