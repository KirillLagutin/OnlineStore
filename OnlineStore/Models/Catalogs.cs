using System.Collections.Concurrent;

namespace OnlineStore.Models;

/*Класс через потокобезопасную коллекцию*/
public class Tabs 
{
    private ConcurrentBag<Tab> _tabs = new()
    {
        new Tab("IPad", 13, 30000),
        new Tab("Samsung", 11.5, 25000),
        new Tab("Other", 10, 10000)
    };

    public ConcurrentBag<Tab> GetTabs()
    {
        return _tabs;
    }

    public void AddTabs(Tab tab)
    {
        _tabs.Add(tab);
    }

    public void DeleteTab(int id)
    {
        var list = _tabs.ToList();
        list.RemoveAt(id);
        _tabs = new ConcurrentBag<Tab>(list);
    }
}

/*Клас через lock*/
public class Phones
{
    private readonly object _syncObj = new();

    private List<Phone> _phones = new()
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

    public IReadOnlyList<Phone> GetPhones()
    {
        lock (_syncObj)
        {
            return _phones.ToList();
        }
    }
    
    public void AddPhone(Phone phone)
    {
        lock (_syncObj)
        {
            _phones.Add(phone);
        }
    }

    public void ClearPhones()
    {
        lock (_syncObj)
        {
            _phones.Clear();
        }
    }
}