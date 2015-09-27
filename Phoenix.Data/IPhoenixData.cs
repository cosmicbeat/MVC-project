namespace Phoenix.Data
{
    using Phoenix.Data.Repositories;
    using Phoenix.Models;

    public interface IPhoenixData
    {
        IRepository<User> Users { get; }

        IRepository<Interview> Interviews { get; }

        IRepository<NewsArticle> NewsArticles { get; }

        IRepository<Events> Events { get; }

        IRepository<AdministrationLog> AdministrationLogs { get; }

        int SaveChanges();
    }
}
