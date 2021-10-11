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
            string path1 = @"../../CauA_testcase1.txt";

            FileHandler fileHandleInstance = new FileHandler();

            fileHandleInstance.readMatrixFromFile(path1, ref matrix1);

            AdjacencyMatrix MatrixCau1 = new AdjacencyMatrix(matrix1);

            Graph G = new Graph(MatrixCau1);

            int start = 0;
            int goal = 7;

/*            G.initialize();
            if(!G.DFS(start, goal))
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
            }*/

            G.initialize();
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
        }
    }
}