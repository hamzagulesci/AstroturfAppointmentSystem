using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaliSahaTakipOtomasyonu
{
    public partial class Rendevuİslemleri : Form
    {
        public Rendevuİslemleri()
        {
            InitializeComponent();
        }

        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HaliSaha.mdb";


        private void RendevuListesi()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT * FROM tblRendevu";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    LblRabdevuId.DataSource = dataTable;
                }
            }
        }

        private void GünlereLilstele()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT * FROM tblRendevu WHERE Gunler = @Gunler";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Gunler", CmbGun.Text);
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        LblRabdevuId.DataSource = dataTable;
                    }
                }
            }
        }

        private void TxtTemizle()
        {
            CmbGun.Text = "";
            TxtSaat1.Text = "";
            TxtSaat2.Text = "";
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "INSERT INTO tblRendevu (Gunler, Saatler, RendevuDurum) VALUES (@Gunler, @Saatler, @RandevuDurum)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Gunler", CmbGun.Text);
                    command.Parameters.AddWithValue("@Saatler", TxtSaat1.Text + " - " + TxtSaat2.Text);
                    command.Parameters.AddWithValue("@RendevuDurum", false);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show($"{CmbGun.Text} gününe {TxtSaat1.Text}-{TxtSaat2.Text} saatli rendevu eklenmiştir", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CmbGun.Text = "";
                        TxtTemizle();
                        RendevuListesi();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Kayıt eklenemedi: {ex.Message}", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"{RandevuGun} {RandevuSaat} rendevu silinsin mi?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "DELETE FROM tblRendevu WHERE Kimlik = @Kimlik";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Kimlik", randevuID);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Kayıt Silindi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CmbGun.Text = "";
                            RendevuListesi();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Kayıt Silinemedi: {ex.Message}", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Kayıt Silinmedi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Rendevuİslemleri_Load(object sender, EventArgs e)
        {
            RendevuListesi();
        }


        string RandevuSaat;
        string RandevuGun;
        string randevuID = "0";

        private void LblRabdevuId_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
        if (rowIndex >= 0 && rowIndex < LblRabdevuId.Rows.Count)
        {
            randevuID = LblRabdevuId.Rows[rowIndex].Cells[0].Value.ToString();
            RandevuGun = LblRabdevuId.Rows[rowIndex].Cells[1].Value.ToString();
            RandevuSaat = LblRabdevuId.Rows[rowIndex].Cells[2].Value.ToString();
            LblRandevuId.Text = randevuID;
        }

        }

        private void CmbGun_SelectedIndexChanged(object sender, EventArgs e)
        {
            GünlereLilstele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            TxtTemizle();
        }
    }
}
