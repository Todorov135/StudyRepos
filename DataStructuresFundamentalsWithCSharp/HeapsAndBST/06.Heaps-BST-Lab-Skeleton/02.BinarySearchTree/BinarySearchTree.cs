namespace _02.BinarySearchTree
{
    using System;
    using System.Collections.Generic;
    using System.Security;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }
            public T Value { get; private set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }
        private Node root;
        public BinarySearchTree()
        {
        }
        private BinarySearchTree(Node node)
        {
            this.PreOrtherCopy(node);
        }

        private void PreOrtherCopy(Node node)
        {
            this.Insert(node.Value);
            this.PreOrtherCopy(node.Left);
            this.PreOrtherCopy(node.Right);
        }

        public bool Contains(T element)
        {
            var searchedNode = this.FindNode(element);
            return searchedNode != null;
        }

        private Node FindNode(T element)
        {
            var node = this.root;
            while (node != null)
            {
                if (element.CompareTo(node.Value) < 0)
                {
                    node = node.Left;
                }
                else if (element.CompareTo(node.Value) > 0)
                {
                    node = node.Right;
                }
                else
                {
                    break;
                }
            }
            return node;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.root);
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }
            this.EachInOrder(action, node.Left);
            action.Invoke(node.Value); //can be -> action(node.Value);
            this.EachInOrder(action, node.Right);
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            return node;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node = this.FindNode(element);
            if (node == null)
            {
                return null;
            }
            
            var subTree = new BinarySearchTree<T>(node);
            
            return subTree;
        }
    }
}
