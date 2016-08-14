using System.ComponentModel.DataAnnotations;


namespace JobSite.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string CityName { get; set; }

    }
}