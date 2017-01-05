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

            dialog.Filter = "All Files (*.*)|*.*";
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
            if (inputFileName != "")
            {
                
                encryptor = new RSA();
                var ok = encryptor.encrypt(inputFileName);

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
            if (encryptedFileName != "")
            {

                encryptor = new RSA();
                var ok = encryptor.decrypt(encryptedFileName);

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
    }
}
