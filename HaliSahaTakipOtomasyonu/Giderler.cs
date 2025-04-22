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
    public partial class Giderler : Form
    {
        public Giderler()
        {
            InitializeComponent();
        }

        static string baglanti = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HaliSaha.mdb;");

        void listele()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(baglanti))
                {
                    connection.Open(); // Bağlantıyı aç
                    OleDbCommand komut = new OleDbCommand("SELECT * FROM tblGiderler", connection); // SQL sorgusu
                    OleDbDataAdapter da = new OleDbDataAdapter(komut); // Veri adaptörü
                    DataTable tablo = new DataTable(); // Veri tablosu
                    da.Fill(tablo); // Veriyi doldur
                    dataGridView1.DataSource = tablo; // Datagridviewe veri ata
                }
            }
            catch (Exception Hata)
            {
                MessageBox.Show("Hata: " + Hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error); // Hata mesajı göster
            }
        }

        // Veri tabanındaki gider listesini getirme işlevi
        void GiderListesi()
        {
            using (OleDbConnection connection = new OleDbConnection(baglanti))
            {
                connection.Open(); // Bağlantıyı aç
                OleDbCommand GiderListe = new OleDbCommand("SELECT * FROM tblGiderler", connection); // SQL sorgusu
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(GiderListe); // Veri adaptörü
                DataTable dataTable = new DataTable(); // Veri tablosu
                dataAdapter.Fill(dataTable); // Veriyi doldur
                dataGridView1.DataSource = dataTable; // DataGridView'e veri ata
            }
        }

        // Form üzerindeki Textboxları temizleme işlevi
        void Temizle()
        {
            TxtCim.Clear();
            TxtDolgaz.Clear();
            TxtElektirik.Clear();
            TxtForma.Clear();
            TxtKira.Clear();
            TxtSu.Clear();
            TxtTop.Clear();
            CmbAy.Text = "";
            TxtMaas.Clear();
        }


        private void Giderler_Load(object sender, EventArgs e)
        {
            GiderListesi();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(baglanti))
                {
                    connection.Open(); // Bağlantıyı aç
                    OleDbCommand Kayıt = new OleDbCommand("INSERT INTO tblGiderler (Elektrik, Su, Dogalgaz, Cim, FutbolTop, Forma, Kira, Yil, Ay, P_Maas, Tutar) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11)", connection);
                    // Parametreler ekle
                    Kayıt.Parameters.AddWithValue("@p1", TxtElektirik.Text);
                    Kayıt.Parameters.AddWithValue("@p2", TxtSu.Text);
                    Kayıt.Parameters.AddWithValue("@p3", TxtDolgaz.Text);
                    Kayıt.Parameters.AddWithValue("@p4", TxtCim.Text);
                    Kayıt.Parameters.AddWithValue("@p5", TxtTop.Text);
                    Kayıt.Parameters.AddWithValue("@p6", TxtForma.Text);
                    Kayıt.Parameters.AddWithValue("@p7", TxtKira.Text);
                    Kayıt.Parameters.AddWithValue("@p8", dateTimePicker1.Value.Year); // Yıl bilgisini al
                    Kayıt.Parameters.AddWithValue("@p9", dateTimePicker1.Value.ToString("MMMM")); // Ay bilgisini isim olarak al
                    Kayıt.Parameters.AddWithValue("@p10", TxtMaas.Text);

                    // Tutar hesaplama
                    decimal toplamTutar = Convert.ToDecimal(TxtElektirik.Text) + Convert.ToDecimal(TxtSu.Text) + Convert.ToDecimal(TxtDolgaz.Text) + Convert.ToDecimal(TxtCim.Text) + Convert.ToDecimal(TxtTop.Text) + Convert.ToDecimal(TxtForma.Text) + Convert.ToDecimal(TxtKira.Text) + Convert.ToDecimal(TxtMaas.Text);
                    Kayıt.Parameters.AddWithValue("@p11", toplamTutar); // Toplam tutar parametresi ekleme

                    Kayıt.ExecuteNonQuery(); // Sorguyu çalıştır
                    MessageBox.Show("Kayıt Başarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // Başarılı mesajı

                    Temizle(); // Formu temizle
                    GiderListesi(); // Gider listesini güncelle
                    listele(); // Kayıtları listele
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt yapılamadı: " + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error); // Hata mesajı
            }
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(baglanti))
                {
                    connection.Open(); // Bağlantıyı aç
                    OleDbCommand guncel = new OleDbCommand("UPDATE tblGiderler SET Elektrik=@p1, Su=@p2, Dogalgaz=@p3, Cim=@p4, FutbolTop=@p5, Forma=@p6, Kira=@p7, P_Maas=@p8, Yil=@p9, Ay=@p10, Tutar=@p11 WHERE Kimlik=@p12", connection);
                    // Parametreler ekleniyor
                    guncel.Parameters.AddWithValue("@p1", Convert.ToDecimal(TxtElektirik.Text));
                    guncel.Parameters.AddWithValue("@p2", Convert.ToDecimal(TxtSu.Text));
                    guncel.Parameters.AddWithValue("@p3", Convert.ToDecimal(TxtDolgaz.Text));
                    guncel.Parameters.AddWithValue("@p4", Convert.ToDecimal(TxtCim.Text));
                    guncel.Parameters.AddWithValue("@p5", Convert.ToDecimal(TxtTop.Text));
                    guncel.Parameters.AddWithValue("@p6", Convert.ToDecimal(TxtForma.Text));
                    guncel.Parameters.AddWithValue("@p7", Convert.ToDecimal(TxtKira.Text));
                    guncel.Parameters.AddWithValue("@p8", Convert.ToDecimal(TxtMaas.Text));
                    guncel.Parameters.AddWithValue("@p9", dateTimePicker1.Value.Year); // Yıl bilgisi
                    guncel.Parameters.AddWithValue("@p10", dateTimePicker1.Value.ToString("MMMM")); // Ay bilgisi isim olarak

                    // Tutar hesaplama
                    decimal toplamTutar = Convert.ToDecimal(TxtElektirik.Text) + Convert.ToDecimal(TxtSu.Text) + Convert.ToDecimal(TxtDolgaz.Text) + Convert.ToDecimal(TxtCim.Text) + Convert.ToDecimal(TxtTop.Text) + Convert.ToDecimal(TxtForma.Text) + Convert.ToDecimal(TxtKira.Text) + Convert.ToDecimal(TxtMaas.Text);
                    guncel.Parameters.AddWithValue("@p11", toplamTutar); // Toplam tutar parametresi

                    guncel.Parameters.AddWithValue("@p12", dataGridView1.CurrentRow.Cells["Kimlik"].Value.ToString()); // Kimlik parametresi
                    guncel.ExecuteNonQuery(); // Sorguyu çalıştır
                    MessageBox.Show("Kayıt Güncellendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // Başarılı mesajı

                    GiderListesi(); // Gider listesini güncelle
                    listele(); // Kayıtları listele
                    Temizle(); // Formu temizle
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme işlemi gerçekleştirilemedi: " + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error); // Hata mesajı
            }
        }

        // KAyıtları listeleme butonu
        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
            GiderListesi();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçili satırın Kimlik değerini alıyoruzz
                string kimlik = dataGridView1.SelectedRows[0].Cells["Kimlik"].Value.ToString();

                // Silme işlemi
                try
                {
                    using (OleDbConnection connection = new OleDbConnection(baglanti))
                    {
                        connection.Open();
                        OleDbCommand komut = new OleDbCommand("DELETE FROM tblGiderler WHERE Kimlik=@p1", connection);
                        komut.Parameters.AddWithValue("@p1", kimlik);
                        komut.ExecuteNonQuery();

                        MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Veri listesini güncelle
                        GiderListesi();
                        listele();
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata: " + hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz kaydı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Seçili satırın verilerini textbox'lara yerleştir
                TxtElektirik.Text = row.Cells["Elektrik"].Value.ToString();
                TxtSu.Text = row.Cells["Su"].Value.ToString();
                TxtDolgaz.Text = row.Cells["Dogalgaz"].Value.ToString();
                TxtCim.Text = row.Cells["Cim"].Value.ToString();
                TxtTop.Text = row.Cells["FutbolTop"].Value.ToString();
                TxtForma.Text = row.Cells["Forma"].Value.ToString();
                TxtKira.Text = row.Cells["Kira"].Value.ToString();
                TxtMaas.Text = row.Cells["P_Maas"].Value.ToString();
                dateTimePicker1.Value = new DateTime(Convert.ToInt32(row.Cells["Yil"].Value), Convert.ToInt32(row.Cells["Ay"].Value), 1); // Yıl ve Ay bilgisini DateTimePicker'a yükleme
                label9.Text = row.Cells["Tutar"].Value.ToString(); // Tutarı label'a yükleme
            }

        }
    }
}
