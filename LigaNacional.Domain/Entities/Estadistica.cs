
namespace LigaNacional.Domain.Entities
{
    public class Estadistica : IEntity
    {
        public virtual long Id { get; set; }
        public virtual int Valor { get; set; }
        public virtual int Minuto { get; set; }
        public virtual TipoEstadistica TipoEstadistica { get; set; }
        public virtual Partido Partido { get; set; }
        public virtual Jugador Jugador { get; set; }
        public virtual bool Activo { get; set; }
    }
}