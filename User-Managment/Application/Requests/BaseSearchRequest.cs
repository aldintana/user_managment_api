namespace Application.Requests
{
    public class BaseSearchRequest
    {
        public string TextSearch { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string[] IncludeList { get; set; }
    }
}
