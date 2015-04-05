using System;
using System.Collections.Generic;

namespace wiercholki
{
    public class Matrix
    {
        private List<List<int>> rows;
        public Matrix()
        {
            rows = new List<List<int>>();
        }

        public Matrix(Graph graph)
        {
            rows = new List<List<int>>();

            foreach (var verticle in graph.verticles)
            {
                AddVerticle();
            }
        }

        public Matrix(int size)
        {

            rows = new List<List<int>>();
            for(int i = 0; i < size; i++)
                AddVerticle();
        }
        public void AddVerticle()
        {
            var newCol = new List<int>();
            for(int i = 0; i < rows.Count; i++)
                newCol.Add(0);
            rows.Add(newCol);

            //wydłuż w dół
            foreach (var col in rows)
            {
                col.Add(0);
            }
        }
        public void RemoveVerticle(int i)
        {
            rows.RemoveAt(i);
            foreach (var col in rows)
            {
                col.RemoveAt(i);
            }
        }

        public int this[int i, int j]
        {
            get { return (rows[i])[j]; }
            set { (rows[i])[j] = value; }
        }

        public void Show()
        {
            Console.WriteLine();
            Console.WriteLine("1 2 3 4 5 6 7 ");
            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < rows.Count; j++)
                {
                    Console.Write(this[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("1 2 3 4 5 6 7 8 9 ");
            Console.WriteLine();
            
        }

        public int GetSize()
        {
            return rows.Count;
        }
        
        public Matrix MultiplyMatrix(Matrix matrix)
        {
            int wymiar = this.GetSize();
            int suma;
            int iloczyn;
 
            Matrix matrixWyn = new Matrix(wymiar);
 
            for (int i = 0; i < wymiar; i++)
            {
                for (int k = 0; k < wymiar; k++)
                {
                    suma = 0;
                    for (int j = 0; j < wymiar; j++)
                    {
                        iloczyn = this[i, j] * matrix[j, k];
                        suma = suma + iloczyn;
                    }
                    matrixWyn[i, k] = suma;
                }
            }
            return matrixWyn;
        }
    }
}
