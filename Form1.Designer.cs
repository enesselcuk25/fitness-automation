namespace spor_salonu_projesi
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.adminGirişToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminGirişiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.adminGirişToolStripMenuItem,
            this.adminGirişiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1028, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(91, 24);
            this.toolStripMenuItem1.Text = "Kayıt ol";
            this.toolStripMenuItem1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // adminGirişToolStripMenuItem
            // 
            this.adminGirişToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("adminGirişToolStripMenuItem.Image")));
            this.adminGirişToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.adminGirişToolStripMenuItem.Name = "adminGirişToolStripMenuItem";
            this.adminGirişToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.adminGirişToolStripMenuItem.Text = " Giriş Yap";
            this.adminGirişToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.adminGirişToolStripMenuItem.Click += new System.EventHandler(this.adminGirişToolStripMenuItem_Click);
            // 
            // adminGirişiToolStripMenuItem
            // 
            this.adminGirişiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("adminGirişiToolStripMenuItem.Image")));
            this.adminGirişiToolStripMenuItem.Name = "adminGirişiToolStripMenuItem";
            this.adminGirişiToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.adminGirişiToolStripMenuItem.Text = "Admin Girişi";
            this.adminGirişiToolStripMenuItem.Click += new System.EventHandler(this.adminGirişiToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ANA MENÜ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem adminGirişToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminGirişiToolStripMenuItem;
    }
}

