using System;

public interface IShippingStrategy
{
    decimal Calculate(decimal amount);
}

public class EconomyShipping : IShippingStrategy
{
    public decimal Calculate(decimal amount)
    {
        return amount * 0.10m; // 10% do valor
    }
}

public class ExpressShipping : IShippingStrategy
{
    public decimal Calculate(decimal amount)
    {
        return amount * 0.25m; // 25% do valor
    }
}

public class ShippingCalculator
{
    private IShippingStrategy strategy;

    public ShippingCalculator(IShippingStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void SetStrategy(IShippingStrategy strategy)
    {
        this.strategy = strategy;
    }

    public decimal Calculate(decimal amount)
    {
        return strategy.Calculate(amount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var calculator = new ShippingCalculator(new EconomyShipping());
        Console.WriteLine(calculator.Calculate(100).ToString("F0"));

        calculator.SetStrategy(new ExpressShipping());
        Console.WriteLine(calculator.Calculate(100).ToString("F0"));
    }
}