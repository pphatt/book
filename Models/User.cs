using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace comic.Models;

public partial class User
{
    [Key]
    public int UserId
    {
        get;
        set;
    }

    public string Email
    {
        get;
        set;
    } = null!;

    public string Password
    {
        get;
        set;
    } = null!;

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

    public string? Sex
    {
        get;
        set;
    }

    public string? PhoneNumber
    {
        get;
        set;
    }

    public int RoleId
    {
        get;
        set;
    }

    public DateTime CreatedAt
    {
        get;
        set;
    }

    public DateTime? UpdatedAt
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

    public virtual Role Role
    {
        get;
        set;
    } = null!;
}