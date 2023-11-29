using System;
using System.Collections.Generic;

namespace comic.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string? AuthorName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
