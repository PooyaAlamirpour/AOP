namespace Core.ViewModels.Results
{
    public class SuccessDataResult<TData> : DataResult<TData>
    {
        public SuccessDataResult(TData data, string message) : base(data, success: true, message)
        {
            
        }

        public SuccessDataResult(TData data) : base(data, success: true)
        {
            
        }

        public SuccessDataResult(string message) : base(default, success: true, message)
        {
            
        }

        public SuccessDataResult() : base(default, success: true)
        {
            
        }
    }
}