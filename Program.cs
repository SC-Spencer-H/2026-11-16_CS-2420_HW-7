// PART 1
// 1) A balanced tree is basically a tree that is as short as possible,
// arranging all the nodes in a way that results in the fewest possible levels. 
// Whether a tree is balanced or not can be determined by checking the height of 
// all the nodes.
// 2) This tree has a height of 4. We have to visit all 5 nodes to find 50. 
// A balanced version of this tree would have a height of 2.
//      10
//       \
//       20
//        \
//        30
//         \
//         40
//          \
//          50
// 3) The balance factor of a node is the height of its left child minus the height of 
// its right child. An AVL can only have factors of -1, 0, or +1, otherwise we know it is
// unbalanced.
// 4) A plain BST like the one above can form chains, which can only be navigated one node at
// a time, causing linear search time. A balanced AVL takes full advantage of the binary tree, 
// halving the number of potential results after every comparison, causing O(log n) search time
// 5) Not an AVL tree, 70 has an invalid height. 
// 50 - height 3, bf 4
// 30 - height 2, bf 1
// 70 - height 2, bf -2
// 20 - height 1, bf 1
// 40 - height 0, bf 0
// 80 - height 1, bf -1
// 10 - height 0, bf 0
// 90 - height 0, bf 0
//           50
//         /    \
//       30      70
//      /  \       \
//    20    40      80
//   /                \
// 10                  90

// PART 2
// 6a) 33 bf=0
//
// 6b)  33 bf=1
//     /
//    18 bf=0
//
// 6c)  33 bf=2     =LL=>    18 bf=0
//     /                    /  \
//    18 bf=1         bf=0 7    33 bf=0
//    / 
//   7 bf=0
//
// 6d)    18 bf=-1
//       /  \
// bf=0 7    33 bf=1
//          /
//    bf=0 25 
// 
//
// 6e)    18 bf=-1
//       /  \
// bf=0 7    33 bf=0
//          /  \
//    bf=0 25  29 bf=0
//
//
//
// 7a)      14 bf=0
//
// 7b)      14 bf=-1
//            \
//             26 bf=0
//
// 7c)      14 bf=-2        =RR=>        26 bf=0
//            \                         /  \
//             26 bf=-1          bf=0 14    38 bf=0
//              \
//               38 bf=0
//
// 7d)        26 bf=-1
//           /  \
//    bf=0 14    38 bf=-1
//                \
//                 44 bf=0
//
// 7e)        26 bf=-2       =RL=>         26 bf=-2         =RR=>            26 bf=-1
//           /  \                         /  \                              /  \
//    bf=0 14    38 bf=-2          bf=0 14    38 bf=-2               bf=0 14    41 bf=0
//                \                            \                               /  \
//                 44 bf=1                      41 bf=-1                bf=0 38    44 bf=0
//                /                              \
//          bf=0 41                               44 bf=0
//
//
//
// 8) insert 42:
//         71 bf=2
//        /  \
// bf=2 48    90 bf=0
//     /
//   39 bf=-1
//     \
//      42 bf=0
//
// LR, rotate left
//         71 bf=2
//        /  \
// bf=2 48    90 bf=0
//     /
//   39 bf=1
//   /
//  42 bf=0
//
// LL, rotate right
//             71 bf=1
//            /  \
//     bf=0 39    90 bf=0
//         /  \
//  bf=0 42    48 bf=0
//
//
//
// 9)
// - insert 52: 52 bf=0
// - insert 37: 37 bf=0, 52 bf=1
// - insert 68: 68 bf=0, 52 bf=0
// - insert 29: 29 bf=0, 37 bf=1, 52 bf=1
// - insert 44: 44 bf=0, 37 bf=0, 52 bf=1
// - insert 41: 41 bf=0, 44 bf=1, 37 bf=-1, 52 bf=2
// - LR imbalance, rotate left at 37 then rotate right at 52
// - insert 75: 75 bf=0, 68 bf=-1, 52 bf=-2, 44 bf=-1
// - RR imbalance, rotate left at 68
// - insert 80: 80 bf=0, 75 bf=-1, 68 bf=-1, 44 bf=-1
// - insert 61: 61 bf=0, 52 bf=-1, 68 bf=0, 44 bf=-1
// - insert 78: 78 bf=0, 80 bf=1, 75 bf=-2, 68 bf=-1, 44 bf=-2
// - RL imbalance, rotate right at 80, then rotate left at 75
// final tree:
//                              44
//                            /    \
//                          37      68
//                         /  \    /  \
//                       29   41  52   78
//                                 \   /\
//                                 61 75 80


internal class Program
{
    static void Main()
    {
        Console.WriteLine("Insert 52");
        AvlNode root = new(52);
        Console.WriteLine("Insert 37");
        AvlNode.Insert(root, 37);
        Console.WriteLine("Insert 68");
        AvlNode.Insert(root, 68);
        Console.WriteLine("Insert 29");
        AvlNode.Insert(root, 29);
        Console.WriteLine("Insert 44");
        AvlNode.Insert(root, 44);
        Console.WriteLine("Insert 41");
        AvlNode.Insert(root, 41);
        Console.WriteLine("Insert 75");
        AvlNode.Insert(root, 75);
        Console.WriteLine("Insert 80");
        AvlNode.Insert(root, 80);
        Console.WriteLine("Insert 61");
        AvlNode.Insert(root, 61);
        Console.WriteLine("Insert 78");
        AvlNode.Insert(root, 78);
        
        Console.WriteLine();
        Console.WriteLine("Root: " + root.Value);
        Console.WriteLine("Height: " + AvlNode.GetHeight(root));
        Console.WriteLine("Is Balanced: " + AvlNode.IsBalanced(root));
        Console.WriteLine();

        AvlNode root2 = new(1);
        for (int i = 2; i <= 15; i++)
        {
            AvlNode.Insert(root2, i);
        }
        Console.WriteLine("Height: " + AvlNode.GetHeight(root2));

    }
}

public class AvlNode
{
    public int Value;
    public AvlNode Left;
    public AvlNode Right;
    public int Height;

    public AvlNode(int value)
    {
        Value = value;
        Height = 1;
    }

    public static int GetHeight(AvlNode node)
    {
        if (node == null)
            return 0;

        int leftHeight = GetHeight(node.Left);
        int rightHeight = GetHeight(node.Right);

        return int.Max(leftHeight, rightHeight) + 1;
    }

    public static int GetBalance(AvlNode node)
    {
        if (node == null)
            return 0;
        if (node.Left == null && node.Right == null)
            return 0;
        if (node.Left == null)
            return 0 - node.Right.Height;
        if (node.Right == null)
            return node.Left.Height;
        return node.Left.Height - node.Right.Height;
    }

    public static bool Balanced(AvlNode node)
    {
        int balanceFactor = GetBalance(node);
        if (-1 <= balanceFactor && balanceFactor <= 1)
            return true;
        else
            return false;
    }

    public static void UpdateHeight(AvlNode node)
    {
        if (node.Left == null && node.Right == null)
            node.Height = 0;
        else if (node.Left == null)
            node.Height = node.Right.Height + 1;
        else if (node.Right == null)
            node.Height = node.Left.Height + 1;
        else
            node.Height = int.Max(node.Left.Height, node.Right.Height) + 1;
    }

    public static AvlNode RotateRight(AvlNode node)
    {
        AvlNode leftChild = node.Left;
        AvlNode leftChildRightChild = leftChild.Right;

        leftChild.Right = node;
        node.Left = leftChildRightChild;

        UpdateHeight(node);
        UpdateHeight(leftChild);
        return leftChild;
    }

    public static AvlNode RotateLeft(AvlNode node)
    {
        AvlNode rightChild = node.Right;
        AvlNode rightChildLeftChild = rightChild.Left;

        rightChild.Left = node;
        node.Right = rightChildLeftChild;

        UpdateHeight(node);
        UpdateHeight(rightChild);
        return rightChild;
    }

    public static AvlNode Insert(AvlNode node, int value)
    {
        if (node == null)
            return new AvlNode(value);

        if (value > node.Value)
        {
            node.Right = Insert(node.Right, value);
            node.Right.Height = AvlNode.GetHeight(node.Right);
        }
        else if (value < node.Value)
        {
            node.Left = Insert(node.Left, value);
            node.Left.Height = AvlNode.GetHeight(node.Left);
        }

        if (!Balanced(node))
        {
            int balanceFactor = GetBalance(node);
            int leftBalance = GetBalance(node.Left);
            int rightBalance = GetBalance(node.Right);
            if (balanceFactor > 1 && leftBalance >= 0)
            {
                Console.WriteLine("LL, rotate right at " + node.Value);
                RotateRight(node);
            }
            if (balanceFactor > 1 && leftBalance < 0)
            {
                Console.WriteLine("LR, rotate left at " + node.Left.Value);
                Console.WriteLine("then rotate right at " + node.Value);
                RotateLeft(node.Left);
                RotateRight(node);
            }
            if (balanceFactor < -1 && rightBalance <= 0)
            {
                Console.WriteLine("RR, rotate left at " + node.Value);
                RotateLeft(node);
            }
            if (balanceFactor < -1 && leftBalance > 0)
            {
                Console.WriteLine("RL, rotate right at " + node.Right.Value);
                Console.WriteLine("then rotate left at " + node.Value);
                RotateRight(node.Right);
                RotateLeft(node);
            }
        }

        return node;
    }

    public static void PrintInOrder(AvlNode node)
    {
        Console.WriteLine($"[{node.Left.Value},{node.Value},{node.Right.Value}]");
    }

    public static bool IsBalanced(AvlNode node)
    {
        if (node == null)
            return true;

        bool leftBalanced = IsBalanced(node.Left);
        bool rightBalanced = IsBalanced(node.Right);

        int leftHeight = GetHeight(node.Left);
        int rightHeight = GetHeight(node.Right);
        int balanceFactor = leftHeight - rightHeight;

        if (-1 <= balanceFactor && balanceFactor <= 1)
            return true;

        if (leftBalanced && rightBalanced)
            return true;

        return false;
    }
}