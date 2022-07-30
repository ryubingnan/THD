namespace THD.Service.Dtos
{
    public class TourPagedQueryDto : PagedQueryDto
    {
        public string Title { get; set; }

        public string Type { get; set; }

        public string Search { get; set; }
    }
}
