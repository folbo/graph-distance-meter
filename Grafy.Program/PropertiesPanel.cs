using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grafy.Logic;

namespace Grafy.Program
{
    public partial class PropertiesPanel : UserControl
    {
        private Graph _graph;

        public PropertiesPanel()
        {
            InitializeComponent();
        }

        public void LoadGraph(Graph graph)
        {
            
        }

        private void bothDirected_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.Checked)
            {
                _graph.ChangeDirection(_graph.SelectedEdge, Direction.Both);
            }
        }

        private void firstDirected_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.Checked)
            {
                _graph.ChangeDirection(_graph.SelectedEdge, Direction.ToFirst);
            }
        }

        private void secondDirected_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.Checked)
            {
                _graph.ChangeDirection(_graph.SelectedEdge, Direction.ToSecond);
            }
        }
    }
}
