using Xunit;
using GraphPractice;
using System.Collections.Generic;

namespace Tests
{
    public class UnitTest1
    {

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 2, 3, 3, 1 }, 1, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { -5, 0, 63 }, new int[] { -5, 0, -5, 63 }, 0, new int[] { 0, -5, 63 })]
        [InlineData(new int[] { -1234, 5678, 10 }, new int[] { 10, -1234, 5678, -1234, 5678, 10 }, 10, new int[] { 10, -1234, 5678 })]
        public void GraphBreadthTest(int[] values, int[] connections, int start, int[] expected)
        {
            Graph<int> graph = new Graph<int>();

            for (int i = 0; i < values.Length; i++)
            {
                graph.AddVertex(values[i]);
            }

            for (int i = 0; i < connections.Length; i += 2)
            {
                graph.AddEdge(connections[i], connections[i + 1]);
            }

            List<int> vals = graph.BreadthFirstTraversal(start);

            for (int i = 0; i < vals.Count; i++)
            {
                Assert.Equal(expected[i], vals[i]);
            }
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 2, 3, 3, 1 }, 1, new int[] { 3, 2, 1 })]
        [InlineData(new int[] { -5, 0, 63 }, new int[] { -5, 0, -5, 63 }, 0, new int[] { 63, -5, 0 })]
        [InlineData(new int[] { -1234, 5678, 10 }, new int[] { 10, -1234, 5678, -1234, 5678, 10 }, 10, new int[] { 5678, -1234, 10 })]
        public void GraphDepthTest(int[] values, int[] connections, int start, int[] expected)
        {
            Graph<int> graph = new Graph<int>();

            for (int i = 0; i < values.Length; i++)
            {
                graph.AddVertex(values[i]);
            }

            for (int i = 0; i < connections.Length; i += 2)
            {
                graph.AddEdge(connections[i], connections[i + 1]);
            }

            List<int> vals = graph.DepthFirstTraversal(start);

            for (int i = 0; i < vals.Count; i++)
            {
                Assert.Equal(expected[i], vals[i]);
            }
        }

        [Fact]
        public void NullDepthFirstTest()
        {
            Graph<int> graph = new Graph<int>();

            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);

            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);

            Assert.Equal(new List<int>(), graph.DepthFirstTraversal(0));
        }

        [Fact]
        public void NullBreadthFirstTest()
        {
            Graph<int> graph = new Graph<int>();

            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);

            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);

            Assert.Equal(new List<int>(), graph.BreadthFirstTraversal(0));
        }
    }
}
