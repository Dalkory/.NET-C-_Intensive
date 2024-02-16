using System;
using System.Linq;
using System.IO;

string path = @"us_names.txt";
if (!File.Exists(path))
{
    Console.Write("Not found file.\n");
    return;
}
string[] names = File.ReadAllLines(path);

Console.Write(">Enter name: \n");
string? name1 = Console.ReadLine();
string name = " ";
if (name1 != null) {
    name = name1.Replace(" ", "");
}
if (string.IsNullOrWhiteSpace(name)|| (name.All(char.IsDigit))) {
    Console.Error.WriteLine("Something went wrong. Check your input and retry.");
    return;
}

if (names.Contains(name))
{
    Console.WriteLine($">Hello, {name}!");
}
else
{
    foreach (string nameik in names)
    {
        int distance = GetLevenshteinDistance(name, nameik);
        
        if (distance < 2)
        {
            Console.WriteLine($">Did you mean \"{nameik}\"? Y/N");
            string? answer = Console.ReadLine();
            
            if (answer == "Y" || answer == "y")
            {
                Console.WriteLine($">Hello, {nameik}!");
                return;
            }
            else if (answer == "N" || answer == "n")
            {
                continue;
            }
            else 
            {
                Console.Error.WriteLine("Something went wrong. Check your input and retry.");
                return;
            }
        }
    }
    Console.WriteLine(">Your name was not found.");
}

static int GetLevenshteinDistance(string word1, string word2)
{
    int[,] distance = new int[word1.Length + 1, word2.Length + 1];

    for (int i = 0; i <= word1.Length; i++)
    {
        distance[i, 0] = i;
    }

    for (int j = 0; j <= word2.Length; j++)
    {
        distance[0, j] = j;
    }

    for (int i = 1; i <= word1.Length; i++)
    {
        for (int j = 1; j <= word2.Length; j++)
        {
            int cost = word1[i - 1] == word2[j - 1] ? 0 : 1;

            distance[i, j] = Math.Min(
                Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1),
                distance[i - 1, j - 1] + cost);
        }
    }

    return distance[word1.Length, word2.Length];
}