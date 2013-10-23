using DomainDrivenDatabaseDeployer;
using NHibernate;

namespace LigaNacional.DatabaseDeployer.Seeder
{
    public class Seeder : IDataSeeder
    {
        internal readonly ISession Session;

        public Seeder(ISession session)
        {
            Session = session;
        }

        public virtual void Seed()
        {

        }
    }
}