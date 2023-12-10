using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace comic.Models;

public class Image
{
    public int ImageId { get; set; }

    public string ImageName { get; set; } = null!;

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;
}
