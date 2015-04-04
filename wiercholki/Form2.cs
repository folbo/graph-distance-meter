using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wiercholki
{
    public delegate void UpdateMatrixDelegate(Graf graf);

    public partial class Form2 : Form
    {
        public Form2()
        {
            //UpdateMatrix update = new UpdateMatrix();
            InitializeComponent();
        }

       

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        public void OnUpdateMatrix(Graf graf)
        {
            matrixControl1.LoadMatrix(graf.Matrix, graf.wierzcholki);
        }
    }
}
