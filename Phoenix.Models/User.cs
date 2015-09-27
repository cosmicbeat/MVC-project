namespace Phoenix.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User : IdentityUser
    {
        //TODO add collections for the elements
        // private ICollection<Element> elements;
        private ICollection<Interview> interviews;
        private ICollection<BlogPost> posts;

        public User()
        {
            this.interviews = new HashSet<Interview>();
            this.posts = new HashSet<BlogPost>();
            this.ContactInfo = new ContactInfo();
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string FullName { get; set; }

        public virtual Image AvatarURL { get; set; }

        public string UrlId { get; set; }

        [MinLength(2)]
        [MaxLength(140)]
        public string Summary { get; set; }

        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public ContactInfo ContactInfo { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateRegister { get; set; }

        public virtual ICollection<Interview> Interviews
        {
            get { return this.interviews; }
            set { this.interviews = value; }
        }

        public virtual ICollection<BlogPost> Posts
        {
            get { return this.posts; }
            set { this.posts = value; } 
        }


    }
}
