using comic.Models;

namespace comic.ViewModels;

public class EditProductViewModel
{
    public int Id
    {
        get;
        set;
    }

    public string Name
    {
        get;
        set;
    } = null!;

    public int PublisherId
    {
        get;
        set;
    }

    public string Description
    {
        get;
        set;
    } = null!;

    public double Price
    {
        get;
        set;
    }

    public int Inventory
    {
        get;
        set;
    }

    public int CategoryId
    {
        get;
        set;
    }

    public int StoreOwnerId
    {
        get;
        set;
    }

    public List<IFormFile>? images
    {
        get;
        set;
    }
}