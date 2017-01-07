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
            this.rb128 = new System.Windows.Forms.RadioButton();
            this.rbA = new System.Windows.Forms.RadioButton();
            this.rbB = new System.Windows.Forms.RadioButton();
            this.rbC = new System.Windows.Forms.RadioButton();
            this.rbABC = new System.Windows.Forms.RadioButton();
            this.rbABC2 = new System.Windows.Forms.RadioButton();
            this.rbBAC = new System.Windows.Forms.RadioButton();
            this.rbAB = new System.Windows.Forms.RadioButton();
            this.rbJpegLS = new System.Windows.Forms.RadioButton();
            this.rbOriginal = new System.Windows.Forms.RadioButton();
            this.rbError = new System.Windows.Forms.RadioButton();
            this.rbDecoded = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rb128
            // 
            this.rb128.AutoSize = true;
            this.rb128.Location = new System.Drawing.Point(32, 269);
            this.rb128.Name = "rb128";
            this.rb128.Size = new System.Drawing.Size(53, 21);
            this.rb128.TabIndex = 12;
            this.rb128.TabStop = true;
            this.rb128.Text = "128";
            this.rb128.UseVisualStyleBackColor = true;
            // 
            // rbA
            // 
            this.rbA.AutoSize = true;
            this.rbA.Location = new System.Drawing.Point(32, 296);
            this.rbA.Name = "rbA";
            this.rbA.Size = new System.Drawing.Size(38, 21);
            this.rbA.TabIndex = 13;
            this.rbA.TabStop = true;
            this.rbA.Text = "A";
            this.rbA.UseVisualStyleBackColor = true;
            // 
            // rbB
            // 
            this.rbB.AutoSize = true;
            this.rbB.Location = new System.Drawing.Point(32, 323);
            this.rbB.Name = "rbB";
            this.rbB.Size = new System.Drawing.Size(38, 21);
            this.rbB.TabIndex = 14;
            this.rbB.TabStop = true;
            this.rbB.Text = "B";
            this.rbB.UseVisualStyleBackColor = true;
            // 
            // rbC
            // 
            this.rbC.AutoSize = true;
            this.rbC.Location = new System.Drawing.Point(32, 350);
            this.rbC.Name = "rbC";
            this.rbC.Size = new System.Drawing.Size(38, 21);
            this.rbC.TabIndex = 15;
            this.rbC.TabStop = true;
            this.rbC.Text = "C";
            this.rbC.UseVisualStyleBackColor = true;
            // 
            // rbABC
            // 
            this.rbABC.AutoSize = true;
            this.rbABC.Location = new System.Drawing.Point(32, 377);
            this.rbABC.Name = "rbABC";
            this.rbABC.Size = new System.Drawing.Size(72, 21);
            this.rbABC.TabIndex = 16;
            this.rbABC.TabStop = true;
            this.rbABC.Text = "A+B+C";
            this.rbABC.UseVisualStyleBackColor = true;
            // 
            // rbABC2
            // 
            this.rbABC2.AutoSize = true;
            this.rbABC2.Location = new System.Drawing.Point(32, 404);
            this.rbABC2.Name = "rbABC2";
            this.rbABC2.Size = new System.Drawing.Size(91, 21);
            this.rbABC2.TabIndex = 17;
            this.rbABC2.TabStop = true;
            this.rbABC2.Text = "A+(B-C)/2";
            this.rbABC2.UseVisualStyleBackColor = true;
            // 
            // rbBAC
            // 
            this.rbBAC.AutoSize = true;
            this.rbBAC.Location = new System.Drawing.Point(32, 431);
            this.rbBAC.Name = "rbBAC";
            this.rbBAC.Size = new System.Drawing.Size(91, 21);
            this.rbBAC.TabIndex = 18;
            this.rbBAC.TabStop = true;
            this.rbBAC.Text = "B+(A-C)/2";
            this.rbBAC.UseVisualStyleBackColor = true;
            // 
            // rbAB
            // 
            this.rbAB.AutoSize = true;
            this.rbAB.Location = new System.Drawing.Point(32, 458);
            this.rbAB.Name = "rbAB";
            this.rbAB.Size = new System.Drawing.Size(77, 21);
            this.rbAB.TabIndex = 19;
            this.rbAB.TabStop = true;
            this.rbAB.Text = "(A+B)/2";
            this.rbAB.UseVisualStyleBackColor = true;
            // 
            // rbJpegLS
            // 
            this.rbJpegLS.AutoSize = true;
            this.rbJpegLS.Location = new System.Drawing.Point(32, 485);
            this.rbJpegLS.Name = "rbJpegLS";
            this.rbJpegLS.Size = new System.Drawing.Size(73, 21);
            this.rbJpegLS.TabIndex = 20;
            this.rbJpegLS.TabStop = true;
            this.rbJpegLS.Text = "jpegLS";
            this.rbJpegLS.UseVisualStyleBackColor = true;
            // 
            // rbOriginal
            // 
            this.rbOriginal.AutoSize = true;
            this.rbOriginal.Location = new System.Drawing.Point(222, 269);
            this.rbOriginal.Name = "rbOriginal";
            this.rbOriginal.Size = new System.Drawing.Size(78, 21);
            this.rbOriginal.TabIndex = 21;
            this.rbOriginal.TabStop = true;
            this.rbOriginal.Text = "Original";
            this.rbOriginal.UseVisualStyleBackColor = true;
            // 
            // rbError
            // 
            this.rbError.AutoSize = true;
            this.rbError.Location = new System.Drawing.Point(222, 296);
            this.rbError.Name = "rbError";
            this.rbError.Size = new System.Drawing.Size(127, 21);
            this.rbError.TabIndex = 22;
            this.rbError.TabStop = true;
            this.rbError.Text = "Error prediction";
            this.rbError.UseVisualStyleBackColor = true;
            // 
            // rbDecoded
            // 
            this.rbDecoded.AutoSize = true;
            this.rbDecoded.Location = new System.Drawing.Point(222, 323);
            this.rbDecoded.Name = "rbDecoded";
            this.rbDecoded.Size = new System.Drawing.Size(86, 21);
            this.rbDecoded.TabIndex = 23;
            this.rbDecoded.TabStop = true;
            this.rbDecoded.Text = "Decoded";
            this.rbDecoded.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 530);
            this.Controls.Add(this.rbDecoded);
            this.Controls.Add(this.rbError);
            this.Controls.Add(this.rbOriginal);
            this.Controls.Add(this.rbJpegLS);
            this.Controls.Add(this.rbAB);
            this.Controls.Add(this.rbBAC);
            this.Controls.Add(this.rbABC2);
            this.Controls.Add(this.rbABC);
            this.Controls.Add(this.rbC);
            this.Controls.Add(this.rbB);
            this.Controls.Add(this.rbA);
            this.Controls.Add(this.rb128);
            this.Name = "Form1";
            this.Text = "Prediction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rb128;
        private System.Windows.Forms.RadioButton rbA;
        private System.Windows.Forms.RadioButton rbB;
        private System.Windows.Forms.RadioButton rbC;
        private System.Windows.Forms.RadioButton rbABC;
        private System.Windows.Forms.RadioButton rbABC2;
        private System.Windows.Forms.RadioButton rbBAC;
        private System.Windows.Forms.RadioButton rbAB;
        private System.Windows.Forms.RadioButton rbJpegLS;
        private System.Windows.Forms.RadioButton rbOriginal;
        private System.Windows.Forms.RadioButton rbError;
        private System.Windows.Forms.RadioButton rbDecoded;
    }
}

