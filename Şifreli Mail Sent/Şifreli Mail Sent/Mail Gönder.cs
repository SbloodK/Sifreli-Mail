using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Net.NetworkInformation;

namespace Şifreli_Mail_Sent
{
    public partial class Mail_Gönder : Form
    {
        public Mail_Gönder()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mail_Gönder_Şifre_Çözümle a = new Mail_Gönder_Şifre_Çözümle();
            a.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Mail_Gönder_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.9;
        }

        #region EncryptionMD5
        string hash = "";

        string EncryptionMD5(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(Encoding.Default.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripleDES.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }
        #endregion

        #region EncryptionSezar
        string EncryptionSezar(string text)
        {
            char[] x = text.ToCharArray();
            string encryptedText = null;

            foreach (char item in x)
            {
                encryptedText += Convert.ToChar(item + 3);
            }
            return encryptedText;
        }
        #endregion

        MailMessage eposta = new MailMessage();

        #region HotMailGönder
        void HotMailGonder()
        {
            try
            {
                eposta.From = new MailAddress(bunifuMaterialTextbox1.Text.ToString());
                eposta.To.Add(bunifuMaterialTextbox3.Text.ToString());
                if (comboBox1.Text == "MD5")
                {
                    eposta.Body = EncryptionMD5(bunifuMaterialTextbox4.Text.ToString());
                }
                else if (comboBox1.Text == "Sezar")
                {
                    eposta.Body = EncryptionSezar(bunifuMaterialTextbox4.Text.ToString());
                }
                else if (comboBox1.Text == "Base64")
                {
                    byte[] sifrele = System.Text.ASCIIEncoding.ASCII.GetBytes(bunifuMaterialTextbox4.Text);
                    eposta.Body = System.Convert.ToBase64String(sifrele);
                }
                else
                {
                    MessageBox.Show("Bir şifreleme türü seçmelisiniz!", "Şifreleme Türü", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                eposta.Subject = textBox1.Text;

                SmtpClient smtp = new SmtpClient();

                smtp.Credentials = new System.Net.NetworkCredential(bunifuMaterialTextbox1.Text, bunifuMaterialTextbox2.Text);
                smtp.Host = "smtp.live.com"; //gmail host adresi = "smtp.live.com";
                smtp.EnableSsl = true;
                smtp.Port = 587;

                smtp.Send(eposta);
                MessageBox.Show("Başarılı bir şekilde tamamlandı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region OutlookMailGönder
        void OutlookMailGonder()
        {
            try
            {
                eposta.From = new MailAddress(bunifuMaterialTextbox1.Text.ToString());
                eposta.To.Add(bunifuMaterialTextbox3.Text.ToString());
                if (comboBox1.Text == "MD5")
                {
                    eposta.Body = EncryptionMD5(bunifuMaterialTextbox4.Text.ToString());
                }
                else if (comboBox1.Text == "Sezar")
                {
                    eposta.Body = EncryptionSezar(bunifuMaterialTextbox4.Text.ToString());
                }
                else if (comboBox1.Text == "Base64")
                {
                    byte[] sifrele = System.Text.ASCIIEncoding.ASCII.GetBytes(bunifuMaterialTextbox4.Text);
                    eposta.Body = System.Convert.ToBase64String(sifrele);
                }
                else
                {
                    MessageBox.Show("Bir şifreleme türü seçmelisiniz!", "Şifreleme Türü", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                eposta.Subject = textBox1.Text;

                SmtpClient smtp = new SmtpClient();

                smtp.Credentials = new System.Net.NetworkCredential(bunifuMaterialTextbox1.Text, bunifuMaterialTextbox2.Text);
                smtp.Host = "smtp.live.com"; //gmail host adresi = "smtp.live.com";
                smtp.EnableSsl = true;
                smtp.Port = 587;

                smtp.Send(eposta);
                MessageBox.Show("Başarılı bir şekilde tamamlandı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region GMailGonder
        void GMailGonder() 
        {
            try
            {
                eposta.From = new MailAddress(bunifuMaterialTextbox1.Text.ToString());
                eposta.To.Add(bunifuMaterialTextbox3.Text.ToString());
                if (comboBox1.Text == "MD5")
                {
                    eposta.Body = EncryptionMD5(bunifuMaterialTextbox4.Text.ToString());
                }
                else if (comboBox1.Text == "Sezar")
                {
                    eposta.Body = EncryptionSezar(bunifuMaterialTextbox4.Text.ToString());
                }
                else if (comboBox1.Text == "Base64")
                {
                    byte[] sifrele = System.Text.ASCIIEncoding.ASCII.GetBytes(bunifuMaterialTextbox4.Text);
                    eposta.Body = System.Convert.ToBase64String(sifrele);
                }
                else
                {
                    MessageBox.Show("Bir şifreleme türü seçmelisiniz!", "Şifreleme Türü", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                eposta.Subject = textBox1.Text;

                SmtpClient smtp = new SmtpClient();

                smtp.Credentials = new System.Net.NetworkCredential(bunifuMaterialTextbox1.Text, bunifuMaterialTextbox2.Text);
                smtp.Host = "smtp.gmail.com"; //gmail host adresi = "smtp.live.com";
                smtp.EnableSsl = true;
                smtp.Port = 587;
                
                smtp.Send(eposta);
                MessageBox.Show("Başarılı bir şekilde tamamlandı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Bir hata oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (NetworkInterface.GetIsNetworkAvailable() == true)
            {
                GMailGonder();
                return;
            }
            else
            {
                MessageBox.Show("İnternet bağlantısı hatası.\n\nLütfen internete bağlanın ve tekrar deneyin.", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {  
            if (NetworkInterface.GetIsNetworkAvailable() == true)
            {
                HotMailGonder();
                return;
            }
            else
            {
                MessageBox.Show("İnternet bağlantısı hatası.\n\nLütfen internete bağlanın ve tekrar deneyin.", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        { 
            if (NetworkInterface.GetIsNetworkAvailable() == true)
            {
                OutlookMailGonder();
                return;
            }
            else
            {
                MessageBox.Show("İnternet bağlantısı hatası.\n\nLütfen internete bağlanın ve tekrar deneyin.", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        bool move;
        int mouse_x, mouse_y;
        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void label6_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void label6_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Mail_Gönder_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Mail_Gönder_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Mail_Gönder_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
    }
}
