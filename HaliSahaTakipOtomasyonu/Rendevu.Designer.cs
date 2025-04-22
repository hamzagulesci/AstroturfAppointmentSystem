namespace HaliSahaTakipOtomasyonu
{
    partial class Rendevu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label10 = new System.Windows.Forms.Label();
            this.CmbUcretDurum = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnRandevuIptal = new System.Windows.Forms.Button();
            this.CmbGun = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbTakimAdı2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.MskUcret = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbTakimAdı1 = new System.Windows.Forms.ComboBox();
            this.TxtMail = new System.Windows.Forms.TextBox();
            this.btnekle = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MskTel1 = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKimlik = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.MskTel2 = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.txtSaat = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.KayitTarihi = new System.Windows.Forms.DateTimePicker();
            this.RandevuTarihi = new System.Windows.Forms.DateTimePicker();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 321);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 18);
            this.label10.TabIndex = 87;
            this.label10.Text = "Randevu Tarih:";
            // 
            // CmbUcretDurum
            // 
            this.CmbUcretDurum.FormattingEnabled = true;
            this.CmbUcretDurum.Items.AddRange(new object[] {
            "Alındı",
            "Kapora"});
            this.CmbUcretDurum.Location = new System.Drawing.Point(155, 477);
            this.CmbUcretDurum.Name = "CmbUcretDurum";
            this.CmbUcretDurum.Size = new System.Drawing.Size(121, 21);
            this.CmbUcretDurum.TabIndex = 85;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 481);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 18);
            this.label7.TabIndex = 84;
            this.label7.Text = "Ücret Durum:";
            // 
            // BtnRandevuIptal
            // 
            this.BtnRandevuIptal.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnRandevuIptal.Location = new System.Drawing.Point(237, 565);
            this.BtnRandevuIptal.Name = "BtnRandevuIptal";
            this.BtnRandevuIptal.Size = new System.Drawing.Size(132, 30);
            this.BtnRandevuIptal.TabIndex = 11;
            this.BtnRandevuIptal.Text = "İptal Et";
            this.BtnRandevuIptal.UseVisualStyleBackColor = true;
            this.BtnRandevuIptal.Click += new System.EventHandler(this.BtnRandevuIptal_Click);
            // 
            // CmbGun
            // 
            this.CmbGun.FormattingEnabled = true;
            this.CmbGun.Items.AddRange(new object[] {
            "Pazartesi",
            "Salı",
            "Çarşamba",
            "Perşembe",
            "Cuma",
            "Cumartesi",
            "Pazar"});
            this.CmbGun.Location = new System.Drawing.Point(155, 355);
            this.CmbGun.Name = "CmbGun";
            this.CmbGun.Size = new System.Drawing.Size(193, 21);
            this.CmbGun.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 359);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 18);
            this.label9.TabIndex = 82;
            this.label9.Text = "Randevu Günü";
            // 
            // CmbTakimAdı2
            // 
            this.CmbTakimAdı2.FormattingEnabled = true;
            this.CmbTakimAdı2.Location = new System.Drawing.Point(155, 140);
            this.CmbTakimAdı2.Name = "CmbTakimAdı2";
            this.CmbTakimAdı2.Size = new System.Drawing.Size(193, 21);
            this.CmbTakimAdı2.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(43, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 18);
            this.label8.TabIndex = 80;
            this.label8.Text = "Takım Ad 2:";
            // 
            // MskUcret
            // 
            this.MskUcret.Location = new System.Drawing.Point(155, 437);
            this.MskUcret.Mask = "00000";
            this.MskUcret.Name = "MskUcret";
            this.MskUcret.Size = new System.Drawing.Size(36, 20);
            this.MskUcret.TabIndex = 8;
            this.MskUcret.Text = "40";
            this.MskUcret.ValidatingType = typeof(int);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(85, 441);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 18);
            this.label6.TabIndex = 76;
            this.label6.Text = "Ücret:";
            // 
            // CmbTakimAdı1
            // 
            this.CmbTakimAdı1.FormattingEnabled = true;
            this.CmbTakimAdı1.Location = new System.Drawing.Point(155, 59);
            this.CmbTakimAdı1.Name = "CmbTakimAdı1";
            this.CmbTakimAdı1.Size = new System.Drawing.Size(193, 21);
            this.CmbTakimAdı1.TabIndex = 1;
            // 
            // TxtMail
            // 
            this.TxtMail.Location = new System.Drawing.Point(155, 235);
            this.TxtMail.Name = "TxtMail";
            this.TxtMail.Size = new System.Drawing.Size(193, 20);
            this.TxtMail.TabIndex = 4;
            // 
            // btnekle
            // 
            this.btnekle.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnekle.Location = new System.Drawing.Point(237, 529);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(132, 30);
            this.btnekle.TabIndex = 9;
            this.btnekle.Text = "Randevu Al";
            this.btnekle.UseVisualStyleBackColor = true;
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 401);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 18);
            this.label5.TabIndex = 71;
            this.label5.Text = "Randevu Saati:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 18);
            this.label4.TabIndex = 70;
            this.label4.Text = "Kayıt Tarih:";
            // 
            // MskTel1
            // 
            this.MskTel1.Location = new System.Drawing.Point(155, 95);
            this.MskTel1.Mask = "(999) 000-0000";
            this.MskTel1.Name = "MskTel1";
            this.MskTel1.Size = new System.Drawing.Size(193, 20);
            this.MskTel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 68;
            this.label3.Text = "Mail Adresi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 36);
            this.label2.TabIndex = 67;
            this.label2.Text = "Takım Bir İrtibat\r\n          Numarası :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 66;
            this.label1.Text = "Takım Ad 1:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(404, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(869, 589);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RANDEVULAR";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(863, 570);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RandevuTarihi);
            this.groupBox1.Controls.Add(this.KayitTarihi);
            this.groupBox1.Controls.Add(this.txtKimlik);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.btnGuncelle);
            this.groupBox1.Controls.Add(this.MskTel2);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.btnTemizle);
            this.groupBox1.Controls.Add(this.txtSaat);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.CmbUcretDurum);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.BtnRandevuIptal);
            this.groupBox1.Controls.Add(this.CmbGun);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.CmbTakimAdı2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.MskUcret);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.CmbTakimAdı1);
            this.groupBox1.Controls.Add(this.TxtMail);
            this.groupBox1.Controls.Add(this.btnekle);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.MskTel1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 604);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            // 
            // txtKimlik
            // 
            this.txtKimlik.Location = new System.Drawing.Point(155, 33);
            this.txtKimlik.Name = "txtKimlik";
            this.txtKimlik.Size = new System.Drawing.Size(193, 20);
            this.txtKimlik.TabIndex = 93;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(40, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 18);
            this.label13.TabIndex = 94;
            this.label13.Text = "Kimlik :";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.Location = new System.Drawing.Point(99, 529);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(132, 30);
            this.btnGuncelle.TabIndex = 92;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // MskTel2
            // 
            this.MskTel2.Location = new System.Drawing.Point(155, 185);
            this.MskTel2.Mask = "(999) 000-0000";
            this.MskTel2.Name = "MskTel2";
            this.MskTel2.Size = new System.Drawing.Size(193, 20);
            this.MskTel2.TabIndex = 90;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(16, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 36);
            this.label12.TabIndex = 91;
            this.label12.Text = "Takım İki İrtibat\r\n          Numarası :";
            // 
            // btnTemizle
            // 
            this.btnTemizle.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Location = new System.Drawing.Point(99, 565);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(132, 30);
            this.btnTemizle.TabIndex = 89;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // txtSaat
            // 
            this.txtSaat.Location = new System.Drawing.Point(155, 399);
            this.txtSaat.Mask = "00:00";
            this.txtSaat.Name = "txtSaat";
            this.txtSaat.Size = new System.Drawing.Size(36, 20);
            this.txtSaat.TabIndex = 88;
            this.txtSaat.ValidatingType = typeof(System.DateTime);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(398, 54);
            this.label11.TabIndex = 90;
            this.label11.Text = "Ücretimiz dolar cinsinden alınmaktadır,\r\ntek bir sahamız mevcuttur ve 10 kişiye 1" +
    "0 kişiliktir.\r\nKapora ücretimiz 20 dolardır versiye yoktur.\r\n";
            // 
            // KayitTarihi
            // 
            this.KayitTarihi.Location = new System.Drawing.Point(155, 279);
            this.KayitTarihi.Name = "KayitTarihi";
            this.KayitTarihi.Size = new System.Drawing.Size(200, 20);
            this.KayitTarihi.TabIndex = 95;
            // 
            // RandevuTarihi
            // 
            this.RandevuTarihi.Location = new System.Drawing.Point(155, 321);
            this.RandevuTarihi.Name = "RandevuTarihi";
            this.RandevuTarihi.Size = new System.Drawing.Size(200, 20);
            this.RandevuTarihi.TabIndex = 96;
            // 
            // Rendevu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 635);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Rendevu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rendevu";
            this.Load += new System.EventHandler(this.Rendevu_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox CmbUcretDurum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnRandevuIptal;
        private System.Windows.Forms.ComboBox CmbGun;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CmbTakimAdı2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox MskUcret;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbTakimAdı1;
        private System.Windows.Forms.TextBox TxtMail;
        private System.Windows.Forms.Button btnekle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox MskTel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txtSaat;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.MaskedTextBox MskTel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.TextBox txtKimlik;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker RandevuTarihi;
        private System.Windows.Forms.DateTimePicker KayitTarihi;
    }
}