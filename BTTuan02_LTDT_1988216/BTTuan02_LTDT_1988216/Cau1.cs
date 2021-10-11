using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BTTuan02_LTDT_1988216
{
    class Cau1
    {
        protected int[,] matrix1;

        public void Run()
        {
            // Câu 1
            string path1 = @"../../testcase2.txt";

            FileHandler fileHandleInstance = new FileHandler();

            fileHandleInstance.readMatrixFromFile(path1, ref matrix1);

            AdjacencyMatrix MatrixCau1 = new AdjacencyMatrix(matrix1);

            Graph G = new Graph(MatrixCau1);

            Console.Write("Nhap start = ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("Nhap goal = ");
            int goal = int.Parse(Console.ReadLine());


            // DFS
            G.initialize();
            Console.WriteLine("=== Ket qua cho thuat toan DFS === ");
            if (!G.DFS(start, goal))
            {
                Console.WriteLine("Khong co duong di");
            }
            else
            {
                Console.WriteLine("Danh sach dinh da duyet theo thu tu: ");
                G.inThuTuDuyetDinh();
                Console.WriteLine("");
                Console.WriteLine("Duong di in kieu nguoc: ");
                G.printPath(start, goal);
            }


            // BFS
            G.initialize();
            Console.WriteLine("");
            Console.WriteLine("=== Ket qua cho thuat toan BFS === ");
            if (!G.BFS(start, goal))
            {
                Console.WriteLine("Khong co duong di");
            }
            else
            {
                Console.WriteLine("Danh sach dinh da duyet theo thu tu: ");
                G.inThuTuDuyetDinh();
                Console.WriteLine("");
                Console.WriteLine("Duong di in kieu nguoc: ");
                G.printPath(start, goal);
            }

            
            // Xac dinh thanh phan lien thong
            if (G.g.isUndirectedGraph())
            {
                G.initialize();
                Console.WriteLine("\n=== Xac dinh thanh phan lien thong cho do thi vo huong === ");
                G.countConnectedComponent();
            }
        }
    }
}