namespace PhoenixBootstrap.ViewModels
{

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using Phoenix.Models;
    using PhoenixBootstrap.ViewModels;
    
    public class EventsViewModel //:IMapFrom<Events>
    {
        public static Expression<Func<Events, EventsViewModel>> ViewModel
        {
            get
            {
                return x => new EventsViewModel
                {
                    
                    Title = x.Title,
                    Description =x.Description //,
                    //DatePublic = x.DatePublic,
                    //Author = x.Author.Id,
                    //AvatarURL = x.AvatarURL.Id

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