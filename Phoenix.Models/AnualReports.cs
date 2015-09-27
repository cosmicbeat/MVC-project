namespace Phoenix.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

 
    public class AnualReports
    {
        [Key]
        public string Id { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        public string DatePublic { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        
    }
}
