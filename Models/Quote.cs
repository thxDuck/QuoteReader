public class MessageContent
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Color { get; set; }
    public required string Text { get; set; }
}
public class Quote
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required List<MessageContent> Content { get; set; }
    public required bool Viewed { get; set; }
    public DateTime? PostedDate { get; set; }
}
