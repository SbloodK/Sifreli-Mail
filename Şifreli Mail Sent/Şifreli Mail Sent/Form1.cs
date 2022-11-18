using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Reflection;

namespace Şifreli_Mail_Sent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool move;
        int mouse_x, mouse_y;
        NotifyIcon notify_Icon = new NotifyIcon();
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.9;
            notify_Icon.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Mail_Gönder_Şifre_Çözümle a = new Mail_Gönder_Şifre_Çözümle();
            if (bunifuMaterialTextbox1.Text == "admin" && bunifuMaterialTextbox2.Text == "pass")
            {
                if (NetworkInterface.GetIsNetworkAvailable() == true)
                {
                    this.Hide();
                    a.Show();
                }
                else
                {
                    MessageBox.Show("İnternet bağlantısı hatası.\n\nLütfen internete bağlanın ve tekrar deneyin.", "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (bunifuMaterialTextbox1.Text == "" && bunifuMaterialTextbox2.Text == "")
            {
                label4.Text = "Kullanıcı adı ve parola boş bırakılamaz!";
            }
            else
            {
                label4.Text = "Kullanıcı adı yada parola yanlış!";
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                NotifyIcon();
                NotifyBildirim("Program simge durumuna getirildi!", "Program arka planda çalışmaya devam edecek!");
            }
        }
        private void NotifyIcon()
        {
            this.Hide();
            notify_Icon.Visible = true;
            notify_Icon.Text = "Notify Icon Uygulaması";
            notify_Icon.BalloonTipTitle = "Notify Icon uygulaması arka planda çalışıyor";
            notify_Icon.BalloonTipText = "Program sağ alt köşede konumlandı.";
            notify_Icon.BalloonTipIcon = ToolTipIcon.Info;
            notify_Icon.ShowBalloonTip(2000);

            // notifyIcon için event ataması yaptık
            notify_Icon.MouseDoubleClick += new MouseEventHandler(notify_Icon_MouseDoubleClick);
            notify_Icon.ContextMenuStrip = contextMenuStrip1;
        }
        int TamamenKapat = 0;
        void notify_Icon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notify_Icon.Visible = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TamamenKapat == 1)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                NotifyIcon();
                NotifyBildirim("Program kapatılmadı!", "Programı kapatamazsınız. Bu sebeple arka planda çalışmaya devam edecek!");
            }
        }

        private void açToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Show();
            notify_Icon.Visible = false;
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TamamenKapat = 1;
            Application.Exit();
        }
        void NotifyBildirim(string baslik, string mesaj)
        {
            notify_Icon.BalloonTipText = mesaj;
            notify_Icon.BalloonTipIcon = ToolTipIcon.Info;
            notify_Icon.BalloonTipTitle = baslik;
            notify_Icon.ShowBalloonTip(100);
        }
    }
}
