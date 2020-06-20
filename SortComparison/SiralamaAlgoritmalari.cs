
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SortComparison
{
    public class SortAlgorithm
    {
        ArrayList siralanacakDizi;
        Graphics g;
        Bitmap bitmap;
        PictureBox diziGosterimEkrani;


        int kareBasinaIslemSayisi; 
        int frameMS; // iki kare arasındaki zaman farkı 
        int islemSayac;
        Dictionary<int, bool> gosterimdeBelirtilenIndisler = new Dictionary<int, bool>(); // framede bu indisleri özel olarak belirteceğiz.
        DateTime sonrakiKareZamani;
        int standartPanelYukseklik;

        Random rand = new Random();

        public SortAlgorithm(ArrayList dizi, PictureBox pic,  int s)
        {
            siralanacakDizi = dizi;
            diziGosterimEkrani = pic;
            islemSayac = 0;
            kareBasinaIslemSayisi = s;
            frameMS = 1000; // saniyedeki işlem sayısı için kullanılacak parametre

            // frame bekleme süresini azaltarak daha iyi izleme deneyimi sağlama (arttırılmış frame hızı)
            while (frameMS >= 40 && kareBasinaIslemSayisi > 1)
            {
                kareBasinaIslemSayisi = kareBasinaIslemSayisi / 2;
                frameMS = frameMS / 2;
            }

            bitmap = new Bitmap(diziGosterimEkrani.Width, diziGosterimEkrani.Height);
            g = Graphics.FromImage(bitmap);
            standartPanelYukseklik = diziGosterimEkrani.Height;
            diziGosterimEkrani.Image = bitmap;
            sonrakiKareZamani = DateTime.UtcNow;

            frameKontrolEt();
        }

        //Gerçekten çok hızlı çalışıyor fakat hafızada k büyüklüğünde veri tutması gerekiyor.Bu k, n elemana sahip dizinin içindeki en büyük elemana bağlı olarak değişir.
        public IList CountingSort(IList siralanacakDizi)
        {
            object min = null;
            object max = null;

            elemaniEkle(siralanacakDizi, ref min, 0);
            elemaniEkle(siralanacakDizi, ref max, 0);
    
            //sıralanacak diziyi gez ve minimum ve maksimum elemanı bul.
            for (int i = 1; i < siralanacakDizi.Count; i++)
            {
                if (elemanlariKarsilastir(siralanacakDizi, i, min) < 0)
                {
                    elemaniEkle(siralanacakDizi, ref min, i);
                }
                else if (elemanlariKarsilastir(siralanacakDizi, i, max) > 0)
                {
                    elemaniEkle(siralanacakDizi, ref max, i);
                }
            }

            //sayma dizisinin indislerini oluşturacak aralık hesaplanır.
            int range = (int)max - (int)min + 1;

            // sayma dizisini hafızada tutmak için yer ayarlanır.
            int[] count = new int[range];

            for (int i = 0; i < range; i++)
            {
                count[i] = 0;
            }

            for (int i = 0; i < siralanacakDizi.Count; i++)
            {
                count[(int)elemaniAl(siralanacakDizi, i) - (int)min]++;
            }

            // işte şimdi asıl dizimizi sıralanmış şekilde oluşturabiliriz.
            int z = 0;
            for (int i = 0; i < count.Length; i++)
            {
                while (count[i] > 0)
                {
                    elemaniEkle(siralanacakDizi, z, (object)(i + (int)min));
                    z++;
                    count[i]--;
                }
            }

            return siralanacakDizi;
        }

 
        // En basit yöntemlerden biri fakat çok yavaş çalışanlardan da biri.
        public IList SelectionSort(IList siralanacakDizi)
        {
            int min;
            for (int i = 0; i < siralanacakDizi.Count; i++)
            {
                min = i;

                for (int j = i + 1; j < siralanacakDizi.Count; j++)
                {
                    if (elemanlariKarsilastir(siralanacakDizi, j, min) < 0)
                    {
                        min = j;
                    }
                }

                if (i < min) // eğer i hala minimum a eşitse yer değiştirme işlemine gerek yok.
                {
                    yerDegistir(siralanacakDizi, i, min);
                }
            }

            return siralanacakDizi;
        }


        private object elemaniAl(IList arrayToSort, int index)
        {
            if (!gosterimdeBelirtilenIndisler.ContainsKey(index))
                gosterimdeBelirtilenIndisler.Add(index, false);

            islemSayac++;
            frameKontrolEt();

            return arrayToSort[index];
        }

        private void elemaniEkle(IList siralanacakDizi, int eklenecekIndis, object alinacakNesne)
        {
            siralanacakDizi[eklenecekIndis] = alinacakNesne;

            if (!gosterimdeBelirtilenIndisler.ContainsKey(eklenecekIndis))
                gosterimdeBelirtilenIndisler.Add(eklenecekIndis, false);

            islemSayac++;
            frameKontrolEt();
        }
        private void elemaniEkle(IList siralanacakDizi, ref object gonderilenNesne, int alinacakIndis)
        {
            gonderilenNesne = siralanacakDizi[alinacakIndis];

            if (!gosterimdeBelirtilenIndisler.ContainsKey(alinacakIndis))
                gosterimdeBelirtilenIndisler.Add(alinacakIndis, false);

            islemSayac++;
            frameKontrolEt();
        }
        private void yerDegistir(IList siralanacakDizi, int indis1, int indis2)
        {
            object temp = siralanacakDizi[indis1];
            siralanacakDizi[indis1] = siralanacakDizi[indis2];
            siralanacakDizi[indis2] = temp;

            if (!gosterimdeBelirtilenIndisler.ContainsKey(indis1))
                gosterimdeBelirtilenIndisler.Add(indis1, false);
            if (!gosterimdeBelirtilenIndisler.ContainsKey(indis2))
                gosterimdeBelirtilenIndisler.Add(indis2, false);

            islemSayac += 2;
            frameKontrolEt();
        }
        private int elemanlariKarsilastir(IList siralanacakDizi, int indis1, int indis2)
        {
            if (!gosterimdeBelirtilenIndisler.ContainsKey(indis1))
                gosterimdeBelirtilenIndisler.Add(indis1, false);
            if (!gosterimdeBelirtilenIndisler.ContainsKey(indis2))
                gosterimdeBelirtilenIndisler.Add(indis2, false);

            islemSayac++;
            frameKontrolEt();

            return ((IComparable)siralanacakDizi[indis1]).CompareTo(siralanacakDizi[indis2]);
        }
        private int elemanlariKarsilastir(IList siralanacakDizi, int indis1, object o)
        {
            if (!gosterimdeBelirtilenIndisler.ContainsKey(indis1))
                gosterimdeBelirtilenIndisler.Add(indis1, false);

            islemSayac++;
            frameKontrolEt();

            return ((IComparable)siralanacakDizi[indis1]).CompareTo(o);
        }

        private void frameKontrolEt()
        {
            if (islemSayac >= kareBasinaIslemSayisi || sonrakiKareZamani <= DateTime.UtcNow)
            {
                // yeni bir frame oluşturmak ve beklemek için zaman
                gosterimiCiz();
                paneliYenile(diziGosterimEkrani);

                // yeni frame için hazırlık aşaması
                gosterimdeBelirtilenIndisler.Clear();
                islemSayac -= kareBasinaIslemSayisi; 

                if (DateTime.UtcNow < sonrakiKareZamani)
                {
                    Thread.Sleep((int)((sonrakiKareZamani - DateTime.UtcNow).TotalMilliseconds));
                }
                sonrakiKareZamani = sonrakiKareZamani.AddMilliseconds(frameMS);
            }
        }

        public void cizimiBitir()
        {
            if (gosterimdeBelirtilenIndisler.Count > 0)
            {
                // son frame i koy.
                sonrakiKareZamani = DateTime.UtcNow;
                frameKontrolEt();
            }

            // son frame i çiz.
            sonrakiKareZamani = DateTime.UtcNow;
            frameKontrolEt();
        }

        delegate void SetControlValueCallback(Control pnlSort);

        private void paneliYenile(Control pnlSort)
        {
            if (pnlSort.InvokeRequired)
            {
                SetControlValueCallback d = new SetControlValueCallback(paneliYenile);
                pnlSort.Invoke(d, new object[] { pnlSort });
            }
            else
            {
                pnlSort.Refresh();
            }
        }

        public void gosterimiCiz()
        {
            double yukseklikCarpani = 1;

            // eğer panel genişliğini değiştirmek gerektiyse kontrol et.
            if (bitmap.Width != diziGosterimEkrani.Width || bitmap.Height != diziGosterimEkrani.Height)
            {
                bitmap = new Bitmap(diziGosterimEkrani.Width, diziGosterimEkrani.Height);
                g = Graphics.FromImage(bitmap);
                diziGosterimEkrani.Image = bitmap;
            }

            if (diziGosterimEkrani.Height != standartPanelYukseklik)
            {
                yukseklikCarpani = (double)(diziGosterimEkrani.Height) / (double)(standartPanelYukseklik);
            }

            // beyaz bir arkaplan ayarla.
            g.Clear(Color.White);

            // siyah renk ile gösterimleri çiz.
            Pen pen = new Pen(Color.Black);
            SolidBrush b = new SolidBrush(Color.Black);

            // kırmızı renk kullanarak da değişimleri göster.
            Pen redPen = new Pen(Color.Red);
            SolidBrush redBrush = new SolidBrush(Color.Red);

            // dizi elemanlarını gösterirken düzgün bir genişlik ayarı sağlamak için...
            int w = (diziGosterimEkrani.Width / siralanacakDizi.Count) - 1;

            for (int i = 0; i < this.siralanacakDizi.Count; i++)
            {
                int x = (int)(((double)diziGosterimEkrani.Width / siralanacakDizi.Count) * i);

                int elemanGosterimYukseklik = (int)Math.Round(Convert.ToDouble(siralanacakDizi[i]) * yukseklikCarpani);

                // değişim uygulanan elemanları belirtmek için
                if (gosterimdeBelirtilenIndisler.ContainsKey(i))
                {
                    if (w <= 1)
                    {
                        g.DrawLine(redPen, new Point(x, diziGosterimEkrani.Height), new Point(x, (int)(diziGosterimEkrani.Height - elemanGosterimYukseklik)));
                    }
                    else
                    {
                        g.FillRectangle(redBrush, x, diziGosterimEkrani.Height - elemanGosterimYukseklik, w, diziGosterimEkrani.Height);
                    }
                }
                else // değişim uygulanmayan elemanların gösterimi
                {
                    if (w <= 1)
                    {
                        g.DrawLine(pen, new Point(x, diziGosterimEkrani.Height), new Point(x, (int)(diziGosterimEkrani.Height - elemanGosterimYukseklik)));
                    }
                    else
                    {
                        g.FillRectangle(b, x, diziGosterimEkrani.Height - elemanGosterimYukseklik, w, diziGosterimEkrani.Height);
                    }
                }
            }
        }
    }
}