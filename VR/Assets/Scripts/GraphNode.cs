using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class GraphNode<T>
{
    #region Fields

    T value;
    List<GraphNode<T>> neighbors;
    List<GraphEdge<LineRenderer>> edges = new List<GraphEdge<LineRenderer>>();
    List<int> edgePositions = new List<int>();
    Transform transform;

    #endregion

    #region Constructors

    public GraphNode(T value)
    {
        this.value = value;
        neighbors = new List<GraphNode<T>>();
    }

    public GraphNode(T value, Transform transform)
    {
        this.value = value;
        this.transform = transform;
        neighbors = new List<GraphNode<T>>();
    }

    #endregion

    #region Properties

    public List<GraphEdge<LineRenderer>> Edges
    {
        get { return edges; }
    }
    public List<int> EdgePositions
    {
        get { return edgePositions; }
    }

    /// <summary>
    ///  Gets the value stored in the node
    /// </summary>
    public T Value
    {
        get { return value; }
    }

    /// <summary>
    /// Gets a read-only list of the neighbors of the node
    /// </summary>
    public IList<GraphNode<T>> Neighbors
    {
        get { return neighbors.AsReadOnly(); }
    }

    /// <summary>
    /// Adds the given node as a neighbor for this node
    /// </summary>
    /// <param name="neighbor">neighbor to add</param>
    /// <returns>true if the neighbor was added, otherwise, returns false</returns>
    public bool AddNeighbor(GraphNode<T> neighbor)
    {
        //if (neighbors.Contains(neighbor))
        //{
        //    return false;
        //}
        //else
        //{
        neighbors.Add(neighbor);
        return true;
        //}
    }

    /// <summary>
    /// Removes the given node as a neighbor for this node
    /// </summary>
    /// <param name="neighbor">neighbor to remove</param>
    /// <returns>true if the neighbor was removed, otherwise, returns false</returns>
    public bool RemoveNeighbor(GraphNode<T> neighbor)
    {
        return neighbors.Remove(neighbor);
    }

    /// <summary>
    /// Removes all the neighbor for the node
    /// </summary>
    /// <param name="neighbor">neighbor to remove</param>
    /// <returns>true if the neighbors were removed, otherwise, returns false</returns>
    public bool RemoveAllNeighbors()
    {
        for (int i = neighbors.Count - 1; i >= 0; i--)
        {
            neighbors.RemoveAt(i);
        }
        return true;
    }

    /// <summary>
    /// Converts the node to a string
    /// </summary>
    /// <returns>the string</returns>
    public override string ToString()
    {
        StringBuilder nodeString = new StringBuilder();
        nodeString.Append($"[Node value: {value} Neighbors: ");
        for (int i = 0; i < neighbors.Count; i++)
        {
            nodeString.Append(neighbors[i].Value + " ");
        }
        nodeString.Append("]");
        return nodeString.ToString();
    }

    #endregion
}
