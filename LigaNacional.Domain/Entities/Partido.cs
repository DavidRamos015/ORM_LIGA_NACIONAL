using System;

namespace LigaNacional.Domain.Entities
{
    public class Partido : IEntity
    {
        public virtual long Id { get; set; }
        public virtual DateTime FechaHora { get; set; }
        public virtual Jornada Jornada { get; set; }
        public virtual Equipo Equipo1 { get; set; }
        public virtual Equipo Equipo2 { get; set; }
        public virtual Estadio Estadio { get; set; }
        public virtual bool Activo { get; set; }
    }
}