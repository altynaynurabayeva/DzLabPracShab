using System;
using System.Collections.Generic;
using System.Linq;

// Mediator Pattern
public interface IMediator
{
    void Register(User user);
    void Send(string message, User from);
    void SendPrivate(string message, User from, string toUserName);
}

public class ChatRoom : IMediator
{
    List<User> users = new();

    public void Register(User user)
    {
        users.Add(user);
        user.SetMediator(this);
        foreach (var u in users)
            u.Receive($"(Система): {user.Name} вошёл в чат");
    }

    public void Send(string message, User from)
    {
        foreach (var u in users.Where(x => x != from))
            u.Receive($"{from.Name}: {message}");
    }

    public void SendPrivate(string message, User from, string toUserName)
    {
        var target = users.FirstOrDefault(u => u.Name == toUserName);
        if (target != null)
            target.Receive($"(лично) {from.Name}: {message}");
        else
            from.Receive($"(Система): {toUserName} не найден");
    }
}

public class User
{
    public string Name;
    IMediator _mediator;

    public User(string name) => Name = name;
    public void SetMediator(IMediator m) => _mediator = m;

    public void Send(string msg) => _mediator.Send(msg, this);
    public void SendPrivate(string msg, string to) => _mediator.SendPrivate(msg, this, to);
    public void Receive(string msg) => Console.WriteLine($"{Name} получил(а): {msg}");
}

public static class MediatorDemo
{
    public static void Run()
    {
        var chat = new ChatRoom();

        var a = new User("Алиса");
        var b = new User("Боб");
        var c = new User("Каролина");

        chat.Register(a);
        chat.Register(b);
        chat.Register(c);

        a.Send("Привет всем!");
        b.SendPrivate("Алиса, можешь помочь?", "Алиса");
        c.Send("Всем хорошего дня!");
    }
}
