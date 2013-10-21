using System;
using System.Threading.Tasks;

namespace TreeParallel
{
    public class Program
    {
        const int MAX_VALUE = 100;
        const int MAX_LEVELS = 10;

        public static void Main(string[] args)
        {                        
            var random = new Random(MAX_VALUE);

            var tree = new Tree<int>
                           {
                               Data = random.Next(MAX_VALUE)
                           };

            populateTree(tree, MAX_LEVELS - 1, random);

            Action<int, int> action =
                (value, level) => Console.WriteLine(string.Format("Level {0}, Value {1}", level, value));

            // traverse with parallel tasks
            //DoWithParallelTasks(tree, action, 1);

            // traverse with parallel invoke
            DoWithParallelInvoke(tree, action, 1);
        }

        // use a task for each subtree of the current node
        public static void DoWithParallelTasks<T>(Tree<T> tree, Action<T, int> action, int level)
        {
            if (tree == null)
            {
                return;
            }

            // preorder
            action(tree.Data, level);                        
            var walkLeft = Task.Factory.StartNew(() => DoWithParallelTasks(tree.Left, action, level + 1));            
            var walkRight = Task.Factory.StartNew(() => DoWithParallelTasks(tree.Right, action, level + 1));
            
            try
            {
                Task.WaitAll(walkLeft, walkRight);
            }
            catch(AggregateException)
            {
                // do something
            }
        }

        public static void DoWithParallelInvoke<T>(Tree<T> tree, Action<T, int> action, int level)
        {
            if (tree == null)
            {
                return;
            }

            Parallel.Invoke(
                () => action(tree.Data, level),
                () => DoWithParallelInvoke(tree.Left, action, level + 1),
                () => DoWithParallelInvoke(tree.Right, action, level + 1));
        }

        private static void populateTree(Tree<int> tree, int level, Random random)
        {
            if (level > 0)
            {
                tree.Left = new Tree<int> { Data = random.Next(MAX_VALUE) };
                tree.Right = new Tree<int> { Data = random.Next(MAX_VALUE) };

                var populateLeft = Task.Factory.StartNew(() => populateTree(tree.Left, level - 1, random));
                var populateRight = Task.Factory.StartNew(() => populateTree(tree.Right, level - 1, random));

                try
                {
                    Task.WaitAll(populateLeft, populateRight);
                }
                catch (AggregateException)
                {
                    // do something
                }
            }
        }
    }
}
