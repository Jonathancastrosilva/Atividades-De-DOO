using System;

public interface IExpression
{
    int Interpret();
}

public class NumberExpression : IExpression
{
    private int number;

    public NumberExpression(int number)
    {
        this.number = number;
    }

    public int Interpret()
    {
        return number;
    }
}

public class AddExpression : IExpression
{
    private IExpression left;
    private IExpression right;

    public AddExpression(IExpression left, IExpression right)
    {
        this.left = left;
        this.right = right;
    }

    public int Interpret()
    {
        return left.Interpret() + right.Interpret();
    }
}

public class SubtractExpression : IExpression
{
    private IExpression left;
    private IExpression right;

    public SubtractExpression(IExpression left, IExpression right)
    {
        this.left = left;
        this.right = right;
    }

    public int Interpret()
    {
        return left.Interpret() - right.Interpret();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var expression = new AddExpression(new NumberExpression(5), new SubtractExpression(new NumberExpression(10), new NumberExpression(3)));

        Console.WriteLine(expression.Interpret());
    }
}
