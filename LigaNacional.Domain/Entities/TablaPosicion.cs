
namespace LigaNacional.Domain.Entities
{
    public class TablaPosicion : IEntity
    {
        public virtual long Id { get; set; }
        public virtual int PJ { get; set; }
        public virtual int PG { get; set; }
        public virtual int PP { get; set; }
        public virtual int PE { get; set; }
        public virtual int GF { get; set; }
        public virtual int GC { get; set; }
        public virtual int DG { get; set; } //diferencia de goles
        public virtual int Puntos { get; set; }
        
        public virtual Equipo Equipo { get; set; }
        public virtual Jornada Jornada { get; set; }
        public virtual bool Activo { get; set; }
    }
}