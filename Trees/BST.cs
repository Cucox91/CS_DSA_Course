namespace Trees;

public class BST
{
    private TreeNode? _root;

    public BST()
    {
        _root = null;
    }

    // This Insert always starts at the root level.
    public void Insert(int value)
    {
        if (_root == null)
        {
            _root = new TreeNode { Value = value };
        }
        else
        {
            InsertIteratively(value, _root);
        }
    }

    // This is the insert that internaly search for the insertion position.
    private void Insert(int value, TreeNode currentNode)
    {
        if (currentNode.Value <= value)
        {
            if (currentNode.Right != null)
            {
                Insert(value, currentNode.Right);
            }
            else
            {
                currentNode.Right = new TreeNode { Value = value, Parent = currentNode };
            }
        }
        else
        {
            if (currentNode.Left != null)
            {
                Insert(value, currentNode.Left);
            }
            else
            {
                currentNode.Left = new TreeNode { Value = value, Parent = currentNode };
            }
        }
    }

    private void InsertIteratively(int value, TreeNode root)
    {
        var current = root;
        while (true)
        {
            if (value <= current!.Value)
            {
                if (current.Left == null)
                {
                    current.Left = new TreeNode { Value = value, Parent = current };
                    break;
                }
                else
                {
                    current = current.Left;
                }
            }
            else
            {
                if (current.Right == null)
                {
                    current.Right = new TreeNode { Value = value, Parent = current };
                    break;
                }
                else
                {
                    current = current.Right;
                }
            }
        }
    }

    public void TraversePostOrder()
    {
        if (_root == null)
        {
            Console.WriteLine("Tree Empty");
        }
        else
        {
            TraversePostOrder(_root);
            Console.WriteLine();
        }
    }

    private void TraversePostOrder(TreeNode currentNode)
    {
        if (currentNode.Left != null)
        {
            TraversePostOrder(currentNode.Left);
        }
        if (currentNode.Right != null)
        {
            TraversePostOrder(currentNode.Right);
        }

        Console.Write(currentNode.Value + " ");
    }

    public void TraversePreOrder()
    {
        if (_root == null)
        {
            Console.WriteLine("Tree Empty");
        }
        else
        {
            TraversePreOrder(_root);
            Console.WriteLine();
        }
    }

    private void TraversePreOrder(TreeNode currentNode)
    {
        Console.Write(currentNode.Value + " ");

        if (currentNode.Left != null)
        {
            TraversePreOrder(currentNode.Left);
        }
        if (currentNode.Right != null)
        {
            TraversePreOrder(currentNode.Right);
        }
    }

    public void TraverseInOrder()
    {
        if (_root == null)
        {
            Console.WriteLine("Tree Empty");
        }
        else
        {
            TraverseInOrder(_root);
            Console.WriteLine();
        }
    }

    private void TraverseInOrder(TreeNode currentNode)
    {
        if (currentNode.Left != null)
        {
            TraverseInOrder(currentNode.Left);
        }

        Console.Write(currentNode.Value + " ");

        if (currentNode.Right != null)
        {
            TraverseInOrder(currentNode.Right);
        }
    }

    public TreeNode? LookupNode(int value)
    {
        if (_root != null)
        {
            return LookupNode(value, _root);
        }
        return null;
    }

    private TreeNode? LookupNode(int value, TreeNode? current)
    {
        while (current != null)
        {
            if (current.Value == value)
            {
                return current;
            }
            else
            {
                if (value < current.Value)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
        }
        return null;
    }

    public bool Remove(int value)
    {

        var nodeToDelete = LookupNode(value, _root);
        if (nodeToDelete == null)
        {
            Console.WriteLine("Element Doesn't Exist");
        }
        else
        {
            // Leaf Note
            if (nodeToDelete.Parent != null && nodeToDelete.Left == null && nodeToDelete.Right == null)
            {
                if (nodeToDelete.Parent.Left != null && nodeToDelete.Value == nodeToDelete.Parent.Left.Value)
                {
                    nodeToDelete.Parent.Left = null;
                    return true;
                }
                if (nodeToDelete.Parent.Right != null && nodeToDelete.Value == nodeToDelete.Parent.Right.Value)
                {
                    nodeToDelete.Parent.Right = null;
                    return true;
                }
            }
            else if (nodeToDelete.Parent == null && nodeToDelete.Left == null && nodeToDelete.Right == null) // Last element Remove Root.
            {
                _root = null;
                return true;
            }

            // One Child (If moved to end will solve the problem of too many comparisons)
            if ((nodeToDelete.Right == null && nodeToDelete.Left != null) || (nodeToDelete.Left == null && nodeToDelete.Right != null))
            {
                if (nodeToDelete.Left != null)
                {
                    var newnode = nodeToDelete.Left;

                    nodeToDelete.Value = newnode.Value;
                    nodeToDelete.Left = newnode.Left;
                    nodeToDelete.Right = newnode.Right;
                    return true;
                }
                if (nodeToDelete.Right != null)
                {
                    var newnode = nodeToDelete.Right;
                    nodeToDelete.Value = newnode.Value;
                    nodeToDelete.Left = newnode.Left;
                    nodeToDelete.Right = newnode.Right;
                    return false;
                }
            }

            // Two Childs. Needs to find the smallest of the bigest after me.
            if (nodeToDelete.Left != null && nodeToDelete.Right != null)
            {
                // Find Smallest to my Right.
                var currentSmallest = nodeToDelete.Right;
                while (currentSmallest.Left != null)
                {
                    if (currentSmallest.Left != null)
                    {
                        currentSmallest = currentSmallest.Left;
                    }
                    // else if (currentSmallest.Right != null)
                    // {
                    //     currentSmallest = currentSmallest.Right;
                    // }
                }

                if (currentSmallest.Right != null)
                {
                    if (currentSmallest.Parent != null)
                    {
                        currentSmallest.Parent.Left = currentSmallest.Right;
                    }
                }

                if (currentSmallest.Parent != null && currentSmallest.Parent.Left != null && currentSmallest.Parent.Left.Value == currentSmallest.Value)
                {
                    currentSmallest.Parent.Left = null;
                }
                else if (currentSmallest.Parent != null && currentSmallest.Parent.Right != null && currentSmallest.Parent.Right.Value == currentSmallest.Value)
                {
                    currentSmallest.Parent.Right = null;
                }

                // Replace To Delete with Smallest and remove smallest.
                if (currentSmallest.Parent != null && currentSmallest.Parent.Left != null && currentSmallest.Parent.Left.Value == currentSmallest.Value)
                {
                    currentSmallest.Parent.Left = null;
                }
                else if (currentSmallest.Parent != null && currentSmallest.Parent.Right != null && currentSmallest.Parent.Right.Value == currentSmallest.Value)
                {
                    currentSmallest.Parent.Right = null;
                }

                nodeToDelete.Value = currentSmallest.Value;
            }
        }
        return false;
    }
}

/*
Notice that the traversals can be done by using a while loop and to be solved
Iteratively. But for Simplicity we are coding it recursively.
*/