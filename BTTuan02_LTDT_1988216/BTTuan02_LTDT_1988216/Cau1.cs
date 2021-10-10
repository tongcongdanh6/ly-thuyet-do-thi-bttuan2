using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            G.initialize();

            // Cau 1a
            //MatrixCau1.printMatrix();


        }
    }
}