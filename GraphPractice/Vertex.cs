using System.Collections.Generic;

namespace GraphPractice
{
    public class Vertex<T>
    {
        public T Value { get; set; }
        public List<Vertex<T>> Neighbors;
        public int Count { get { return Neighbors.Count; } }

        public Vertex(T value)
        {
            Value = value;
            Neighbors = new List<Vertex<T>>();
        }
    }
}
