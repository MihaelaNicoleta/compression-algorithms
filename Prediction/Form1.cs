using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prediction
{
    public partial class Form1 : Form
    {
        String inputPictureName;
        String compressedPictureName;

        Bitmap originalPicture;

        Prediction compresser;

        
        int checkedRadioButtonIndex = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "BMP Image Files (.bmp)|*.bmp";
            dialog.FilterIndex = 1;
            dialog.Multiselect = false;

            DialogResult opened = dialog.ShowDialog();

            if (opened == DialogResult.OK)
            {
                inputPictureName = dialog.FileName;
            }

            FileStream fileStream = new FileStream(inputPictureName, FileMode.Open);
            originalPicture = new Bitmap(fileStream);
            fileStream.Close();
            pbOriginal.Image = (Bitmap)originalPicture.Clone();
        }

        private void btnPredict_Click(object sender, EventArgs e)
        {
            /* get prediction type index */
            var checkedRadioButton = gbPredictionType.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);

            checkedRadioButtonIndex = (checkedRadioButton != null) ? Convert.ToInt32(checkedRadioButton.Tag) : 0;
            

            if (inputPictureName != "")
            {
                compresser = new Prediction(checkedRadioButtonIndex);
                var ok = compresser.compress(inputPictureName);

                if (ok == true)
                {
                    tbMessage.Text = "Compression was a great success.\r\n";
                }                
            }
            else
            {
                throw new Exception("You haven't selected any file.");
            }

        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            String pictureName = Path.GetFileNameWithoutExtension(inputPictureName);
            var savedFileName = compresser.storeCompressedFile(pictureName);
            
            tbMessage.Text = "The file: " + savedFileName + " was saved.\r\n";
            
        }

        private void btnErrorMatrix_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadEncoded_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Predicted Image Files (.pre)|*.pre";
            dialog.FilterIndex = 1;
            dialog.Multiselect = false;

            DialogResult opened = dialog.ShowDialog();

            if (opened == DialogResult.OK)
            {
                compressedPictureName = dialog.FileName;
            }

        }

        private void btnDecode_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveDecoded_Click(object sender, EventArgs e)
        {

        }

        private void btnHistogram_Click(object sender, EventArgs e)
        {

        }
        
    }
}
