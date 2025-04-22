using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaliSahaTakipOtomasyonu
{
    public partial class Rendevu : Form
    {
        public Rendevu()
        {
            InitializeComponent();
        }
        static string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HaliSaha.mdb";

        public string Kullanici;

        void Listele()
        {
            using (OleDbConnection baglanti = new OleDbConnection(connection))
            {
                baglanti.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter("select * from tblRandevuKayit", baglanti);
                DataSet ds = new DataSet();
                listele.Fill(ds, "tblRandevuKayit");
                dataGridView1.DataSource = ds.Tables["tblRandevuKayit"];
            }
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(CmbTakimAdı1.Text) &&
                    !string.IsNullOrWhiteSpace(CmbTakimAdı2.Text) &&
                    !string.IsNullOrWhiteSpace(MskTel1.Text) &&
                    !string.IsNullOrWhiteSpace(MskTel2.Text) &&
                    !string.IsNullOrWhiteSpace(TxtMail.Text) &&
                    !string.IsNullOrWhiteSpace(txtSaat.Text) &&
                    !string.IsNullOrWhiteSpace(MskUcret.Text) &&
                    !string.IsNullOrWhiteSpace(CmbUcretDurum.Text))
                {
                    using (OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HaliSaha.mdb;"))
                    {
                        baglanti.Open();

                        // Aynı gün ve saat kontrolü
                        string kontrolSorgu = "SELECT COUNT(*) FROM tblRandevuKayit WHERE RandevuTarih = @randevuTarih AND RandevuSaat = @randevuSaat";
                        OleDbCommand kontrolKomutu = new OleDbCommand(kontrolSorgu, baglanti);
                        kontrolKomutu.Parameters.AddWithValue("@randevuTarih", RandevuTarihi.Value.ToShortDateString());
                        kontrolKomutu.Parameters.AddWithValue("@randevuSaat", txtSaat.Text);

                        int count = (int)kontrolKomutu.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Aynı gün ve saatte başka bir randevu mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Randevu gününü almak için
                        string randevuGunu = RandevuTarihi.Value.ToString("dddd", new CultureInfo("tr-TR"));

                        OleDbCommand kayit = new OleDbCommand(
                            "INSERT INTO tblRandevuKayit (TakimAd1, TakimAd2, Irtibat1, Irtibat2, Mail, KayitTarih, RandevuTarih, RandevuGun, RandevuSaat, Ucret, UcretDurum) " +
                            "VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11)", baglanti);

                        kayit.Parameters.AddWithValue("@p1", CmbTakimAdı1.Text);
                        kayit.Parameters.AddWithValue("@p2", CmbTakimAdı2.Text);
                        kayit.Parameters.AddWithValue("@p3", MskTel1.Text);
                        kayit.Parameters.AddWithValue("@p4", MskTel2.Text);
                        kayit.Parameters.AddWithValue("@p5", TxtMail.Text);
                        kayit.Parameters.AddWithValue("@p6", KayitTarihi.Value.ToShortDateString());
                        kayit.Parameters.AddWithValue("@p7", RandevuTarihi.Value.ToShortDateString());
                        kayit.Parameters.AddWithValue("@p8", randevuGunu);

                        string saatFormati = "HH:mm";
                        DateTime saat;
                        if (!DateTime.TryParseExact(txtSaat.Text, saatFormati, CultureInfo.InvariantCulture, DateTimeStyles.None, out saat))
                        {
                            MessageBox.Show("Geçersiz saat formatı! Saat formatı " + saatFormati + " olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        kayit.Parameters.AddWithValue("@p9", txtSaat.Text);

                        decimal ucret;
                        if (!decimal.TryParse(MskUcret.Text, out ucret))
                        {
                            MessageBox.Show("Ücret alanı geçerli bir sayı olmalıdır.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        kayit.Parameters.AddWithValue("@p10", ucret);
                        kayit.Parameters.AddWithValue("@p11", CmbUcretDurum.Text);

                        kayit.ExecuteNonQuery();
                        MessageBox.Show("Kayıt oluşturulmuştur", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Listele();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bütün alanları doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri eklenirken bir hata oluştu: " + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKimlik.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            CmbTakimAdı1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            MskTel1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            CmbTakimAdı2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            MskTel2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            TxtMail.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            //DateTime tarih =Convert.ToDateTime( dataGridView1.CurrentRow.Cells[6].Value.ToString()).Date;
            //MessageBox.Show(tarih.ToString());
            //KayitTarihi.Value = tarih;
           // dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[6].Value.ToString());
            KayitTarihi.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[6].Value.ToString());

            RandevuTarihi.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[7].Value.ToString());
            CmbGun.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtSaat.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            MskUcret.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            CmbUcretDurum.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
        }

        private void BtnRandevuIptal_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçili satırın Kimlik değerini alıyoruz
                string kimlik = dataGridView1.SelectedRows[0].Cells["Kimlik"].Value.ToString();

                // Silme işlemi
                try
                {
                    using (OleDbConnection baglanti = new OleDbConnection(connection))
                    {
                        baglanti.Open();
                        OleDbCommand komut = new OleDbCommand("DELETE FROM tblRandevuKayit WHERE Kimlik=@p1", baglanti);
                        komut.Parameters.AddWithValue("@p1", kimlik);
                        komut.ExecuteNonQuery();

                        MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Veri listesini güncelle
                        Listele();
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata: " + hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz kaydı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Rendevu_Load(object sender, EventArgs e)
        {
            Listele();
            // KayitTarihi.MinDate = DateTime.Today;
            RandevuTarihi.MinDate = DateTime.Today;
        }

        void temizle()
        {
            CmbTakimAdı1.Text = "";
            CmbTakimAdı2.Text = "";
            MskTel1.Clear();
            TxtMail.Clear();
            KayitTarihi.Text = "";
            RandevuTarihi.Text = "";
            CmbGun.Text = "";
            txtSaat.Clear();
            MskUcret.Text = "";
            CmbUcretDurum.Text = "";
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }


        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtKimlik.Text) &&
                    !string.IsNullOrWhiteSpace(CmbTakimAdı1.Text) &&
                    !string.IsNullOrWhiteSpace(CmbTakimAdı2.Text) &&
                    !string.IsNullOrWhiteSpace(MskTel1.Text) &&
                    !string.IsNullOrWhiteSpace(MskTel2.Text) &&
                    !string.IsNullOrWhiteSpace(TxtMail.Text) &&
                    !string.IsNullOrWhiteSpace(txtSaat.Text) &&
                    !string.IsNullOrWhiteSpace(MskUcret.Text) &&
                    !string.IsNullOrWhiteSpace(CmbUcretDurum.Text))
                {
                    using (OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HaliSaha.mdb;"))
                    {
                        baglanti.Open();

                        // Randevu gününü almak için
                        string randevuGunu = RandevuTarihi.Value.ToString("dddd", new CultureInfo("tr-TR"));

                        // Güncelleme sorgusu
                        OleDbCommand guncelle = new OleDbCommand(
                            "UPDATE tblRandevuKayit SET TakimAd1 = @p1, TakimAd2 = @p2, Irtibat1 = @p3, Irtibat2 = @p4, Mail = @p5, " +
                            "KayitTarih = @p6, RandevuTarih = @p7, RandevuGun = @p8, RandevuSaat = @p9, Ucret = @p10, UcretDurum = @p11 " +
                            "WHERE Kimlik = @p12", baglanti);

                        guncelle.Parameters.AddWithValue("@p1", CmbTakimAdı1.Text);
                        guncelle.Parameters.AddWithValue("@p2", CmbTakimAdı2.Text);
                        guncelle.Parameters.AddWithValue("@p3", MskTel1.Text);
                        guncelle.Parameters.AddWithValue("@p4", MskTel2.Text);
                        guncelle.Parameters.AddWithValue("@p5", TxtMail.Text);
                        guncelle.Parameters.AddWithValue("@p6", KayitTarihi.Value.ToShortDateString());
                        guncelle.Parameters.AddWithValue("@p7", RandevuTarihi.Value.ToShortDateString());
                        guncelle.Parameters.AddWithValue("@p8", randevuGunu);

                        string saatFormati = "HH:mm";
                        DateTime saat;
                        if (!DateTime.TryParseExact(txtSaat.Text, saatFormati, CultureInfo.InvariantCulture, DateTimeStyles.None, out saat))
                        {
                            MessageBox.Show("Geçersiz saat formatı! Saat formatı " + saatFormati + " olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        guncelle.Parameters.AddWithValue("@p9", txtSaat.Text);

                        decimal ucret;
                        if (!decimal.TryParse(MskUcret.Text, out ucret))
                        {
                            MessageBox.Show("Ücret alanı geçerli bir sayı olmalıdır.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        guncelle.Parameters.AddWithValue("@p10", ucret);
                        guncelle.Parameters.AddWithValue("@p11", CmbUcretDurum.Text);

                        // Güncellenecek kaydın Kimlik değerini ekleyin
                        int kimlik;
                        if (!int.TryParse(txtKimlik.Text, out kimlik))
                        {
                            MessageBox.Show("Geçersiz Kimlik değeri!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        guncelle.Parameters.AddWithValue("@p12", kimlik);

                        guncelle.ExecuteNonQuery();
                        MessageBox.Show("Kayıt güncellenmiştir", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Listele();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bütün alanları doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri güncellenirken bir hata oluştu: " + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
