using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaliSahaTakipOtomasyonu
{
    public partial class HesapOlustur : Form
    {
        public HesapOlustur()
        {
            InitializeComponent();
        }

        private void btnHesabimiOlustur_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) ||
                string.IsNullOrWhiteSpace(txtSifre.Text) ||
                string.IsNullOrWhiteSpace(txtTekrarSifre.Text))
                {
                    MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz.");
                    return;
                }

                if (txtSifre.Text != txtTekrarSifre.Text)
                {
                    MessageBox.Show("Şifreler uyuşmuyor.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HaliSaha.mdb;";
                string query = "INSERT INTO tblKullanicilar (kullaniciadi, sifre, yetki) VALUES (@kullaniciadi, @sifre, @yetki)";

                using (OleDbConnection baglanti = new OleDbConnection(connectionString))
                {
                    baglanti.Open();

                    using (OleDbCommand command = new OleDbCommand(query, baglanti))
                    {
                        command.Parameters.AddWithValue("@kullaniciadi", txtKullaniciAdi.Text);
                        command.Parameters.AddWithValue("@sifre", txtSifre.Text);
                        command.Parameters.AddWithValue("@yetki", 1);

                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Hesabınız Başarıyla Oluşturuldu", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GirisPaneli giris = new GirisPaneli();
                this.Hide();
                giris.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hesap oluşturulurken bir hata oluştu: " + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGirisEkrani_Click(object sender, EventArgs e)
        {
            GirisPaneli giris = new GirisPaneli();
            this.Hide();
            giris.ShowDialog();
            this.Close();
        }
    }
}
