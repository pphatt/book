namespace comic.ViewModels;

public class ManageUsersViewModel
{
    public string Id
    {
        get;
        set;
    }

    public string UserName
    {
        get;
        set;
    }
    
    public string Name
    {
        get;
        set;
    }

    public string Email
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

    public IEnumerable<string> Roles
    {
        get;
        set;
    }
}