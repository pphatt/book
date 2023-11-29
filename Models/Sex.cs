using System;
using System.Collections.Generic;

namespace comic.Models;

public partial class Sex
{
    public int SexId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
