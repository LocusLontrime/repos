public class SearchInABinarySearchTree700 // accepted (speed: average)
{

    static void Main(string[] args)
    {



    }
    
    public static TreeNode SearchBST(TreeNode root, int val) // O(log(n)) runtime, O(n) memory
    {
        if (root == null || val == root.val) return root;
        
        return val < root.val ? SearchBST(root.left, val) : SearchBST(root.right, val);
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}