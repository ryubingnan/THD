namespace THD.Service.Dtos
{
    public class EmailVericationDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Error { get; set; }

        public bool Success => string.IsNullOrWhiteSpace(Error);
    }
}
