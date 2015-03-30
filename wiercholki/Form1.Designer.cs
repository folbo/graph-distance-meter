﻿namespace wiercholki
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.edgeModeButton = new System.Windows.Forms.RadioButton();
            this.vertexModeButton = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.newGraphButton = new System.Windows.Forms.Button();
            this.openGraphButton = new System.Windows.Forms.Button();
            this.saveGraphButton = new System.Windows.Forms.Button();
            this.mainPanel = new wiercholki.DisplayPanel();
            this.propertyPanel = new System.Windows.Forms.Panel();
            this.secondDirectedRadio = new System.Windows.Forms.RadioButton();
            this.firstDirectedRadio = new System.Windows.Forms.RadioButton();
            this.bothDirectedRadio = new System.Windows.Forms.RadioButton();
            this.titleLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.matrixPanel = new System.Windows.Forms.Panel();
            this.calculateDistance = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.vertex2ComboBox = new System.Windows.Forms.ComboBox();
            this.vertex1ComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.propertyPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.matrixPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 212F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mainPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.matrixPanel, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.62876F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.37124F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(735, 326);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Controls.Add(this.edgeModeButton);
            this.panel2.Controls.Add(this.vertexModeButton);
            this.panel2.Location = new System.Drawing.Point(3, 295);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(517, 28);
            this.panel2.TabIndex = 1;
            // 
            // radioButton3
            // 
            this.radioButton3.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton3.AutoSize = true;
            this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton3.Location = new System.Drawing.Point(384, 0);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(60, 25);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Zaznacz";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // edgeModeButton
            // 
            this.edgeModeButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.edgeModeButton.AutoSize = true;
            this.edgeModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edgeModeButton.Location = new System.Drawing.Point(239, 0);
            this.edgeModeButton.Name = "edgeModeButton";
            this.edgeModeButton.Size = new System.Drawing.Size(96, 25);
            this.edgeModeButton.TabIndex = 3;
            this.edgeModeButton.TabStop = true;
            this.edgeModeButton.Text = "Rysuj krawędzie";
            this.edgeModeButton.UseVisualStyleBackColor = true;
            this.edgeModeButton.Click += new System.EventHandler(this.edgeModeButton_Click);
            // 
            // vertexModeButton
            // 
            this.vertexModeButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.vertexModeButton.AutoSize = true;
            this.vertexModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vertexModeButton.Location = new System.Drawing.Point(96, 0);
            this.vertexModeButton.Name = "vertexModeButton";
            this.vertexModeButton.Size = new System.Drawing.Size(102, 25);
            this.vertexModeButton.TabIndex = 2;
            this.vertexModeButton.TabStop = true;
            this.vertexModeButton.Text = "Rysuj wierzchołki";
            this.vertexModeButton.UseVisualStyleBackColor = true;
            this.vertexModeButton.Click += new System.EventHandler(this.vertexModeButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.newGraphButton);
            this.flowLayoutPanel1.Controls.Add(this.openGraphButton);
            this.flowLayoutPanel1.Controls.Add(this.saveGraphButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(517, 28);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // newGraphButton
            // 
            this.newGraphButton.Location = new System.Drawing.Point(3, 3);
            this.newGraphButton.Name = "newGraphButton";
            this.newGraphButton.Size = new System.Drawing.Size(75, 23);
            this.newGraphButton.TabIndex = 0;
            this.newGraphButton.Text = "Nowy";
            this.newGraphButton.UseVisualStyleBackColor = true;
            this.newGraphButton.Click += new System.EventHandler(this.newGraphButton_Click);
            // 
            // openGraphButton
            // 
            this.openGraphButton.Location = new System.Drawing.Point(84, 3);
            this.openGraphButton.Name = "openGraphButton";
            this.openGraphButton.Size = new System.Drawing.Size(75, 23);
            this.openGraphButton.TabIndex = 1;
            this.openGraphButton.Text = "Otwórz";
            this.openGraphButton.UseVisualStyleBackColor = true;
            // 
            // saveGraphButton
            // 
            this.saveGraphButton.Location = new System.Drawing.Point(165, 3);
            this.saveGraphButton.Name = "saveGraphButton";
            this.saveGraphButton.Size = new System.Drawing.Size(75, 23);
            this.saveGraphButton.TabIndex = 2;
            this.saveGraphButton.Text = "Zapisz";
            this.saveGraphButton.UseVisualStyleBackColor = true;
            // 
            // mainPanel
            // 
            this.mainPanel.Bitmap = null;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.propertyPanel);
            this.mainPanel.Location = new System.Drawing.Point(3, 37);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(517, 252);
            this.mainPanel.TabIndex = 3;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseDown);
            this.mainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseMove);
            this.mainPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseUp);
            // 
            // propertyPanel
            // 
            this.propertyPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.propertyPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.propertyPanel.Controls.Add(this.secondDirectedRadio);
            this.propertyPanel.Controls.Add(this.firstDirectedRadio);
            this.propertyPanel.Controls.Add(this.bothDirectedRadio);
            this.propertyPanel.Controls.Add(this.titleLabel);
            this.propertyPanel.Controls.Add(this.nameLabel);
            this.propertyPanel.Controls.Add(this.nameTextBox);
            this.propertyPanel.Location = new System.Drawing.Point(324, 3);
            this.propertyPanel.Name = "propertyPanel";
            this.propertyPanel.Size = new System.Drawing.Size(185, 109);
            this.propertyPanel.TabIndex = 0;
            // 
            // secondDirectedRadio
            // 
            this.secondDirectedRadio.AutoSize = true;
            this.secondDirectedRadio.Location = new System.Drawing.Point(66, 75);
            this.secondDirectedRadio.Name = "secondDirectedRadio";
            this.secondDirectedRadio.Size = new System.Drawing.Size(83, 17);
            this.secondDirectedRadio.TabIndex = 5;
            this.secondDirectedRadio.TabStop = true;
            this.secondDirectedRadio.Text = "Do drugiego";
            this.secondDirectedRadio.UseVisualStyleBackColor = true;
            this.secondDirectedRadio.MouseClick += new System.Windows.Forms.MouseEventHandler(this.secondDirectedRadio_MouseClick);
            // 
            // firstDirectedRadio
            // 
            this.firstDirectedRadio.AutoSize = true;
            this.firstDirectedRadio.Location = new System.Drawing.Point(66, 52);
            this.firstDirectedRadio.Name = "firstDirectedRadio";
            this.firstDirectedRadio.Size = new System.Drawing.Size(95, 17);
            this.firstDirectedRadio.TabIndex = 4;
            this.firstDirectedRadio.TabStop = true;
            this.firstDirectedRadio.Text = "Do pierwszego";
            this.firstDirectedRadio.UseVisualStyleBackColor = true;
            this.firstDirectedRadio.MouseClick += new System.Windows.Forms.MouseEventHandler(this.firstDirectedRadio_MouseClick);
            // 
            // bothDirectedRadio
            // 
            this.bothDirectedRadio.AutoSize = true;
            this.bothDirectedRadio.Location = new System.Drawing.Point(66, 29);
            this.bothDirectedRadio.Name = "bothDirectedRadio";
            this.bothDirectedRadio.Size = new System.Drawing.Size(78, 17);
            this.bothDirectedRadio.TabIndex = 3;
            this.bothDirectedRadio.TabStop = true;
            this.bothDirectedRadio.Text = "Obie strony";
            this.bothDirectedRadio.UseVisualStyleBackColor = true;
            this.bothDirectedRadio.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bothDirectedRadio_MouseClick);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(26, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(129, 13);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Właściwości wierzchołka";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(3, 29);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(40, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Nazwa";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(49, 26);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(122, 20);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(526, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 28);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Macierz sąsiedztwa";
            // 
            // matrixPanel
            // 
            this.matrixPanel.AutoScroll = true;
            this.matrixPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.matrixPanel.Controls.Add(this.calculateDistance);
            this.matrixPanel.Controls.Add(this.label2);
            this.matrixPanel.Controls.Add(this.vertex2ComboBox);
            this.matrixPanel.Controls.Add(this.vertex1ComboBox);
            this.matrixPanel.Controls.Add(this.dataGridView1);
            this.matrixPanel.Location = new System.Drawing.Point(526, 37);
            this.matrixPanel.Name = "matrixPanel";
            this.matrixPanel.Size = new System.Drawing.Size(206, 252);
            this.matrixPanel.TabIndex = 6;
            // 
            // calculateDistance
            // 
            this.calculateDistance.Location = new System.Drawing.Point(64, 217);
            this.calculateDistance.Name = "calculateDistance";
            this.calculateDistance.Size = new System.Drawing.Size(75, 23);
            this.calculateDistance.TabIndex = 5;
            this.calculateDistance.Text = "Oblicz";
            this.calculateDistance.UseVisualStyleBackColor = true;
            this.calculateDistance.Click += new System.EventHandler(this.calculateDistance_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Oblicz odległość między wierzchołkami";
            // 
            // vertex2ComboBox
            // 
            this.vertex2ComboBox.FormattingEnabled = true;
            this.vertex2ComboBox.Location = new System.Drawing.Point(107, 190);
            this.vertex2ComboBox.Name = "vertex2ComboBox";
            this.vertex2ComboBox.Size = new System.Drawing.Size(94, 21);
            this.vertex2ComboBox.TabIndex = 3;
            // 
            // vertex1ComboBox
            // 
            this.vertex1ComboBox.FormattingEnabled = true;
            this.vertex1ComboBox.Location = new System.Drawing.Point(5, 190);
            this.vertex1ComboBox.Name = "vertex1ComboBox";
            this.vertex1ComboBox.Size = new System.Drawing.Size(96, 21);
            this.vertex1ComboBox.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(198, 164);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 348);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.propertyPanel.ResumeLayout(false);
            this.propertyPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.matrixPanel.ResumeLayout(false);
            this.matrixPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button openGraphButton;
        private System.Windows.Forms.Button newGraphButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button saveGraphButton;
        private DisplayPanel mainPanel;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton edgeModeButton;
        private System.Windows.Forms.RadioButton vertexModeButton;
        private System.Windows.Forms.Panel propertyPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.RadioButton bothDirectedRadio;
        private System.Windows.Forms.RadioButton secondDirectedRadio;
        private System.Windows.Forms.RadioButton firstDirectedRadio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel matrixPanel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox vertex1ComboBox;
        private System.Windows.Forms.ComboBox vertex2ComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button calculateDistance;

    }
}

