using System;
using System.Collections.Generic;

namespace GraphPractice
{
    public class Vertex<T> where T : IComparable
    {
        public T Value { get; set; }
        public List<Vertex<T>> Neighbors;
        public int Count { get { return Neighbors.Count; } }
        public bool Null { get; }

        public Vertex(T value)
        {
            Value = value;
            Neighbors = new List<Vertex<T>>();
            Null = false;
        }

        public Vertex(bool isNull)
        {
            Null = isNull;
        }
    }
}
