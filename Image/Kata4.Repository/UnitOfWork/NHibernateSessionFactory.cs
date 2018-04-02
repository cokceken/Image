using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Kata4.Repository.Map;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Kata4.Repository.UnitOfWork
{
    public class NHibernateSessionFactory
    {
        private const string ConnectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=image;Integrated Security=True";

        public static ISession OpenSession()
        {
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(ConnectionString)
                    .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ImageMap>())
                .ExposeConfiguration(x => new SchemaUpdate(x).Execute(false, true))
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }

        public static ISessionFactory GetSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(ConnectionString)
                    .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ImageMap>())
                .ExposeConfiguration(x => new SchemaUpdate(x).Execute(false, true))
                //.ExposeConfiguration(x => new SchemaExport(x).Create(false, true))
                .BuildSessionFactory();
        }
    }
}