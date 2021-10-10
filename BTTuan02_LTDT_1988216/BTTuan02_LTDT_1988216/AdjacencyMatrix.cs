using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTuan02_LTDT_1988216
{
    class AdjacencyMatrix
    {
        public int[,] Matrix { set; get; }
        public int n { set; get; }

        public AdjacencyMatrix(int[,] arr)
        {
            this.Matrix = arr;
            this.n = arr.GetLength(0);
        }

        public void printMatrix()
        {
            Console.WriteLine(n);
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.n; j++)
                {
                    Console.Write(Matrix[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }

        public bool isUndirectedGraph()
        {
            // @ Chức năng: có phải là đồ thị vô hướng hay không?

            // Kiểm tra tính đối xứng qua đường chéo chính
            bool isSymmetric = true;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (Matrix[i, j] != Matrix[j, i])
                    {
                        isSymmetric = false;
                        break;
                    }
                }
            }
            return isSymmetric;
        }
    }
}