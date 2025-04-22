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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Policy;

namespace HaliSahaTakipOtomasyonu
{
    public partial class GirisPaneli : Form
    {
        public GirisPaneli()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti; //Bağlantı kurmak için
        OleDbCommand komut;//Sorgu nesnesi 

        public static string yetki;
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz.");
                return;
            }

            string kullaniciadi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;
            OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HaliSaha.mdb;");
            try
            {
                baglanti.Open();
                OleDbCommand giris = new OleDbCommand("SELECT * FROM tblKullanicilar WHERE kullaniciadi=@kullaniciadi AND sifre=@sifre", baglanti);
                giris.Parameters.AddWithValue("@kullaniciadi", kullaniciadi);
                giris.Parameters.AddWithValue("@sifre", sifre);
                OleDbDataReader oku = giris.ExecuteReader();

                if (oku.Read())
                {
                    string kullaniciAdi = oku["kullaniciadi"].ToString();
                    yetki = oku["yetki"].ToString();
                    if (yetki == "2")
                    {
                        AdminPaneli rendevu = new AdminPaneli();
                        rendevu.Show();
                        this.Hide();
                        MessageBox.Show($"Hoşgeldiniz, {kullaniciAdi}!", "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Yetkiniz bulunmamaktadır.", "Yetki Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre yanlış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }

        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            HesapOlustur hesap = new HesapOlustur();
            hesap.Show();
            this.Hide();
        }
    }
}
