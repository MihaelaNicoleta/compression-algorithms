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
            Bitmap originalPicture = new Bitmap(fileStream);
            originalPicture = makeGrayscale(originalPicture);
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
                var ok = compresser.compress();

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

        private Bitmap makeGrayscale(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
               });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }
    }
}
