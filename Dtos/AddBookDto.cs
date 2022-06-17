using System.ComponentModel.DataAnnotations;

namespace LMA_backend.Dtos;

public class AddBookDto
{
    [Required]
    [MaxLength(250)]
    public string Title { get; set; }
    [Required]
    public string AuthorFirstName { get; set; }
    [Required]
    public string AuthorLastName { get; set; }
}