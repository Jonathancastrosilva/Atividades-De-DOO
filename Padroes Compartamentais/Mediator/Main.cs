using System;
using System.Collections.Generic;

public interface IMediator
{
    void SendMessage(string message, User sender);
    void RegisterUser(User user);
}

public class ChatMediator : IMediator
{
    private List<User> users = new List<User>();

    public void RegisterUser(User user)
    {
        users.Add(user);
    }

    public void SendMessage(string message, User sender)
    {
        foreach (var user in users)
        {
            if (user != sender)
            {
                Console.WriteLine($"{sender.Name} to {user.Name}: {message}");
            }
        }
    }
}

public class User
{
    public string Name { get; private set; }
    private IMediator mediator;

    public User(string name, IMediator mediator)
    {
        Name = name;
        this.mediator = mediator;
        mediator.RegisterUser(this);
    }

    public void SendMessage(string message)
    {
        mediator.SendMessage(message, this);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var mediator = new ChatMediator();

        var user1 = new User("Alice", mediator);
        var user2 = new User("Bob", mediator);

        user1.SendMessage("Hello, Bob!");
        user2.SendMessage("Hi, Alice!");
    }
}