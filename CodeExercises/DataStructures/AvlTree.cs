using System;
using System.Xml.Linq;

namespace CodeExercises.DataStructures;

public class AvlTree
{
    private class AvlNode
    {
        public int Value { get; set; }
        public int Height { get; set; }
        public AvlNode LeftChild { get; set; }
        public AvlNode RightChild { get; set; }

        public AvlNode(int value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return $"Node.value: {this.Value}";
        }
    }

    private AvlNode Root { get; set; }

    public void Insert(int value)
    {
        Root = Insert(Root, value);
    }

    private AvlNode Insert(AvlNode root, int value)
    {
        if (root == null)
        {
            return new AvlNode(value);
        }

        if (value < root.Value)
        {
            root.LeftChild = Insert(root.LeftChild, value);
        }
        else
        {
            root.RightChild = Insert(root.RightChild, value);
        }
        root.Height = Math.Max(GetNodeHeight(root.LeftChild), GetNodeHeight(root.RightChild)) + 1;

        return BalanceNode(Root);
    }
    private int GetNodeHeight(AvlNode node)
    {
        return (node == null) ? -1 : node.Height;
    }

    private AvlNode BalanceNode(AvlNode node)
    {
        if (IsLeftHeavy(node))
        {
            if (GetBalanceFactor(node.LeftChild) < 0)
            {
                Console.WriteLine($"Left Rotate {node.LeftChild}");
                node.LeftChild = RotateLeft(node.LeftChild);
            }
            Console.WriteLine($"Right Rotate {node.Value}");
            return RotateRight(node);     
            
        }  
        else if (IsRightHeavy(node))
        {
            if (GetBalanceFactor(node.RightChild) > 0)
            {
                Console.WriteLine($"Right Rotate {node.RightChild}");
                node.RightChild = RotateRight(node.RightChild);
            }
            Console.WriteLine($"Left Rotate {node.Value}");
            return RotateLeft(node);    
            
        }
        return node;
    }

    private AvlNode RotateLeft(AvlNode root)
    {
        var newRoot = root.RightChild;

        root.RightChild = newRoot.LeftChild;
        newRoot.LeftChild = root;

        SetHeight(root);
        SetHeight(newRoot);

        return newRoot;
    }

    private AvlNode RotateRight(AvlNode root)
    {
        var newRoot = root.LeftChild;

        root.LeftChild = newRoot.RightChild;
        newRoot.RightChild = root;

        SetHeight(root);
        SetHeight(newRoot);

        return newRoot;
    }

    private bool IsLeftHeavy(AvlNode node)
    {
        return GetBalanceFactor(node) > 1;
    }

    private bool IsRightHeavy(AvlNode node)
    {
        return GetBalanceFactor(node) < -1;
    }

    private int GetBalanceFactor(AvlNode node)
    {
        return (node == null) ? 0 : GetNodeHeight(node.LeftChild) - GetNodeHeight(node.RightChild);
    }

    private void SetHeight(AvlNode node)
    {
        node.Height = Math.Max(GetNodeHeight(node.LeftChild), GetNodeHeight(node.RightChild)) + 1;
    }

}

