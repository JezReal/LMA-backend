using System.ComponentModel.DataAnnotations;

namespace LMA_backend.Models;

public class Credential
{
    [Key] 
    [Required] 
    public long CredentialId { get; set; }

    [Required] 
    public string EmailAddress { get; set; } = string.Empty;
    [Required] 
    public byte[] Password { get; set; } = Array.Empty<Byte>();
}