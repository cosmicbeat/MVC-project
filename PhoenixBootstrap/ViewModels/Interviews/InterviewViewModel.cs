namespace PhoenixBootstrap.ViewModels
{

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using Phoenix.Models;
    using PhoenixBootstrap.ViewModels;
    
    public class InterviewViewModel //:IMapFrom<Interview>
    {
        public static Expression<Func<Interview, InterviewViewModel>> ViewModel
        {
            get
            {
                return x => new InterviewViewModel
                {
                    Id = x.Id,
                    AvatarURL = x.AvatarURL,
                    Description = x.Description,
                    DatePublic = x.DatePublic,
                    Title = x.Title
                };
            }
        }
        public int Id { get; set; }

        public string Title { get; set; }
 
        public string Description { get; set; }

        public DateTime DatePublic { get; set; }

        public virtual User Author { get; set; }

        public virtual Image AvatarURL { get; set; }
        
    }
}