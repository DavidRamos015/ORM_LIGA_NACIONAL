using System;

namespace LigaNacional.Domain.Entities
{
    public class Jornada : IEntityMaintenance
    {
        public virtual long Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual int Año { get; set; }
        public virtual int NumJornada { get; set; }
        public virtual DateTime FechaInicio { get; set; }
        public virtual DateTime FechaFin { get; set; }
        public virtual bool Activo { get; set; }
    }
}