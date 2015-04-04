using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wiercholki
{
    enum InputState { DrawVertex, DrawEdge, MoveVertex, NoInput }
    
    public partial class Form1 : Form
    {
        private InputState state;
        private Graf graf;

        private Point mouse;

        private object hovered;
        private object selected;

        //edge-build stage
        private Edge edgeInBuild;

        private string nextVerticleText;



        public Form1()
        {
            InitializeComponent();
            state = InputState.NoInput;

            mainPanel.Bitmap = new Bitmap(mainPanel.Width, mainPanel.Height);
            mouse = new Point();

            propertyPanel.Visible = false;

            nextVerticleText = "w1";
        }


        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (graf != null)
            {
                switch (state)
                {
                    case InputState.DrawVertex:
                        //dodaj wierzchołek
                        if (e.Button == MouseButtons.Left)
                        {
                            Vertex v = new Vertex();
                            v.X = e.X;
                            v.Y = e.Y;
                            v.Size = 10;
                            v.Name = nextVerticleText;
                            graf.AddVertex(v);

                            selected = v;
                            int lastNumber = Convert.ToInt32(nextVerticleText.Substring(1));
                            nextVerticleText = nextVerticleText.Remove(1);
                            nextVerticleText += lastNumber + 1;

                            mainPanel.Refresh();
                            vertex1ComboBox.Items.Add(v);
                            vertex2ComboBox.Items.Add(v);
                        }
                        //usun wierzchołek
                        if (e.Button == MouseButtons.Right)
                        {
                            if (hovered as Vertex != null)
                            {
                                graf.RemoveVertex(hovered as Vertex);
                            }
                            else
                            {
                                if (selected as Vertex == null)
                                {
                                    state = InputState.NoInput;
                                    radioButton3.Checked = true;
                                }
                            }
                            selected = null;
                        }
                        break;

                    case InputState.DrawEdge:
                        if (e.Button == MouseButtons.Left)
                        {
                            //magnet
                            if (hovered as Vertex != null)
                            {
                                //rozpocznij rysowanie od wierzchołka
                                if (edgeInBuild == null)
                                {
                                    edgeInBuild = new Edge();
                                    edgeInBuild.FirstVertex = hovered as Vertex;
                                    edgeInBuild.direction = Direction.Both;
                                }
                                    //koncz rysowanie
                                else
                                {
                                    edgeInBuild.SecondVertex = hovered as Vertex;
                                    graf.AddEdge(edgeInBuild);
                                    edgeInBuild = null;
                                }

                                mainPanel.Refresh();
                            }

                        }
                        //przerwij rysowanie krawedzi lub usun
                        if (e.Button == MouseButtons.Right)
                        {
                            if (edgeInBuild != null)
                                edgeInBuild = null;
                            else
                            {
                                if (hovered as Edge != null)
                                {
                                    graf.RemoveEdge(hovered as Edge);
                                }
                                else
                                {
                                    if (selected as Vertex == null)
                                    {
                                        state = InputState.NoInput;
                                        radioButton3.Checked = true;
                                    }
                                }

                                selected = null;
                            }
                        }
                        break;
                    case InputState.NoInput:
                        selected = hovered as Vertex;
                        if ((hovered as Vertex) == null)
                        {
                            selected = hovered as Edge;
                        }

                        TogglePropertyPanel();
                        if (selected as Vertex != null)
                        {
                            state = InputState.MoveVertex;
                        }
                        break;
                }
                matrixControl1.LoadMatrix(graf.Matrix, graf.wierzcholki);
            }
        }
        private void mainPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (graf != null)
            {
                if (state == InputState.MoveVertex)
                    state = InputState.NoInput;
            }
        }

        private void PropertyPanelEdge()
        {
            titleLabel.Text = "Właściowości krawędzi";
            propertyPanel.Height = 110; //185, 110

            nameLabel.Text = "Kierunek: ";
            nameTextBox.Visible = false;

            bothDirectedRadio.Visible = true;
            firstDirectedRadio.Visible = true;
            secondDirectedRadio.Visible = true;
            if ((selected as Edge) != null)
            {
                if ((selected as Edge).direction == Direction.Both)
                    bothDirectedRadio.Checked = true;
                if ((selected as Edge).direction == Direction.ToFirst)
                    firstDirectedRadio.Checked = true;
                if ((selected as Edge).direction == Direction.ToSecond)
                    secondDirectedRadio.Checked = true;
            }
        }

        void PropertyPanelVertex()
        {
            titleLabel.Text = "Właściowości wierzchołka";
            propertyPanel.Height = 64; //185, 64

            nameLabel.Text = "Nazwa";
            nameTextBox.Visible = true;

            bothDirectedRadio.Visible = false;
            firstDirectedRadio.Visible = false;
            secondDirectedRadio.Visible = false;
        }

        private void TogglePropertyPanel()
        {
          
                if ((selected as Vertex) == null)
                {
                    if (selected as Edge != null)
                    {
                        PropertyPanelEdge();
                        propertyPanel.Visible = true;
                    }
                    else
                    {
                        PropertyPanelVertex();
                        if ((hovered as Vertex) != null)
                        {
                            propertyPanel.Visible = true;
                            nameTextBox.Text =( hovered as Vertex).Name;
                        }
                        else
                            propertyPanel.Visible = false;
                    }
                }
                else
                {
                    PropertyPanelVertex();
                    propertyPanel.Visible = true;
                    nameTextBox.Text = (selected as Vertex).Name;
                }
            
        }
        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (graf != null)
            {
                hovered = graf.FindNearestVertex(e.X, e.Y, 50);
                if ((hovered as Vertex) == null)
                    hovered = graf.FindNearestEdge(e.X, e.Y, 10);

                mouse.X = e.X;
                mouse.Y = e.Y;

                TogglePropertyPanel();

                if (state == InputState.MoveVertex)
                {
                    if ((selected as Vertex) != null)
                    {
                        (selected as Vertex).X = e.X;
                        (selected as Vertex).Y = e.Y;

                        var relatedEdges = graf.krawedzie.Where( edge =>
                            (edge.FirstVertex == selected) ||
                            (edge.SecondVertex == selected)).ToArray();
                        foreach (var edge in relatedEdges)
                        {
                            graf.UpdatePaths(edge);
                        }
                    }
                }
                mainPanel.Refresh();
            }
        }

        private void newGraphButton_Click(object sender, EventArgs e)
        {
            graf = new Graf();
            mainPanel.Refresh();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            if (graf != null)
            {
                using (var graphics = Graphics.FromImage(mainPanel.Bitmap))
                {
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    graphics.Clear(Color.Black);

                    foreach (var vertex in graf.wierzcholki)
                    {
                        graphics.DrawEllipse(System.Drawing.Pens.BlueViolet, vertex.X - vertex.Size / 2, vertex.Y - vertex.Size / 2, vertex.Size, vertex.Size);
                        FontFamily fontFamily = new FontFamily("Times New Roman");
                        Font font = new Font(
                           fontFamily,
                           12,
                           FontStyle.Regular,
                           GraphicsUnit.Pixel);
                        
                        graphics.DrawString(vertex.Name, font, Brushes.White, new PointF(vertex.X-20, vertex.Y-20));
                        //najpierw pokoloruj zaznaczony, potem obsłuż hover
                        if (vertex == selected as Vertex)
                        {
                            using (Brush brush = new SolidBrush(Color.FromArgb(200, 200, 60, 40)))
                            {
                                // graphics.FillRectangle(brush, vertex.X - vertex.Size / 2, vertex.Y - vertex.Size / 2,
                                //vertex.Size + 1, vertex.Size + 1);
                                graphics.FillEllipse(brush, vertex.X - vertex.Size / 2, vertex.Y - vertex.Size / 2, vertex.Size, vertex.Size);
                            }
                        }
                        //as vertex
                        if (vertex == hovered)
                        {
                            using (Brush brush = new SolidBrush(Color.FromArgb(100, 20, 60, 200)))
                            {
                               // graphics.FillRectangle(brush, vertex.X - vertex.Size / 2, vertex.Y - vertex.Size / 2,
                                    //vertex.Size + 1, vertex.Size + 1);
                                graphics.FillEllipse(brush, vertex.X - vertex.Size / 2, vertex.Y - vertex.Size / 2, vertex.Size, vertex.Size);
                            }
                        }
                    }
                    foreach (var edge in graf.krawedzie)
                    {
                       
                        using (var pen = new System.Drawing.Pen(System.Drawing.Color.White, 1))
                        {
                            if (edge.direction == Direction.ToFirst)
                            {
                                AdjustableArrowCap cap = new AdjustableArrowCap(3, 7);
                                cap.Filled = true;
                                pen.CustomStartCap = cap;
                            }
                            if (edge.direction == Direction.ToSecond)
                            {
                                AdjustableArrowCap cap = new AdjustableArrowCap(3, 7);
                                cap.Filled = true;
                                pen.CustomEndCap = cap;
                            }

                            graphics.DrawPath(pen, edge.Path);
                        }
                        //as edge
                        if (edge == hovered && edgeInBuild == null)
                        {
                            using (var pen = new System.Drawing.Pen(Color.FromArgb(100, 20, 60, 200), 4))
                            {
                                graphics.DrawPath(pen, edge.Path);
                            }
                        }
                        if (edge == selected as Edge)
                        {
                            using (var pen = new System.Drawing.Pen(Color.FromArgb(100, 20, 60, 200), 4))
                            {
                                graphics.DrawPath(pen, edge.Path);
                            }
                        }
                    }

                    //jesli jakas krawedz jest w budowie
                    if (edgeInBuild != null)
                    {
                        //magnetic
                        if ((hovered as Vertex)!= null)
                        {
                            using (var pen = new System.Drawing.Pen(Color.FromArgb(100, 20, 60, 200), 4))
                            {
                                graphics.DrawLine(pen, edgeInBuild.FirstVertex.X, edgeInBuild.FirstVertex.Y,
                                    (hovered as Vertex).X, (hovered as Vertex).Y);
                            }
                        }
                        //free move
                        else
                        {
                            using (var pen = new System.Drawing.Pen(Color.FromArgb(100, 20, 60, 200), 1))
                            {
                                graphics.DrawLine(pen, edgeInBuild.FirstVertex.X, edgeInBuild.FirstVertex.Y,
                                    mouse.X, mouse.Y);
                            }
                        }
                    }
                }
            }
        }

        private void vertexModeButton_Click(object sender, EventArgs e)
        {
            state = InputState.DrawVertex;
            edgeInBuild = null;
        }

        private void edgeModeButton_Click(object sender, EventArgs e)
        {
            state = InputState.DrawEdge;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            state = InputState.NoInput;
            edgeInBuild = null;
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (selected as Vertex != null)
            {
                (selected as Vertex).Name = nameTextBox.Text;
                matrixControl1.UpdateHeaders((Vertex)selected);

                int index = vertex1ComboBox.Items.IndexOf(selected);
                vertex1ComboBox.Items.RemoveAt(index);
                vertex1ComboBox.Items.Insert(index, selected);
                vertex2ComboBox.Items.RemoveAt(index);
                vertex2ComboBox.Items.Insert(index, selected);
            }
        }

        private void bothDirectedRadio_MouseClick(object sender, MouseEventArgs e)
        {
            graf.ChangeDirection(selected as Edge, Direction.Both);
            mainPanel.Refresh();
        }

        private void firstDirectedRadio_MouseClick(object sender, MouseEventArgs e)
        {
            graf.ChangeDirection(selected as Edge, Direction.ToFirst);
            mainPanel.Refresh();
        }

        private void secondDirectedRadio_MouseClick(object sender, MouseEventArgs e)
        {
            graf.ChangeDirection(selected as Edge, Direction.ToSecond);
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
                    e.Graphics.DrawString(e.Value.ToString(),

                    e.CellStyle.Font, br, e.CellBounds, sf);

                }

                e.Handled = true;

            }
        }

        private void calculateDistance_Click(object sender, EventArgs e)
        {
            Vertex firstSelected = vertex1ComboBox.SelectedItem as Vertex;
            Vertex secondSelected = vertex2ComboBox.SelectedItem as Vertex;
            if (firstSelected != null && secondSelected != null)
            {
                if (firstSelected == secondSelected)
                {
                    int zero = 0;
                    MessageBox.Show("Odległość wynosi: " + zero.ToString() + ".\n\nZ definicji, ponieważ odniesienie do tego samego wierzchołka.");
                    return;
                }
                int i = 1;
                if (graf.Matrix[firstSelected.Id, secondSelected.Id] <= 0)
                {
                    var multiplied = graf.Matrix.MultiplyMatrix(graf.Matrix);
                    i++;
                    while (multiplied[firstSelected.Id, secondSelected.Id] <= 0 && i < graf.wierzcholki.Count)
                    {
                        i++;
                        multiplied = graf.Matrix.MultiplyMatrix(multiplied);
                    }
                    if (multiplied[firstSelected.Id, secondSelected.Id] == 0)
                    {
                        i = 0;
                    }
                }
                MessageBox.Show("Odległość wynosi: " + i.ToString() + ".");
            }
        }
    }

    class Alphabet
    {
        private List<char> alfabet;
        public int Current { get; set; }
        private int index;

        public Alphabet()
        {
            index = 0;
            alfabet = new List<char>();
            for (char z = 'A'; z <= 'Z'; z++)
            {
                alfabet.Add(z);
            }
            Current = 0;
        }

        public string Next()
        {
            return null;
        }
    }
}
