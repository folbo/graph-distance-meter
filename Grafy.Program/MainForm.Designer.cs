namespace Grafy.Program
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.drawVertex_radioButton = new System.Windows.Forms.RadioButton();
            this.drawEdge_radioButton = new System.Windows.Forms.RadioButton();
            this.select_radioButton = new System.Windows.Forms.RadioButton();
            this.clear_button = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.graph_tab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.adjMatrix_tab = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.calculateDistance_Button = new System.Windows.Forms.Button();
            this.vertex1_ComboBox = new System.Windows.Forms.ComboBox();
            this.vertex2_ComboBox = new System.Windows.Forms.ComboBox();
            this.graphPanel1 = new Grafy.Program.GraphPanel();
            this.propertyPanel = new System.Windows.Forms.Panel();
            this.weight_TextBox = new System.Windows.Forms.TextBox();
            this.secondDirected_RadioButton = new System.Windows.Forms.RadioButton();
            this.firstDirected_RadioButton = new System.Windows.Forms.RadioButton();
            this.bothDirected_RadioButton = new System.Windows.Forms.RadioButton();
            this.panelTitle_Label = new System.Windows.Forms.Label();
            this.name_Label = new System.Windows.Forms.Label();
            this.name_TextBox = new System.Windows.Forms.TextBox();
            this.adjMatrix_MatrixControl = new Grafy.Program.MatrixControl();
            this.tabControl1.SuspendLayout();
            this.graph_tab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.adjMatrix_tab.SuspendLayout();
            this.panel5.SuspendLayout();
            this.graphPanel1.SuspendLayout();
            this.propertyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawVertex_radioButton
            // 
            this.drawVertex_radioButton.AutoSize = true;
            this.drawVertex_radioButton.Location = new System.Drawing.Point(3, 33);
            this.drawVertex_radioButton.Name = "drawVertex_radioButton";
            this.drawVertex_radioButton.Size = new System.Drawing.Size(54, 17);
            this.drawVertex_radioButton.TabIndex = 1;
            this.drawVertex_radioButton.TabStop = true;
            this.drawVertex_radioButton.Text = "vertex";
            this.drawVertex_radioButton.UseVisualStyleBackColor = true;
            this.drawVertex_radioButton.CheckedChanged += new System.EventHandler(this.drawVertex_radioButton_CheckedChanged);
            // 
            // drawEdge_radioButton
            // 
            this.drawEdge_radioButton.AutoSize = true;
            this.drawEdge_radioButton.Location = new System.Drawing.Point(3, 57);
            this.drawEdge_radioButton.Name = "drawEdge_radioButton";
            this.drawEdge_radioButton.Size = new System.Drawing.Size(54, 17);
            this.drawEdge_radioButton.TabIndex = 2;
            this.drawEdge_radioButton.TabStop = true;
            this.drawEdge_radioButton.Text = "edges";
            this.drawEdge_radioButton.UseVisualStyleBackColor = true;
            this.drawEdge_radioButton.CheckedChanged += new System.EventHandler(this.drawEdge_radioButton_CheckedChanged);
            // 
            // select_radioButton
            // 
            this.select_radioButton.AutoSize = true;
            this.select_radioButton.Location = new System.Drawing.Point(3, 81);
            this.select_radioButton.Name = "select_radioButton";
            this.select_radioButton.Size = new System.Drawing.Size(51, 17);
            this.select_radioButton.TabIndex = 3;
            this.select_radioButton.TabStop = true;
            this.select_radioButton.Text = "move";
            this.select_radioButton.UseVisualStyleBackColor = true;
            this.select_radioButton.CheckedChanged += new System.EventHandler(this.select_radioButton_CheckedChanged);
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(13, 13);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(75, 23);
            this.clear_button.TabIndex = 4;
            this.clear_button.Text = "Rozpocznij";
            this.clear_button.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.graph_tab);
            this.tabControl1.Controls.Add(this.adjMatrix_tab);
            this.tabControl1.Location = new System.Drawing.Point(13, 42);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(710, 270);
            this.tabControl1.TabIndex = 0;
            // 
            // graph_tab
            // 
            this.graph_tab.Controls.Add(this.panel1);
            this.graph_tab.Controls.Add(this.graphPanel1);
            this.graph_tab.Location = new System.Drawing.Point(4, 22);
            this.graph_tab.Name = "graph_tab";
            this.graph_tab.Padding = new System.Windows.Forms.Padding(3);
            this.graph_tab.Size = new System.Drawing.Size(702, 244);
            this.graph_tab.TabIndex = 0;
            this.graph_tab.Text = "Graf";
            this.graph_tab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.drawVertex_radioButton);
            this.panel1.Controls.Add(this.drawEdge_radioButton);
            this.panel1.Controls.Add(this.select_radioButton);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(88, 232);
            this.panel1.TabIndex = 0;
            // 
            // adjMatrix_tab
            // 
            this.adjMatrix_tab.Controls.Add(this.adjMatrix_MatrixControl);
            this.adjMatrix_tab.Location = new System.Drawing.Point(4, 22);
            this.adjMatrix_tab.Name = "adjMatrix_tab";
            this.adjMatrix_tab.Padding = new System.Windows.Forms.Padding(3);
            this.adjMatrix_tab.Size = new System.Drawing.Size(503, 244);
            this.adjMatrix_tab.TabIndex = 1;
            this.adjMatrix_tab.Text = "Macierz sąsiedztwa";
            this.adjMatrix_tab.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.calculateDistance_Button);
            this.panel5.Controls.Add(this.vertex1_ComboBox);
            this.panel5.Controls.Add(this.vertex2_ComboBox);
            this.panel5.Location = new System.Drawing.Point(13, 318);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(360, 57);
            this.panel5.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Oblicz odległość między wierzchołkami:";
            // 
            // calculateDistance_Button
            // 
            this.calculateDistance_Button.Location = new System.Drawing.Point(230, 25);
            this.calculateDistance_Button.Name = "calculateDistance_Button";
            this.calculateDistance_Button.Size = new System.Drawing.Size(107, 23);
            this.calculateDistance_Button.TabIndex = 5;
            this.calculateDistance_Button.Text = "Oblicz";
            this.calculateDistance_Button.UseVisualStyleBackColor = true;
            this.calculateDistance_Button.Click += new System.EventHandler(this.calculateDistance_Button_Click);
            // 
            // vertex1_ComboBox
            // 
            this.vertex1_ComboBox.FormattingEnabled = true;
            this.vertex1_ComboBox.Location = new System.Drawing.Point(10, 27);
            this.vertex1_ComboBox.Name = "vertex1_ComboBox";
            this.vertex1_ComboBox.Size = new System.Drawing.Size(96, 21);
            this.vertex1_ComboBox.TabIndex = 2;
            // 
            // vertex2_ComboBox
            // 
            this.vertex2_ComboBox.FormattingEnabled = true;
            this.vertex2_ComboBox.Location = new System.Drawing.Point(112, 27);
            this.vertex2_ComboBox.Name = "vertex2_ComboBox";
            this.vertex2_ComboBox.Size = new System.Drawing.Size(94, 21);
            this.vertex2_ComboBox.TabIndex = 3;
            // 
            // graphPanel1
            // 
            this.graphPanel1.Bitmap = null;
            this.graphPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphPanel1.Controls.Add(this.propertyPanel);
            this.graphPanel1.Location = new System.Drawing.Point(97, 6);
            this.graphPanel1.Name = "graphPanel1";
            this.graphPanel1.Size = new System.Drawing.Size(599, 229);
            this.graphPanel1.TabIndex = 0;
            this.graphPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.graphPanel1_Paint);
            this.graphPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.graphPanel1_MouseDown);
            this.graphPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphPanel1_MouseMove);
            this.graphPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.graphPanel1_MouseUp);
            // 
            // propertyPanel
            // 
            this.propertyPanel.BackColor = System.Drawing.Color.White;
            this.propertyPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.propertyPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.propertyPanel.Controls.Add(this.weight_TextBox);
            this.propertyPanel.Controls.Add(this.secondDirected_RadioButton);
            this.propertyPanel.Controls.Add(this.firstDirected_RadioButton);
            this.propertyPanel.Controls.Add(this.bothDirected_RadioButton);
            this.propertyPanel.Controls.Add(this.panelTitle_Label);
            this.propertyPanel.Controls.Add(this.name_Label);
            this.propertyPanel.Controls.Add(this.name_TextBox);
            this.propertyPanel.Location = new System.Drawing.Point(409, 3);
            this.propertyPanel.Name = "propertyPanel";
            this.propertyPanel.Size = new System.Drawing.Size(185, 95);
            this.propertyPanel.TabIndex = 5;
            // 
            // weight_TextBox
            // 
            this.weight_TextBox.Location = new System.Drawing.Point(6, 65);
            this.weight_TextBox.Name = "weight_TextBox";
            this.weight_TextBox.Size = new System.Drawing.Size(54, 20);
            this.weight_TextBox.TabIndex = 6;
            // 
            // secondDirected_RadioButton
            // 
            this.secondDirected_RadioButton.AutoSize = true;
            this.secondDirected_RadioButton.Location = new System.Drawing.Point(66, 68);
            this.secondDirected_RadioButton.Name = "secondDirected_RadioButton";
            this.secondDirected_RadioButton.Size = new System.Drawing.Size(83, 17);
            this.secondDirected_RadioButton.TabIndex = 5;
            this.secondDirected_RadioButton.TabStop = true;
            this.secondDirected_RadioButton.Text = "Do drugiego";
            this.secondDirected_RadioButton.UseVisualStyleBackColor = true;
            this.secondDirected_RadioButton.CheckedChanged += new System.EventHandler(this.secondDirected_RadioButton_CheckedChanged);
            // 
            // firstDirected_RadioButton
            // 
            this.firstDirected_RadioButton.AutoSize = true;
            this.firstDirected_RadioButton.Location = new System.Drawing.Point(66, 45);
            this.firstDirected_RadioButton.Name = "firstDirected_RadioButton";
            this.firstDirected_RadioButton.Size = new System.Drawing.Size(95, 17);
            this.firstDirected_RadioButton.TabIndex = 4;
            this.firstDirected_RadioButton.TabStop = true;
            this.firstDirected_RadioButton.Text = "Do pierwszego";
            this.firstDirected_RadioButton.UseVisualStyleBackColor = true;
            this.firstDirected_RadioButton.CheckedChanged += new System.EventHandler(this.firstDirected_RadioButton_CheckedChanged);
            // 
            // bothDirected_RadioButton
            // 
            this.bothDirected_RadioButton.AutoSize = true;
            this.bothDirected_RadioButton.Location = new System.Drawing.Point(66, 22);
            this.bothDirected_RadioButton.Name = "bothDirected_RadioButton";
            this.bothDirected_RadioButton.Size = new System.Drawing.Size(78, 17);
            this.bothDirected_RadioButton.TabIndex = 3;
            this.bothDirected_RadioButton.TabStop = true;
            this.bothDirected_RadioButton.Text = "Obie strony";
            this.bothDirected_RadioButton.UseVisualStyleBackColor = true;
            this.bothDirected_RadioButton.CheckedChanged += new System.EventHandler(this.bothDirected_RadioButton_CheckedChanged);
            // 
            // panelTitle_Label
            // 
            this.panelTitle_Label.AutoSize = true;
            this.panelTitle_Label.Location = new System.Drawing.Point(26, 0);
            this.panelTitle_Label.Name = "panelTitle_Label";
            this.panelTitle_Label.Size = new System.Drawing.Size(129, 13);
            this.panelTitle_Label.TabIndex = 2;
            this.panelTitle_Label.Text = "Właściwości wierzchołka";
            // 
            // name_Label
            // 
            this.name_Label.AutoSize = true;
            this.name_Label.Location = new System.Drawing.Point(3, 22);
            this.name_Label.Name = "name_Label";
            this.name_Label.Size = new System.Drawing.Size(40, 13);
            this.name_Label.TabIndex = 1;
            this.name_Label.Text = "Nazwa";
            // 
            // name_TextBox
            // 
            this.name_TextBox.Location = new System.Drawing.Point(49, 19);
            this.name_TextBox.Name = "name_TextBox";
            this.name_TextBox.Size = new System.Drawing.Size(51, 20);
            this.name_TextBox.TabIndex = 0;
            this.name_TextBox.TextChanged += new System.EventHandler(this.name_TextBox_TextChanged);
            // 
            // adjMatrix_MatrixControl
            // 
            this.adjMatrix_MatrixControl.Location = new System.Drawing.Point(7, 7);
            this.adjMatrix_MatrixControl.Name = "adjMatrix_MatrixControl";
            this.adjMatrix_MatrixControl.Size = new System.Drawing.Size(341, 234);
            this.adjMatrix_MatrixControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 379);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.clear_button);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tabControl1.ResumeLayout(false);
            this.graph_tab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.adjMatrix_tab.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.graphPanel1.ResumeLayout(false);
            this.propertyPanel.ResumeLayout(false);
            this.propertyPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GraphPanel graphPanel1;
        private System.Windows.Forms.RadioButton drawVertex_radioButton;
        private System.Windows.Forms.RadioButton drawEdge_radioButton;
        private System.Windows.Forms.RadioButton select_radioButton;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage graph_tab;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage adjMatrix_tab;
        private MatrixControl adjMatrix_MatrixControl;
        private System.Windows.Forms.Panel propertyPanel;
        private System.Windows.Forms.TextBox weight_TextBox;
        private System.Windows.Forms.RadioButton secondDirected_RadioButton;
        private System.Windows.Forms.RadioButton firstDirected_RadioButton;
        private System.Windows.Forms.RadioButton bothDirected_RadioButton;
        private System.Windows.Forms.Label panelTitle_Label;
        private System.Windows.Forms.Label name_Label;
        private System.Windows.Forms.TextBox name_TextBox;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button calculateDistance_Button;
        private System.Windows.Forms.ComboBox vertex1_ComboBox;
        private System.Windows.Forms.ComboBox vertex2_ComboBox;
    }
}