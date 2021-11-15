namespace Core.ViewModels.Results
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}