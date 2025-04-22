namespace HaliSahaTakipOtomasyonu
{
    partial class AdminPaneli
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gelirlerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.giderlerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.personelToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rANDEUİŞLEMLERİToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gelirlerToolStripMenuItem1,
            this.giderlerToolStripMenuItem1,
            this.personelToolStripMenuItem1,
            this.rANDEUİŞLEMLERİToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1278, 25);
            this.menuStrip1.TabIndex = 37;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gelirlerToolStripMenuItem1
            // 
            this.gelirlerToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gelirlerToolStripMenuItem1.Name = "gelirlerToolStripMenuItem1";
            this.gelirlerToolStripMenuItem1.Size = new System.Drawing.Size(65, 21);
            this.gelirlerToolStripMenuItem1.Text = "Gelirler";
            this.gelirlerToolStripMenuItem1.Click += new System.EventHandler(this.gelirlerToolStripMenuItem1_Click);
            // 
            // giderlerToolStripMenuItem1
            // 
            this.giderlerToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.giderlerToolStripMenuItem1.Name = "giderlerToolStripMenuItem1";
            this.giderlerToolStripMenuItem1.Size = new System.Drawing.Size(68, 21);
            this.giderlerToolStripMenuItem1.Text = "Giderler";
            this.giderlerToolStripMenuItem1.Click += new System.EventHandler(this.giderlerToolStripMenuItem1_Click);
            // 
            // personelToolStripMenuItem1
            // 
            this.personelToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.personelToolStripMenuItem1.Name = "personelToolStripMenuItem1";
            this.personelToolStripMenuItem1.Size = new System.Drawing.Size(75, 21);
            this.personelToolStripMenuItem1.Text = "Personel ";
            this.personelToolStripMenuItem1.Click += new System.EventHandler(this.personelToolStripMenuItem1_Click);
            // 
            // rANDEUİŞLEMLERİToolStripMenuItem
            // 
            this.rANDEUİŞLEMLERİToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rANDEUİŞLEMLERİToolStripMenuItem.Name = "rANDEUİŞLEMLERİToolStripMenuItem";
            this.rANDEUİŞLEMLERİToolStripMenuItem.Size = new System.Drawing.Size(72, 21);
            this.rANDEUİŞLEMLERİToolStripMenuItem.Text = "Rendevu";
            this.rANDEUİŞLEMLERİToolStripMenuItem.Click += new System.EventHandler(this.rANDEUİŞLEMLERİToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(89, 21);
            this.toolStripMenuItem1.Text = "Kullanicilar";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click_1);
            // 
            // AdminPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 592);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "AdminPaneli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminPaneli";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rANDEUİŞLEMLERİToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gelirlerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem giderlerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem personelToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}