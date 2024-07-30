namespace Api.Shared
{
    public class Response<T>
    {
        public bool IsValid { get; set; }
        public T? Value { get; set; }
        public string? Menssage { get; set; }
    }
}
