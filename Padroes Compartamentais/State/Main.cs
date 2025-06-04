using System;

public interface IState
{
    void InsertCoin();
    void SelectProduct();
    void DispenseProduct();
}

public class VendingMachine
{
    private IState state;

    public VendingMachine()
    {
        state = new NoCoinState(this);
    }

    public void SetState(IState newState)
    {
        state = newState;
    }

    public void InsertCoin()
    {
        state.InsertCoin();
    }

    public void SelectProduct()
    {
        state.SelectProduct();
    }

    public void DispenseProduct()
    {
        state.DispenseProduct();
    }
}

public class NoCoinState : IState
{
    private VendingMachine machine;

    public NoCoinState(VendingMachine machine)
    {
        this.machine = machine;
    }

    public void InsertCoin()
    {
        Console.WriteLine("Coin inserted.");
        machine.SetState(new HasCoinState(machine));
    }

    public void SelectProduct()
    {
        Console.WriteLine("Please insert a coin first.");
    }

    public void DispenseProduct()
    {
        Console.WriteLine("Please insert a coin and select a product first.");
    }
}

public class HasCoinState : IState
{
    private VendingMachine machine;

    public HasCoinState(VendingMachine machine)
    {
        this.machine = machine;
    }

    public void InsertCoin()
    {
        Console.WriteLine("Coin already inserted.");
    }

    public void SelectProduct()
    {
        Console.WriteLine("Product selected.");
        machine.SetState(new SoldState(machine));
    }

    public void DispenseProduct()
    {
        Console.WriteLine("Please select a product first.");
    }
}

public class SoldState : IState
{
    private VendingMachine machine;

    public SoldState(VendingMachine machine)
    {
        this.machine = machine;
    }

    public void InsertCoin()
    {
        Console.WriteLine("Please wait, dispensing product.");
    }

    public void SelectProduct()
    {
        Console.WriteLine("Already dispensing product.");
    }

    public void DispenseProduct()
    {
        Console.WriteLine("Product dispensed.");
        machine.SetState(new NoCoinState(machine));
    }
}

class Program
{
    static void Main(string[] args)
    {
        var vendingMachine = new VendingMachine();

        vendingMachine.InsertCoin();
        vendingMachine.SelectProduct();
        vendingMachine.DispenseProduct();
    }
}