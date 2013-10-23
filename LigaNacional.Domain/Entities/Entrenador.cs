
namespace LigaNacional.Domain.Entities
{
    public class Entrenador : IEntityMaintenance
    {
        public virtual long Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string NumeroLicencia { get; set; }
        public virtual Nacionalidad Nacionalidad { get; set; }
        public virtual bool Activo { get; set; }
    }
}