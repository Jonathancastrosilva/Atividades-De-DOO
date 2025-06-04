using System;
using System.Collections;
using System.Collections.Generic;

public class Playlist : IEnumerable<string>
{
    private List<string> songs = new List<string>();
    private bool shuffle = false;

    public void Add(string song)
    {
        songs.Add(song);
    }

    // Método para ativar ou desativar aleatoriedade
    public void SetShuffle(bool shuffle)
    {
        this.shuffle = shuffle;
    }

    public IEnumerator<string> GetEnumerator()
    {
        if (shuffle)
        {
            // Retorna um iterador aleatorio
            List<string> shuffledSongs = new List<string>(songs);
            Random rand = new Random();
            int n = shuffledSongs.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                var value = shuffledSongs[k];
                shuffledSongs[k] = shuffledSongs[n];
                shuffledSongs[n] = value;
            }

            foreach (var song in shuffledSongs)
            {
                yield return song;
            }
        }
        else
        {
            // Iterador ordenado
            foreach (var song in songs)
            {
                yield return song;
            }
        }
    }

    // Implementação obrigatória para IEnumerable
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var playlist = new Playlist();
        playlist.Add("Song 1");
        playlist.Add("Song 2");
        playlist.Add("Song 3");

        // Iteração ordenada
        Console.WriteLine("Iteracao ordenada:");
        foreach (var song in playlist)
        {
            Console.WriteLine(song);
        }

        // Iteração aleatória
        Console.WriteLine("\nIteracao aleatoria:");
        playlist.SetShuffle(true);
        foreach (var song in playlist)
        {
            Console.WriteLine(song);
        }
    }
}

