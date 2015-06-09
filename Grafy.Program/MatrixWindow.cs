using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grafy.Logic;

namespace Grafy.Program
{
    public partial class MatrixWindow : Form
    {
        public MatrixWindow()
        {
            InitializeComponent();
        }



        public void LoadMatrix(AdjacencyMatrix matrix, List<Vertex> list)
        {
            matrixControl1.LoadMatrix(matrix, list);
        }
    }
}
