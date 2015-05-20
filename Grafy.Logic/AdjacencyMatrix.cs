using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy.Logic
{
    public class AdjacencyMatrix
    {
        /// <summary>
        /// np. rows = { {1 2 3} {4 5 6} {7 8 9} }
        /// 1 2 3
        /// 4 5 6
        /// 7 8 9
        /// </summary>
        private List<List<int>> _rows;

        public AdjacencyMatrix()
        {
            _rows = new List<List<int>>();
        }

        private AdjacencyMatrix(int size)
        {
            _rows = new List<List<int>>();
            for(int i = 0; i < size; i++)
                AddVerticle();
        }

        public int this[int i, int j]
        {
            get { return (_rows[i])[j]; }
            set { (_rows[i])[j] = value; }
        }

        public int Size()
        {
            return _rows.Count;
        }

        public void AddVerticle()
        {
            //dodaj nowy wiersz
            //{ {1 2 3} {4 5 6} {7 8 9} {x x x} }
            var newRow = new List<int>();
            for (int i = 0; i < _rows.Count; i++)
                newRow.Add(0);
            _rows.Add(newRow);

            //wydluz wszystkie wiersze o jeden { {1 2 3 y} {4 5 6 y} {7 8 9 y} {x x x y} }
            foreach (var row in _rows)
            {
                row.Add(0);
            }
        }

        public void RemoveVerticle(int i)
        {
            //{ {1 2 3} {x} {7 8 9} }
            _rows.RemoveAt(i);

            //{ {1 x 3} {7 x 9} }
            foreach (var row in _rows)
            {
                row.RemoveAt(i);
            }
            //rezultat:
            //{ {1 3} {7 9} }
        }

        public int GetSize()
        {
            return _rows.Count;
        }

        public AdjacencyMatrix MultiplyMatrix(AdjacencyMatrix matrix)
        {
            int wymiar = this.GetSize();
            int suma;
            int iloczyn;

            AdjacencyMatrix matrixWyn = new AdjacencyMatrix(wymiar);

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
