using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Mayin_Tarlasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Mayin_tarlasi mayin_tarlamiz;
        Image mayin_Resmi = Image.FromFile(@"mayin.png");
        List<Mayin> mayinlarimiz;
        int bulunan_temiz_alan;

        private void Form1_Load(object sender, EventArgs e)
        {
            yeni_oyun_baslat();
        }

        private void yeni_oyun_baslat()
        {
            lbl_durum.Text = "";
            mayin_tarlamiz = new Mayin_tarlasi(new Size(600, 600), 250); // 30x30 boyut ve 90 mayın
            panel1.Size = mayin_tarlamiz.buyuklugu;
            bulunan_temiz_alan = 0;
            Mayin_ekle();
        }

        public void Mayin_ekle()
        {
            for (int x = 0; x < panel1.Width; x += 20)
            {
                for (int y = 0; y < panel1.Height; y += 20)
                {
                    Button_ekle(new Point(x, y));
                }
            }
        }

        public void Button_ekle(Point loc)
        {
            Button btn = new Button
            {
                Name = loc.X + "" + loc.Y,
                Size = new Size(20, 20),
                Location = loc
            };
            btn.Click += new EventHandler(btn_Click);
            btn.MouseUp += new MouseEventHandler(btn_MouseUp);
            panel1.Controls.Add(btn);
        }

        void btn_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = (sender as Button);
            if (e.Button == MouseButtons.Right)
            {
                btn.Text = "!";
            }
        }

        public void btn_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            Mayin myn = mayin_tarlamiz.mayin_al_loc(btn.Location);
            mayinlarimiz = new List<Mayin>();

            if (myn.mayin_var_mi)  // Eğer mayın varsa
            {
                MessageBox.Show("Kaybettin");
                Mayinlari_goster();  // Tüm mayınları göster
            }
            else
            {
                int s = etrafta_kac_mayin_var(myn);  // Etrafındaki mayın sayısını al

                if (s == 0)  // Eğer çevresinde hiç mayın yoksa
                {
                    mayinlarimiz.Add(myn);

                    for (int i = 0; i < mayinlarimiz.Count; i++)
                    {
                        Mayin item = mayinlarimiz[i];
                        if (item != null)
                        {
                            if (item.bakildi_ == false && item.mayin_var_mi == false)
                            {
                                Button btnx = (Button)panel1.Controls.Find(item.konum_al.X + "" + item.konum_al.Y, false)[0];
                                if (etrafta_kac_mayin_var(mayinlarimiz[i]) == 0)  // Etrafında hiç mayın yoksa
                                {
                                    btnx.Enabled = false;
                                    cevresindekileri_ekle(item);
                                }
                                else
                                {
                                    btnx.Text = etrafta_kac_mayin_var(item).ToString();  // Etrafındaki mayın sayısını butona yaz
                                }
                                bulunan_temiz_alan++;
                                item.bakildi_ = true;
                            }
                        }
                    }
                }
                else
                {
                    btn.Text = s.ToString();  // Eğer çevrede mayın varsa, sayıyı butona yaz
                    bulunan_temiz_alan++;
                }
            }

            // Kazanma kontrolü
            if (bulunan_temiz_alan >= mayin_tarlamiz.toplam_alan - mayin_tarlamiz.toplam_mayin_sayisi)
            {
                lbl_durum.Text = "Kazandınız";
            }
        }


        public int etrafta_kac_mayin_var(Mayin m)
        {
            int sayi = 0;

            // Çevredeki 8 hücreyi kontrol etmek için
            Point[] komsular = new Point[]
            {
        new Point(-20, -20), new Point(0, -20), new Point(20, -20),
        new Point(-20, 0),                  /* M */         new Point(20, 0),
        new Point(-20, 20),  new Point(0, 20),  new Point(20, 20)
            };

            foreach (var komsu in komsular)
            {
                Point kontrol_noktasi = new Point(m.konum_al.X + komsu.X, m.konum_al.Y + komsu.Y);

                // Kontrol edilen noktanın panel boyutlarının içinde olup olmadığını kontrol ediyoruz
                if (kontrol_noktasi.X >= 0 && kontrol_noktasi.Y >= 0 &&
                    kontrol_noktasi.X < panel1.Width && kontrol_noktasi.Y < panel1.Height)
                {
                    Mayin komsu_mayin = mayin_tarlamiz.mayin_al_loc(kontrol_noktasi);

                    if (komsu_mayin != null && komsu_mayin.mayin_var_mi)
                    {
                        sayi++;
                    }
                }
            }

            return sayi;
        }



        public void cevresindekileri_ekle(Mayin m)
        {
            // Çevre ekleme işlemi
        }

        public void Mayinlari_goster()
        {
            foreach (Mayin item in mayin_tarlamiz.GetAllMayin)
            {
                if (item.mayin_var_mi)
                {
                    Button btn = (Button)panel1.Controls.Find(item.konum_al.X + "" + item.konum_al.Y, false)[0];
                    btn.BackgroundImage = mayin_Resmi;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            yeni_oyun_baslat();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            yeni_oyun_baslat();
        }
    }
}
