using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LZ77
{
    public partial class Form1 : Form
    {
        String inputFileName;
        String compressedFileName;
        String decompressedFileName;

        public Form1()
        {
            InitializeComponent();

            for(int i = 3; i <= 16; i++)
            {
                lbOffset.Items.Add(i);
            }
            for (int i = 2; i <= 5; i++)
            {
                lbLength.Items.Add(i);
            }
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
    }
}
