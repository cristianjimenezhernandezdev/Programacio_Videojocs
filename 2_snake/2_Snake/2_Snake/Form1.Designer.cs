namespace _2_Snake
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pbCanvas = new PictureBox();
            lblPuntuacio = new Label();
            lblPunts = new Label();
            ((System.ComponentModel.ISupportInitialize)pbCanvas).BeginInit();
            SuspendLayout();
            // 
            // pbCanvas
            // 
            pbCanvas.Location = new Point(12, 44);
            pbCanvas.Name = "pbCanvas";
            pbCanvas.Size = new Size(1004, 453);
            pbCanvas.TabIndex = 0;
            pbCanvas.TabStop = false;
            // 
            // lblPuntuacio
            // 
            lblPuntuacio.AutoSize = true;
            lblPuntuacio.Font = new Font("Segoe UI", 14F);
            lblPuntuacio.Location = new Point(29, 9);
            lblPuntuacio.Name = "lblPuntuacio";
            lblPuntuacio.Size = new Size(120, 32);
            lblPuntuacio.TabIndex = 1;
            lblPuntuacio.Text = "Puntuacio";
            lblPuntuacio.Click += label1_Click;
            // 
            // lblPunts
            // 
            lblPunts.AutoSize = true;
            lblPunts.Font = new Font("Segoe UI", 14F);
            lblPunts.Location = new Point(155, 9);
            lblPunts.Name = "lblPunts";
            lblPunts.Size = new Size(78, 32);
            lblPunts.TabIndex = 2;
            lblPunts.Text = "label2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 504);
            Controls.Add(lblPunts);
            Controls.Add(lblPuntuacio);
            Controls.Add(pbCanvas);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbCanvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbCanvas;
        private Label lblPuntuacio;
        private Label lblPunts;
    }
}
