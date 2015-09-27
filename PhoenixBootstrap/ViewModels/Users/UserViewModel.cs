namespace  PhoenixBootstrap.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using System.Linq;
    using Phoenix.Models;
    using System.Web.Mvc;


    public class UserViewModel //: IMapFrom<User>
    {

        public static Expression<Func<User, UserViewModel>> ViewModel
        {
            get
            {
                return x => new UserViewModel
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    ContactInfo = x.ContactInfo,
                    FullName = x.FullName,
                    Summary = x.Summary,
                    Email = x.Email,
                    DateRegister = x.DateRegister
                    //Tweets = x.Tweets.AsQueryable().Select(TweetViewModel.ViewModel)
                    
                };
            }
        }

        public string Id { get; set; }

        [Display(Name = "Username")]
        [StringLength(20, MinimumLength= 4, ErrorMessage = "The username should be at least 4 symbols long.")]
        [Remote("check", "Account", HttpMethod = "POST", ErrorMessage = "Username already taken")]
        public string UserName { get; set; }

        [Display(Name = "Fullname")]
        public string FullName { get; set; }

        public string Email { get; set; }
        public virtual Image AvatarURL { get; set; }

        public string UrlId { get; set; }
        public DateTime DateRegister { get; set; }
        public string Summary { get; set; }

        public ContactInfo ContactInfo { get; set; }


    }
}