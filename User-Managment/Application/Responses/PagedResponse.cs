namespace Application.Responses
{
    public class PagedResponse<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public T Items { get; set; }
        public PagedResponse(T items, int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            Items = items;
        }
    }
}