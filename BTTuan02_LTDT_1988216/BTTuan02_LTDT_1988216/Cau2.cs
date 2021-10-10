using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTuan02_LTDT_1988216
{
    class Cau2
    {
        protected int[,] matrix;

        public void Run()
        {
            // Câu 2
            string path1 = @"../../Cau2_testcase3.txt";

            FileHandler fileHandleInstance = new FileHandler();

            fileHandleInstance.readMatrixFromFile(path1, ref matrix);

            AdjacencyMatrix MatrixCau2 = new AdjacencyMatrix(matrix);
        }

    }

}