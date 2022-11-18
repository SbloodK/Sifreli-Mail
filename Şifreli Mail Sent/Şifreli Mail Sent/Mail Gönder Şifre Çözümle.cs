using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Şifreli_Mail_Sent
{
    public partial class Mail_Gönder_Şifre_Çözümle : Form
    {
        public Mail_Gönder_Şifre_Çözümle()
        {
            InitializeComponent();
        }

        private void Mail_Gönder_Şifre_Çözümle_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.9;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Mail_Gönder mailGonder = new Mail_Gönder();
            this.Hide();
            mailGonder.Show();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            ŞifreliMetniÇozme coz = new ŞifreliMetniÇozme();
            this.Hide();
            coz.Show();
        }
        bool move;
        int mouse_x, mouse_y;
        private void Mail_Gönder_Şifre_Çözümle_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Mail_Gönder_Şifre_Çözümle_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Mail_Gönder_Şifre_Çözümle_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
    }
}
