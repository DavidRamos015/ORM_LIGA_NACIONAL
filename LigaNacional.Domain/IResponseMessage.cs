namespace LigaNacional.Domain
{
    public interface IResponseMessage : IToken
    {
        char Successfully { get; set; }
        string Message { get; set; }
        string TechnicalError { get; set; }
        string StackTrace { get; set; }
    }
}