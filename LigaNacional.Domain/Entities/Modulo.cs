using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviText.Domain.Entities
{
    public class Modulo : IEntity
    {
        public virtual long Id { get; set; }

        public virtual string Descripcion { get; set; }

        public virtual IList<AccesoUsuario> Accesos { get; set; }

        public virtual bool Activo { get; set; }

    }
}
