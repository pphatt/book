using System;
using System.Collections.Generic;

namespace comic.Models;

public partial class StoreOwner
{
    public int StoreOwnerId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? SexId { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
