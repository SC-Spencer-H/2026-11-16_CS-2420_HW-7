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
        
    }
}