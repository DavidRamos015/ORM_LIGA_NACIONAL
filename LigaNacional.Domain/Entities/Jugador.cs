namespace LigaNacional.Domain.Entities
{
    public class Jugador : IEntity
    {
        public virtual long Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual int Edad { get; set; }
        public virtual string Altura { get; set; }
        public virtual string Peso { get; set; }
        public virtual decimal Salario { get; set; }
        public virtual Nacionalidad Nacionalidad { get; set; }
        public virtual bool Activo { get; set; }
    }
}