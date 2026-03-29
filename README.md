# NTP Ödevler — C# WinForms Mini Oyun Koleksiyonu

Nesne Tabanlı Programlama dersi kapsamında geliştirilen 5 farklı mini oyundan oluşan bir Windows Forms proje koleksiyonu. Her oyun kendi çözümüne sahip olup ortak bir `.sln` dosyası altında da bir araya getirilmiştir.

## Öne Çıkanlar

- **Adam Asmaca** — Türkiye'nin 81 ilini kelime havuzu olarak kullanan Hangman oyunu; her yanlış tahminle değişen 12 aşamalı adam figürü animasyonu
- **Mayın Tarlası** — `Mayin` ve `Mayin_tarlasi` sınıflarıyla nesne yönelimli modelleme; sıfır-çevresinde taşma açma (flood-fill benzeri) ve sağ tıkla bayrak koyma mekanizması
- **Tic-Tac-Toe** — Timer tabanlı gecikmeli yapay zeka hamlesiyle insan vs bot modu; maç başına kazanma sayısı takibi
- **Flappy Bird** — Gerçek zamanlı `Timer` döngüsü, klavye tetiklemeli yerçekimi ve piksel düzeyinde `Bounds.IntersectsWith` çarpışma tespiti
- **Araba Yarışı** — Aynı klavyeden iki oyuncuyu destekleyen basit 2'li yarış mekaniği

## Tech Stack

![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white)
![.NET Framework](https://img.shields.io/badge/.NET_Framework-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows_Forms-0078D4?style=flat-square&logo=windows&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=flat-square&logo=visualstudio&logoColor=white)

## Kurulum

```bash
# Repoyu klonla
git clone https://github.com/HalitACET/NTPodevler.git
cd NTPodevler
```

Ardından Visual Studio ile `AdamAsmaca.sln` ya da ilgili oyunun `.sln` dosyasını aç ve **F5** ile çalıştır.

> .NET Framework 4.x ve Visual Studio 2019+ gereklidir.

## Proje Yapısı

```
NTPodevler/
├── AdamAsmaca/          # Hangman — 81 il kelime havuzu, 12 aşamalı animasyon
├── ArabaYarisi/         # 2 oyunculu klavye yarışı
├── Mayin_Tarlasi/       # Mayın Tarlası — OOP model + flood-fill açma
├── flappyBird/          # Flappy Bird — yerçekimi fiziği + çarpışma tespiti
└── tictactoe_/          # Tic-Tac-Toe — timer tabanlı AI + skor takibi
```

## Oyunlar Hakkında

### 🎯 Adam Asmaca
Kullanıcı Türkiye'nin 81 ilinden birine rastgele seçilen şehri tahmin etmeye çalışır. Her yanlış harf seçiminde `PictureBox` içindeki adam figürü 11 adımda tamamlanır (ayrı `.png` kaynakları kullanılarak). 11 hak dolduğunda ya da kelime doğru tahmin edildiğinde yeni oyun otomatik başlar.

### 💣 Mayın Tarlası
600×600 piksel alanda 250 mayın barındıran grid. `Mayin` sınıfı her hücreyi konum ve `mayin_var_mi` bayrağıyla modeller; `Mayin_tarlasi` sınıfı koleksiyonu yönetir. Boş bir hücreye tıklandığında çevre tespiti yapılır ve etrafındaki mayın sayısı gösterilir. Sağ tıkla `!` işaretiyle bayrak bırakılabilir.

### ❌ Tic-Tac-Toe
3×3 ızgarada oyuncu (X) karşısına bot (O) oynar. Oyuncunun hamlesinin ardından `Timer` tetiklenerek bot kısa bir gecikmeyle rastgele boş kareye hamle yapar. Kazanma koşulları tüm satır, sütun ve köşegen kombinasyonları için kontrol edilir; her oyun sonucunda skor güncellenir.

### 🐦 Flappy Bird
`Space` tuşuna basınca yerçekimi tersine döner, bırakınca geri döner. `Timer` her tetiklenişinde kuşu ve boruları hareket ettirir, `Bounds.IntersectsWith` ile çarpışma kontrolü yapar. Boru ekran sınırını geçtiğinde sağ tarafa ışınlanır ve skor artar.

### 🚗 Araba Yarışı
İki oyuncu aynı klavyeden oynuyor. `↑` tuşu kırmızı arabayı, `↓` tuşu beyaz arabayı ilerletir. Finite çizgisine ilk ulaşan oyuncu kazanır ve araçlar başlangıç pozisyonuna sıfırlanır.

## Öğrendiklerim

- WinForms event-driven mimarisi (`Click`, `KeyDown`, `Timer.Tick` gibi olaylar)
- Nesne yönelimli modelleme: veriyi UI'dan ayırmak için ayrı model sınıfları yazma (Mayın Tarlası)
- `PictureBox` ve dinamik görsel değiştirerek animasyon simülasyonu
- Timer kullanarak gerçek zamanlı oyun döngüsü oluşturma
- Piksel tabanlı çarpışma tespiti (`Rectangle.IntersectsWith`)
