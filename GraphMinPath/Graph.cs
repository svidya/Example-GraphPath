using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphMinPath
{
    public class Graph
    {
        Node rootNode = null;
        List<Node> nodes = new List<Node>();
        int[,] adjMatrix;
        int size;

        public void SetRootNode(Node root)
        {
            this.rootNode = root;
        }

        public Node GetRootNode()
        {
            return rootNode;
        }

        public void addNode(Node n)
        {
            nodes.Add(n);
        }

        public void connectNode(Node start, Node end)
        {
            if (adjMatrix == null)
            {
                size = nodes.Count();
                adjMatrix = new int[size,size];
            }

            int startIndex = nodes.IndexOf(start);
            int endIndex = nodes.IndexOf(end);
            adjMatrix[startIndex,endIndex] = 1;
            adjMatrix[endIndex,startIndex] = 1;
        }

        private Node getUnvisitedChildNode(Node n)
        {

            int index = nodes.IndexOf(n);
            int j = 0;
            while (j < size)
            {
                if (adjMatrix[index, j] == 1 && ((Node)nodes[j]).visited == false)
                {
                    return (Node)nodes[j];
                }
                j++;
            }
            return null;
        }

        public void dfs()
        {
            //DFS uses Stack data structure
            Stack<Node> s = new Stack<Node>();
            s.Push(this.rootNode);
            rootNode.visited = true;
            printNode(rootNode);
            while (s.Count() != 0 )
            {
                Node n = (Node)s.Peek();
                Node child = getUnvisitedChildNode(n);
                if (child != null)
                {
                    child.visited = true;
                    printNode(child);
                    s.Push(child);
                }
                else
                {
                    s.Pop();
                }
            }
            //Clear visited property of nodes
            clearNodes();
        }


        public void bfs()
        {
            for (int i = 0; i < adjMatrix.GetLength(0); i++)
            {

                for (int k = 0; k < adjMatrix.GetLength(1); k++)
                {

                    Console.WriteLine(" i = {0} k = {1} value = {2}", i, k, adjMatrix[i, k]);
                }
            }

            //BFS uses Queue data structure
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(this.rootNode);
            printNode(this.rootNode);
            rootNode.visited = true;
            while (q.Count() !=0 )
            {
                Node n = (Node)q.Dequeue();
                Node child = null;
                while ((child = getUnvisitedChildNode(n)) != null)
                {
                    child.visited = true;
                    printNode(child);
                    q.Enqueue(child);
                }
            }
            //Clear visited property of nodes
            clearNodes();
        }

        public void FindShortestDistance(int start, int end)
        {
            //DFS uses Stack data structure
            Stack<Node> s = new Stack<Node>();
            s.Push(this.rootNode);
            rootNode.visited = true;
            printNode(rootNode);


            while (s.Count() != 0)
            {
                Node n = (Node)s.Peek();
                Node child = getUnvisitedChildNode(n);
                if (child != null)
                {
                    child.visited = true;
                    printNode(child);

                    if (child.NodeId == end)
                        break;

                    s.Push(child);
                }
                else
                {
                    s.Pop();
                }
            }
            //Clear visited property of nodes
            clearNodes();
        }


        public void FindShortestDistance2(int start, int end)
        {
            //DFS uses Stack data structure
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(this.rootNode);
            printNode(this.rootNode);
            rootNode.visited = true;
            while (q.Count() != 0)
            {
                Node n = (Node)q.Dequeue();
                Node child = null;
                while ((child = getUnvisitedChildNode(n)) != null)
                {
                    if (child.NodeId == end)
                        break;
                    child.visited = true;
                    printNode(child);
                    q.Enqueue(child);
                }
            }
            //Clear visited property of nodes
            clearNodes();
        }


        private void clearNodes()
        {
            int i = 0;
            while (i < size)
            {
                Node n = (Node)nodes[i];
                n.visited = false;
                i++;
            }
        }

        //Utility methods for printing the node's label
        private void printNode(Node n)
        {
            Console.WriteLine(n.Label + " ");
        }
    }
}
