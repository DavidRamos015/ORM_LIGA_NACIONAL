namespace MoviText.Domain.Entities
{
    public class AccesoUsuario : IEntity
    {
        public virtual long Id { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Modulo Modulo { get; set; }

        public virtual bool Activo { get; set; }
    }
}