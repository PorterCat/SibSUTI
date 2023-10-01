namespace RandomTree.Data_structs
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public T Value;
        public TreeNode<T>? Left;
        public TreeNode<T>? Right;

        public TreeNode()
        {

            Left = null;
            Right = null;
        }

        public TreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

    }
}
