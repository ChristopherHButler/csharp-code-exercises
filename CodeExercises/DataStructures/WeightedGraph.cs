using System;
namespace CodeExercises.DataStructures;

public class WeightedGraph
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

    private class Edge
    {
        private Node from;
        private Node to;
        private int weight;

        public Edge(Node from, Node to, int weight)
        {
            this.from = from;
            this.to = to;
            this.weight = weight;
        }

        public override string ToString()
        {
            return $"{from} -> {to}";
        }
    }

    private Dictionary<string, Node> nodes = new Dictionary<string, Node>();
    private Dictionary<Node, List<Edge>> adjacencyList = new Dictionary<Node, List<Edge>>();

    public void AddNode(string label)
    {
        var node = new Node(label);
        nodes.Add(label, node);
        adjacencyList.Add(node, new List<Edge>());
    }

    public void AddEdge(string from, string to, int weight)
    {
        var fromNode = nodes[from];
        if (fromNode == null)
            throw new ArgumentNullException();

        var toNode = nodes[to];
        if (toNode == null)
            throw new ArgumentNullException();

        adjacencyList[fromNode].Add(new Edge(fromNode, toNode, weight));
        adjacencyList[toNode].Add(new Edge(toNode, fromNode, weight));
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
}

