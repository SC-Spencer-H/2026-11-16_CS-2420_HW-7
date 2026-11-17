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



internal class Program
{
    static void Main()
    {
        
    }
}