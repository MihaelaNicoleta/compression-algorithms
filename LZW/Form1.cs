using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LZW
{
    public partial class Form1 : Form
    {
        String inputFileName;
        String compressedFileName;
        
        int noBitsForIndex = 9;

        LZW compresser;

        public Form1()
        {
            InitializeComponent();
                       
            for (int i = 9; i <= 15; i++)
            {
                lbIndex.Items.Add(i);
            }
            
            lbIndex.SelectedIndex = 0;

            tbTokens.Text = "";

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

        private void btnLoadCompressedFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "LZW Compressed Files (.lzw)|*.lzw";
            dialog.FilterIndex = 1;
            dialog.Multiselect = false;

            DialogResult opened = dialog.ShowDialog();

            if (opened == DialogResult.OK)
            {
                tbCompressedPath.Text = dialog.FileName;
                compressedFileName = tbCompressedPath.Text;
            }

        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            noBitsForIndex = (int)lbIndex.SelectedItem;

            if(inputFileName != "")
            {
                var action = (chkDisplayTokens.Checked) ? 1 : 0;
                compresser = new LZW(action, noBitsForIndex);
                var ok = compresser.compress(inputFileName);

                if (ok == true)
                {
                    tbTokens.Text += "\r\nCompression was a great success.\r\n";
                }

                /*if (chkDisplayTokens.Checked)
                {
                    List<Token> resultTokens = new List<Token>();
                    resultTokens = coder.getTokens();

                    displayTokens(resultTokens);
                }*/
            }
            else
            {
                throw new Exception("You haven't selecetd any file.");
            }        

        }

        private void displayTokens(List<Token> tokens)
        {
            foreach (Token token in tokens)
            {
                tbTokens.Text += token.toString();
            }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            if (compressedFileName != "")
            {
                compresser = new LZW();
                var ok = compresser.decompress(compressedFileName);
                if(ok == true)
                {
                    tbTokens.Text += "\r\nDecompression was a great success.\r\n";
                }
                
            }
            else
            {
                throw new Exception("You haven't selecetd any file.");
            }
        }
    }
}
