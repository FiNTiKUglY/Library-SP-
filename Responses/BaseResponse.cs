namespace Library.Responses
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string? Description { get; set; }

        public int StatusCode { get; set; }

        public T? Data { get; set; }
    }

    public interface IBaseResponse<T>
    {
        int StatusCode { get; }
        T Data { get; }
    }
}
