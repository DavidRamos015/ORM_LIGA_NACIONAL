using LigaNacional.Domain.Entities;
using NHibernate;

namespace LigaNacional.DatabaseDeployer.Seeder
{
    public class UsuarioSeeder : LigaNacional.DatabaseDeployer.Seeder.Seeder
    {
        public UsuarioSeeder(ISession session)
            : base(session)
        {
        }

        public override void Seed()
        {
            var usuario = new Usuario
            {
                Nombre = "admin",
                Correo = "admin@mail.com",
                Clave = "adminpwd",
                Confirmado = true,
                Activo = true
            };

            Session.Save(usuario);
        }
    }
}
