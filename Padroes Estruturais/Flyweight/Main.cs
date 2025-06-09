using System;
using System.Collections.Generic;

public class TreeType
{
    public string Name { get; }
    public string Color { get; }
    public string Texture { get; }

    public TreeType(string name, string color, string texture)
    {
        Name = name;
        Color = color;
        Texture = texture;
    }

    public void Display(int x, int y)
    {
        Console.WriteLine($"Árvore {Name} na posição ({x},{y}), cor: {Color}, textura: {Texture}");
    }
}

public static class TreeFactory
{
    private static Dictionary<string, TreeType> treeTypes = new Dictionary<string,TreeType>();

    public static TreeType GetTreeType(string name, string color, string texture)
    {
        string key = $"{name}-{color}-{texture}";

        if (!treeTypes.ContainsKey(key))
        {
            treeTypes[key] = new TreeType(name, color, texture);
        }

        return treeTypes[key];
    }
}

public class Tree
{
    private int x, y;
    private TreeType type;

    public Tree(int x, int y, TreeType type)
    {
        this.x = x;
        this.y = y;
        this.type = type;
    }

    public void Draw()
    {
        type.Display(x, y);
    }
}

class Program
{
    static void Main()
    {
        List<Tree> forest = new List<Tree>();

        for (int i = 0; i < 5; i++)
        {
            TreeType pineType = TreeFactory.GetTreeType("Pinheiro", "Verde", "Textura1");
            forest.Add(new Tree(i * 10, i * 5, pineType));
        }

        for (int i = 0; i < 3; i++)
        {
            TreeType oakType = TreeFactory.GetTreeType("Carvalho", "Marrom", "Textura2");
            forest.Add(new Tree(i * 15, i * 8, oakType));
        }

        foreach (var tree in forest)
        {
            tree.Draw();
        }
    }
}
