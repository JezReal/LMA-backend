using System.ComponentModel.DataAnnotations;

namespace LMA_backend.Auth.Dtos;

public class RegisterDto
{
    [Required]
    public string EmailAddress = string.Empty;
    [Required]
    public string Password = string.Empty;
}