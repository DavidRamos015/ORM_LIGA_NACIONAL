using System;
namespace LigaNacional.Domain.Entities
{
    public class Calendario : IEntity
    {
        public virtual long Id { get; set; }
        public virtual DateTime FechaHora { get; set; }
        public virtual Partido Partido { get; set; }
        public virtual bool Activo { get; set; }
    }
}