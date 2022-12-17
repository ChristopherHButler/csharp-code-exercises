using System;
namespace CodeExercises.DataStructures;

public class BTree
{

    private class Node
    {
        public int value;
        public Node leftChild;
        public Node rightChild;

        public Node(int value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return $"Node.value: {this.value}";
        }
    }

    private Node Root;

    #region Public Methods

    public void Insert(int value)
    {
        var newNode = new Node(value);

        if (Root == null)
        {
            Root = newNode;
            return;
        }

        var current = Root;

        while (true)
        {
            if (value < current.value)
            {
                if (current.leftChild == null)
                {
                    current.leftChild = newNode;
                    break;
                }
                current = current.leftChild;

            }
            else
            {
                if (current.rightChild == null)
                {
                    current.rightChild = newNode;
                    break;
                }
                current = current.rightChild;
            }
        }
    }

    public bool Find(int value)
    {
        var current = Root;

        while (current != null)
        {
            if (value < current.value)
            {
                current = current.leftChild;
            }
            else if (value > current.value)
            {
                current = current.rightChild;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    public int Height()
    {
        return Height(Root);
    }

    public int Min()
    {
        return Min(Root);
    }

    public void TraversePreOrder()
    {
        TraversePreOrder(Root);
    }

    public void TraverseInOrder()
    {
        TraverseInOrder(Root);
    }

    public void TraversePostOrder()
    {
        TraversePostOrder(Root);
    }

    public bool Equals(BTree other)
    {
        return Equals(Root, other.Root);
    }

    public bool IsBinarySearchTree()
    {
        return IsBinarySearchTree(Root, Int32.MinValue, Int32.MaxValue);
    }

    public List<int> GetNodesAtDistance(int distance)
    {
        List<int> nodes = new List<int>();
        GetNodesAtDistance(Root, distance, nodes);
        return nodes;
    }

    #endregion

    #region Private Methods

    private int Height(Node root)
    {
        if (root == null)
            return -1;
        if (IsLeaf(root))
            return 0;
        return 1 + Math.Max(Height(root.leftChild), Height(root.rightChild));
    }

    // binary search tree: O(log dn)
    //private int Min()
    //{
    //    if (Root == null)
    //        throw new ArgumentNullException();
    //    var current = Root;
    //    var last = current;

    //    while(current != null)
    //    {
    //        last = current;
    //        current = current.leftChild;
    //    }
    //    return last.value;
    //}

    // recursive solution: O(n)
    private int Min(Node root)
    {
        if (IsLeaf(root))
            return root.value;

        var left = Min(root.leftChild);
        var right = Min(root.rightChild);

        return Math.Min(Math.Min(left, right), root.value);
    }

    private bool IsLeaf(Node node)
    {
        return node.leftChild == null && node.rightChild == null;
    }

    private void TraversePreOrder(Node root)
    {
        if (root == null)
            return;
        Console.WriteLine($"{root.value}");
        TraversePreOrder(root.leftChild);
        TraversePreOrder(root.rightChild);
    }

    private void TraverseInOrder(Node root)
    {
        if (root == null)
            return;
        TraversePreOrder(root.leftChild);
        Console.WriteLine($"{root.value}");
        TraversePreOrder(root.rightChild);
    }

    private void TraversePostOrder(Node root)
    {
        if (root == null)
            return;
        TraversePreOrder(root.leftChild);
        TraversePreOrder(root.rightChild);
        Console.WriteLine($"{root.value}");
    }

    private bool Equals(Node first, Node second)
    {
        if (first == null && second == null)
            return true;
        if (first != null && second != null)
        {
            return first.value == second.value &&
                Equals(first.leftChild, second.leftChild) &&
                Equals(first.rightChild, second.rightChild);
        }
        return false;
    }

    private bool IsBinarySearchTree(Node root, int min, int max)
    {
        if (root == null)
            return true;

        if (root.value < min || root.value > max)
            return false;

        return 
        IsBinarySearchTree(root.leftChild, min, max: root.value - 1) &&
        IsBinarySearchTree(root.rightChild, min: root.value + 1, max);
    }

    private void GetNodesAtDistance(Node root, int distance, List<int> nodes)
    {
        if (root == null)
            return;

        if (distance == 0)
        {
            nodes.Add(root.value);
            // Console.WriteLine(root.value);
            return;
        }

        GetNodesAtDistance(root.leftChild, distance - 1, nodes);
        GetNodesAtDistance(root.rightChild, distance - 1, nodes);

    }

    private void TraverseLevelOrder()
    {
        for (var i = 0; i <= Height(); i++)
        {
            var list = GetNodesAtDistance(i);
            foreach (var value in list)
            {
                Console.WriteLine($"value: {value}");
            }
        }
    }

    #endregion
}

