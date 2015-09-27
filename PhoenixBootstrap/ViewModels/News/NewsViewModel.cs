namespace PhoenixBootstrap.ViewModels
{

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using Phoenix.Models;
    using PhoenixBootstrap.ViewModels;
    
    public class NewsViewModel //:IMapFrom<News>
    {
        public static Expression<Func<NewsArticle, NewsViewModel>> ViewModel
        {
            get
            {
                return x => new NewsViewModel
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