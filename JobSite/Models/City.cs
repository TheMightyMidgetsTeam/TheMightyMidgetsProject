using System.ComponentModel.DataAnnotations;


namespace JobSite.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CityName { get; set; }

        public override string ToString()
        {
            return this.CityName;
        }

    }

}