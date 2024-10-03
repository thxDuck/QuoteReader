public class Quote
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required bool Viewed { get; set; }
    public DateTime? PostedDate { get; set; }
}