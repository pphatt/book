using System;
using System.Collections.Generic;

namespace comic.Models;

public partial class Image
{
    public int ImageId { get; set; }

    public string ImageName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
