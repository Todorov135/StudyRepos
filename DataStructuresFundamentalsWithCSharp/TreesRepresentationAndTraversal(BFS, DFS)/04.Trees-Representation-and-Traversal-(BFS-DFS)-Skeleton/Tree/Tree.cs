namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> Children;
        private T Value;
        private Tree<T> Parent;
        public Tree(T value)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this; // every child know that THIS node is his paret
                this.Children.Add(child); 
            }
        }

        

        public IEnumerable<T> OrderBfs()
        {
            var queue = new Queue<Tree<T>>();
            var result = new List<T>();
            queue.Enqueue(this); //star from the root
            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                result.Add(subtree.Value);
                foreach (var child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return result;
        }
        private void DFSRecurtion(Tree<T> node, ICollection<T> result)
        {
            foreach (var child in node.Children)
            {
                this.DFSRecurtion(child, result);
            }
            result.Add(node.Value);
        }
        public IEnumerable<T> OrderDfs()
        {
            var list = new List<T>();
            this.DFSRecurtion(this, list);
            return list;
        }
        private IEnumerable<T> DFSWhitStack()
        {
            var result = new Stack<T>();
            var stack = new Stack<Tree<T>>();
            stack.Push(this); //push root to the stack
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                foreach (var child in node.Children)
                {
                    stack.Push(child);
                }
                result.Push(node.Value);
            }
            return result;
        }
        public void AddChild(T parentKey, Tree<T> child)
        {
            var parentNode = this.FindNodeWhitBfs(parentKey);
            if (parentNode is null)
            {
                throw new ArgumentNullException();
            }
            parentNode.Children.Add(child);
            child.Parent = parentNode;
        }

        private Tree<T> FindNodeWhitBfs(T parentKey)
        {
            var queue = new Queue<Tree<T>>();
           
            queue.Enqueue(this); 
            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                if (subtree.Value.Equals(parentKey))
                {
                    return subtree;
                }
                foreach (var child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return null;
        }

        public void RemoveNode(T nodeKey)
        {
            var toBeDeletedNode = FindNodeWhitBfs(nodeKey);
            if (toBeDeletedNode is null)
            {
                throw new ArgumentNullException();
            }
            var parentNode = toBeDeletedNode.Parent;
            if (parentNode is null)
            {
                throw new ArgumentException();
            }
            parentNode.Children.Remove(toBeDeletedNode);
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = this.FindNodeWhitBfs(firstKey);
            var secondNode = this.FindNodeWhitBfs(secondKey);
            if (firstNode is null || secondNode is null)
            {
                throw new ArgumentNullException();
            }
            var firstParent = firstNode.Parent;
            var secondParent = secondNode.Parent;
            if (firstParent is null || secondParent is null)
            {
                throw new ArgumentException();
            }
            var idexOfFirstChild = firstParent.Children.IndexOf(firstNode);
            var idexOfSecondChild = secondParent.Children.IndexOf(secondNode);
            firstParent.Children[idexOfFirstChild] = secondNode;
            secondNode.Parent = firstParent;
            secondParent.Children[idexOfSecondChild] = firstNode;
            firstNode.Parent = secondNode;

        }
    }
}
