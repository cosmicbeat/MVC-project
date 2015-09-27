namespace Phoenix.Data
{
    using System.Data.Entity;
    using Phoenix.Models;

    public interface IPhoenixContext
    {
         IDbSet<UserLanguage> Languages { get; set; }

         IDbSet<Interview> Interviews { get; set; }

         IDbSet<Events> Events { get; set; }

         IDbSet<NewsArticle> NewsArticles { get; set; }

         IDbSet<AdministrationLog> AdministrationLogs { get; set; }

         int SaveChanges();

    }
}
