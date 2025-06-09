using System;
using System.Collections.Generic;

public interface IMenuComponent
{
    void Display();
    void Add(IMenuComponent component);
}

public class MenuItem : IMenuComponent
{
    private string name;

    public MenuItem(string name)
    {
        this.name = name;
    }

    public void Display()
    {
        Console.WriteLine($"  - {name}");
    }

    public void Add(IMenuComponent component)
    {
        throw new NotSupportedException("Não é possível adicionar a um item de menu individual.");
    }
}

public class Menu : IMenuComponent
{
    private string name;
    private List<IMenuComponent> components = new List<IMenuComponent>();

    public Menu(string name)
    {
        this.name = name;
    }

    public void Add(IMenuComponent component)
    {
        components.Add(component);
    }

    public void Display()
    {
        Console.WriteLine($"\n{name}:");
        foreach (var component in components)
        {
            component.Display();
        }
    }
}

class Program
{
    static void Main()
    {
        var massa = new MenuItem("Macarrão");
        var molho = new MenuItem("Molho De Tomate");
        var queijo = new MenuItem("Parmesão");
        var sobremesa = new MenuItem("Mousse De Maracujá");
        var pratoPrincipal = new Menu("Prato Principal");
        
        pratoPrincipal.Add(massa);
        pratoPrincipal.Add(molho);
        pratoPrincipal.Add(queijo);

        var sobremesas = new Menu("Sobremesa");
        
        sobremesas.Add(sobremesa);

        var menuCompleto = new Menu("Menu do Dia");
        
        menuCompleto.Add(pratoPrincipal);
        menuCompleto.Add(sobremesas);
        
        menuCompleto.Display();
    }
}
