using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace comic.Models;

public class User : IdentityUser
{
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