namespace Phoenix.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //[ComplexType]
   public class NewsArticle
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

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }


        public virtual Image AvatarURL { get; set; }

        public string UrlId { get; set; }


    }
}
