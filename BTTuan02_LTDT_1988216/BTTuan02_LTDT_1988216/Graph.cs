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
        public int[] parent;
        public Queue<int> dsDuyetDinhTheoThuTu;

        public Graph(AdjacencyMatrix G)
        {
            g = G;
            visited = new bool[G.n];
            parent = new int[G.n];
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

        /*        public void DFS(int start, int goal)
                {
                    visited[start] = true;

                    for (int i = 0; i < g.n; i++)
                    {
                        if (g.Matrix[start,i] == 1)
                        {
                            if(!visited[i])
                            {
                                Console.Write(i+" ");
                                DFS(i, goal);
                            }
                        }
                    }
                }*/

        /*        public void DFS(int start, int goal)
                {
                    Stack<int> stack = new Stack<int>();
                    bool[] visited = new bool[g.n];
                    int[] parent = new int[g.n];
                    List<int> path = new List<int>();

                    // Initialize
                    for (int i = 0; i < g.n; i++)
                    {
                        visited[i] = false;
                        parent[i] = -1;
                    }

                    // Push start vào
                    stack.Push(start);
                    // Marked visited start
                    visited[start] = true;
                    bool foundGoal = false;

                    while (stack.Count > 0)
                    {
                        int v1 = stack.Peek();
                        stack.Pop();

                        Console.Write(v1 + " ");
                        if (v1 == goal)
                        {
                            foundGoal = true;
                            Console.WriteLine("");
                            break;
                        }

                        for (int i = 0; i < 0; i++)
                        {

                            if (g.Matrix[v1, i] == 1 && (!visited[i]))
                            {
                                stack.Push(i);
                                visited[i] = true;
                                parent[i] = v1;
                            }
                        }
                    }

                    Console.WriteLine("Path: ");
                    if (foundGoal)
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

                }*/

        public bool DFS(int start, int goal)
        {
            dsDuyetDinhTheoThuTu.Enqueue(start);
            visited[start] = true;

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
    }
}
