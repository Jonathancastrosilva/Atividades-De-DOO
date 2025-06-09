using System;

public interface IColor
{
    void ApplyColor();
}

public class RedColor : IColor
{
    public void ApplyColor()
    {
        Console.WriteLine("Aplicando a cor vermelha.");
    }
}

public class BlueColor : IColor
{
    public void ApplyColor()
    {
        Console.WriteLine("Aplicando a cor azul.");
    }
}


public abstract class Shape
{
    protected IColor color;

    public Shape(IColor color)
    {
        this.color = color;
    }

    public abstract void Draw();
}

public class Circle : Shape
{
    public Circle(IColor color) : base(color) {}

    public override void Draw()
    {
        Console.Write("Desenhando um círculo. ");
        color.ApplyColor();
    }
}

public class Square : Shape
{
    public Square(IColor color) : base(color) {}

    public override void Draw()
    {
        Console.Write("Desenhando um quadrado. ");
        color.ApplyColor();
    }
}

class Program
{
    static void Main()
    {
        Shape redCircle = new Circle(new RedColor());
        Shape blueCircle = new Circle(new BlueColor());
        Shape redSquare = new Square(new RedColor());
        Shape blueSquare = new Square(new BlueColor());
        
        redCircle.Draw();
        blueCircle.Draw();
        redSquare.Draw();
        blueSquare.Draw();
    }
}
