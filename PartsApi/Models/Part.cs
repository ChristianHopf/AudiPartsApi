namespace PartsApi.Models
{
    public class Part
    {
        public Guid Id { get; set; }
        public string? partNumber { get; set; }
        public string? name { get; set; }
    }
}
