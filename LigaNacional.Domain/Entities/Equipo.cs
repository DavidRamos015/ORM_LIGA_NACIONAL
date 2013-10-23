namespace LigaNacional.Domain.Entities
{
    public class Equipo : IEntityMaintenance
    {
        public virtual long Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual Sede Sede { get; set; }
        public virtual Estadio Estadio { get; set; }
        public virtual bool Activo { get; set; }
    }
}