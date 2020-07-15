using System;
using System.Collections.Generic;

namespace GraphPractice
{
    public class Graph<T> where T : IComparable
    {

        // TODO:
        //   - Add Single Source Shortest Path + corresponding unit tests: https://www.geeksforgeeks.org/shortest-path-unweighted-graph/

        public List<Vertex<T>> Vertices;
        public int Count { get { return Vertices.Count; } }

        public Graph()
        {
            Vertices = new List<Vertex<T>>();
        }

        /// <summary>
        /// Adds vertex to graph
        /// </summary>
        /// <param name="v">The value to add</param>
        public void AddVertex(T v)
        {
            Vertex<T> vert = new Vertex<T>(v);

            if (vert == null || Vertices.Contains(vert)) return;

            Vertices.Add(vert);
        }

        /// <summary>
        /// Removes vertex from graph
        /// </summary>
        /// <param name="v">The value to remove</param>
        /// <returns>Whether the removal was successful</returns>
        public bool RemoveVertex(T v)
        {
            Vertex<T> vert = new Vertex<T>(v);

            if (!Vertices.Contains(vert)) return false;

            for (int i = 0; i < vert.Neighbors.Count; i++)
            {
                for (int j = 0; j < vert.Neighbors[i].Neighbors.Count; j++)
                {
                    if (vert.Neighbors[i].Neighbors[j] == vert)
                    {
                        vert.Neighbors[i].Neighbors.RemoveAt(j);
                        break;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Add both vertices to eachother's neighbor lists
        /// </summary>
        /// <param name="a">The value of the first vertex</param>
        /// <param name="b">The value of the second vertex</param>
        /// <returns></returns>
        public bool AddEdge(T a, T b)
        {
            Vertex<T> va = Search(a);
            Vertex<T> vb = Search(b);

            if (va == null || vb == null) return false;

            va.Neighbors.Add(vb);
            vb.Neighbors.Add(va);

            return true;
        }


        /// <summary>
        /// Remove the edge between the two vertices.
        /// </summary>
        /// <param name="a">The value of the first vertex</param>
        /// <param name="b">The value of the second vertex</param>
        /// <returns>Whether the removal was successful</returns>
        public bool RemoveEdge(T a, T b)
        {
            Vertex<T> va = Search(a);
            Vertex<T> vb = Search(b);

            if (va == null || vb == null || !va.Neighbors.Contains(vb) || !vb.Neighbors.Contains(va)) return false;

            va.Neighbors.Remove(vb);
            vb.Neighbors.Remove(va);

            return true;
        }

        /// <summary>
        /// Finds the given value and returns corresponding vertex, or if non-existant, null
        /// </summary>
        /// <param name="value">The value to search for</param>
        /// <returns>The vertex corresponding to given value or null</returns>
        public Vertex<T> Search(T value)
        {
            int n = -1;

            for (int i = 0; i < Vertices.Count; i++)
            {
                if (value.CompareTo(Vertices[i].Value) == 0)
                {
                    n = i;
                    break;
                }
            }

            return n == -1 ? null : Vertices[n];
        }

        /// <summary>
        /// Finds the index of vertex of given value in Vertices list
        /// </summary>
        /// <param name="value">The value to find</param>
        /// <returns>The index of the node corresponding to the value specified, or if null, -1</returns>
        public int IndexOf(T value)
        {
            int n = -1;

            for (int i = 0; i < Vertices.Count; i++)
            {
                if (value.Equals(Vertices[i]))
                {
                    n = i;
                    break;
                }
            }

            return n;
        }

        /// <summary>
        /// Returns all values of nodes connected to starting node using a depth first search
        /// </summary>
        /// <param name="start">The value of the node to start at</param>
        /// <returns>List of values of all connected nodes</returns>
        public List<T> DepthFirstTraversal(T start)
        {
            Vertex<T> v = Search(start);
            Stack<Vertex<T>> stack = new Stack<Vertex<T>>();
            List<T> values = new List<T>();

            while (stack.Count != 0)
            {
                Vertex<T> current = stack.Pop();

                for (int i = 0; i < current.Neighbors.Count; i++)
                {
                    if (!values.Contains(current.Neighbors[i].Value)) stack.Push(current.Neighbors[i]);
                }

                values.Add(current.Value);
            }

            return values;
        }

        /// <summary>
        /// Returns all values of nodes connected to starting node using a breadth first search
        /// </summary>
        /// <param name="start">The value of the node to start at</param>
        /// <returns>List of values of all connected nodes</returns>
        public List<T> BreadthFirstTraversal(T start)
        {
            Vertex<T> v = Search(start);
            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            List<T> values = new List<T>();

            while (queue.Count != 0)
            {
                Vertex<T> current = queue.Dequeue();

                for (int i = 0; i < current.Neighbors.Count; i++)
                {
                    if (!values.Contains(current.Neighbors[i].Value)) queue.Enqueue(current.Neighbors[i]);
                }

                values.Add(current.Value);
            }

            return values;
        }

        public List<T> SingleSourceShortestPath(T start, T end)
        {
            // Todo: add predecessor logic
            Vertex<T> v = Search(start);
            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            Queue<Vertex<T>> predQueue = new Queue<Vertex<T>>();
            List<Vertex<T>> values = new List<Vertex<T>>();
            List<Vertex<T>> predValues = new List<Vertex<T>>();

            queue.Enqueue(v);
            predQueue.Enqueue(new Vertex<T>(true));

            while (queue.Count != 0)
            {
                Vertex<T> current = queue.Dequeue();
                Vertex<T> pred = predQueue.Dequeue();

                for (int i = 0; i < current.Neighbors.Count; i++)
                {
                    if (!values.Contains(current.Neighbors[i]))
                    {
                        queue.Enqueue(current.Neighbors[i]);
                        predQueue.Enqueue(current);
                    }
                }

                values.Add(current);
                predValues.Add(pred);

                if (current.Value.CompareTo(end) == 0) break;
            }

            List<T> path = new List<T>();
            int index = values.Count - 1;

            while (!predValues[index].Null)
            {
                path.Add(values[index].Value);
                index = values.IndexOf(predValues[index]);
            }

            // Todo: add last

            return path;
        }

        /// <summary>
        /// Gets the length of the shortest path
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int SingleSourceShortestPathLength(T start, T end)
        {
            return SingleSourceShortestPath(start, end).Count;
        }
    }
}
