namespace Atl.Data
{
    public class QueryObject
    {
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
