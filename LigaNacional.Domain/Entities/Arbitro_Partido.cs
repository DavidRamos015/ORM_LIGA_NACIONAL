
namespace LigaNacional.Domain.Entities
{
    public class Arbitro_Partido : IEntity
    {
        public virtual long Id { get; set; }
        public virtual Arbitro Arbitro { get; set; }
        public virtual PosicionArbitro PosicionArbitro { get; set; }
        public virtual Partido Partido { get; set; }
        public virtual bool Activo { get; set; }
    }
}