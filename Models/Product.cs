﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace comic.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public int PublisherId { get; set; }

    public string Description { get; set; } = null!;

    public double Price { get; set; }

    public int Inventory { get; set; }

    public int CategoryId { get; set; }

    public int StoreOwnerId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Publisher Publisher { get; set; } = null!;

    public virtual StoreOwner StoreOwner { get; set; } = null!;

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
