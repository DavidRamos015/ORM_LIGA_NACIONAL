

namespace LigaNacional.Domain.Entities
{
    public class Alineacion : IEntity
    {
        public virtual long Id { get; set; }
        public virtual int Numero { get; set; }
        public virtual Jugador Jugador { get; set; }
        public virtual PosicionJugador PosicionJugador { get; set; }
        public virtual Partido Partido { get; set; }
        public virtual bool Activo { get; set; }
    }
}