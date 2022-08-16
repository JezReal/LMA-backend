using System.ComponentModel.DataAnnotations;

namespace LMA_backend.Dtos;

public class UpdateBookDto
{
    [Required]
    [MaxLength(250)]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string AuthorFirstName { get; set; } = string.Empty;
    [Required]
    public string AuthorLastName { get; set; } = string.Empty;
}