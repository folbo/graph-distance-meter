namespace Grafy.Program
{
    partial class PropertiesPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.propertyPanel = new System.Windows.Forms.Panel();
            this.weight_TextBox = new System.Windows.Forms.TextBox();
            this.secondDirected_RadioButton = new System.Windows.Forms.RadioButton();
            this.firstDirected_RadioButton = new System.Windows.Forms.RadioButton();
            this.bothDirected_RadioButton = new System.Windows.Forms.RadioButton();
            this.panelTitle_Label = new System.Windows.Forms.Label();
            this.name_Label = new System.Windows.Forms.Label();
            this.name_TextBox = new System.Windows.Forms.TextBox();
            this.propertyPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.propertyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyPanel.Location = new System.Drawing.Point(0, 0);
            this.propertyPanel.Name = "propertyPanel";
            this.propertyPanel.Size = new System.Drawing.Size(187, 101);
            this.propertyPanel.TabIndex = 6;
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
            // 
            // PropertiesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.propertyPanel);
            this.Name = "PropertiesPanel";
            this.Size = new System.Drawing.Size(187, 101);
            this.propertyPanel.ResumeLayout(false);
            this.propertyPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel propertyPanel;
        private System.Windows.Forms.TextBox weight_TextBox;
        private System.Windows.Forms.RadioButton secondDirected_RadioButton;
        private System.Windows.Forms.RadioButton firstDirected_RadioButton;
        private System.Windows.Forms.RadioButton bothDirected_RadioButton;
        private System.Windows.Forms.Label panelTitle_Label;
        private System.Windows.Forms.Label name_Label;
        private System.Windows.Forms.TextBox name_TextBox;
    }
}
