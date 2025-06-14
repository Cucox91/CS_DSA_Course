using System.Collections;

namespace Graphs;

public class GraphNode
{
    public int Value { get; set; }
    public List<int>? Adjacent { get; set; }
}

public class AdjacentListGraph
{
    public long NumberOfNodes { get; set; } = 0;
    public Hashtable AdjacentList { get; set; } = new Hashtable();

    public void AddVertex(int value)
    {
        if (AdjacentList[value] == null)
        {
            AdjacentList.Add(value, new List<int>());
            NumberOfNodes++;
        }
        {
            Console.WriteLine("Element Already Exists");
        }
    }

    public void AddEdge(int node1, int node2)
    {
        var vertex1 = AdjacentList[node1];
        var vertex2 = AdjacentList[node2];

        if (vertex1 == null)
        {
            Console.WriteLine($"Vertex with value: {node1} doesn't exist");
        }
        if (vertex2 == null)
        {
            Console.WriteLine($"Vertex with value: {node2} doesn't exist");
        }

        if (vertex1 != null && vertex2 != null)
        {
            var listVertex1 = (List<int>)AdjacentList[node1]!;
            var listVertex2 = (List<int>)AdjacentList[node2]!;
            if (listVertex1.Contains(node2)) // We only check in one because we add and remove at the same time from both.
            {
                Console.WriteLine($"Relationship between {node1} and {node2} exists.");
            }
            else
            {
                listVertex1.Add(node2);
                listVertex2.Add(node1);
            }
        }
    }

    public void ShowConnections()
    {
        var keys = AdjacentList.Keys.Cast<int>().Order();
        foreach (var key in keys)
        {
            var adjacentNodes = (List<int>)AdjacentList[key]!;
            var nodes = "";
            foreach (var value in adjacentNodes)
            {
                nodes += value.ToString() + " ";
            }
            Console.WriteLine($"{key}-->{nodes}");
        }
    }

}
