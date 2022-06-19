namespace LMA_backend.Dtos;

public class GetBookWithIdDto
{
    public long BookId { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
}