using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph = new Graph<int>();

            graph.AddVertex(2);
            graph.AddVertex(1);
            graph.AddVertex(0);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(7);
            graph.AddVertex(5);
            graph.AddVertex(6);

            graph.AddEdge(2, 1);
            graph.AddEdge(1, 0);
            graph.AddEdge(0, 3);
            graph.AddEdge(3, 7);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 7);
            graph.AddEdge(4, 6);
            graph.AddEdge(4, 5);
            graph.AddEdge(5, 6);
            graph.AddEdge(6, 7);

            List<int> test = graph.SingleSourceShortestPath(0, 7);


        }
    }
}
