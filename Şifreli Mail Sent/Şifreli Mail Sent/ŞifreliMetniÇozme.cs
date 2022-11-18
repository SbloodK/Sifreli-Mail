using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Şifreli_Mail_Sent
{
    public partial class ŞifreliMetniÇozme : Form
    {
        public ŞifreliMetniÇozme()
        {
            InitializeComponent();
        }

        private void ŞifreliMetniÇozme_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.9;
        }

        string hash = "";

        string DescryptMD5(string text)
        {
            byte[] data = Convert.FromBase64String(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(Encoding.Default.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripleDES.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Encoding.Default.GetString(results);
                }
            }
        }

        string DescryptionSezar(string text)
        {
            char[] x = text.ToCharArray();
            string encryptedText = null;

            foreach (char item in x)
            {
                encryptedText += Convert.ToChar(item - 3);
            }
            return encryptedText;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "MD5")
            {
                textBox2.Text = DescryptMD5(textBox1.Text);
            }
            else if (comboBox1.Text == "Sezar")
            {
                textBox2.Text = DescryptionSezar(textBox1.Text);
            }
            else if (comboBox1.Text == "Base64")
            {
                byte[] sifrele = Convert.FromBase64String(textBox1.Text);
                textBox2.Text = ASCIIEncoding.ASCII.GetString(sifrele);
            }
            else
            {
                MessageBox.Show("Bir şifreleme türü seçmelisiniz!", "Şifreleme Türü", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mail_Gönder_Şifre_Çözümle a = new Mail_Gönder_Şifre_Çözümle();
            a.Show();
        }
        bool move;
        int mouse_x, mouse_y;
        private void ŞifreliMetniÇozme_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void ŞifreliMetniÇozme_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void ŞifreliMetniÇozme_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
    }
}
