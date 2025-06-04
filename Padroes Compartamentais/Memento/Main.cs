using System;

public class PlayerMemento
{
    public int Position { get; }
    public int Health { get; }

    public PlayerMemento(int position, int health)
    {
        Position = position;
        Health = health;
    }
}

public class Player
{
    public int Position { get; set; }
    public int Health { get; set; }

    public PlayerMemento SaveState()
    {
        return new PlayerMemento(Position, Health);
    }

    public void RestoreState(PlayerMemento memento)
    {
        Position = memento.Position;
        Health = memento.Health;
    }
}

public class Caretaker
{
    private PlayerMemento memento;

    public void Save(PlayerMemento m)
    {
        memento = m;
    }

    public void Restore(Player player)
    {
        player.RestoreState(memento);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var player = new Player();
        player.Position = 5;
        player.Health = 100;

        var caretaker = new Caretaker();
        caretaker.Save(player.SaveState());

        // Altera o estado do jogador
        player.Position = 10;
        //player.Health = 90;

        // Restaura o estado salvo
        //caretaker.Restore(player);

        Console.WriteLine(player.Position);
        //Console.WriteLine(player.Health);
    }
}