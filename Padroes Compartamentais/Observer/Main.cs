using System;
using System.Collections.Generic;

public interface IObserver
{
    void Update(string status);
}

public class Order
{
    private List<IObserver> observers = new List<IObserver>();
    private string status;

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void UpdateStatus(string newStatus)
    {
        status = newStatus;
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(status);
        }
    }
}

public class EmailNotifier : IObserver
{
    public void Update(string status)
    {
        Console.WriteLine($"Email: Your order is now {status}.");
    }
}

public class SmsNotifier : IObserver
{
    public void Update(string status)
    {
        Console.WriteLine($"SMS: Your order is now {status}.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var order = new Order();
        order.Attach(new EmailNotifier());
        order.Attach(new SmsNotifier());

        order.UpdateStatus("Shipped");
    }
}