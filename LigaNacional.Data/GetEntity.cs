using System.Linq;
using LigaNacional.Data.Helper;
using LigaNacional.Domain;
using LigaNacional.Domain.Entities;
using NHibernate;
using NHibernate.Linq;

namespace LigaNacional.Data
{
    public class FindEntity
    {

        public static IQueryable<Jugador> Jugador(IRepository repository)
        {
            var result = repository.Query<Jugador>(x => x.Activo);

            return result.LongCount() <= 0 ? null : result;
        }

        public static Jugador Jugador(IRepository repository, long id)
        {
            if (id <= 0)
                return null;

            var result = repository.Query<Jugador>(x => x.Id == id && x.Activo);

            if (result.LongCount() <= 0)
                return null;

            return result.FirstOrDefault();
        }

        public static Jugador Jugador(ISession session, long id)
        {
            if (id <= 0)
                return null;

            var result = session.Query<Jugador>().Where(x => x.Id == id && x.Activo);

            if (result.LongCount() <= 0)
                return null;

            return result.FirstOrDefault();
        }


        public static Usuario Usuario(IRepository repository, long id)
        {
            if (id <= 0)
                return null;

            var result = repository.Query<Usuario>(x => x.Id == id && x.Activo);

            if (result.LongCount() <= 0)
                return null;

            return result.FirstOrDefault();
        }

        public static Usuario Usuario_Login(IRepository repository, string nombreUsuario, string clave)
        {
            if (nombreUsuario.IsNullOrEmpty() || clave.IsNullOrEmpty())
                return null;

            var result = repository.Query<Usuario>(x => x.Nombre == nombreUsuario &&
                                                        x.Clave == clave &&
                                                        x.Confirmado &&
                                                        x.Activo);

            if (result.LongCount() <= 0)
                return null;

            return result.FirstOrDefault();
        }

        public static Usuario Usuario_Nombre(IRepository repository, string nombreUsuario, long usuarioIdOmitir)
        {
            if (nombreUsuario.IsNullOrEmpty())
                return null;

            var result = repository.Query<Usuario>(x => x.Nombre == nombreUsuario && x.Activo && x.Confirmado && x.Id != usuarioIdOmitir);

            if (result.LongCount() <= 0)
                return null;

            return result.FirstOrDefault();
        }

        public static Usuario Usuario_Correo(IRepository repository, string correo, long usuarioIdOmitir)
        {
            if (correo.IsNullOrEmpty())
                return null;

            var result = repository.Query<Usuario>(x => x.Correo == correo && x.Activo && x.Confirmado && x.Id != usuarioIdOmitir);

            if (result.LongCount() <= 0)
                return null;

            return result.FirstOrDefault();
        }





    }
}
