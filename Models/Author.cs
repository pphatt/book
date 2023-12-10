using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace comic.Models;

public class Author
{
    [Key]
    public int AuthorId { get; set; }

    public string AuthorName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
