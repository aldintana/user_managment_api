namespace Application.Requests
{
    public class BaseSearchRequest
    {
        public string TextSearch { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 25;
        public string[] IncludeList { get; set; }
    }
}
