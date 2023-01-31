namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;
        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child); 
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string AsString()
        {
            var sb = new StringBuilder();

            this.DfsAsString(sb, this, 0);
            return sb.ToString().Trim();
        }

        private void DfsAsString(StringBuilder sb, Tree<T> tree, int depth)
        {
            sb.Append(' ', depth)
              .AppendLine(tree.Key.ToString());

            foreach (var child in tree.children)
            {
                this.DfsAsString(sb, child, +2);
            }
        }

        public IEnumerable<T> GetInternalKeys()
        {
            return this.BfsWithResultKeys(tree=> tree.children.Count>0 && tree.Parent != null).Select(tree => tree.Key);
        }

        public IEnumerable<T> GetLeafKeys()
        {
            return this.BfsWithResultKeys(tree => tree.children.Count == 0).Select(tree => tree.Key); 
        }
        private IEnumerable<Tree<T>> BfsWithResultKeys(Predicate<Tree<T>> predicate)
        {
            var result = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var currSubtree = queue.Dequeue();
                if (predicate.Invoke(currSubtree))
                {
                    result.Add(currSubtree);
                }
                foreach (var child in currSubtree.children)
                {
                    queue.Enqueue(child);
                }
            }
            return result;
        }

        public T GetDeepestKey()
        {
            return this.GetDeepestNode().Key;
        }

        private Tree<T> GetDeepestNode()
        {
            var leafs = this.BfsWithResultKeys(tree => tree.children.Count == 0);
            Tree<T> deepestNode = null;
            int maxDepth = 0;
            foreach (var leaf in leafs)
            {
                int depth = this.GetDepth(leaf);
                if (depth > maxDepth)
                {
                    maxDepth = depth;
                    deepestNode = leaf;
                }
            }
            return deepestNode;
        }

        private int GetDepth(Tree<T> leaf)
        {
            int depth = 0;
            var tree = leaf;
            while (tree.Parent != null)
            {
                depth++;
                tree = tree.Parent;
            }
            return depth;
        }

        public IEnumerable<T> GetLongestPath()
        {
            throw new NotImplementedException();
        }
    }
}
