
namespace LigaNacional.Domain
{
    public interface IBaseModel : IToken
    {
        long Id { get; set; }
    }
}