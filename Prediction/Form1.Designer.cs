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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnPredict = new System.Windows.Forms.Button();
            this.btnStore = new System.Windows.Forms.Button();
            this.btnErrorMatrix = new System.Windows.Forms.Button();
            this.btnLoadEncoded = new System.Windows.Forms.Button();
            this.btnDecode = new System.Windows.Forms.Button();
            this.btnSaveDecoded = new System.Windows.Forms.Button();
            this.btnHistogram = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pbDecoded = new System.Windows.Forms.PictureBox();
            this.pbError = new System.Windows.Forms.PictureBox();
            this.pbOriginal = new System.Windows.Forms.PictureBox();
            this.gbHistogram = new System.Windows.Forms.GroupBox();
            this.nudHistogram = new System.Windows.Forms.NumericUpDown();
            this.gbPredictionType = new System.Windows.Forms.GroupBox();
            this.nudErrorMatrix = new System.Windows.Forms.NumericUpDown();
            this.tbMessage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDecoded)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginal)).BeginInit();
            this.gbHistogram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHistogram)).BeginInit();
            this.gbPredictionType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudErrorMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // rb128
            // 
            this.rb128.AutoSize = true;
            this.rb128.Location = new System.Drawing.Point(17, 26);
            this.rb128.Name = "rb128";
            this.rb128.Size = new System.Drawing.Size(53, 21);
            this.rb128.TabIndex = 12;
            this.rb128.TabStop = true;
            this.rb128.Tag = "0";
            this.rb128.Text = "128";
            this.rb128.UseVisualStyleBackColor = true;
            // 
            // rbA
            // 
            this.rbA.AutoSize = true;
            this.rbA.Location = new System.Drawing.Point(17, 53);
            this.rbA.Name = "rbA";
            this.rbA.Size = new System.Drawing.Size(38, 21);
            this.rbA.TabIndex = 13;
            this.rbA.TabStop = true;
            this.rbA.Tag = "1";
            this.rbA.Text = "A";
            this.rbA.UseVisualStyleBackColor = true;
            // 
            // rbB
            // 
            this.rbB.AutoSize = true;
            this.rbB.Location = new System.Drawing.Point(17, 80);
            this.rbB.Name = "rbB";
            this.rbB.Size = new System.Drawing.Size(38, 21);
            this.rbB.TabIndex = 14;
            this.rbB.TabStop = true;
            this.rbB.Tag = "2";
            this.rbB.Text = "B";
            this.rbB.UseVisualStyleBackColor = true;
            // 
            // rbC
            // 
            this.rbC.AutoSize = true;
            this.rbC.Location = new System.Drawing.Point(17, 107);
            this.rbC.Name = "rbC";
            this.rbC.Size = new System.Drawing.Size(38, 21);
            this.rbC.TabIndex = 15;
            this.rbC.TabStop = true;
            this.rbC.Tag = "3";
            this.rbC.Text = "C";
            this.rbC.UseVisualStyleBackColor = true;
            // 
            // rbABC
            // 
            this.rbABC.AutoSize = true;
            this.rbABC.Location = new System.Drawing.Point(17, 134);
            this.rbABC.Name = "rbABC";
            this.rbABC.Size = new System.Drawing.Size(69, 21);
            this.rbABC.TabIndex = 16;
            this.rbABC.TabStop = true;
            this.rbABC.Tag = "4";
            this.rbABC.Text = "A+B-C";
            this.rbABC.UseVisualStyleBackColor = true;
            // 
            // rbABC2
            // 
            this.rbABC2.AutoSize = true;
            this.rbABC2.Location = new System.Drawing.Point(17, 161);
            this.rbABC2.Name = "rbABC2";
            this.rbABC2.Size = new System.Drawing.Size(91, 21);
            this.rbABC2.TabIndex = 17;
            this.rbABC2.TabStop = true;
            this.rbABC2.Tag = "5";
            this.rbABC2.Text = "A+(B-C)/2";
            this.rbABC2.UseVisualStyleBackColor = true;
            // 
            // rbBAC
            // 
            this.rbBAC.AutoSize = true;
            this.rbBAC.Location = new System.Drawing.Point(17, 188);
            this.rbBAC.Name = "rbBAC";
            this.rbBAC.Size = new System.Drawing.Size(91, 21);
            this.rbBAC.TabIndex = 18;
            this.rbBAC.TabStop = true;
            this.rbBAC.Tag = "6";
            this.rbBAC.Text = "B+(A-C)/2";
            this.rbBAC.UseVisualStyleBackColor = true;
            // 
            // rbAB
            // 
            this.rbAB.AutoSize = true;
            this.rbAB.Location = new System.Drawing.Point(17, 215);
            this.rbAB.Name = "rbAB";
            this.rbAB.Size = new System.Drawing.Size(77, 21);
            this.rbAB.TabIndex = 19;
            this.rbAB.TabStop = true;
            this.rbAB.Tag = "7";
            this.rbAB.Text = "(A+B)/2";
            this.rbAB.UseVisualStyleBackColor = true;
            // 
            // rbJpegLS
            // 
            this.rbJpegLS.AutoSize = true;
            this.rbJpegLS.Location = new System.Drawing.Point(17, 242);
            this.rbJpegLS.Name = "rbJpegLS";
            this.rbJpegLS.Size = new System.Drawing.Size(73, 21);
            this.rbJpegLS.TabIndex = 20;
            this.rbJpegLS.TabStop = true;
            this.rbJpegLS.Tag = "8";
            this.rbJpegLS.Text = "jpegLS";
            this.rbJpegLS.UseVisualStyleBackColor = true;
            // 
            // rbOriginal
            // 
            this.rbOriginal.AutoSize = true;
            this.rbOriginal.Location = new System.Drawing.Point(17, 27);
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
            this.rbError.Location = new System.Drawing.Point(17, 54);
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
            this.rbDecoded.Location = new System.Drawing.Point(17, 81);
            this.rbDecoded.Name = "rbDecoded";
            this.rbDecoded.Size = new System.Drawing.Size(86, 21);
            this.rbDecoded.TabIndex = 23;
            this.rbDecoded.TabStop = true;
            this.rbDecoded.Text = "Decoded";
            this.rbDecoded.UseVisualStyleBackColor = true;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(58, 339);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(94, 23);
            this.btnLoadImage.TabIndex = 24;
            this.btnLoadImage.Text = "Load image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnPredict
            // 
            this.btnPredict.Location = new System.Drawing.Point(158, 339);
            this.btnPredict.Name = "btnPredict";
            this.btnPredict.Size = new System.Drawing.Size(94, 23);
            this.btnPredict.TabIndex = 25;
            this.btnPredict.Text = "Predict";
            this.btnPredict.UseVisualStyleBackColor = true;
            this.btnPredict.Click += new System.EventHandler(this.btnPredict_Click);
            // 
            // btnStore
            // 
            this.btnStore.Location = new System.Drawing.Point(258, 339);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(94, 23);
            this.btnStore.TabIndex = 26;
            this.btnStore.Text = "Store";
            this.btnStore.UseVisualStyleBackColor = true;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // btnErrorMatrix
            // 
            this.btnErrorMatrix.Location = new System.Drawing.Point(552, 339);
            this.btnErrorMatrix.Name = "btnErrorMatrix";
            this.btnErrorMatrix.Size = new System.Drawing.Size(138, 23);
            this.btnErrorMatrix.TabIndex = 27;
            this.btnErrorMatrix.Text = "Show error matrix";
            this.btnErrorMatrix.UseVisualStyleBackColor = true;
            this.btnErrorMatrix.Click += new System.EventHandler(this.btnErrorMatrix_Click);
            // 
            // btnLoadEncoded
            // 
            this.btnLoadEncoded.Location = new System.Drawing.Point(731, 339);
            this.btnLoadEncoded.Name = "btnLoadEncoded";
            this.btnLoadEncoded.Size = new System.Drawing.Size(121, 23);
            this.btnLoadEncoded.TabIndex = 28;
            this.btnLoadEncoded.Text = "Load encoded";
            this.btnLoadEncoded.UseVisualStyleBackColor = true;
            this.btnLoadEncoded.Click += new System.EventHandler(this.btnLoadEncoded_Click);
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(858, 339);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(121, 23);
            this.btnDecode.TabIndex = 29;
            this.btnDecode.Text = "Decode";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // btnSaveDecoded
            // 
            this.btnSaveDecoded.Location = new System.Drawing.Point(985, 339);
            this.btnSaveDecoded.Name = "btnSaveDecoded";
            this.btnSaveDecoded.Size = new System.Drawing.Size(121, 23);
            this.btnSaveDecoded.TabIndex = 30;
            this.btnSaveDecoded.Text = "Save decoded";
            this.btnSaveDecoded.UseVisualStyleBackColor = true;
            this.btnSaveDecoded.Click += new System.EventHandler(this.btnSaveDecoded_Click);
            // 
            // btnHistogram
            // 
            this.btnHistogram.Location = new System.Drawing.Point(17, 156);
            this.btnHistogram.Name = "btnHistogram";
            this.btnHistogram.Size = new System.Drawing.Size(124, 66);
            this.btnHistogram.TabIndex = 31;
            this.btnHistogram.Text = "Show histogram";
            this.btnHistogram.UseVisualStyleBackColor = true;
            this.btnHistogram.Click += new System.EventHandler(this.btnHistogram_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(429, 417);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(673, 231);
            this.chart1.TabIndex = 32;
            this.chart1.Text = "chart1";
            // 
            // pbDecoded
            // 
            this.pbDecoded.Location = new System.Drawing.Point(753, 12);
            this.pbDecoded.Name = "pbDecoded";
            this.pbDecoded.Size = new System.Drawing.Size(328, 307);
            this.pbDecoded.TabIndex = 33;
            this.pbDecoded.TabStop = false;
            // 
            // pbError
            // 
            this.pbError.Location = new System.Drawing.Point(396, 12);
            this.pbError.Name = "pbError";
            this.pbError.Size = new System.Drawing.Size(328, 307);
            this.pbError.TabIndex = 34;
            this.pbError.TabStop = false;
            // 
            // pbOriginal
            // 
            this.pbOriginal.Location = new System.Drawing.Point(40, 12);
            this.pbOriginal.Name = "pbOriginal";
            this.pbOriginal.Size = new System.Drawing.Size(328, 307);
            this.pbOriginal.TabIndex = 35;
            this.pbOriginal.TabStop = false;
            // 
            // gbHistogram
            // 
            this.gbHistogram.Controls.Add(this.nudHistogram);
            this.gbHistogram.Controls.Add(this.btnHistogram);
            this.gbHistogram.Controls.Add(this.rbDecoded);
            this.gbHistogram.Controls.Add(this.rbError);
            this.gbHistogram.Controls.Add(this.rbOriginal);
            this.gbHistogram.Location = new System.Drawing.Point(219, 439);
            this.gbHistogram.Name = "gbHistogram";
            this.gbHistogram.Size = new System.Drawing.Size(168, 229);
            this.gbHistogram.TabIndex = 36;
            this.gbHistogram.TabStop = false;
            this.gbHistogram.Text = "Histogram";
            // 
            // nudHistogram
            // 
            this.nudHistogram.Location = new System.Drawing.Point(17, 118);
            this.nudHistogram.Name = "nudHistogram";
            this.nudHistogram.Size = new System.Drawing.Size(70, 22);
            this.nudHistogram.TabIndex = 40;
            // 
            // gbPredictionType
            // 
            this.gbPredictionType.Controls.Add(this.rbJpegLS);
            this.gbPredictionType.Controls.Add(this.rbAB);
            this.gbPredictionType.Controls.Add(this.rbBAC);
            this.gbPredictionType.Controls.Add(this.rbABC2);
            this.gbPredictionType.Controls.Add(this.rbABC);
            this.gbPredictionType.Controls.Add(this.rbC);
            this.gbPredictionType.Controls.Add(this.rbB);
            this.gbPredictionType.Controls.Add(this.rbA);
            this.gbPredictionType.Controls.Add(this.rb128);
            this.gbPredictionType.Location = new System.Drawing.Point(22, 386);
            this.gbPredictionType.Name = "gbPredictionType";
            this.gbPredictionType.Size = new System.Drawing.Size(154, 275);
            this.gbPredictionType.TabIndex = 37;
            this.gbPredictionType.TabStop = false;
            this.gbPredictionType.Text = "Prediction type";
            // 
            // nudErrorMatrix
            // 
            this.nudErrorMatrix.Location = new System.Drawing.Point(428, 342);
            this.nudErrorMatrix.Name = "nudErrorMatrix";
            this.nudErrorMatrix.Size = new System.Drawing.Size(70, 22);
            this.nudErrorMatrix.TabIndex = 38;
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(236, 700);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(624, 38);
            this.tbMessage.TabIndex = 39;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 750);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.nudErrorMatrix);
            this.Controls.Add(this.gbPredictionType);
            this.Controls.Add(this.gbHistogram);
            this.Controls.Add(this.pbOriginal);
            this.Controls.Add(this.pbError);
            this.Controls.Add(this.pbDecoded);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnSaveDecoded);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnLoadEncoded);
            this.Controls.Add(this.btnErrorMatrix);
            this.Controls.Add(this.btnStore);
            this.Controls.Add(this.btnPredict);
            this.Controls.Add(this.btnLoadImage);
            this.Name = "Form1";
            this.Text = "Prediction";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDecoded)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOriginal)).EndInit();
            this.gbHistogram.ResumeLayout(false);
            this.gbHistogram.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHistogram)).EndInit();
            this.gbPredictionType.ResumeLayout(false);
            this.gbPredictionType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudErrorMatrix)).EndInit();
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
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnPredict;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.Button btnErrorMatrix;
        private System.Windows.Forms.Button btnLoadEncoded;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.Button btnSaveDecoded;
        private System.Windows.Forms.Button btnHistogram;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.PictureBox pbDecoded;
        private System.Windows.Forms.PictureBox pbError;
        private System.Windows.Forms.PictureBox pbOriginal;
        private System.Windows.Forms.GroupBox gbHistogram;
        private System.Windows.Forms.GroupBox gbPredictionType;
        private System.Windows.Forms.NumericUpDown nudHistogram;
        private System.Windows.Forms.NumericUpDown nudErrorMatrix;
        private System.Windows.Forms.TextBox tbMessage;
    }
}

