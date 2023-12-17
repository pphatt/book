using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace comic.Models;

public class StoreOwner
{
    [Key]
    public int StoreOwnerId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
    
    public string FullName => $"{FirstName} {LastName}";

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
