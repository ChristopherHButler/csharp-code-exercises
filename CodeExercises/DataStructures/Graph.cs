using System;
namespace CodeExercises.DataStructures;

public class Graph
{
    private class Node
    {
        private string label;

        public Node(string label)
        {
            this.label = label;
        }

        public override string ToString()
        {
            return $"{this.label}";
        }
    }

    private Dictionary<string, Node> nodes = new Dictionary<string, Node>();
    private Dictionary<Node, List<Node>> adjacencyList = new Dictionary<Node, List<Node>>();

    public void AddNode(string label)
    {
        var node = new Node(label);
        nodes.Add(label, node);
        adjacencyList.Add(node, new List<Node>());
    }

    public void AddEdge(string from, string to)
    {
        var fromNode = nodes[from];
        if (fromNode == null)
            throw new ArgumentNullException();

        var toNode = nodes[to];
        if (toNode == null)
            throw new ArgumentNullException();

        adjacencyList[fromNode].Add(toNode);
    }

    public void Print()
    {
        foreach (var src in adjacencyList.Keys)
        {
            var targets = adjacencyList[src];
            if (targets.Count > 0)
            {
                Console.WriteLine($"{src} is connected to {targets}");
            }
        }
    }

    public void RemoveNode(string label)
    {
        var node = nodes[label];
        if (node == null)
            return;

        foreach (var n in adjacencyList.Keys)
        {
            adjacencyList[n].Remove(node);
        }

        adjacencyList.Remove(node);
        nodes.Remove(label);
    }

    public void RemoveEdge(string from, string to)
    {
        var fromNode = nodes[from];
        var toNode = nodes[to];

        if (fromNode == null || toNode == null)
        {
            return;
        }

        adjacencyList[fromNode].Remove(toNode);
    }

    public void TraverseDepthFirst(string root)
    {
        TraverseDepthFirst(nodes[root], new HashSet<Node>());
    }

    private void TraverseDepthFirst(Node root, HashSet<Node> visited)
    {
        Console.WriteLine($"{root}");
        visited.Add(root);

        foreach (var node in adjacencyList[root])
        {
            if (!visited.Contains(node))
            {
                TraverseDepthFirst(node, visited);
            }
        }
    }

    public bool HasCycle()
    {
        var all = new HashSet<Node>();

        foreach (var node in nodes)
            all.Add(node.Value);

        var visiting = new HashSet<Node>();
        var visited = new HashSet<Node>();

        while (all.Count > 0)
        {
            var current = all.ToArray()[0];

            if (HasCycle(current, all, visiting, visited))
                return true;
        }
        return false;
    }

    private bool HasCycle(Node node, HashSet<Node> all, HashSet<Node> visiting, HashSet<Node> visited)
    {
        all.Remove(node);
        visiting.Add(node);

        foreach (var neighbour in adjacencyList[node])
        {
            if (visited.Contains(neighbour))
                continue;

            if (visiting.Contains(neighbour))
                return true;

            if (HasCycle(neighbour, all, visiting, visited))
                return true;
        }
        visiting.Remove(node);
        visited.Add(node);

        return false;
    }
}

