using System;
using System.Collections.Generic;

namespace comic.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? SexId { get; set; }

    public string? PhoneNumber { get; set; }

    public int RoleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role Role { get; set; } = null!;

    public virtual Sex? Sex { get; set; }
}
