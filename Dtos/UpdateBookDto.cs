using System.ComponentModel.DataAnnotations;

namespace Lma_backend.Dtos;

public class UpdateBookDto
{
    [Required]
    [MaxLength(250)]
    public string Title { get; set; }
    [Required]
    public string AuthorFirstName { get; set; }
    [Required]
    public string AuthorLastName { get; set; }
}