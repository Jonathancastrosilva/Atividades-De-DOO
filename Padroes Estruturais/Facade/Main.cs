using System;

public class DvdPlayer
{
    public void On(){
      Console.WriteLine("DVD Player ligado.");
    }
    
    public void Play(string movie){
      Console.WriteLine($"Reproduzindo filme: {movie}");
    }
    
    public void Stop(){
      Console.WriteLine("Filme parado.");
    }
    
    public void Off(){
      Console.WriteLine("DVD Player desligado.");
    }
}

public class Projector
{
    public void On(){
      Console.WriteLine("Projetor ligado.");
    }
    
    public void SetInput(string source){
      Console.WriteLine($"Projetor configurado para entrada: {source}");
    }
    
    public void Off(){
      Console.WriteLine("Projetor desligado.");
    }
}

public class Lights
{
    public void Dim(int level){
      Console.WriteLine($"Luzes ajustadas para {level}% de intensidade.");
    }
    
    public void On(){
      Console.WriteLine("Luzes acesas.");
    }
}

public class SoundSystem
{
    public void On(){
      Console.WriteLine("Sistema de som ligado.");
    }
    
    public void SetVolume(int level){
      Console.WriteLine($"Volume ajustado para {level}.");
    }
    
    public void Off(){
      Console.WriteLine("Sistema de som desligado.");
    }
}

public class HomeTheaterFacade
{
    private DvdPlayer dvd;
    private Projector projector;
    private Lights lights;
    private SoundSystem soundSystem;

    public HomeTheaterFacade(DvdPlayer dvd, Projector projector, Lights lights, SoundSystem soundSystem)
    {
        this.dvd = dvd;
        this.projector = projector;
        this.lights = lights;
        this.soundSystem = soundSystem;
    }

    public void PlayMovie(string movie)
    {
        Console.WriteLine("\nIniciando sessão de cinema...");

        lights.Dim(10);
        projector.On();
        projector.SetInput("DVD");
        soundSystem.On();
        soundSystem.SetVolume(20);
        dvd.On();
        dvd.Play(movie);

        Console.WriteLine("Filme em reprodução.\n");
    }

    public void EndMovie()
    {
        Console.WriteLine("\nEncerrando sessão de cinema...");

        dvd.Stop();
        dvd.Off();
        projector.Off();
        soundSystem.Off();
        lights.On();

        Console.WriteLine("Filme finalizado.\n");
    }
}

class Program
{
    static void Main()
    {
        var dvd = new DvdPlayer();
        var projector = new Projector();
        var lights = new Lights();
        var soundSystem = new SoundSystem();

        var homeTheater = new HomeTheaterFacade(dvd, projector, lights, soundSystem);

        homeTheater.PlayMovie("O Senhor dos Anéis");
        homeTheater.EndMovie();
    }
}
