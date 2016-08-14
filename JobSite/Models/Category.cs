using System.ComponentModel.DataAnnotations;


namespace JobSite.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

    }
}