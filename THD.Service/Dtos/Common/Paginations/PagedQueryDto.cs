namespace THD.Service.Dtos
{
    public class PagedQueryDto
    {
        private int _pageIndex = 1;
        private int _pageSize = DefaultPageSize;

        public static int DefaultPageSize { get; set; } = 10;

        public static int MaxPageSize { get; set; } = 1000;

        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = value < 1 ? 1 : value;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value < 0 ? 0 : value;
        }

    }
}
