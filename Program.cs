using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "./names.txt";
        string fileContent = File.ReadAllText(filePath);
        string[] lines = fileContent.Split(',');

        List<Player> players = new List<Player>();

        foreach (var line in lines)
        {
            var parts = line.Trim().Split(':');

            if (parts.Length != 2)
            {
                Console.WriteLine($"Invalid entry: {line}");
                continue;
            }

            players.Add(new Player(parts[0].Trim(), parts[1].Trim()));
        }

        if (players.Count < 2)
        {
            Console.WriteLine("Not enough players.");
            return;
        }

        var buckets = players
            .GroupBy(p => p.Bucket)
            .ToDictionary(g => g.Key, g => g.ToList());

        List<Player> givers = new List<Player>(players);
        List<Player> receivers = new List<Player>(players);

        Random rand = new Random();
        receivers = receivers.OrderBy(x => rand.Next()).ToList();

        bool valid = false;
        while (!valid)
        {
            valid = true;

            for (int i = 0; i < givers.Count; i++)
            {
                if (givers[i].Name == receivers[i].Name ||
                    givers[i].Bucket == receivers[i].Bucket)
                {
                    valid = false;
                    receivers = receivers.OrderBy(x => rand.Next()).ToList();
                    break;
                }
            }
        }

        for (int i = 0; i < givers.Count; i++)
        {
            string giver = givers[i].Name;
            string receiver = receivers[i].Name;
            File.WriteAllText($"./{giver}.txt", receiver);
        }

        Console.WriteLine("Secret Santa assignment complete!");
    }
}
