using System.ComponentModel.DataAnnotations;

namespace LMA_backend.Auth.Dtos;

public class LoginDto
{
    [Required]
    public string EmailAddress = string.Empty;
    [Required]
    public string Password = string.Empty;
}