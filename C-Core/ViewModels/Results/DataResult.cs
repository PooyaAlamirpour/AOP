namespace Core.ViewModels.Results
{
    public class DataResult<TData> : Result, IDataResult<TData>
    {
        public TData Data { get; }

        public DataResult(TData data, bool success, string message) : base(success, message)
        {
            this.Data = data;
        }
        
        public DataResult(TData data, bool success) : base(success)
        {
            this.Data = data;
        }

    }
}