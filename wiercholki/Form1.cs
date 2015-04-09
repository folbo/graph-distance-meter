using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using wiercholki.Logic;

namespace wiercholki
{
    enum InputState { DrawVertex, DrawEdge, MoveVertex, NoInput, MovePropertyPanel }

    public partial class Form1 : Form
    {
        private InputState state;
        private Graph graph;

        private myPoint mouse;

        private object hovered;
        private object selected;

        //edge-build stage
        private Edge edgeInBuild;

        private string nextVerticleText;

        int dX;
        int dY;

        

        public Form1()
        {
            InitializeComponent();
            state = InputState.NoInput;

            mainPanel.Bitmap = new Bitmap(mainPanel.Width, mainPanel.Height);
            mouse = new myPoint();

            propertyPanel.Visible = false;

            nextVerticleText = "A";
            matrixControl1.UpdateEdges += UpdateEdges;

            vertexModeButton_Click(null, null);
        }

        private System.Drawing.Point? clickPosition;
        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (graph != null)
            {
                switch (state)
                {
                    case InputState.DrawVertex:
                        //dodaj wierzchołek
                        if (e.Button == MouseButtons.Left)
                        {
                            Vertex v = new Vertex(e.X, e.Y, 10, nextVerticleText);
                            graph.AddVertex(v);

                            selected = v;
                            nextVerticleText = Alphabet.GetNextBase26(nextVerticleText);

                            mainPanel.Refresh();
                            vertex1ComboBox.Items.Add(v);
                            vertex2ComboBox.Items.Add(v);
                        }
                        //usun wierzchołek
                        if (e.Button == MouseButtons.Right)
                        {
                            if (hovered as Vertex != null)
                            {
                                graph.RemoveVertex(hovered as Vertex);
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
                                    edgeInBuild = new Edge(hovered as Vertex, null, Direction.Both);
                                }
                                //koncz rysowanie
                                else
                                {
                                    edgeInBuild.SecondVertex = hovered as Vertex;
                                    graph.AddEdge(edgeInBuild);

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
                                    graph.RemoveEdge(hovered as Edge);
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
                        if (e.Button == MouseButtons.Left)
                        {
                            selected = hovered as Vertex;
                            if ((hovered as Vertex) == null)
                            {
                                selected = hovered as Edge;
                            }

                            TogglePropertyPanel();
                            if (selected as Vertex != null)
                            {
                                state = InputState.MoveVertex;
                                mouse.X = e.X;
                                mouse.Y = e.Y;
                            }
                        }
                        if (e.Button == MouseButtons.Right)
                        {
                            selected = null;
                        }
                        break;
                }
                matrixControl1.LoadMatrix(graph.Matrix, graph.verticles);
            }
        }
        private void mainPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (graph != null)
            {
                if (state == InputState.MoveVertex)
                    state = InputState.NoInput;

                clickPosition = null;
            }
        }

        void UpdateGraphFromInput()
        {
            graph.SelectedEdge = selected as Edge;
            graph.SelectedVertex = selected as Vertex;
            graph.HoveredEdge = hovered as Edge;
            graph.HoveredVertex = hovered as Vertex;
        }

        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (graph != null)
            {
                hovered = graph.FindNearestVertex(e.X, e.Y, 50);
                
                if ((hovered as Vertex) == null)
                    hovered = graph.FindNearestEdge(e.X, e.Y, 10);

                mouse.X = e.X;
                mouse.Y = e.Y;

                //TogglePropertyPanel();

                if (state == InputState.MoveVertex)
                {
                    if ((selected as Vertex) != null)
                    {
                        if (!clickPosition.HasValue)
                        {
                            clickPosition = e.Location;
                        }
                        else
                        {

                            dX = e.Location.X - clickPosition.Value.X;
                            dY = e.Location.Y - clickPosition.Value.Y;

                            (selected as Vertex).X += dX;
                            (selected as Vertex).Y += dY;

                            if ((selected as Vertex).X < 0)
                                (selected as Vertex).X = 0;
                            if ((selected as Vertex).X > mainPanel.Width)
                                (selected as Vertex).X = mainPanel.Width;
                            if ((selected as Vertex).Y < 0)
                                (selected as Vertex).Y = 0;
                            if ((selected as Vertex).Y > mainPanel.Height)
                                (selected as Vertex).Y = mainPanel.Height;

                            var relatedEdges = graph.edges.Where(edge =>
                                (edge.FirstVertex == selected) ||
                                (edge.SecondVertex == selected)).ToArray();
                            foreach (var edge in relatedEdges)
                            {
                                graph.UpdatePaths(edge);
                            }

                            //reset click postition so move offset won't increase forever
                            clickPosition = e.Location;
                        }
                    }
                }
                if (state == InputState.MovePropertyPanel)
                {
                    if (!clickPosition.HasValue)
                    {
                        clickPosition = e.Location;
                    }
                    else
                    {
                        dX = e.Location.X - clickPosition.Value.X;
                        dY = e.Location.Y - clickPosition.Value.Y;

                        (selected as Vertex).X += dX;
                        (selected as Vertex).Y += dY;

                        var relatedEdges = graph.edges.Where(edge =>
                            (edge.FirstVertex == selected) ||
                            (edge.SecondVertex == selected)).ToArray();
                        foreach (var edge in relatedEdges)
                        {
                            graph.UpdatePaths(edge);
                        }

                        //reset click postition so move offset won't increase forever
                        clickPosition = e.Location;
                    }
                }
                mainPanel.Refresh();
            }
        }

        /// <summary>
        /// create new graph
        /// </summary>
        private void newGraphButton_Click(object sender, EventArgs e)
        {
            graph = new Graph();
            mainPanel.Refresh();
            nextVerticleText = "A";
            matrixControl1.ResetMatrix();
            matrixControl1.Refresh();

            vertex1ComboBox.Items.Clear();
            vertex2ComboBox.Items.Clear();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            if (graph != null)
            {
                using (var graphics = Graphics.FromImage(mainPanel.Bitmap))
                {
                    
                    UpdateGraphFromInput();

                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    graphics.Clear(Color.DarkGray);


                    graph.PaintGraph(graphics, mouse);
                }
            }
        }
        // Property panel appearance
        private void PropertyPanelEdge()
        {
            titleLabel.Text = "Właściowości krawędzi";
            propertyPanel.Height = 90; //185, 110

            nameLabel.Text = "Kierunek: ";
            nameTextBox.Visible = false;

            bothDirectedRadio.Visible = true;
            firstDirectedRadio.Visible = true;
            secondDirectedRadio.Visible = true;
            weightTextBox.Visible = true;

            if ((selected as Edge) != null)
            {
                if ((selected as Edge).Direction == Direction.Both)
                    bothDirectedRadio.Checked = true;
                if ((selected as Edge).Direction == Direction.ToFirst)
                    firstDirectedRadio.Checked = true;
                if ((selected as Edge).Direction == Direction.ToSecond)
                    secondDirectedRadio.Checked = true;

                weightTextBox.Text = (selected as Edge).Weight.ToString();


                //update labels
                firstDirectedRadio.Text = "Do " + (selected as Edge).FirstVertex.Name;
                secondDirectedRadio.Text = "Do " + (selected as Edge).SecondVertex.Name;
            }
        }

        void PropertyPanelVertex()
        {
            titleLabel.Text = "Właściowości wierzchołka";
            propertyPanel.Height = 50; //185, 64

            nameLabel.Text = "Nazwa";
            nameTextBox.Visible = true;

            bothDirectedRadio.Visible = false;
            firstDirectedRadio.Visible = false;
            secondDirectedRadio.Visible = false;
            weightTextBox.Visible = false;
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
                        nameTextBox.Text = (hovered as Vertex).Name;
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
        //end of property panel appearance


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

        /// <summary>
        /// change edge direction to both sides radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bothDirectedRadio_MouseClick(object sender, MouseEventArgs e)
        {
            graph.ChangeDirection(selected as Edge, Direction.Both);
            mainPanel.Refresh();
        }

        /// <summary>
        /// change edge direction to first vertex radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void firstDirectedRadio_MouseClick(object sender, MouseEventArgs e)
        {
            graph.ChangeDirection(selected as Edge, Direction.ToFirst);
            mainPanel.Refresh();
        }

        /// <summary>
        /// change edge direction to second vertex readio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void secondDirectedRadio_MouseClick(object sender, MouseEventArgs e)
        {
            graph.ChangeDirection(selected as Edge, Direction.ToSecond);
            mainPanel.Refresh();
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
                    MessageBox.Show("Szukana odległość wynosi: " + zero.ToString() + ".\n\nZ definicji, ponieważ odniesienie do tego samego wierzchołka.");
                    return;
                }

                int i = 1;
                if (graph.Matrix[firstSelected.Id, secondSelected.Id] <= 0)
                {
                    var multiplied = graph.Matrix.MultiplyMatrix(graph.Matrix);
                    i++;
                    while (multiplied[firstSelected.Id, secondSelected.Id] <= 0 && i < graph.verticles.Count)
                    {
                        i++;
                        multiplied = graph.Matrix.MultiplyMatrix(multiplied);
                    }
                    if (multiplied[firstSelected.Id, secondSelected.Id] == 0)
                    {
                        i = 0;
                    }
                }
                MessageBox.Show("Szukana odległość wynosi: " + i.ToString() + ".");
            }
        }

        /// <summary>
        /// Callback function - it updates graph's edges entered to matrix
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="number"></param>
        void UpdateEdges(int v1, int v2, int number)
        {
            //int needToAdd = Graph.
            var relatedEdges = graph.edges.Where(x => (x.FirstVertex.Id == v1 && x.SecondVertex.Id == v2) || (x.FirstVertex.Id == v2 && x.SecondVertex.Id == v1));
            var list = relatedEdges.ToList();

            var firstVertex = graph.verticles.FirstOrDefault(x => x.Id == v1);
            var secondVertex = graph.verticles.FirstOrDefault(x => x.Id == v2);

            foreach (var edge in list)
            {
                graph.RemoveEdge(edge, false);
            }

            graph.Matrix[v1, v2] = number;
            //matrixControl1.LoadMatrix(graph.Matrix, graph.verticles);
            var oppositeSide = graph.Matrix[v2, v1];
            
            Console.WriteLine(v1 + " " + v2 + " edited: " + graph.Matrix[v1, v2] + ", opposite: " + graph.Matrix[v2, v1]);
            
            if (oppositeSide == number)
            {
                for (int i = 0; i < number; i++)
                {
                    Edge edge = new Edge();
                    edge.FirstVertex = firstVertex;
                    edge.SecondVertex = secondVertex;
                    edge.Direction = Direction.Both;
                    graph.AddEdge(edge, false);
                }

            }
            if (oppositeSide < number)
            {
                for (int i = 0; i < oppositeSide; i++)
                {
                    Edge edge = new Edge();
                    edge.FirstVertex = firstVertex;
                    edge.SecondVertex = secondVertex;
                    edge.Direction = Direction.Both;
                    graph.AddEdge(edge, false);
                }
                for (int i = 0; i < number - oppositeSide; i++)
                {
                    Edge edge = new Edge();
                    edge.FirstVertex = firstVertex;
                    edge.SecondVertex = secondVertex;
                    edge.Direction = Direction.ToSecond;
                    graph.AddEdge(edge, false);
                }
            }
            if (oppositeSide > number)
            {
                for (int i = 0; i < number; i++)
                {
                    Edge edge = new Edge();
                    edge.FirstVertex = firstVertex;
                    edge.SecondVertex = secondVertex;
                    edge.Direction = Direction.Both;
                    graph.AddEdge(edge, false);
                }
                for (int i = 0; i < oppositeSide - number; i++)
                {
                    Edge edge = new Edge();
                    edge.FirstVertex = firstVertex;
                    edge.SecondVertex = secondVertex;
                    edge.Direction = Direction.ToFirst;
                    graph.AddEdge(edge, false);
                }
            }

            mainPanel.Refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            System.Environment.Exit(-1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("JD&KR Crew, 2015");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("")
            if (MessageBox.Show(
                    "Pewien?", "EasterEgg!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk
                    ) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("http://i1.kwejk.pl/k/obrazki/2014/11/ce61ca4c882f361c771673ced5c96281.jpg");
            }
        }

        private void weightTextBox_TextChanged(object sender, EventArgs e)
        {
            if (selected as Edge != null)
            {
                try
                {
                    int weight = Convert.ToInt16(weightTextBox.Text);
                    (selected as Edge).Weight = weight;
                    if (graph.maxWeight < weight) graph.maxWeight = weight;
                }
                catch (Exception)
                {
                    MessageBox.Show("Waga jest liczbą!");
                }
            }
        }

    }
}
