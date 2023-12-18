using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace comic.Models;

public class User : IdentityUser
{
    public string? Name
    {
        get;
        set;
    }
    
    public string? FirstName
    {
        get;
        set;
    }
    
    public string? LastName
    {
        get;
        set;
    }

    public int? Age
    {
        get;
        set;
    }

    public string? Sex
    {
        get;
        set;
    }

    public DateTime? Birthday
    {
        get;
        set;
    }

    public virtual ICollection<Cart> Carts
    {
        get;
        set;
    } = new List<Cart>();

    public virtual ICollection<Order> Orders
    {
        get;
        set;
    } = new List<Order>();
}