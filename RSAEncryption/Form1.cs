using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSAEncryption
{
    public partial class Form1 : Form
    {

        String inputFileName;
        String encryptedFileName;

        RSA encryptor;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "All Files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.Multiselect = false;

            DialogResult opened = dialog.ShowDialog();

            if (opened == DialogResult.OK)
            {
                tbPath.Text = dialog.FileName;
                inputFileName = tbPath.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "RSA Compressed Files (.rsa)|*.rsa";
            dialog.FilterIndex = 1;
            dialog.Multiselect = false;

            DialogResult opened = dialog.ShowDialog();

            if (opened == DialogResult.OK)
            {
                tbDecryptPath.Text = dialog.FileName;
                encryptedFileName = tbDecryptPath.Text;
            }

        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            int N = Convert.ToInt32(tbNEncrypt.Text.Trim());
            int E = Convert.ToInt32(tbEEncrypt.Text.Trim());
            
            if((N < (int)Math.Pow(2, 8)) && (N > (int)Math.Pow(2, 32)))
            {
                throw new Exception("N should have values between 2^8 and 2^32");
            }
    
            if ((inputFileName != "") && (N > 0) && (E > 0))
            {
                
                encryptor = new RSA(N, E);
                var ok = encryptor.encrypt(inputFileName);

                tbKeyEncrypt.Text = encryptor.getEncryptKey();

                if (ok == true)
                {
                    tbMessages.Text += "\r\nEncryption was a great success.\r\n";
                }

            }
            else
            {
                throw new Exception("You haven't selecetd any file.");
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            int D = Convert.ToInt32(tbDDecrypt.Text.Trim());
            if ((encryptedFileName != "") && (D > 0))
            {
                encryptor = new RSA(D);
                var ok = encryptor.decrypt(encryptedFileName);
                tbNDecrypt.Text = encryptor.getN();
                tbEDecrypt.Text = encryptor.getE();
                tbKeyDecrypt.Text = encryptor.getDecryptKey();

                if (ok == true)
                {
                    tbMessages.Text += "\r\nDecryption was a great success.\r\n";
                }

            }
            else
            {
                throw new Exception("You haven't selecetd any file.");
            }
        }
    }
}
