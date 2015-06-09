namespace Grafy.Program
{
    partial class MatrixWindow
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
            this.matrixControl1 = new Grafy.Program.MatrixControl();
            this.SuspendLayout();
            // 
            // matrixControl1
            // 
            this.matrixControl1.Location = new System.Drawing.Point(12, 12);
            this.matrixControl1.Name = "matrixControl1";
            this.matrixControl1.Size = new System.Drawing.Size(369, 262);
            this.matrixControl1.TabIndex = 0;
            // 
            // MatrixWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 286);
            this.Controls.Add(this.matrixControl1);
            this.Name = "MatrixWindow";
            this.Text = "MatrixWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private MatrixControl matrixControl1;
    }
}