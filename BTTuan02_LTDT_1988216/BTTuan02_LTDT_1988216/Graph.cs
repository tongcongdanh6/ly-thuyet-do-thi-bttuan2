using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTuan02_LTDT_1988216
{
    class Graph
    {
        public bool[] visited;
        public AdjacencyMatrix g;

        public Graph(AdjacencyMatrix G)
        {
            g = G;
            visited = new bool[G.n];
        }

        public void initialize()
        {
            for(int i = 0; i < visited.Length; i++)
            {
                // Đánh flag là đỉnh i chưa được ghé thăm
                visited[i] = false;
            }
        }

        public void DFS()
        {
            Console.WriteLine(g.n);
            Console.WriteLine(visited.Length);
        }
    }
}
