using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphMinPath
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Node> nodes = new List<Node>();
            using (StreamReader rd = new StreamReader("nodes.txt"))
            {
                while (!rd.EndOfStream)
                {
                    string line = rd.ReadLine();
                    string[] data = line.Split(new char[] { ',' });
                    try
                    {
                        int nodeId = int.Parse(data[0]);
                        string label = data[1];

                        Node n = new Node();
                        n.NodeId = nodeId;
                        n.Label = label;

                        nodes.Add(n);
                    }
                    catch
                    {

                    }
                }

                foreach (Node n in nodes)
                {
                    Console.WriteLine(n.ToString());
                }
            }

            using (StreamReader rd = new StreamReader("NodesTree.txt"))
            {
                while (!rd.EndOfStream)
                {
                    string line = rd.ReadLine();
                    string[] data = line.Split(new char[] { ',' });

                    int baseNodeId = int.Parse(data[0]);
                    int adjNodeId = int.Parse(data[1]);

                    Node baseNode = nodes.Find((n) => { return n.NodeId == baseNodeId; });
                    Node adjNode = nodes.Find((n) => { return n.NodeId == adjNodeId; });

                    baseNode.AddNode(adjNode);
                }
            }

            Graph g = new Graph();
            nodes.ForEach((n) => g.addNode(n));

            g.SetRootNode(nodes[0]);

            
            nodes.ForEach((n) =>
            {
                n.GetNodes().ForEach((cn) => g.connectNode(n, cn));
            });

            //g.FindShortestDistance2(1, 7);

            Console.WriteLine("BFS");
            g.bfs();

            Console.WriteLine("DFS");
            g.dfs();

        }
    }

    public class Node
    {
        public int NodeId { get; set; }
        public string Label { get; set; }
        List<Node> nodes = new List<Node>();

        public bool visited { get; set; }

        public override string ToString()
        {
            return NodeId.ToString() + " - " + Label;
        }

        public void AddNode(Node n)
        {
            nodes.Add(n);
        }

        public List<Node> GetNodes() {  return nodes; }
    }
}
