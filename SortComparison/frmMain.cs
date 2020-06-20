using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace SortComparison
{
    public partial class frmMain : Form
    {
        Graphics g1;
        Graphics g2;
        ArrayList array1;
        ArrayList array2;
        Bitmap bmpsave1;
        Bitmap bmpsave2;

        int middleSpacer;
        int leftSpacer;
        int rightSpacer;
        int bottomSpacer;
        int topSpacer;

        static Random rand = new Random();

        Thread thread1;
        Thread thread2;

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbAlg1.SelectedIndex = cbAlg1.Items.IndexOf("Counting Sort");
            cbAlg2.SelectedIndex = cbAlg2.Items.IndexOf("Selection Sort");
            tbDiziBuyukluk.Value = 100;
            middleSpacer = pbSort2.Left - (pbSort1.Left + pbSort1.Width);
            leftSpacer = pbSort1.Left;
            rightSpacer = this.Width - (pbSort2.Left + pbSort2.Width);
            bottomSpacer = this.Height - (pbSort1.Top + pbSort1.Height);
            topSpacer = pbSort1.Top;
            cbDiziTipleri.SelectedIndex = cbDiziTipleri.Items.IndexOf("Rastgele");
        }

        public void Randomize(IList list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int swapIndex = rand.Next(i + 1);
                if (swapIndex != i)
                {
                    object tmp = list[swapIndex];
                    list[swapIndex] = list[i];
                    list[i] = tmp;
                }
            }
        }

        private void siralamaHazirlik()
        {
            resizeGraphics();

            bmpsave1 = new Bitmap(pbSort1.Width, pbSort1.Height);
            g1 = Graphics.FromImage(bmpsave1);

            bmpsave2 = new Bitmap(pbSort2.Width, pbSort2.Height);
            g2 = Graphics.FromImage(bmpsave2);

            pbSort1.Image = bmpsave1;
            pbSort2.Image = bmpsave2;

            array1 = new ArrayList(tbDiziBuyukluk.Value);
            array2 = new ArrayList(tbDiziBuyukluk.Value);
            for (int i = 0; i < array1.Capacity; i++)
            {
                int y = (int)((double)(i + 1) / array1.Capacity * pbSort1.Height);
                array1.Add(y);
            }
            Randomize(array1);

            array2 = (ArrayList)array1.Clone();
        }

        private void butonSort_click(object sender, EventArgs e)
        {
            if (thread1 != null)
            {
                thread1.Abort();
                thread1.Join();
            }
            if (thread2 != null)
            {
                thread2.Abort();
                thread2.Join();
            }

            siralamaHazirlik();

            if (cbDiziTipleri.SelectedItem.ToString() == "Rastgele")
            {
                // çalışmaya hazır, ek işleme gerek yok.
            }
            else if (cbDiziTipleri.SelectedItem.ToString() == "Sıralı")
            {
                array1.Sort();
                array2 = (ArrayList)array1.Clone();
            }

            else if (cbDiziTipleri.SelectedItem.ToString() == "Tersten Sıralı")
            {
                array1.Sort();
                array1.Reverse();

                array2 = (ArrayList)array1.Clone();
            }

            resizeGraphics();

            int speed = 1;
            for (int i = 0; i < tbHiz.Value; i++)
            {
                speed *= 2;
            }

            string alg1="";
            string alg2="";

            if(cbAlg1.SelectedItem!=null)
                alg1 = cbAlg1.SelectedItem.ToString();

            if(cbAlg2.SelectedItem!=null)
                alg2 = cbAlg2.SelectedItem.ToString();

            SortAlgorithm sa = new SortAlgorithm(array1, pbSort1,   speed);
            SortAlgorithm sa2 = new SortAlgorithm(array2, pbSort2,   speed);
            
            ThreadStart ts = delegate()
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                switch (alg1)
                {
                    case "Counting Sort":
                        sa.CountingSort(array1);
                        break;
                    case "Selection Sort":
                        sa.SelectionSort(array1);
                        break;
                }
                sa.cizimiBitir();
                watch.Stop();
                lblAlg1CalismaSuresi.Text = $"{ watch.ElapsedMilliseconds} ms";

                if (!dizi_siralandiMi(array1))
                    MessageBox.Show("#1 Sort Failed!");
            };

            ThreadStart ts2 = delegate()
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                switch (alg2)
                {
                    case "Counting Sort":
                        sa2.CountingSort(array2);
                        break;
                    case "Selection Sort":
                        sa2.SelectionSort(array2);
                        break;
                }
                sa2.cizimiBitir();
                watch.Stop();
                lblAlg2CalismaSuresi.Text = $"{ watch.ElapsedMilliseconds} ms";

                if (!dizi_siralandiMi(array2))
                    MessageBox.Show("#2 Sort Failed!");
            };

            if (alg1 != "")
            {
                thread1 = new Thread(ts);
                thread1.Start();
            }
            if (alg2 != "")
            {
                thread2 = new Thread(ts2);
                thread2.Start();
            }
        }

        private bool dizi_siralandiMi(IList checkThis)
        {
            for (int i = 0; i < checkThis.Count - 1; i++)
            {
                if (((IComparable)checkThis[i]).CompareTo(checkThis[i + 1]) > 0)
                    return false;
            }

            return true;
        }
        
        private void diziBuyukluk_ayarla(object sender, EventArgs e)
        {
            lblGosterim.Text = "Dizilerin Büyüklüğü: " + tbDiziBuyukluk.Value.ToString("n0");
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            resizeGraphics();
        }

        public void resizeGraphics()
        {
            // grafik size ayarlama.

            pbSort1.Height = this.Height - topSpacer - bottomSpacer;
            pbSort2.Height = pbSort1.Height;

            if (cbAlg2.SelectedItem == null || cbAlg2.SelectedItem.ToString().Trim() == "")
            {
                pbSort2.Left = this.Width + 1;
                pbSort1.Width = (this.Width - leftSpacer - rightSpacer);
                pbSort2.Width = pbSort1.Width;
            }
            else if (cbAlg1.SelectedItem == null || cbAlg1.SelectedItem.ToString().Trim() == "")
            {
                pbSort1.Left = this.Width + 1;
                pbSort1.Width = (this.Width - leftSpacer - rightSpacer);
                pbSort2.Width = pbSort1.Width;
                pbSort2.Left = leftSpacer;
            }
            else
            {
                pbSort1.Width = (this.Width - leftSpacer - rightSpacer - middleSpacer) / 2;
                pbSort2.Width = pbSort1.Width;

                pbSort1.Left = leftSpacer;
                pbSort2.Left = pbSort1.Left + pbSort1.Width + middleSpacer;
            }
        }

        public void cbAlg1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbAlg1.SelectedItem.ToString() == "Counting Sort")
            {
                // picturebox a resim atama.

                pbSort1.Load(@"..\\..\\..\\algoritmalar\\countingSortFull.JPG");
            }

            else if(cbAlg1.SelectedItem.ToString() == "Selection Sort")
            {
                pbSort1.Load(@"..\\..\\..\\algoritmalar\\selectionSortFull.JPG");
            }

            pbSort1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void cbAlg2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbAlg2.SelectedItem.ToString() == "Selection Sort")
            {
                // picturebox a resim atama.

                pbSort2.Load(@"..\\..\\..\\algoritmalar\\selectionSortFull.JPG");
                
                
            }

            else if (cbAlg2.SelectedItem.ToString() == "Counting Sort")
            {
                pbSort2.Load(@"..\\..\\..\\algoritmalar\\countingSortFull.JPG");
                
            }
            pbSort2.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }
    }
}
