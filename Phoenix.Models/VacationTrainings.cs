namespace Phoenix.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

   // [ComplexType]
    public class VacationTrainings
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public string DatePublic { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
