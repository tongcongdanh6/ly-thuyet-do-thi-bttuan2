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
        public int[] parent; // Mang danh dau dinh cha 
        public Queue<int> dsDuyetDinhTheoThuTu;
        public List<int> component;
        public List<List<int>> comp2;

        public Graph(AdjacencyMatrix G)
        {
            g = G;
            visited = new bool[G.n];
            parent = new int[G.n];
            component = new List<int>();
            comp2 = new List<List<int>>();
            dsDuyetDinhTheoThuTu = new Queue<int>();
        }

        public void initialize()
        {
            for(int i = 0; i < g.n; i++)
            {
                // Đánh flag là đỉnh i chưa được ghé thăm
                visited[i] = false;
                parent[i] = -1;
            }
        }

        public bool DFS(int start, int goal)
        {
            dsDuyetDinhTheoThuTu.Enqueue(start);
            visited[start] = true;

            if(g.isUndirectedGraph())
            {
                component.Add(start); // Dung de xac dinh thanh phan lien thong
            }
            

            if (start == goal)
            {
                return true;
            }

            for (int i = 0; i < g.n; i++)
            {
                if (g.Matrix[start, i] == 1 && (!visited[i]))
                {
                    if (DFS(i, goal)) 
                    {
                        parent[i] = start;
                        return true;
                    }
                }
            }

            return false;
        }

        public bool BFS(int start, int goal)
        {
            Queue<int> queue = new Queue<int>();
            bool found = false; // Biến cờ đánh dấu tìm thấy goal hay chưa

            visited[start] = true;

            queue.Enqueue(start);

            while(queue.Count > 0)
            {
                int cur = queue.Dequeue();
                dsDuyetDinhTheoThuTu.Enqueue(cur);

                if (cur == goal)
                {
                    found = true;
                    break;
                }

                for (int i = 0; i < g.n; i++)
                {
                    if(g.Matrix[cur, i] == 1 && (!visited[i]))
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                        parent[i] = cur;
                    }
                }
            }

            return found;

        }

        public void inThuTuDuyetDinh()
        {
            while(dsDuyetDinhTheoThuTu.Count > 0)
            {
                Console.Write(dsDuyetDinhTheoThuTu.Dequeue() + " ");
            }
        }
        public void printPath(int start, int goal)
        {
            int current = goal;
            while (current != -1 && current != start)
            {
                //path.Add(current);
                Console.Write("{0} <- ", current.ToString());
                current = parent[current];
            }

            if (current == start)
            {
                Console.WriteLine(current.ToString());
            }
        }

        public void countConnectedComponent()
        {
            for(int i = 0; i < g.n; i++)
            {
                if(!visited[i])
                {
                    component.Clear();
                    DFS(i, g.n - 1);
                    // Tao bien tmp vi clear component la xoa luon ref
                    List<int> tmp = new List<int>(component);
                    comp2.Add(tmp);
                }
            }

            Console.WriteLine("So thanh phan lien thong {0}: ", comp2.Count);

            for (int i = 0; i < comp2.Count; i++)
            {
                Console.Write("Thanh phan lien thong thu {0}: ", i+1);
                foreach(var c in comp2[i])
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
