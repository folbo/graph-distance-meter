using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grafy.Logic;

namespace Grafy.Program
{
    enum InputState { DrawVertex, DrawEdge, MoveVertex, Idle }

    public partial class MainForm : Form
    {
        private Graph _graph;
        private Input _input;
        private InputState _inputState;
        private myPoint _mouseCursor;

        private string _nextVertexName = "A";

        private AdjacencyMatrix _multipliedMatrix;
        private int _lastestShortestPath;
        private bool _dirty;
        private bool dirty 
        {
            get { return _dirty; }
            set
            {
                _dirty = value;
                Update();
            } 
        }

        public MainForm()
        {
            InitializeComponent();

            graphPanel1.Bitmap = new Bitmap(graphPanel1.Width, graphPanel1.Height);
            _graph = new Graph();
            _input = new Input();
            _inputState = InputState.DrawVertex;
            _mouseCursor = new myPoint();

            propertyPanel.Visible = false;

            dirty = true;
        }

        private void graphPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    _input.MouseButtonState[0] = true;
                    break;
                case MouseButtons.Middle:
                    _input.MouseButtonState[1] = true;
                    break;
                case MouseButtons.Right:
                    _input.MouseButtonState[2] = true;
                    break;
            }

            switch (e.Button)
            {
                case MouseButtons.Left:
                    switch (_inputState)
                    {
                        case InputState.DrawVertex:
                            var newVertex = new Vertex((int) _mouseCursor.X, (int) _mouseCursor.Y, 10, _nextVertexName);
                            _graph.AddVertex(newVertex);
                            _nextVertexName = Alphabet.GetNextBase26(_nextVertexName);

                            vertex1_ComboBox.Items.Add(newVertex);
                            vertex2_ComboBox.Items.Add(newVertex);

                            dirty = true;

                            break;

                        case InputState.DrawEdge:
                            if (_graph.HoveredVertex != null)
                            {
                                //rozpocznij rysowanie od wierzchołka
                                if (_graph.EdgeInBuild == null)
                                {
                                    _graph.EdgeInBuild = new Edge(_graph.HoveredVertex, null, Direction.Both);
                                }
                                //koncz rysowanie
                                else
                                {
                                    _graph.EdgeInBuild.SecondVertex = _graph.HoveredVertex;
                                    _graph.AddEdge(_graph.EdgeInBuild);

                                    _graph.EdgeInBuild = null;

                                    dirty = true;
                                }
                            }
                            break;

                        case InputState.Idle:
                            if (_graph.HoveredVertex != null)
                            {
                                _graph.SelectedVertex = _graph.HoveredVertex;
                                _graph.SelectedEdge = null;

                                _inputState = InputState.MoveVertex;
                            }
                            else
                            {
                                _graph.SelectedVertex = null;
                            }
                            if (_graph.HoveredEdge != null)
                            {
                                _graph.SelectedEdge = _graph.HoveredEdge;
                                _graph.SelectedVertex = null;
                            }
                            else
                            {
                                _graph.SelectedEdge = null;
                            }

                            break;
                    }
                    break;
                case MouseButtons.Middle:
                    break;
                case MouseButtons.Right:
                    _graph.EdgeInBuild = null;

                    if (_graph.HoveredVertex != null)
                    {
                        string name = _graph.HoveredVertex.Name;

                        vertex1_ComboBox.Items.Remove(_graph.HoveredVertex);
                        vertex2_ComboBox.Items.Remove(_graph.HoveredVertex);

                        _graph.RemoveVertex(_graph.HoveredVertex);

                        dirty = true;
                    }

                    if (_graph.HoveredEdge != null)
                    {
                        _graph.RemoveEdge(_graph.HoveredEdge);

                        dirty = true;
                    }

                    _graph.SelectedVertex = null;
                    _graph.SelectedEdge = null;
                    break;
            }
            Update();
            adjMatrix_MatrixControl.LoadMatrix(_graph.AdjacencyMatrix, _graph.Verticles);
        }

        private Point? clickPosition;
        private void graphPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    _input.MouseButtonState[0] = false;

                    if (_inputState == InputState.MoveVertex)
                    {
                        _inputState = InputState.Idle;
                    }

                    clickPosition = null;

                    break;
                case MouseButtons.Middle:
                    _input.MouseButtonState[1] = false;
                    break;
                case MouseButtons.Right:
                    _input.MouseButtonState[2] = false;
                    break;
            }
            Update();
        }

        private void graphPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            _mouseCursor.X = e.X;
            _mouseCursor.Y = e.Y;

            if (_graph != null)
            {
                //albo wierzchołek, albo krawędź
                object hovered = _graph.FindNearestVertex(_mouseCursor.X, _mouseCursor.Y, 50);
                if (hovered as Vertex == null)
                    hovered = _graph.FindNearestEdge(_mouseCursor.X, _mouseCursor.Y, 10);
                //..
                _graph.HoveredVertex = hovered as Vertex;
                _graph.HoveredEdge = hovered as Edge;
        
                if (_input.MouseButtonState[0])
                {
                    switch (e.Button)
                    {
                        case MouseButtons.Left:
                            
                            break;
                    }
                }

                if (_inputState == InputState.MoveVertex)
                {
                    if (_graph.SelectedVertex != null)
                    {
                        if (!clickPosition.HasValue)
                        {
                            clickPosition = e.Location;
                        }
                        else
                        {

                            int dX = e.Location.X - clickPosition.Value.X;
                            int dY = e.Location.Y - clickPosition.Value.Y;

                            _graph.SelectedVertex.X += dX;
                            _graph.SelectedVertex.Y += dY;

                            if (_graph.SelectedVertex.X < 0)
                                _graph.SelectedVertex.X = 0;
                            if (_graph.SelectedVertex.X > graphPanel1.Width)
                                _graph.SelectedVertex.X = graphPanel1.Width;
                            if (_graph.SelectedVertex.Y < 0)
                                _graph.SelectedVertex.Y = 0;
                            if (_graph.SelectedVertex.Y > graphPanel1.Height)
                                _graph.SelectedVertex.Y = graphPanel1.Height;

                            var relatedEdges = _graph.Edges.Where(edge =>
                                (edge.FirstVertex == _graph.SelectedVertex) ||
                                (edge.SecondVertex == _graph.SelectedVertex)).ToArray();

                            foreach (var edge in relatedEdges)
                            {
                                _graph.UpdateRelatedPaths(edge);
                            }

                            //reset click postition so move offset won't increase forever
                            clickPosition = e.Location;
                        }
                    }
                }

                graphPanel1.Refresh();
                TogglePropertyPanel();

                Update();
            }
        }

        private void drawVertex_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.Checked)
                _inputState = InputState.DrawVertex;

            TogglePropertyPanel();
        }

        private void drawEdge_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.Checked)
                _inputState = InputState.DrawEdge;

            TogglePropertyPanel();
        }

        private void select_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.Checked)
                _inputState = InputState.Idle;

            TogglePropertyPanel();
        }

        private void graphPanel1_Paint(object sender, PaintEventArgs e)
        {
            if (_graph != null)
            {
                using (var graphics = Graphics.FromImage(graphPanel1.Bitmap))
                {
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    graphics.Clear(Color.DarkGray);

                    _graph.PaintGraph(graphics, _mouseCursor);
                }
            }
        }

        #region PropertyPanel

        private void PropertyPanelEdge()
        {
            panelTitle_Label.Text = @"Właściowości krawędzi";
            propertyPanel.Height = 90; //185, 110

            name_Label.Text = @"Kierunek: ";
            name_TextBox.Visible = false;

            bothDirected_RadioButton.Visible = true;
            firstDirected_RadioButton.Visible = true;
            secondDirected_RadioButton.Visible = true;

            if (_graph.SelectedEdge != null)
            {
                if (_graph.SelectedEdge.Direction == Direction.Both)
                    bothDirected_RadioButton.Checked = true;
                if (_graph.SelectedEdge.Direction == Direction.ToFirst)
                    firstDirected_RadioButton.Checked = true;
                if (_graph.SelectedEdge.Direction == Direction.ToSecond)
                    secondDirected_RadioButton.Checked = true;

              

                //update labels
                firstDirected_RadioButton.Text = "Do " + _graph.SelectedEdge.FirstVertex.Name;
                secondDirected_RadioButton.Text = "Do " + _graph.SelectedEdge.SecondVertex.Name;
            }
        }

        void PropertyPanelVertex()
        {
            panelTitle_Label.Text = "Właściowości wierzchołka";
            propertyPanel.Height = 50; //185, 64

            name_Label.Text = "Nazwa";
            name_TextBox.Visible = true;

            bothDirected_RadioButton.Visible = false;
            firstDirected_RadioButton.Visible = false;
            secondDirected_RadioButton.Visible = false;
        }

        private void TogglePropertyPanel()
        {
            if (_inputState == InputState.Idle)
            {
                if (_graph.SelectedVertex == null)
                {
                    if (_graph.SelectedEdge != null)
                    {
                        PropertyPanelEdge();
                        propertyPanel.Visible = true;
                    }
                    else
                    {
                        propertyPanel.Visible = false;
                    }
                }
                else
                {
                    PropertyPanelVertex();
                    propertyPanel.Visible = true;
                    name_TextBox.Text = _graph.SelectedVertex.Name;
                }
            }
            else
            {
                propertyPanel.Visible = false;
            }
        }

        private void bothDirected_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.Checked)
            {
                _graph.ChangeDirection(_graph.SelectedEdge, Direction.Both);
                graphPanel1.Refresh();
            }
        }

        private void firstDirected_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.Checked)
            {
                _graph.ChangeDirection(_graph.SelectedEdge, Direction.ToFirst);
                graphPanel1.Refresh();
            }
        }

        private void secondDirected_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.Checked)
            {
                _graph.ChangeDirection(_graph.SelectedEdge, Direction.ToSecond);
                graphPanel1.Refresh();
            }
        }

        private void name_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (_graph.SelectedVertex != null)
            {
                _graph.SelectedVertex.Name = name_TextBox.Text;
                adjMatrix_MatrixControl.UpdateHeaders(_graph.SelectedVertex);

                int index = vertex1_ComboBox.Items.IndexOf(_graph.SelectedVertex);
                vertex1_ComboBox.Items.RemoveAt(index);
                vertex1_ComboBox.Items.Insert(index, _graph.SelectedVertex);
                vertex2_ComboBox.Items.RemoveAt(index);
                vertex2_ComboBox.Items.Insert(index, _graph.SelectedVertex);

                dirty = true;
            }
        }

        #endregion

        private void calculateDistance_Button_Click(object sender, EventArgs e)
        {
            Vertex firstSelected = vertex1_ComboBox.SelectedItem as Vertex;
            Vertex secondSelected = vertex2_ComboBox.SelectedItem as Vertex;

            if (firstSelected != null && secondSelected != null)
            {
                if (firstSelected == secondSelected)
                {
                    int zero = 0;
                    MessageBox.Show("Szukana odległość wynosi: " + zero.ToString() +
                                    ".\n\nZ definicji, ponieważ odniesienie do tego samego wierzchołka.");
                    return;
                }

                _multipliedMatrix = _graph.AdjacencyMatrix;
                int i = 1;

                if (_graph.AdjacencyMatrix[firstSelected.Id, secondSelected.Id] <= 0)
                {
                    _multipliedMatrix = _graph.AdjacencyMatrix.MultiplyMatrix(_graph.AdjacencyMatrix);
                    i++;
                    while (_multipliedMatrix[firstSelected.Id, secondSelected.Id] <= 0 && i < _graph.Verticles.Count)
                    {
                        i++;
                        _multipliedMatrix = _graph.AdjacencyMatrix.MultiplyMatrix(_multipliedMatrix);
                    }
                    if (_multipliedMatrix[firstSelected.Id, secondSelected.Id] == 0)
                    {
                        i = 0;
                    }
                }

                dirty = false;
                _lastestShortestPath = i;
                MessageBox.Show("Szukana odległość wynosi: " + i.ToString() + ".");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void adjMatrix_MatrixControl_Load(object sender, EventArgs e)
        {

        }
        
        private void Update()
        {
            if (_graph == null)
            {
                infol.Text = "...";
            }
            else if (_graph.Edges.Count == 0)
            {
                infol.Text = "To jest graf pusty.";
            }
            else if (_graph.IsMulti)
            {
                infol.Text = "To jest multigraf.";
            }
            else
            {
                infol.Text = "To jest graf prosty.";
            }

            TogglePropertyPanel();
            graphPanel1.Refresh();

            showMatrix_Button.Enabled = !dirty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _graph = new Graph();
            adjMatrix_MatrixControl.LoadMatrix(_graph.AdjacencyMatrix, _graph.Verticles);

            vertex1_ComboBox.Items.Clear();
            vertex2_ComboBox.Items.Clear();

            _nextVertexName = "A";

            showMatrix_Button.Enabled = false;

            Update();
        }

        private void showMatrixButton_Click(object sender, EventArgs e)
        {
            if (_multipliedMatrix != null)
            {
                MatrixWindow window = new MatrixWindow();

                window.LoadMatrix(_multipliedMatrix, _graph.Verticles);
                window.Text = _lastestShortestPath + " potęga macierzy";
                window.ShowDialog();
            }
        }
    }
}
