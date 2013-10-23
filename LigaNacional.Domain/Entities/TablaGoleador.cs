
namespace LigaNacional.Domain.Entities
{
    public class TablaGoleador : IEntity
    {
        public virtual long Id { get; set; }
        public virtual int NumGoles { get; set; }
        public virtual Jugador Jugador { get; set; }
        public virtual Jornada Jornada { get; set; }
        public virtual bool Activo { get; set; }
    }
}