namespace Phoenix.Data
{    
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Phoenix.Models;
    using Phoenix.Data.Repositories;
    public class PhoenixData : IPhoenixData
    {
        private IPhoenixContext context;
        private IDictionary<Type, object> repositories;

        public PhoenixData(IPhoenixContext context)
        {
            this.context = context;
            repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Interview> Interviews
        {
            get { return this.GetRepository<Interview>(); }
        }

        public IRepository<NewsArticle> NewsArticles
        {
            get { return this.GetRepository<NewsArticle>(); }
        }


        public IRepository<Events> Events
        {
            get { return this.GetRepository<Events>(); }
        }

        public IRepository<AdministrationLog> AdministrationLogs
        {
            get { return this.GetRepository<AdministrationLog>(); }
        } 

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                //                if (type.IsAssignableFrom(typeof(Game)))
                //                {
                //                    typeOfRepository = typeof(GamesRepository);
                //                }

                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    
    }
}
