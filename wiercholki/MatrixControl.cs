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
    public delegate void UpdateEdgesDelegate(int v1_id, int v2_id, int numberOfEdges);

    public partial class MatrixControl : UserControl
    {
        public event UpdateEdgesDelegate UpdateEdges;
        public MatrixControl()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            //dataGridView1.ReadOnly = true;
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

            dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }

        private void dataGridView1_CellErrorTextChanged(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("oaa");
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                var value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                int val = Convert.ToInt32(value);
                if(UpdateEdges != null)
                    UpdateEdges(e.RowIndex, e.ColumnIndex, val);
            }
        }

        public void ResetMatrix()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
        }
    }
}
