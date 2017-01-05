namespace RSAEncryption
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnLoadEncryptedFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.tbDecryptPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNEncrypt = new System.Windows.Forms.TextBox();
            this.tbEEncrypt = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.tbKeyEncrypt = new System.Windows.Forms.TextBox();
            this.tbKeyDecrypt = new System.Windows.Forms.TextBox();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.tbEDecrypt = new System.Windows.Forms.TextBox();
            this.tbNDecrypt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbDDecrypt = new System.Windows.Forms.TextBox();
            this.tbMessages = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLoad.Location = new System.Drawing.Point(84, 33);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(166, 32);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load file";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnLoadEncryptedFile
            // 
            this.btnLoadEncryptedFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLoadEncryptedFile.Location = new System.Drawing.Point(421, 33);
            this.btnLoadEncryptedFile.Name = "btnLoadEncryptedFile";
            this.btnLoadEncryptedFile.Size = new System.Drawing.Size(166, 32);
            this.btnLoadEncryptedFile.TabIndex = 2;
            this.btnLoadEncryptedFile.Text = "Load encrypted file";
            this.btnLoadEncryptedFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLoadEncryptedFile.UseVisualStyleBackColor = true;
            this.btnLoadEncryptedFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "File path:";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(84, 92);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(215, 22);
            this.tbPath.TabIndex = 4;
            // 
            // tbDecryptPath
            // 
            this.tbDecryptPath.Location = new System.Drawing.Point(421, 95);
            this.tbDecryptPath.Name = "tbDecryptPath";
            this.tbDecryptPath.ReadOnly = true;
            this.tbDecryptPath.Size = new System.Drawing.Size(217, 22);
            this.tbDecryptPath.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "N";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(12, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Key";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(12, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "E";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(349, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "D";
            // 
            // tbNEncrypt
            // 
            this.tbNEncrypt.Location = new System.Drawing.Point(84, 154);
            this.tbNEncrypt.Name = "tbNEncrypt";
            this.tbNEncrypt.Size = new System.Drawing.Size(215, 22);
            this.tbNEncrypt.TabIndex = 10;
            // 
            // tbEEncrypt
            // 
            this.tbEEncrypt.Location = new System.Drawing.Point(84, 198);
            this.tbEEncrypt.Name = "tbEEncrypt";
            this.tbEEncrypt.Size = new System.Drawing.Size(215, 22);
            this.tbEEncrypt.TabIndex = 11;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEncrypt.Location = new System.Drawing.Point(84, 280);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(166, 32);
            this.btnEncrypt.TabIndex = 12;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // tbKeyEncrypt
            // 
            this.tbKeyEncrypt.Location = new System.Drawing.Point(84, 344);
            this.tbKeyEncrypt.Name = "tbKeyEncrypt";
            this.tbKeyEncrypt.ReadOnly = true;
            this.tbKeyEncrypt.Size = new System.Drawing.Size(215, 22);
            this.tbKeyEncrypt.TabIndex = 13;
            // 
            // tbKeyDecrypt
            // 
            this.tbKeyDecrypt.Location = new System.Drawing.Point(421, 344);
            this.tbKeyDecrypt.Name = "tbKeyDecrypt";
            this.tbKeyDecrypt.ReadOnly = true;
            this.tbKeyDecrypt.Size = new System.Drawing.Size(215, 22);
            this.tbKeyDecrypt.TabIndex = 20;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDecrypt.Location = new System.Drawing.Point(421, 280);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(166, 32);
            this.btnDecrypt.TabIndex = 19;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // tbEDecrypt
            // 
            this.tbEDecrypt.Location = new System.Drawing.Point(421, 198);
            this.tbEDecrypt.Name = "tbEDecrypt";
            this.tbEDecrypt.ReadOnly = true;
            this.tbEDecrypt.Size = new System.Drawing.Size(215, 22);
            this.tbEDecrypt.TabIndex = 18;
            // 
            // tbNDecrypt
            // 
            this.tbNDecrypt.Location = new System.Drawing.Point(421, 154);
            this.tbNDecrypt.Name = "tbNDecrypt";
            this.tbNDecrypt.ReadOnly = true;
            this.tbNDecrypt.Size = new System.Drawing.Size(215, 22);
            this.tbNDecrypt.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(349, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "E";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(349, 349);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Key";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(349, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "N";
            // 
            // tbDDecrypt
            // 
            this.tbDDecrypt.Location = new System.Drawing.Point(421, 242);
            this.tbDDecrypt.Name = "tbDDecrypt";
            this.tbDDecrypt.Size = new System.Drawing.Size(215, 22);
            this.tbDDecrypt.TabIndex = 21;
            // 
            // tbMessages
            // 
            this.tbMessages.Location = new System.Drawing.Point(84, 396);
            this.tbMessages.Multiline = true;
            this.tbMessages.Name = "tbMessages";
            this.tbMessages.Size = new System.Drawing.Size(552, 51);
            this.tbMessages.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(12, 412);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "Message";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 479);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbMessages);
            this.Controls.Add(this.tbDDecrypt);
            this.Controls.Add(this.tbKeyDecrypt);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.tbEDecrypt);
            this.Controls.Add(this.tbNDecrypt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbKeyEncrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.tbEEncrypt);
            this.Controls.Add(this.tbNEncrypt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDecryptPath);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadEncryptedFile);
            this.Controls.Add(this.btnLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnLoadEncryptedFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.TextBox tbDecryptPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNEncrypt;
        private System.Windows.Forms.TextBox tbEEncrypt;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox tbKeyEncrypt;
        private System.Windows.Forms.TextBox tbKeyDecrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox tbEDecrypt;
        private System.Windows.Forms.TextBox tbNDecrypt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbDDecrypt;
        private System.Windows.Forms.TextBox tbMessages;
        private System.Windows.Forms.Label label9;
    }
}

