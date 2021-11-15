namespace Core.ViewModels.Results
{
    public class ErrorDataResult<TData> : DataResult<TData>
    {
        public ErrorDataResult(TData data, string message) : base(data, success: false, message)
        {
        }

        public ErrorDataResult(TData data) : base(data, success: false)
        {
        }

        public ErrorDataResult(string message) : base(default, success: false, message)
        {
            
        }

        public ErrorDataResult() : base(default, success: false)
        {
            
        }
    }
}