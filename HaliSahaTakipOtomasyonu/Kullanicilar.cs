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
    public partial class Kullanicilar : Form
    {
        public Kullanicilar()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HaliSaha.mdb");

        void Listele()
        {
            try
            {
                if (baglanti == null) baglanti.Open();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("Select * From tblKullanicilar", baglanti);
                da.Fill(dt);
                dataPersonel.DataSource = dt;
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
            }
        }
        void Temizle()
        {
            txtKimlik.Clear();
            txtKullaniciAdi.Clear();
            txtSifre.Clear();
            txtYetki.Clear();
        }

        private void Kullanicilar_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            // Geri alınamaycak bir işlemdir. Silme işlemi için önce soruyoruz
            // evet derse siliyor hayır derse iptal ediyoruz
            DialogResult dialogSil = MessageBox.Show(txtKimlik.Text
                + " " + txtKullaniciAdi.Text +
                " Kullanıcı Kaydı silinecek emin misiniz?",
                "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (dialogSil == DialogResult.OK)
            {
                try
                {
                    // Kimlik yardımıyla siliyoruz
                    OleDbCommand Sil = new OleDbCommand("delete from tblPersonel where Kimlik=@p1", baglanti);
                    Sil.Parameters.AddWithValue("@p1", dataPersonel.CurrentRow.Cells["Kimlik"].Value.ToString());
                    baglanti.Open();
                    Sil.ExecuteNonQuery();
                    MessageBox.Show(txtKullaniciAdi.Text + " " + " Adlı personel kaydı silindi",
                        "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    baglanti.Close();                    
                    Listele();
                    Temizle();
                }
                catch (Exception HATA)
                {
                    // Hatayı mesajıyla beraber alıyoruz.
                    MessageBox.Show("Personel kaydı silinemedi Hata: " + HATA.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // En sonunda bağlantıyı kapadık.
                    baglanti.Close();
                }
            }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text
                != "" && txtSifre.Text
                != "" && txtYetki.Text
                != "")
            {
                OleDbCommand Güncelle = new OleDbCommand("update tblKullanicilar set KullaniciAdi=@p1, Sifre=@p2, Yetki=@p3, where Kimlik=@p0", baglanti);
                Güncelle.Parameters.AddWithValue("@p0", txtKimlik.Text);
                Güncelle.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
                Güncelle.Parameters.AddWithValue("@p2", txtSifre.Text);
                Güncelle.Parameters.AddWithValue("@p3", txtYetki.Text);

                try
                {
                    baglanti.Open();
                    Güncelle.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı bilgisi güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Listele();
                    Temizle();
                }
                catch (Exception HATA)
                {
                    MessageBox.Show("Personel bilgisi güncellenemedi Hata: " + HATA.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    baglanti.Close();
                }
            }
            else
            {
                MessageBox.Show("Boş alan bırakmayınız!!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataPersonel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataPersonel.SelectedCells[0].RowIndex;

            txtKimlik.Text = dataPersonel.Rows[secilen].Cells[0].Value.ToString();
            txtKullaniciAdi.Text = dataPersonel.Rows[secilen].Cells[1].Value.ToString();
            txtSifre.Text = dataPersonel.Rows[secilen].Cells[2].Value.ToString();
            txtYetki.Text = dataPersonel.Rows[secilen].Cells[3].Value.ToString();


        }

        private void AramaYap(string txtAra)
        {
            string query = "SELECT * FROM tblKullanicilar WHERE 1=1";
            if (!string.IsNullOrEmpty(txtAra.Trim()))
            {
                query += " AND Trim(KullaniciAdi) LIKE ?";
            }

            using (OleDbCommand command = new OleDbCommand(query, baglanti))
            {
                if (!string.IsNullOrEmpty(txtAra.Trim()))
                {
                    command.Parameters.AddWithValue("?", "%" + txtAra.Trim() + "%");
                }

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();

                try
                {
                    baglanti.Open();
                    da.Fill(dt);
                    dataPersonel.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    baglanti.Close();
                }
            }
        }
        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            AramaYap(txtKullaniciAdi.Text);
        }
    }
}
