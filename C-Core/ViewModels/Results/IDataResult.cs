namespace Core.ViewModels.Results
{
    public interface IDataResult<out TData> : IResult
    {
        TData Data { get; }
    }
}