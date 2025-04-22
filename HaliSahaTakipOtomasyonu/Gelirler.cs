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
    public partial class Gelirler : Form
    {
        public Gelirler()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HaliSaha.mdb");

        void Temizle()
        {
            TxtTutar.Text = "00TL";
            TxtSu.Text = "0";
            Txtsat3.Text = "0";
            TxtSat2.Text = "0";
            Txtsat1.Text = "0";
            TxtKola.Text = "0";
            Txtkira3.Text = "0";
            Txtkira2.Text = "0";
            Txtkira1.Text = "0";
            Txtcikolata.Text = "0";
            TxtSaha.Text = "0";
        }
        void listele()
        {
            try
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("SELECT * FROM tblGelirler", baglanti);
                OleDbDataAdapter da = new OleDbDataAdapter(komut);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            catch (Exception Hata)
            {
                MessageBox.Show("Hata: " + Hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }
        void GelirListe()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                // dateTimePicker1'den sadece tarih kısmını alıyoruz
                DateTime selectedDate = dateTimePicker1.Value.Date;

                // Sonraki günün başlangıcı
                DateTime nextDay = selectedDate.AddDays(1);

                // Sorgu parametrelerini güncelleyerek tarih aralığı kullanıyoruz
                OleDbCommand komut = new OleDbCommand("SELECT * FROM tblGelirler WHERE Tarih >= ? AND Tarih < ?", baglanti);
                komut.Parameters.Add(new OleDbParameter("@p1", OleDbType.Date)).Value = selectedDate;
                komut.Parameters.Add(new OleDbParameter("@p2", OleDbType.Date)).Value = nextDay;

                OleDbDataAdapter da = new OleDbDataAdapter(komut);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }
        void KayıtliRandevuLİste()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("SELECT Kimlik, RandevuTarih, RandevuGun, UcretDurum, Ucret FROM tblRandevuKayit", baglanti);
            //komut.Parameters.AddWithValue("@p1", dateTimePicker1.Value.ToString());
            OleDbDataAdapter da = new OleDbDataAdapter(komut);
            DataTable tablo0 = new DataTable();
            da.Fill(tablo0);
            dataGridView2.DataSource = tablo0;
            baglanti.Close();
            randevuRenk();
        }

        string randevuKimlik;
        string UcretDurum;
        void DurumGuncel()
        {
            if (UcretDurum == "False")
            {
                try
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }

                    OleDbCommand DurumGuncel = new OleDbCommand("UPDATE tblRendevuKayit SET UcretDurum='True' WHERE Kimlik=?", baglanti);
                    DurumGuncel.Parameters.AddWithValue("@p1", randevuKimlik);
                    DurumGuncel.ExecuteNonQuery();
                }
                catch (Exception HATA)
                {
                    MessageBox.Show("HATA: " + HATA.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Randevu ücreti daha önce alınmıştır.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        void randevuRenk()
        {
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();

                bool deger;
                if (bool.TryParse(dataGridView2.Rows[i].Cells[3].Value.ToString(), out deger))
                {
                    if (deger == false)
                    {
                        renk.BackColor = Color.Red;
                        renk.ForeColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        renk.BackColor = Color.Green;
                        renk.ForeColor = Color.Black;
                    }
                }
                else
                {
                    // Eğer değer bir boolean değilse, varsayılan renk ayarları uygulayabilirsiniz veya hata mesajı gösterebilirsiniz.
                    renk.BackColor = Color.Yellow; // Örneğin, bilinmeyen değerler için sarı renk kullanabilirsiniz.
                    renk.ForeColor = Color.Black;
                }

                dataGridView2.Rows[i].DefaultCellStyle = renk;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int aktar = dataGridView2.SelectedCells[0].RowIndex;
                randevuKimlik = dataGridView2.Rows[aktar].Cells[0].Value.ToString();
                TxtSaha.Text = dataGridView2.Rows[aktar].Cells[4].Value.ToString();
                UcretDurum = dataGridView2.Rows[aktar].Cells[3].Value.ToString();
            }
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            double top = 0;
            int su = Convert.ToInt16(TxtSu.Text);
            int kola = Convert.ToInt16(TxtKola.Text);
            int cikolata = Convert.ToInt16(Txtcikolata.Text);
            int kıra1 = Convert.ToInt16(Txtkira1.Text);
            int kıra2 = Convert.ToInt16(Txtkira2.Text);
            int kıra3 = Convert.ToInt16(Txtkira3.Text);
            int sat1 = Convert.ToInt16(Txtsat1.Text);
            int sat2 = Convert.ToInt16(TxtSat2.Text);
            int sat3 = Convert.ToInt16(Txtsat3.Text);
            int saha = Convert.ToInt16(TxtSaha.Text);
            top = su * 2 + kola * 5 + cikolata * 5 + kıra1 * 20 + kıra2 * 20 + kıra3 * 20 + sat1 * 500 + sat2 * 900 + sat3 * 800 + saha * 1;
            TxtTutar.Text = top.ToString();
        }
        private void btnOnayla_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtTutar.Text) && !string.IsNullOrEmpty(dateTimePicker1.Text) || TxtSaha.Text != "0")
            {
                try
                {
                    baglanti.Open();
                    OleDbCommand Gelir = new OleDbCommand("INSERT INTO tblGelirler (Tarih, Su, Kola, Cikolata, Adidas_Kira, Puma_Kira, Nike_Kira, Adidas, Nike, Puma, SahaÜcreti, Tutar) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", baglanti);
                    Gelir.Parameters.AddWithValue("@p1", dateTimePicker1.Value);
                    Gelir.Parameters.AddWithValue("@p2", TxtSu.Text);
                    Gelir.Parameters.AddWithValue("@p3", TxtKola.Text);
                    Gelir.Parameters.AddWithValue("@p4", Txtcikolata.Text);
                    Gelir.Parameters.AddWithValue("@p5", Txtkira1.Text);
                    Gelir.Parameters.AddWithValue("@p6", Txtkira2.Text);
                    Gelir.Parameters.AddWithValue("@p7", Txtkira3.Text);
                    Gelir.Parameters.AddWithValue("@p8", Txtsat1.Text);
                    Gelir.Parameters.AddWithValue("@p9", TxtSat2.Text);
                    Gelir.Parameters.AddWithValue("@p10", Txtsat3.Text);
                    Gelir.Parameters.AddWithValue("@p11", TxtSaha.Text);
                    Gelir.Parameters.AddWithValue("@p12", TxtTutar.Text);
                    Gelir.ExecuteNonQuery();
                    MessageBox.Show("Başarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Temizle();
                    GelirListe();
                    KayıtliRandevuLİste();
                    DurumGuncel();
                    randevuRenk();
                    listele();
                }
                catch (Exception Hata)
                {
                    MessageBox.Show("Hata: " + Hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    baglanti.Close();
                }
            }
            else
            {
                MessageBox.Show("Tutar ve Tarih kısımları boş bırakılamaz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnSilme_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçili satırın Kimlik değerini alıyoruz
                string kimlik = dataGridView1.SelectedRows[0].Cells["Kimlik"].Value.ToString();

                // Silme işlemi
                try
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }

                    OleDbCommand komut = new OleDbCommand("DELETE FROM tblGelirler WHERE Kimlik=?", baglanti);
                    komut.Parameters.AddWithValue("@p1", kimlik);
                    komut.ExecuteNonQuery();

                    MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Veri listesini güncelle
                    GelirListe();
                    listele();
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata: " + hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz kaydı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Gelirler_Load(object sender, EventArgs e)
        {
            listele();
            GelirListe();
            KayıtliRandevuLİste();
            randevuRenk();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            GelirListe();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Seçili satırın verilerini textbox'lara yerleştir
                TxtSu.Text = row.Cells["Su"].Value.ToString();
                TxtKola.Text = row.Cells["Kola"].Value.ToString();
                Txtcikolata.Text = row.Cells["Cikolata"].Value.ToString();
                Txtkira1.Text = row.Cells["Adidas_Kira"].Value.ToString();
                Txtkira2.Text = row.Cells["Puma_Kira"].Value.ToString();
                Txtkira3.Text = row.Cells["Nike_Kira"].Value.ToString();
                Txtsat1.Text = row.Cells["Adidas"].Value.ToString();
                TxtSat2.Text = row.Cells["Nike"].Value.ToString();
                Txtsat3.Text = row.Cells["Puma"].Value.ToString();
                TxtSaha.Text = row.Cells["SahaÜcreti"].Value.ToString();
                TxtTutar.Text = row.Cells["Tutar"].Value.ToString();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string kimlik = dataGridView1.SelectedRows[0].Cells["Kimlik"].Value.ToString();

                try
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }

                    OleDbCommand komut = new OleDbCommand("UPDATE tblGelirler SET Su=?, Kola=?, Cikolata=?, Adidas_Kira=?, Puma_Kira=?, Nike_Kira=?, Adidas=?, Nike=?, Puma=?, SahaÜcreti=?, Tutar=? WHERE Kimlik=?", baglanti);
                    komut.Parameters.AddWithValue("@p1", TxtSu.Text);
                    komut.Parameters.AddWithValue("@p2", TxtKola.Text);
                    komut.Parameters.AddWithValue("@p3", Txtcikolata.Text);
                    komut.Parameters.AddWithValue("@p4", Txtkira1.Text);
                    komut.Parameters.AddWithValue("@p5", Txtkira2.Text);
                    komut.Parameters.AddWithValue("@p6", Txtkira3.Text);
                    komut.Parameters.AddWithValue("@p7", Txtsat1.Text);
                    komut.Parameters.AddWithValue("@p8", TxtSat2.Text);
                    komut.Parameters.AddWithValue("@p9", Txtsat3.Text);
                    komut.Parameters.AddWithValue("@p10", TxtSaha.Text);
                    komut.Parameters.AddWithValue("@p11", TxtTutar.Text);
                    komut.Parameters.AddWithValue("@p12", kimlik);

                    komut.ExecuteNonQuery();

                    MessageBox.Show("Kayıt başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GelirListe();
                    listele();
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata: " + hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz kaydı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
