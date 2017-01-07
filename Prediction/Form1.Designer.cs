namespace Prediction
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
            this.cb128 = new System.Windows.Forms.CheckBox();
            this.cbA = new System.Windows.Forms.CheckBox();
            this.cbB = new System.Windows.Forms.CheckBox();
            this.cbC = new System.Windows.Forms.CheckBox();
            this.cbABC = new System.Windows.Forms.CheckBox();
            this.cbABC2 = new System.Windows.Forms.CheckBox();
            this.cbBAC = new System.Windows.Forms.CheckBox();
            this.cbAB = new System.Windows.Forms.CheckBox();
            this.cbJpegLS = new System.Windows.Forms.CheckBox();
            this.cbOriginal = new System.Windows.Forms.CheckBox();
            this.cbError = new System.Windows.Forms.CheckBox();
            this.cbDecoded = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cb128
            // 
            this.cb128.AutoSize = true;
            this.cb128.Location = new System.Drawing.Point(27, 237);
            this.cb128.Name = "cb128";
            this.cb128.Size = new System.Drawing.Size(54, 21);
            this.cb128.TabIndex = 0;
            this.cb128.Text = "128";
            this.cb128.UseVisualStyleBackColor = true;
            // 
            // cbA
            // 
            this.cbA.AutoSize = true;
            this.cbA.Location = new System.Drawing.Point(27, 264);
            this.cbA.Name = "cbA";
            this.cbA.Size = new System.Drawing.Size(39, 21);
            this.cbA.TabIndex = 1;
            this.cbA.Text = "A";
            this.cbA.UseVisualStyleBackColor = true;
            // 
            // cbB
            // 
            this.cbB.AutoSize = true;
            this.cbB.Location = new System.Drawing.Point(27, 291);
            this.cbB.Name = "cbB";
            this.cbB.Size = new System.Drawing.Size(39, 21);
            this.cbB.TabIndex = 2;
            this.cbB.Text = "B";
            this.cbB.UseVisualStyleBackColor = true;
            // 
            // cbC
            // 
            this.cbC.AutoSize = true;
            this.cbC.Location = new System.Drawing.Point(27, 318);
            this.cbC.Name = "cbC";
            this.cbC.Size = new System.Drawing.Size(39, 21);
            this.cbC.TabIndex = 3;
            this.cbC.Text = "C";
            this.cbC.UseVisualStyleBackColor = true;
            // 
            // cbABC
            // 
            this.cbABC.AutoSize = true;
            this.cbABC.Location = new System.Drawing.Point(27, 345);
            this.cbABC.Name = "cbABC";
            this.cbABC.Size = new System.Drawing.Size(73, 21);
            this.cbABC.TabIndex = 4;
            this.cbABC.Text = "A+B+C";
            this.cbABC.UseVisualStyleBackColor = true;
            // 
            // cbABC2
            // 
            this.cbABC2.AutoSize = true;
            this.cbABC2.Location = new System.Drawing.Point(27, 372);
            this.cbABC2.Name = "cbABC2";
            this.cbABC2.Size = new System.Drawing.Size(92, 21);
            this.cbABC2.TabIndex = 5;
            this.cbABC2.Text = "A+(B-C)/2";
            this.cbABC2.UseVisualStyleBackColor = true;
            // 
            // cbBAC
            // 
            this.cbBAC.AutoSize = true;
            this.cbBAC.Location = new System.Drawing.Point(27, 399);
            this.cbBAC.Name = "cbBAC";
            this.cbBAC.Size = new System.Drawing.Size(92, 21);
            this.cbBAC.TabIndex = 6;
            this.cbBAC.Text = "B+(A-C)/2";
            this.cbBAC.UseVisualStyleBackColor = true;
            // 
            // cbAB
            // 
            this.cbAB.AutoSize = true;
            this.cbAB.Location = new System.Drawing.Point(27, 426);
            this.cbAB.Name = "cbAB";
            this.cbAB.Size = new System.Drawing.Size(78, 21);
            this.cbAB.TabIndex = 7;
            this.cbAB.Text = "(A+B)/2";
            this.cbAB.UseVisualStyleBackColor = true;
            // 
            // cbJpegLS
            // 
            this.cbJpegLS.AutoSize = true;
            this.cbJpegLS.Location = new System.Drawing.Point(27, 453);
            this.cbJpegLS.Name = "cbJpegLS";
            this.cbJpegLS.Size = new System.Drawing.Size(74, 21);
            this.cbJpegLS.TabIndex = 8;
            this.cbJpegLS.Text = "jpegLS";
            this.cbJpegLS.UseVisualStyleBackColor = true;
            // 
            // cbOriginal
            // 
            this.cbOriginal.AutoSize = true;
            this.cbOriginal.Location = new System.Drawing.Point(262, 291);
            this.cbOriginal.Name = "cbOriginal";
            this.cbOriginal.Size = new System.Drawing.Size(79, 21);
            this.cbOriginal.TabIndex = 9;
            this.cbOriginal.Text = "Original";
            this.cbOriginal.UseVisualStyleBackColor = true;
            // 
            // cbError
            // 
            this.cbError.AutoSize = true;
            this.cbError.Location = new System.Drawing.Point(262, 318);
            this.cbError.Name = "cbError";
            this.cbError.Size = new System.Drawing.Size(128, 21);
            this.cbError.TabIndex = 10;
            this.cbError.Text = "Error prediction";
            this.cbError.UseVisualStyleBackColor = true;
            // 
            // cbDecoded
            // 
            this.cbDecoded.AutoSize = true;
            this.cbDecoded.Location = new System.Drawing.Point(262, 345);
            this.cbDecoded.Name = "cbDecoded";
            this.cbDecoded.Size = new System.Drawing.Size(87, 21);
            this.cbDecoded.TabIndex = 11;
            this.cbDecoded.Text = "Decoded";
            this.cbDecoded.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 530);
            this.Controls.Add(this.cbDecoded);
            this.Controls.Add(this.cbError);
            this.Controls.Add(this.cbOriginal);
            this.Controls.Add(this.cbJpegLS);
            this.Controls.Add(this.cbAB);
            this.Controls.Add(this.cbBAC);
            this.Controls.Add(this.cbABC2);
            this.Controls.Add(this.cbABC);
            this.Controls.Add(this.cbC);
            this.Controls.Add(this.cbB);
            this.Controls.Add(this.cbA);
            this.Controls.Add(this.cb128);
            this.Name = "Form1";
            this.Text = "Prediction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb128;
        private System.Windows.Forms.CheckBox cbA;
        private System.Windows.Forms.CheckBox cbB;
        private System.Windows.Forms.CheckBox cbC;
        private System.Windows.Forms.CheckBox cbABC;
        private System.Windows.Forms.CheckBox cbABC2;
        private System.Windows.Forms.CheckBox cbBAC;
        private System.Windows.Forms.CheckBox cbAB;
        private System.Windows.Forms.CheckBox cbJpegLS;
        private System.Windows.Forms.CheckBox cbOriginal;
        private System.Windows.Forms.CheckBox cbError;
        private System.Windows.Forms.CheckBox cbDecoded;
    }
}

