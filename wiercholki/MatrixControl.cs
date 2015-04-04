using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wiercholki
{
    public partial class MatrixControl : UserControl
    {
        public MatrixControl()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                e.PaintBackground(e.CellBounds, true);

                using (SolidBrush br = new SolidBrush(Color.Black))
                {
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    var vertex = e.Value as Vertex;
                    if (vertex != null)
                        e.Graphics.DrawString(vertex.Name, e.CellStyle.Font, br, e.CellBounds, sf);
                    else
                    {
                        e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, br, e.CellBounds, sf);
                    }
                }

                e.Handled = true;
            }
        }

        public void UpdateHeaders(Vertex vertex)
        {
            dataGridView1.Columns[vertex.Id].HeaderCell.Value = vertex.Name;
            dataGridView1.Rows[vertex.Id].HeaderCell.Value = vertex.Name;

            dataGridView1.Update();
        }

        public void LoadMatrix(Matrix matrix, List<Vertex> verticles)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            int size = verticles.Count;
            for (int j = 0; j < size; j++)
            {
                dataGridView1.Columns.Add(verticles[j].Name, verticles[j].Name);

                if (dataGridView1.Columns.Contains(verticles[j].Name))
                    dataGridView1.Columns[verticles[j].Name].Width = 40;
                else throw new Exception("something went wrong when creating dataGridView column");
            }
            for (int i = 0; i < size; i++)
            {
                string[] datarow = new string[size];
                for (int j = 0; j < size; j++)
                {
                    datarow[j] = Convert.ToString(matrix[i, j]);
                }
                dataGridView1.Rows.Add(datarow);
                dataGridView1.Rows[i].Height = 20;
                dataGridView1.Rows[i].HeaderCell.Value = verticles[i].Name.ToString();
            }
        }
    }
}
