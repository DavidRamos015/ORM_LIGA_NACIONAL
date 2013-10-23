
namespace LigaNacional.Domain.Entities
{
    public class Usuario : IEntity
    {
        public virtual long Id { get; set; }

        public virtual string Nombre { get; set; }
        public virtual string Correo { get; set; }
        public virtual string Clave { get; set; }
        public virtual bool Confirmado { get; set; }
        public virtual bool Activo { get; set; }
    }
}
