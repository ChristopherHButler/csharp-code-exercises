using System;
namespace CodeExercises.DataStructures;

public class Trie
{
    public static int ALPHABET_SIZE = 26;

    private class Node
    {
        public char Value { get; set; }
        public Node[] Children { get; set; } = new Node[ALPHABET_SIZE];
        public bool IsEndOfWord { get; set; }

        public Node(char value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return $"Node.value: {this.Value}";
        }

        public bool HasChild(char ch)
        {
            return Array.Exists(Children, item => item.Value == ch);
        }
    }

    private Node Root { get; set; }

    public void Insert(string word)
    {
        var current = Root;

        foreach (var ch in word.ToCharArray())
        {
            var index = ch - 'a';
            if (current.Children[index] == null)
            {
                current.Children[index] = new Node(ch);
            }
            current = current.Children[index];
        }
        current.IsEndOfWord = true;
    }

}

