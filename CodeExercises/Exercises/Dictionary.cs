using System;
namespace CodeExercises.Exercises;

public class Dictionary
{
    private class Entry
    {
        public int Key { get; set; }
        public string Value { get; set; }

        public Entry(int key, string value)
        {
            Key = key;
            Value = value;
        }
    }

    private LinkedList<Entry>[] entries = new LinkedList<Entry>[5];

    public string Get(int key)
    {
        var index = hash(key);
        var bucket = entries[index];
        if (bucket != null)
        {
            foreach (var entry in bucket)
            {
                if (entry.Key == key)
                    return entry.Value;
            
            }
        }
        return string.Empty;
    }

    public void Put(int key, string value)
    {
        var index = hash(key);
        var bucket = entries[index];

        if (bucket == null)
            bucket = new LinkedList<Entry>();

        foreach (var entry in bucket)
        {
            if (entry.Key == key)
            {
                entry.Value = value;
                return;
            }
        }

        bucket.AddLast(new Entry(key, value));
    }

    public void Remove(int key)
    {
        var index = hash(key);
        var bucket = entries[index];

        if (bucket == null)
            throw new Exception();

        foreach (var entry in bucket)
        {
            if (entry.Key == key)
            {
                bucket.Remove(entry);
                return;
            }
        }
        throw new Exception();
    }

    private int hash(int key)
    {
        return Math.Abs(key) % entries.Length;
    }

    
}

