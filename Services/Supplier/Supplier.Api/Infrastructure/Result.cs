namespace Supplier.Api.Infrastructure
{
    public class Result
    {
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public ResultCode ResultCode { get; set; }
    }
    public enum ResultCode
    {
        NotCreated,
        Created,
        Updated,
        Deleted,
        AlreadyExists,
        DoesNotExist,
        ValidationError,
        Exception
    }
}
