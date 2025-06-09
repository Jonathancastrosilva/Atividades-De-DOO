using System;
using System.Collections.Generic;

public interface IImage
{
  void Display();
}

public class RealImage : IImage
{
  private string fileName;

  public RealImage(string fileName){
    this.fileName = fileName;
    LoadFromDisk();
  }

  private void LoadFromDisk(){
    Console.WriteLine($"Carregando imagem {fileName} do disco...");
  }

  public void Display(){
    Console.WriteLine($"Exibindo imagem {fileName}");
  }
}

public class ProxyImage : IImage
{
  private string fileName;
  private RealImage realImage;

  public ProxyImage(string fileName){
    this.fileName = fileName;
  }

  public void Display(){
    if (realImage == null)
    {
      realImage = new RealImage(fileName);
    }
    realImage.Display();
  }
}

class Program
{
  static void Main(){
      
    IImage image1 = new ProxyImage("foto1.jpg");
    IImage image2 = new ProxyImage("foto2.jpg");
      
    Console.WriteLine("Imagens criadas, mas não carregadas ainda.");

    Console.WriteLine("\nExibindo imagem 1 pela primeira vez:");
    image1.Display();

    Console.WriteLine("\nExibindo imagem 1 novamente:");
    image1.Display();

    Console.WriteLine("\nExibindo imagem 2 pela primeira vez:");
    image2.Display();
  }
}
