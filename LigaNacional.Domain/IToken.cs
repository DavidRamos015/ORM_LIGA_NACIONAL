namespace LigaNacional.Domain
{
    public interface IToken
    {
        string RequestToken { get; set; }
        string AccessToken { get; set; }
    }
}