namespace HaliSahaTakipOtomasyonu
{
    partial class HesapOlustur
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
            this.btnGirisEkrani = new System.Windows.Forms.Button();
            this.btnHesabimiOlustur = new System.Windows.Forms.Button();
            this.txtTekrarSifre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGirisEkrani
            // 
            this.btnGirisEkrani.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGirisEkrani.Location = new System.Drawing.Point(66, 185);
            this.btnGirisEkrani.Name = "btnGirisEkrani";
            this.btnGirisEkrani.Size = new System.Drawing.Size(274, 37);
            this.btnGirisEkrani.TabIndex = 67;
            this.btnGirisEkrani.Text = "Giriş Ekranına Geri Dön";
            this.btnGirisEkrani.UseVisualStyleBackColor = true;
            this.btnGirisEkrani.Click += new System.EventHandler(this.btnGirisEkrani_Click);
            // 
            // btnHesabimiOlustur
            // 
            this.btnHesabimiOlustur.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHesabimiOlustur.Location = new System.Drawing.Point(138, 142);
            this.btnHesabimiOlustur.Name = "btnHesabimiOlustur";
            this.btnHesabimiOlustur.Size = new System.Drawing.Size(202, 37);
            this.btnHesabimiOlustur.TabIndex = 66;
            this.btnHesabimiOlustur.Text = "Hesabımı Oluştur";
            this.btnHesabimiOlustur.UseVisualStyleBackColor = true;
            this.btnHesabimiOlustur.Click += new System.EventHandler(this.btnHesabimiOlustur_Click);
            // 
            // txtTekrarSifre
            // 
            this.txtTekrarSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTekrarSifre.Location = new System.Drawing.Point(175, 100);
            this.txtTekrarSifre.Name = "txtTekrarSifre";
            this.txtTekrarSifre.Size = new System.Drawing.Size(165, 31);
            this.txtTekrarSifre.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(19, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 25);
            this.label3.TabIndex = 64;
            this.label3.Text = "Tekrar Şifre :";
            // 
            // txtSifre
            // 
            this.txtSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSifre.Location = new System.Drawing.Point(175, 56);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(165, 31);
            this.txtSifre.TabIndex = 63;
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKullaniciAdi.Location = new System.Drawing.Point(175, 12);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(165, 31);
            this.txtKullaniciAdi.TabIndex = 62;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(94, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 25);
            this.label2.TabIndex = 61;
            this.label2.Text = "Şifre :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 60;
            this.label1.Text = "Kullanıcı Adı :";
            // 
            // HesapOlustur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 238);
            this.Controls.Add(this.btnGirisEkrani);
            this.Controls.Add(this.btnHesabimiOlustur);
            this.Controls.Add(this.txtTekrarSifre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HesapOlustur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HesapOlustur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGirisEkrani;
        private System.Windows.Forms.Button btnHesabimiOlustur;
        private System.Windows.Forms.TextBox txtTekrarSifre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}