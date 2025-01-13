using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdamAsmaca
{
    public partial class Form1 : Form
    {
        // tüm 81 il
        private string[] sehirler = new string[]
       {
            "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Amasya", "Ankara", "Antalya",
            "Artvin", "Aydın", "Balıkesir", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur",
            "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Edirne",
            "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane",
            "Hakkâri", "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir", "Kars", "Kastamonu",
            "Kayseri", "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya",
            "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde",
            "Ordu", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ",
            "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Uşak", "Van", "Yozgat", "Zonguldak",
            "Aksaray", "Bayburt", "Karaman", "Kırıkkale", "Batman", "Şırnak", "Bartın",
            "Ardahan", "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce"
           
       };

        private string seciliKelime;
        private List<char> dogruHarfler = new List<char>();
        private int yanlisTahminSayisi = 0;
        private int dogruTahminSayisi = 0;
        public Button[] harfButonlari;
        private Label[] kelimeLabelArray;
        private const int maxHak = 11; // Toplam hak sayısı 11

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde buton ve label'ları başlat
            harfButonlari = new Button[] { buttonA, buttonB, buttonC, buttonÇ, buttonD, buttonE, buttonF, buttonG, buttonĞ, buttonH, buttonI, buttonİ, buttonJ, buttonK, buttonL, buttonM, buttonN, buttonO, buttonÖ, buttonP, buttonR, buttonS, buttonŞ, buttonT, buttonU, buttonÜ, buttonV, buttonY, buttonZ/* diğer butonlar */ };
            kelimeLabelArray = new Label[] { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12,label13,label14/* diğer 9 label */ };

            foreach (var buton in harfButonlari)
            {
                buton.Click += HarfButon_Click; // Olayı bağla
            }

            YeniOyun();
        }

        private void YeniOyun()
        {
            dogruTahminSayisi = 0;
            // Rastgele şehir seçimi
            Random rnd = new Random();
            seciliKelime = sehirler[rnd.Next(sehirler.Length)].ToUpper();
            dogruHarfler.Clear();
            yanlisTahminSayisi = 0;

            // Tüm harf butonlarını aktif hale getir
            foreach (var buton in harfButonlari)
            {
                buton.Enabled = true;
            }

            // label'ları gizle
            
            for (int i = 0; i < kelimeLabelArray.Length; i++)
            {
                kelimeLabelArray[i].Visible = false;
                kelimeLabelArray[i].Text = "_____";
            }

            // Seçilen kelimenin harf sayısına göre label'ları ayarla
            for (int i = 0; i < seciliKelime.Length; i++)
            {
                kelimeLabelArray[i].Visible = true;
            }

            // Adam asma resmi sıfırla
            AdamCiz(yanlisTahminSayisi);
        }

        private void HarfButon_Click(object sender, EventArgs e)
        {
            Button buton = sender as Button;

            if (buton != null)
            {
                // Tıklanan butonun metnini al
                string harf = buton.Text;
               
                MessageBox.Show($"Tahmin ettiğiniz harf: {harf}");
            }

            char tahmin = buton.Text[0];

            // Seçilen harf butonunu devre dışı bırak
            buton.Enabled = false;
            
            if (seciliKelime.Contains(tahmin))
            {
                // Doğru tahmin
                for (int i = 0; i < seciliKelime.Length; i++)
                {
                    if (seciliKelime[i] == tahmin)
                    {
                        dogruTahminSayisi++;
                        kelimeLabelArray[i].Text = tahmin.ToString();
                        
                    }
                }
            }
            else
            {
                // Yanlış tahmin
                yanlisTahminSayisi++;
                AdamCiz(yanlisTahminSayisi);
            }

            // Oyunun bitme koşulları
            if (yanlisTahminSayisi == maxHak) // 11 yanlışta oyun biter
            {
                MessageBox.Show("Kaybettiniz! Kelime: " + seciliKelime);
                YeniOyun();
            }
            else if (dogruTahminSayisi == seciliKelime.Length)
            {
                MessageBox.Show("Tebrikler, kazandınız!");
                YeniOyun();
            }
        }

        private void AdamCiz(int yanlisSayisi)
        {
            // PictureBox'ta adam figürünü güncelleme mantığı
            pictureBox1.Image = Properties.Resources.adam_0;
            switch (yanlisSayisi)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.adam_1; // İlk parça
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources.adam_2;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources.adam_3;
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources.adam_4;
                    break;
                case 5:
                    pictureBox1.Image = Properties.Resources.adam_5;
                    break;
                case 6:
                    pictureBox1.Image = Properties.Resources.adam_6;
                    break;
                case 7:
                    pictureBox1.Image = Properties.Resources.adam_7;
                    break;
                case 8:
                    pictureBox1.Image = Properties.Resources.adam_8;
                    break;
                case 9:
                    pictureBox1.Image = Properties.Resources.adam_9;
                    break;
                case 10:
                    pictureBox1.Image = Properties.Resources.adam_10;
                    break;
                case 11:
                    pictureBox1.Image = Properties.Resources.adam_11; // Son aşama
                    break;
            }
        }
    }
}
