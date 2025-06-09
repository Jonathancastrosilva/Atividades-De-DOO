using System;

public interface INotification
{
    void Send(string message);
}

public class BaseNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Notificação básica: {message}");
    }
}

public abstract class NotificationDecorator : INotification
{
    protected INotification wrappedNotification;

    public NotificationDecorator(INotification notification)
    {
        wrappedNotification = notification;
    }

    public virtual void Send(string message)
    {
        wrappedNotification.Send(message);
    }
}

public class EmailDecorator : NotificationDecorator
{
    public EmailDecorator(INotification notification) : base(notification) {}

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"Enviando por E-mail: {message}");
    }
}

public class SMSDecorator : NotificationDecorator
{
    public SMSDecorator(INotification notification) : base(notification) {}

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"Enviando por SMS: {message}");
    }
}

public class PushDecorator : NotificationDecorator
{
    public PushDecorator(INotification notification) : base(notification) {}

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"Enviando por Push Notification: {message}");
    }
}

class Program
{
    static void Main()
    {
        INotification notificacao = new BaseNotification();

        notificacao = new EmailDecorator(notificacao);
        notificacao = new SMSDecorator(notificacao);
        notificacao = new PushDecorator(notificacao);

        notificacao.Send("Seu pedido foi enviado!");
    }
}