namespace LigaNacional.Domain
{
    public interface IEntity
    {
        long Id { get; set; }
        bool Activo { get; set; }
    }
}
