
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal.");
            return;
        }

        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (var entry in _entries)
            {
                string escapedDate = EscapeCsv(entry._date);
                string escapedPrompt = EscapeCsv(entry._promptText);
                string escapedEntry = EscapeCsv(entry._entryText);
                outputFile.WriteLine($"{escapedDate},{escapedPrompt},{escapedEntry}");
            }
        }
        Console.WriteLine($"Journal saved to {file}.");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"File {file} does not exist.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            // Split CSV line handling quotes
            string[] parts = Regex.Split(line, @",(?=(?:[^""]*""[^""]*"")*[^""]*$)");

            if (parts.Length == 3)
            {
                string date = UnescapeCsv(parts[0]);
                string prompt = UnescapeCsv(parts[1]);
                string entryText = UnescapeCsv(parts[2]);
                Entry entry = new Entry(date, prompt, entryText);
                _entries.Add(entry);
            }
        }
        Console.WriteLine($"Journal loaded from {file}.");
    }

    private string EscapeCsv(string s)
    {
        if (s.Contains("\"") || s.Contains(",") || s.Contains("\n"))
        {
            s = s.Replace("\"", "\"\"");
            return $"\"{s}\"";
        }
        return s;
    }

    private string UnescapeCsv(string s)
    {
        if (s.StartsWith("\"") && s.EndsWith("\""))
        {
            s = s.Substring(1, s.Length - 2).Replace("\"\"", "\"");
        }
        return s;
    }
}