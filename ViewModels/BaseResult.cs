namespace UniPlatform.ViewModels
{
    public class BaseResult<T>
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
        public T Data { get; set; }
    }
}
