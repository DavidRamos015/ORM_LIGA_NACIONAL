using System;
namespace LigaNacional.Domain.Entities
{
    public class Entrenador_Equipo : IEntity
    {
        public virtual long Id { get; set; }
        public virtual Entrenador Entrenador { get; set; }
        public virtual Equipo Equipo { get; set; }
        public virtual DateTime FechaInicio { get; set; }
        public virtual DateTime FechaFin { get; set; }
        public virtual bool Activo { get; set; }
    }
}