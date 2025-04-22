using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HaliSahaTakipOtomasyonu
{
    public partial class AdminPaneli : Form
    {
        public AdminPaneli()
        {
            InitializeComponent();
        }
        
        public static bool menu = false;

        private void gelirlerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Gelirler ekle = new Gelirler();
            ekle.MdiParent = this;
            ekle.Show();
        }

        private void giderlerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Giderler ekle = new Giderler();
            ekle.MdiParent = this;
            ekle.Show();
        }

        private void personelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Personel ekle = new Personel();
            ekle.MdiParent = this;
            ekle.Show();
        }

        private void rANDEUİŞLEMLERİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rendevu ekle = new Rendevu();
            ekle.MdiParent = this;
            ekle.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Rendevuİslemleri ekle = new Rendevuİslemleri();
            ekle.MdiParent = this;
            ekle.Show();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Kullanicilar ekle = new Kullanicilar();
            ekle.MdiParent = this;
            ekle.Show();
        }
    }
}