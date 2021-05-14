using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    /// <summary>
    /// A graph
    /// </summary>
    /// <typeparam name="="T">type of values stored in graph</typeparam>
    public class Graph<T>
    {
        #region Fields

        List<GraphNode<T>> nodes = new List<GraphNode<T>>();

        #endregion

        #region Constructors

        public Graph()
        {
        }

        #endregion

        #region Properties

        public int Count
        {
            get { return nodes.Count; }
        }

        public IList<GraphNode<T>> Nodes
        {
            get { return nodes.AsReadOnly(); }
        }

        #endregion

        #region Methods

        public void Clear()
        {
            foreach (GraphNode<T> node in nodes)
            {
                node.RemoveAllNeighbors();
            }

            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                nodes.RemoveAt(i);
            }
        }

        public bool AddNode(T value)
        {
            if(Find(value) != null)
            {
                return false;
            }
            else
            {
                nodes.Add(new GraphNode<T>(value));

                return true;
            }
        }

        public bool AddNode(GraphNode<T> node)
        {
            //if (Find(node.Value) != null)
            //{
            //    return false;
            //}
            //else
            //{
                nodes.Add(node);
                return true;
            //}
        }

        public bool AddEdge(T value1, T value2)
        {
            GraphNode<T> node1 = Find(value1);
            GraphNode<T> node2 = Find(value2);

            if(node1 == null || node2 == null)
            {
                return false;
            }
            else if (node1.Neighbors.Contains(node2))
            {
                return false;
            }
            else
            {
                // undirected graph
                node1.AddNeighbor(node2);
                node2.AddNeighbor(node1);
                return true;
            }
        }

        public bool RemoveNode(T value)
        {
            GraphNode<T> removeNode = Find(value);
            if (removeNode == null) // node not in the graph
            {
                return false;
            }
            else
            {
                nodes.Remove(removeNode);
                foreach (GraphNode<T> node in nodes)
                {
                    node.RemoveNeighbor(removeNode); // remove as neightbor for all nodes
                }
                return true;
            }
        }


        public bool RemoveEdge(T value1, T value2)
        {
            GraphNode<T> node1 = Find(value1);
            GraphNode<T> node2 = Find(value2);
            if (node1 == null || node2 == null)
            {
                return false;
            }
            else if(!node1.Neighbors.Contains(node2))
            {
                return false; // edge doesn't exist
            }
            else
            {
                node1.RemoveNeighbor(node2);
                node2.RemoveNeighbor(node1);
                return true;
            }
        }

        public GraphNode<T> Find(T value)
        {
            foreach (GraphNode<T> node in nodes)
            {
                if(node.Value.Equals(value))
                {
                    return node;
                }
            }
            return null;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                builder.Append(nodes[i].ToString());
            }
            return builder.ToString();
        }

        #endregion
    }
}
