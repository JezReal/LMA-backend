﻿using System.ComponentModel.DataAnnotations;

namespace LMA_backend.Models;

public class Book
{
    [Key] 
    [Required] 
    public int BookId { get; set; }

    [Required] 
    public string Title { get; set; }

    [Required] 
    public string AuthorFirstName { get; set; }
    
    [Required]
    public string AuthorLastName { get; set; }
}