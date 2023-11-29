using System;
using System.Collections.Generic;

namespace comic.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public int Category { get; set; }

    public string Description { get; set; } = null!;

    public double Price { get; set; }

    public int Inventory { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<Publisher> Publishers { get; set; } = new List<Publisher>();

    public virtual ICollection<StoreOwner> StoreOwners { get; set; } = new List<StoreOwner>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
