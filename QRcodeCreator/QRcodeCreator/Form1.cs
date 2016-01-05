using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;

namespace QRcodeCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Create QR Code
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string URL = txtURL.Text;
            QRCodeEncoder encoder = new QRCodeEncoder();
            Bitmap qrcode = encoder.Encode(URL);
            pbQR.Image = (Image) qrcode;
        }

        // Save QR Code
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog {Filter = @"PNG|*.png|JPEG|*.jpeg|BMP|*.bmp|GIF|*.gif"};
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pbQR.Image.Save(s.FileName);
            }
        }

        // Open QR Code
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pbQR.ImageLocation = o.FileName;
            }
        }

        // Convert QR Code back to URL
        private void btnConvert_Click(object sender, EventArgs e)
        {
            QRCodeDecoder decoder = new QRCodeDecoder();
            MessageBox.Show(decoder.decode(new QRCodeBitmapImage(pbQR.Image as Bitmap)));
        }

    }
}
