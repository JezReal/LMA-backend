using System.ComponentModel.DataAnnotations;

namespace LMA_backend.Auth.Dtos;

public class RegisterDto
{
    [Required]
    public string EmailAddress { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}