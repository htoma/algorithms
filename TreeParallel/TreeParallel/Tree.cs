namespace TreeParallel
{
    public class Tree<T>
    {
        public T Data { get; set; }

        public Tree<T> Left { get; set; }

        public Tree<T> Right { get; set; }
    }
}