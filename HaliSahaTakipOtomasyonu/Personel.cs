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
    public partial class Personel : Form
    {
        public Personel()
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
                OleDbDataAdapter da = new OleDbDataAdapter("Select * From tblPersonel", baglanti);
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
            TxtAd.Clear();
            TxtSoyad.Clear();
            txtKimlik.Clear();
            MskMaas.Clear();
            MskTel.Clear();
        }
        void PersoneListesi()
        {
            OleDbCommand komut = new OleDbCommand("select * from tblPersonel", baglanti);
            OleDbDataAdapter da = new OleDbDataAdapter(komut);
            DataTable tablo = new DataTable();
            baglanti.Open();
            da.Fill(tablo);
            dataPersonel.DataSource = tablo;
            baglanti.Close();
        }

        private string Kimlik;

        private void Personel_Load(object sender, EventArgs e)
        {
            PersoneListesi();
            Listele();
        }

        private void BtnEkle_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (//string.IsNullOrWhiteSpace(txtKimlik.Text) ||
                    string.IsNullOrWhiteSpace(TxtAd.Text) ||
                    string.IsNullOrWhiteSpace(TxtSoyad.Text) ||
                    string.IsNullOrWhiteSpace(MskTel.Text) ||
                    string.IsNullOrWhiteSpace(DtpTarih.Text) ||
                    string.IsNullOrWhiteSpace(MskMaas.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HaliSaha.mdb"))
                {
                    baglanti.Open();

                    OleDbCommand kaydet = new OleDbCommand(
                        "INSERT INTO tblPersonel (Ad, Soyad, Tarih, Maas, Telefon) VALUES (@p1, @p2, @p3, @p4, @p5)", baglanti);

                    kaydet.Parameters.AddWithValue("@p1", TxtAd.Text);
                    kaydet.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                    kaydet.Parameters.AddWithValue("@p3", DtpTarih.Text);

                    decimal maas;
                    if (decimal.TryParse(MskMaas.Text, out maas))
                    {
                        kaydet.Parameters.AddWithValue("@p4", maas);
                    }
                    else
                    {
                        MessageBox.Show("Maas alanı geçerli bir sayı olmalıdır.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string telefon = MskTel.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
                    kaydet.Parameters.AddWithValue("@p5", telefon);

                    kaydet.ExecuteNonQuery();
                    MessageBox.Show("Personel kaydı başarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    PersoneListesi();
                    Listele();
                    Temizle();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Personel kaydı başarısız. Hata: " + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnGüncelle_Click_1(object sender, EventArgs e)
        {
            if (TxtAd.Text != "" && TxtSoyad.Text
                != "" && MskTel.Text
                != "" && DtpTarih.Text
                != "" && MskMaas.Text
                != "" && MskTel.Text
                != "")
            {
                OleDbCommand Güncelle = new OleDbCommand("update tblPersonel set Ad=@p1, Soyad=@p2, Tarih=@p3, Maas=@p4, Telefon=@p5 where Kimlik=@p0", baglanti);
                Güncelle.Parameters.AddWithValue("@p0", txtKimlik.Text);
                Güncelle.Parameters.AddWithValue("@p1", TxtAd.Text);
                Güncelle.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                Güncelle.Parameters.AddWithValue("@p3", DtpTarih.Text);
                Güncelle.Parameters.AddWithValue("@p4", MskMaas.Text);
                Güncelle.Parameters.AddWithValue("@p5", MskTel.Text);

                try
                {
                    baglanti.Open();
                    Güncelle.ExecuteNonQuery();
                    MessageBox.Show("Personel bilgisi güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    PersoneListesi();
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

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            // Geri alınamaycak bir işlemdir. Silme işlemi için önce soruyoruz
            // evet derse siliyor hayır derse iptal ediyoruz
            DialogResult dialogSil = MessageBox.Show(TxtAd.Text
                + " " + TxtSoyad.Text +
                " Personel Kaydı silinecek emin misiniz?",
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
                    MessageBox.Show(TxtAd.Text + " " + TxtSoyad.Text + " Adlı personel kaydı silindi",
                        "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    baglanti.Close();
                    PersoneListesi();
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

        private void btnListele_Click_1(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void dataPersonel_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataPersonel.SelectedCells[0].RowIndex;

            // Kimlik değerini TextBox'e atadım
            txtKimlik.Text = dataPersonel.Rows[secilen].Cells[0].Value.ToString();

            // Diğer sütunlara eriştim
            TxtAd.Text = dataPersonel.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataPersonel.Rows[secilen].Cells[2].Value.ToString();
            // Tarih değerini alıp dönüştürdüm
            string tarihStr = dataPersonel.Rows[secilen].Cells[3].Value.ToString();
            DateTime tarih;
            if (DateTime.TryParse(tarihStr, out tarih))
            {
                DtpTarih.Value = tarih;
            }
            else
            {
                // Hata durumunda varsayılan bir tarih değeri atayabiliriz
                DtpTarih.Value = DateTime.Now; // veya farklı bir varsayılan değer
            }
            MskMaas.Text = dataPersonel.Rows[secilen].Cells[4].Value.ToString();
            MskTel.Text = dataPersonel.Rows[secilen].Cells[5].Value.ToString();
        }

        private void AramaYap(string txtAra)
        {
            string query = "SELECT * FROM tblPersonel WHERE 1=1";
            if (!string.IsNullOrEmpty(txtAra.Trim()))
            {
                query += " AND Trim(Ad) LIKE ?";
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
            AramaYap(txtAra.Text);
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
