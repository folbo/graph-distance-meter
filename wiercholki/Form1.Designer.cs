namespace wiercholki
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.edgeModeButton = new System.Windows.Forms.RadioButton();
            this.vertexModeButton = new System.Windows.Forms.RadioButton();
            this.newGraphButton = new System.Windows.Forms.Button();
            this.calculateDistance = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.vertex2ComboBox = new System.Windows.Forms.ComboBox();
            this.vertex1ComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.mainPanel = new wiercholki.DisplayPanel();
            this.propertyPanel = new System.Windows.Forms.Panel();
            this.secondDirectedRadio = new System.Windows.Forms.RadioButton();
            this.firstDirectedRadio = new System.Windows.Forms.RadioButton();
            this.bothDirectedRadio = new System.Windows.Forms.RadioButton();
            this.titleLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.matrixControl1 = new wiercholki.MatrixControl();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button1_1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.propertyPanel.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton3.Location = new System.Drawing.Point(3, 253);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(65, 17);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.Text = "Zaznacz";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // edgeModeButton
            // 
            this.edgeModeButton.AutoSize = true;
            this.edgeModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edgeModeButton.Location = new System.Drawing.Point(3, 45);
            this.edgeModeButton.Name = "edgeModeButton";
            this.edgeModeButton.Size = new System.Drawing.Size(73, 17);
            this.edgeModeButton.TabIndex = 3;
            this.edgeModeButton.Text = "Krawędzie";
            this.edgeModeButton.UseVisualStyleBackColor = true;
            this.edgeModeButton.Click += new System.EventHandler(this.edgeModeButton_Click);
            // 
            // vertexModeButton
            // 
            this.vertexModeButton.AutoSize = true;
            this.vertexModeButton.Checked = true;
            this.vertexModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vertexModeButton.Location = new System.Drawing.Point(3, 22);
            this.vertexModeButton.Name = "vertexModeButton";
            this.vertexModeButton.Size = new System.Drawing.Size(81, 17);
            this.vertexModeButton.TabIndex = 2;
            this.vertexModeButton.TabStop = true;
            this.vertexModeButton.Text = "Wierzchołki";
            this.vertexModeButton.UseVisualStyleBackColor = true;
            this.vertexModeButton.Click += new System.EventHandler(this.vertexModeButton_Click);
            // 
            // newGraphButton
            // 
            this.newGraphButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.newGraphButton.Location = new System.Drawing.Point(12, 12);
            this.newGraphButton.Name = "newGraphButton";
            this.newGraphButton.Size = new System.Drawing.Size(147, 23);
            this.newGraphButton.TabIndex = 0;
            this.newGraphButton.Text = "Rozpocznij";
            this.newGraphButton.UseVisualStyleBackColor = true;
            this.newGraphButton.Click += new System.EventHandler(this.newGraphButton_Click);
            // 
            // calculateDistance
            // 
            this.calculateDistance.Location = new System.Drawing.Point(230, 25);
            this.calculateDistance.Name = "calculateDistance";
            this.calculateDistance.Size = new System.Drawing.Size(107, 23);
            this.calculateDistance.TabIndex = 5;
            this.calculateDistance.Text = "Oblicz";
            this.calculateDistance.UseVisualStyleBackColor = true;
            this.calculateDistance.Click += new System.EventHandler(this.calculateDistance_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Oblicz odległość między wierzchołkami:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // vertex2ComboBox
            // 
            this.vertex2ComboBox.FormattingEnabled = true;
            this.vertex2ComboBox.Location = new System.Drawing.Point(112, 27);
            this.vertex2ComboBox.Name = "vertex2ComboBox";
            this.vertex2ComboBox.Size = new System.Drawing.Size(94, 21);
            this.vertex2ComboBox.TabIndex = 3;
            // 
            // vertex1ComboBox
            // 
            this.vertex1ComboBox.FormattingEnabled = true;
            this.vertex1ComboBox.Location = new System.Drawing.Point(10, 27);
            this.vertex1ComboBox.Name = "vertex1ComboBox";
            this.vertex1ComboBox.Size = new System.Drawing.Size(96, 21);
            this.vertex1ComboBox.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(547, 310);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.mainPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(539, 284);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Graf";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.vertexModeButton);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.edgeModeButton);
            this.panel1.Location = new System.Drawing.Point(0, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(87, 273);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Obiekty grafu:";
            // 
            // mainPanel
            // 
            this.mainPanel.Bitmap = null;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.propertyPanel);
            this.mainPanel.Location = new System.Drawing.Point(93, 3);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(443, 278);
            this.mainPanel.TabIndex = 3;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseDown);
            this.mainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseMove);
            this.mainPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPanel_MouseUp);
            // 
            // propertyPanel
            // 
            this.propertyPanel.BackColor = System.Drawing.Color.White;
            this.propertyPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.propertyPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.propertyPanel.Controls.Add(this.secondDirectedRadio);
            this.propertyPanel.Controls.Add(this.firstDirectedRadio);
            this.propertyPanel.Controls.Add(this.bothDirectedRadio);
            this.propertyPanel.Controls.Add(this.titleLabel);
            this.propertyPanel.Controls.Add(this.nameLabel);
            this.propertyPanel.Controls.Add(this.nameTextBox);
            this.propertyPanel.Location = new System.Drawing.Point(253, 3);
            this.propertyPanel.Name = "propertyPanel";
            this.propertyPanel.Size = new System.Drawing.Size(185, 95);
            this.propertyPanel.TabIndex = 0;
            // 
            // secondDirectedRadio
            // 
            this.secondDirectedRadio.AutoSize = true;
            this.secondDirectedRadio.Location = new System.Drawing.Point(66, 68);
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
            this.firstDirectedRadio.Location = new System.Drawing.Point(66, 45);
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
            this.bothDirectedRadio.Location = new System.Drawing.Point(66, 22);
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
            this.nameLabel.Location = new System.Drawing.Point(3, 22);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(40, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Nazwa";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(49, 19);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(51, 20);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.matrixControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(539, 284);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Macierz sąsiedztwa";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // matrixControl1
            // 
            this.matrixControl1.Location = new System.Drawing.Point(6, 6);
            this.matrixControl1.Name = "matrixControl1";
            this.matrixControl1.Size = new System.Drawing.Size(527, 272);
            this.matrixControl1.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.calculateDistance);
            this.panel5.Controls.Add(this.vertex1ComboBox);
            this.panel5.Controls.Add(this.vertex2ComboBox);
            this.panel5.Location = new System.Drawing.Point(16, 362);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(360, 57);
            this.panel5.TabIndex = 2;
            // 
            // button1_1
            // 
            this.button1_1.Location = new System.Drawing.Point(430, 387);
            this.button1_1.Name = "button1_1";
            this.button1_1.Size = new System.Drawing.Size(125, 23);
            this.button1_1.TabIndex = 6;
            this.button1_1.Text = "Zamknij";
            this.button1_1.UseVisualStyleBackColor = true;
            this.button1_1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(485, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(74, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(382, 362);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(19, 23);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(567, 418);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1_1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.newGraphButton);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Obliczanie odległości między wierzchołkami grafu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.propertyPanel.ResumeLayout(false);
            this.propertyPanel.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newGraphButton;
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
        private System.Windows.Forms.ComboBox vertex1ComboBox;
        private System.Windows.Forms.ComboBox vertex2ComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button calculateDistance;
        private MatrixControl matrixControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button1_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;

    }
}

