namespace OnlineStore.Models;

public class Catalog
{
    public static List<Phone> phones = new()
    {
        new Phone
        {
            Id = 0,
            Brand = "Samsung",
            Model = "A40",
            ReleaseDate = DateTime.Parse("12.04.2019"),
            Price = 18300
        },
        new Phone
        {
            Id = 1,
            Brand = "Nokia",
            Model = "XR20",
            ReleaseDate = DateTime.Parse("27.08.2021"),
            Price = 37900
        },
        new Phone
        {
            Id = 2,
            Brand = "IPhone",
            Model = "X",
            ReleaseDate = DateTime.Parse("11.03.2017"),
            Price = 21400
        }
    };
}