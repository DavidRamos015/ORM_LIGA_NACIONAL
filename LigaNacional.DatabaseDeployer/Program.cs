using System;
using System.Collections.Generic;
using System.Threading;
using AcklenAvenue.Data.NHibernate;
using DomainDrivenDatabaseDeployer;
using FluentNHibernate.Cfg.Db;
using LigaNacional.Data;
using LigaNacional.Data.Helper;
using LigaNacional.Data.Logger;
using LigaNacional.DatabaseDeployer.Seeder;
using NHibernate;

namespace LigaNacional.DatabaseDeployer
{
    public class Program
    {
        static void Main()
        {

            try
            {
                
                IDatabaseDeployer dd = null;
                SessionFactoryBuilder sessionFactoryBuilder = null;

                //Usar SQLSERVER / MySQL dependiendo de la configuracion
                if (Utility.UseSqlServerDb)
                {
                    var dbMsSqlConfiguration = MsSqlConfiguration.MsSql2008.ShowSql().ConnectionString(x => x.FromConnectionStringWithKey(Utility.ConnectionString));
                    sessionFactoryBuilder = new SessionFactoryBuilder(new MappingScheme(), dbMsSqlConfiguration);

                }
                else
                {
                    var dbMySqlConfiguration = MySQLConfiguration.Standard.ShowSql().ConnectionString(x => x.FromConnectionStringWithKey(Utility.ConnectionString));
                    sessionFactoryBuilder = new SessionFactoryBuilder(new MappingScheme(), dbMySqlConfiguration);
                }

                var sessionFactory = sessionFactoryBuilder.Build(
                                                                    cfg =>
                                                                    {
                                                                        dd = new DomainDrivenDatabaseDeployer.DatabaseDeployer(cfg);
                                                                    }
                                                                  );

                //Eliminar la bdd
                dd.Drop();
                Console.WriteLine("Database dropped.");
                Thread.Sleep(1000);

                //volver a crearla
                dd.Create();
                Console.WriteLine("Database created.");

                var session = sessionFactory.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {

                    dd.Seed(new List<IDataSeeder>
                            {
                                new UsuarioSeeder (session ),
                            });
                    tx.Commit();
                }
                session.Close();
                sessionFactory.Close();
                Console.WriteLine("Seed data added. Press any key to exit.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                var innerMessage = "";
                if (ex.InnerException.IsValid())
                    innerMessage = ex.InnerException.Message.ToSafeString();

                Console.WriteLine("An error ocurred:" + ex.Message + " inner message:" + innerMessage + Environment.NewLine + Environment.NewLine + "Press any key to exit.");
                Console.ReadKey();
                Log.WriteError(ex);

            }

        }
    }
}
