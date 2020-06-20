namespace SortComparison
{
    partial class frmMain
    {
        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            this.cbAlg1 = new System.Windows.Forms.ComboBox();
            this.cbAlg2 = new System.Windows.Forms.ComboBox();
            this.butonSort = new System.Windows.Forms.Button();
            this.pbSort1 = new System.Windows.Forms.PictureBox();
            this.pbSort2 = new System.Windows.Forms.PictureBox();
            this.tbDiziBuyukluk = new System.Windows.Forms.TrackBar();
            this.lblGosterim = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHiz = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAlg1CalismaSuresi = new System.Windows.Forms.Label();
            this.lblAlg2CalismaSuresi = new System.Windows.Forms.Label();
            this.cbDiziTipleri = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSort1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSort2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDiziBuyukluk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbHiz)).BeginInit();
            this.SuspendLayout();
            // 
            // ComboBox Algoritma1
            // 
            this.cbAlg1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbAlg1.FormattingEnabled = true;
            this.cbAlg1.Items.AddRange(new object[] {
            "",
            "Counting Sort", 
            "Selection Sort"});
            this.cbAlg1.Location = new System.Drawing.Point(13, 220);
            this.cbAlg1.Name = "cbAlg1";
            this.cbAlg1.Size = new System.Drawing.Size(200, 21);
            this.cbAlg1.TabIndex = 2;
            this.cbAlg1.SelectedIndexChanged += new System.EventHandler(cbAlg1_SelectedIndexChanged);
            // 
            // ComboBox Algoritma2
            // 
            this.cbAlg2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbAlg2.FormattingEnabled = true;
            this.cbAlg2.Items.AddRange(new object[] {
            "",
            "Counting Sort",
            "Selection Sort"});
            this.cbAlg2.Location = new System.Drawing.Point(219, 220);
            this.cbAlg2.Name = "cbAlg2";
            this.cbAlg2.Size = new System.Drawing.Size(200, 21);
            this.cbAlg2.TabIndex = 3;
            this.cbAlg2.SelectedIndexChanged += new System.EventHandler(cbAlg2_SelectedIndexChanged);
            // 
            // Sıralama Butonu
            // 
            this.butonSort.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butonSort.Location = new System.Drawing.Point(344, 257);
            this.butonSort.Name = "butonSort";
            this.butonSort.Size = new System.Drawing.Size(75, 23);
            this.butonSort.TabIndex = 5;
            this.butonSort.Text = "Sırala";
            this.butonSort.UseVisualStyleBackColor = true;
            this.butonSort.Click += new System.EventHandler(this.butonSort_click);
            // 
            // pbSort1
            // 
            this.pbSort1.BackColor = System.Drawing.Color.White;
            this.pbSort1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSort1.Location = new System.Drawing.Point(13, 12);
            this.pbSort1.Name = "pbSort1";
            this.pbSort1.Size = new System.Drawing.Size(200, 200);
            this.pbSort1.TabIndex = 6;
            this.pbSort1.TabStop = false;
            // 
            // pbSort2
            // 
            this.pbSort2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbSort2.BackColor = System.Drawing.Color.White;
            this.pbSort2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSort2.Location = new System.Drawing.Point(219, 12);
            this.pbSort2.Name = "pbSort2";
            this.pbSort2.Size = new System.Drawing.Size(200, 200);
            this.pbSort2.TabIndex = 7;
            this.pbSort2.TabStop = false;
            // 
            // trackBar Dizi Büyüklüğü 
            // 
            this.tbDiziBuyukluk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbDiziBuyukluk.LargeChange = 10;
            this.tbDiziBuyukluk.Location = new System.Drawing.Point(137, 257);
            this.tbDiziBuyukluk.Maximum = 1000;
            this.tbDiziBuyukluk.Minimum = 10;
            this.tbDiziBuyukluk.Name = "tbDiziBuyukluk";
            this.tbDiziBuyukluk.Size = new System.Drawing.Size(120, 45);
            this.tbDiziBuyukluk.TabIndex = 8;
            this.tbDiziBuyukluk.TickFrequency = 100;
            this.tbDiziBuyukluk.Value = 100;
            this.tbDiziBuyukluk.Scroll += new System.EventHandler(this.diziBuyukluk_ayarla);
            // 
            // lblGosterim
            // 
            this.lblGosterim.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblGosterim.AutoSize = true;
            this.lblGosterim.Location = new System.Drawing.Point(10, 257);
            this.lblGosterim.Name = "lblGosterim";
            this.lblGosterim.Size = new System.Drawing.Size(121, 13);
            this.lblGosterim.TabIndex = 9;
            this.lblGosterim.Text = "Dizilerin Büyüklüğü:100";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Gösterim Hızı:";
            // 
            // tbSpeed
            // 
            this.tbHiz.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbHiz.Location = new System.Drawing.Point(137, 289);
            this.tbHiz.Maximum = 20;
            this.tbHiz.Minimum = 1;
            this.tbHiz.Name = "tbHiz";
            this.tbHiz.Size = new System.Drawing.Size(120, 45);
            this.tbHiz.TabIndex = 11;
            this.tbHiz.Value = 7;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Min";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Max";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(010, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Algoritma 1 Çalışma Süresi:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Algoritma 2 Çalışma Süresi:";
            //
            // lblAlg1CalismaSuresi
            // 
            this.lblAlg1CalismaSuresi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblAlg1CalismaSuresi.AutoSize = true;
            this.lblAlg1CalismaSuresi.Location = new System.Drawing.Point(140, 330);
            this.lblAlg1CalismaSuresi.Name = "lblAlg1CalismaSuresi";
            this.lblAlg1CalismaSuresi.Size = new System.Drawing.Size(27, 13);
            this.lblAlg1CalismaSuresi.TabIndex = 16;
            this.lblAlg1CalismaSuresi.Text = "";
            //
            // lblAlg2CalismaSuresi
            // 
            this.lblAlg2CalismaSuresi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblAlg2CalismaSuresi.AutoSize = true;
            this.lblAlg2CalismaSuresi.Location = new System.Drawing.Point(350, 330);
            this.lblAlg2CalismaSuresi.Name = "lblAlg2CalismaSuresi";
            this.lblAlg2CalismaSuresi.Size = new System.Drawing.Size(27, 13);
            this.lblAlg2CalismaSuresi.TabIndex = 17;
            this.lblAlg2CalismaSuresi.Text = "";
            //
            // comboBox Dizi Tipleri
            // 
            this.cbDiziTipleri.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbDiziTipleri.FormattingEnabled = true;
            this.cbDiziTipleri.Items.AddRange(new object[] {
            "Rastgele",
            "Tersten Sıralı",
            "Sıralı"});
            this.cbDiziTipleri.Location = new System.Drawing.Point(255, 257);
            this.cbDiziTipleri.Name = "cbDiziTipleri";
            this.cbDiziTipleri.Size = new System.Drawing.Size(83, 21);
            this.cbDiziTipleri.TabIndex = 34;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 348);
            this.Controls.Add(this.lblAlg2CalismaSuresi);
            this.Controls.Add(this.lblAlg1CalismaSuresi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbDiziTipleri);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbHiz);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGosterim);
            this.Controls.Add(this.tbDiziBuyukluk);
            this.Controls.Add(this.pbSort2);
            this.Controls.Add(this.butonSort);
            this.Controls.Add(this.cbAlg2);
            this.Controls.Add(this.cbAlg1);
            this.Controls.Add(this.pbSort1);
            this.MaximumSize = new System.Drawing.Size(10000, 10000);
            this.MinimumSize = new System.Drawing.Size(450, 386);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sıralama Algoritmalarının Karşılaştırılması";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbSort1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSort2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDiziBuyukluk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbHiz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        
        private System.Windows.Forms.ComboBox cbAlg1;
        private System.Windows.Forms.ComboBox cbAlg2;
        private System.Windows.Forms.Button butonSort;
        private System.Windows.Forms.PictureBox pbSort1;
        private System.Windows.Forms.PictureBox pbSort2;
        private System.Windows.Forms.TrackBar tbDiziBuyukluk;
        private System.Windows.Forms.Label lblGosterim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbHiz;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAlg1CalismaSuresi;
        private System.Windows.Forms.Label lblAlg2CalismaSuresi;
        private System.Windows.Forms.ComboBox cbDiziTipleri;
    }
}

