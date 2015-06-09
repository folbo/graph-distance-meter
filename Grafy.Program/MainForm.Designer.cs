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
            this.components = new System.ComponentModel.Container();
            this.drawVertex_radioButton = new System.Windows.Forms.RadioButton();
            this.drawEdge_radioButton = new System.Windows.Forms.RadioButton();
            this.select_radioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.calculateDistance_Button = new System.Windows.Forms.Button();
            this.vertex1_ComboBox = new System.Windows.Forms.ComboBox();
            this.vertex2_ComboBox = new System.Windows.Forms.ComboBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.infol = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.showMatrix_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.adjMatrix_MatrixControl = new Grafy.Program.MatrixControl();
            this.graphPanel1 = new Grafy.Program.GraphPanel();
            this.propertyPanel = new System.Windows.Forms.Panel();
            this.secondDirected_RadioButton = new System.Windows.Forms.RadioButton();
            this.firstDirected_RadioButton = new System.Windows.Forms.RadioButton();
            this.bothDirected_RadioButton = new System.Windows.Forms.RadioButton();
            this.panelTitle_Label = new System.Windows.Forms.Label();
            this.name_Label = new System.Windows.Forms.Label();
            this.name_TextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.graphPanel1.SuspendLayout();
            this.propertyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawVertex_radioButton
            // 
            this.drawVertex_radioButton.AutoSize = true;
            this.drawVertex_radioButton.Checked = true;
            this.drawVertex_radioButton.Location = new System.Drawing.Point(3, 5);
            this.drawVertex_radioButton.Name = "drawVertex_radioButton";
            this.drawVertex_radioButton.Size = new System.Drawing.Size(86, 17);
            this.drawVertex_radioButton.TabIndex = 1;
            this.drawVertex_radioButton.TabStop = true;
            this.drawVertex_radioButton.Text = "Wierzchołek";
            this.drawVertex_radioButton.UseVisualStyleBackColor = true;
            this.drawVertex_radioButton.CheckedChanged += new System.EventHandler(this.drawVertex_radioButton_CheckedChanged);
            // 
            // drawEdge_radioButton
            // 
            this.drawEdge_radioButton.AutoSize = true;
            this.drawEdge_radioButton.Location = new System.Drawing.Point(3, 29);
            this.drawEdge_radioButton.Name = "drawEdge_radioButton";
            this.drawEdge_radioButton.Size = new System.Drawing.Size(66, 17);
            this.drawEdge_radioButton.TabIndex = 2;
            this.drawEdge_radioButton.Text = "Krawędź";
            this.drawEdge_radioButton.UseVisualStyleBackColor = true;
            this.drawEdge_radioButton.CheckedChanged += new System.EventHandler(this.drawEdge_radioButton_CheckedChanged);
            // 
            // select_radioButton
            // 
            this.select_radioButton.AutoSize = true;
            this.select_radioButton.Location = new System.Drawing.Point(3, 205);
            this.select_radioButton.Name = "select_radioButton";
            this.select_radioButton.Size = new System.Drawing.Size(54, 17);
            this.select_radioButton.TabIndex = 3;
            this.select_radioButton.Text = "Edytuj";
            this.select_radioButton.UseVisualStyleBackColor = true;
            this.select_radioButton.CheckedChanged += new System.EventHandler(this.select_radioButton_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.drawVertex_radioButton);
            this.panel1.Controls.Add(this.drawEdge_radioButton);
            this.panel1.Controls.Add(this.select_radioButton);
            this.panel1.Location = new System.Drawing.Point(22, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(90, 229);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.calculateDistance_Button);
            this.panel5.Controls.Add(this.vertex1_ComboBox);
            this.panel5.Controls.Add(this.vertex2_ComboBox);
            this.panel5.Location = new System.Drawing.Point(22, 303);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(339, 71);
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
            this.calculateDistance_Button.Location = new System.Drawing.Point(210, 34);
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
            this.vertex1_ComboBox.Location = new System.Drawing.Point(8, 36);
            this.vertex1_ComboBox.Name = "vertex1_ComboBox";
            this.vertex1_ComboBox.Size = new System.Drawing.Size(96, 21);
            this.vertex1_ComboBox.TabIndex = 2;
            // 
            // vertex2_ComboBox
            // 
            this.vertex2_ComboBox.FormattingEnabled = true;
            this.vertex2_ComboBox.Location = new System.Drawing.Point(110, 36);
            this.vertex2_ComboBox.Name = "vertex2_ComboBox";
            this.vertex2_ComboBox.Size = new System.Drawing.Size(94, 21);
            this.vertex2_ComboBox.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox2.Location = new System.Drawing.Point(602, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1, 362);
            this.pictureBox2.TabIndex = 76;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.Location = new System.Drawing.Point(603, 321);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(310, 1);
            this.pictureBox1.TabIndex = 77;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(619, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 82;
            this.label4.Text = "Macierz sąsiedztwa grafu";
            // 
            // infol
            // 
            this.infol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.infol.Location = new System.Drawing.Point(622, 354);
            this.infol.Name = "infol";
            this.infol.Size = new System.Drawing.Size(292, 20);
            this.infol.TabIndex = 83;
            this.infol.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(619, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 84;
            this.label5.Text = "Typ grafu";
            // 
            // showMatrix_Button
            // 
            this.showMatrix_Button.Enabled = false;
            this.showMatrix_Button.Location = new System.Drawing.Point(405, 339);
            this.showMatrix_Button.Name = "showMatrix_Button";
            this.showMatrix_Button.Size = new System.Drawing.Size(162, 23);
            this.showMatrix_Button.TabIndex = 6;
            this.showMatrix_Button.Text = "Wyświetl";
            this.showMatrix_Button.UseVisualStyleBackColor = true;
            this.showMatrix_Button.Click += new System.EventHandler(this.showMatrixButton_Click);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(373, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 71);
            this.label3.TabIndex = 85;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(395, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 13);
            this.label6.TabIndex = 86;
            this.label6.Text = "Wyświetlanie macierzy potęgowanej:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 35);
            this.button1.TabIndex = 87;
            this.button1.Text = "Wyczyść";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // adjMatrix_MatrixControl
            // 
            this.adjMatrix_MatrixControl.Location = new System.Drawing.Point(622, 15);
            this.adjMatrix_MatrixControl.Name = "adjMatrix_MatrixControl";
            this.adjMatrix_MatrixControl.Size = new System.Drawing.Size(292, 270);
            this.adjMatrix_MatrixControl.TabIndex = 0;
            // 
            // graphPanel1
            // 
            this.graphPanel1.Bitmap = null;
            this.graphPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.graphPanel1.Controls.Add(this.propertyPanel);
            this.graphPanel1.Location = new System.Drawing.Point(119, 15);
            this.graphPanel1.Name = "graphPanel1";
            this.graphPanel1.Size = new System.Drawing.Size(469, 270);
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
            this.propertyPanel.Controls.Add(this.secondDirected_RadioButton);
            this.propertyPanel.Controls.Add(this.firstDirected_RadioButton);
            this.propertyPanel.Controls.Add(this.bothDirected_RadioButton);
            this.propertyPanel.Controls.Add(this.panelTitle_Label);
            this.propertyPanel.Controls.Add(this.name_Label);
            this.propertyPanel.Controls.Add(this.name_TextBox);
            this.propertyPanel.Location = new System.Drawing.Point(277, 168);
            this.propertyPanel.Name = "propertyPanel";
            this.propertyPanel.Size = new System.Drawing.Size(185, 95);
            this.propertyPanel.TabIndex = 5;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 390);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.showMatrix_Button);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.infol);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.adjMatrix_MatrixControl);
            this.Controls.Add(this.graphPanel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label3);
            this.Name = "MainForm";
            this.Text = "Oblicznie odległości między zadanymi wierzchołkami grafu skierowanego";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.graphPanel1.ResumeLayout(false);
            this.propertyPanel.ResumeLayout(false);
            this.propertyPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GraphPanel graphPanel1;
        private System.Windows.Forms.RadioButton drawVertex_radioButton;
        private System.Windows.Forms.RadioButton drawEdge_radioButton;
        private System.Windows.Forms.RadioButton select_radioButton;
        private System.Windows.Forms.Panel panel1;
        private MatrixControl adjMatrix_MatrixControl;
        private System.Windows.Forms.Panel propertyPanel;
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
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label infol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button showMatrix_Button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}