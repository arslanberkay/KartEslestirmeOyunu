using System.ComponentModel.Design.Serialization;

namespace WFAKartEslestirmeOyunu.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        List<int> tekrarEtmeyenRasgeleSayilar = new List<int>();
        int resimAcmaSayaci;
        int acilanResimSayisi;
        List<Button> resimKartlari = new List<Button>();
        Button birinciTiklananResimKarti, ikinciTiklananResimKarti;

        List<string> resimListesi = new List<string>()  //2 þer tane 6 farklý hayvan resmi listeye yüklendi.
        {
            @"images/kopekBaligi.png", @"images/kopekBaligi.png",
            @"images/baykus.png" ,@"images/baykus.png",
            @"images/aslan.png",@"images/aslan.png",
            @"images/yilan.png",@"images/yilan.png",
            @"images/timsah.png",@"images/timsah.png",
            @"images/fil.png",@"images/fil.png"

        };

        void KartOlustur()  // Kart butonlarý oluþturuldu. Boyutlarý ve rengi verildi. Click eventi oluþturuldu.
        {
            int rasgeleSayi = rnd.Next(12);

            for (int i = 0; i < 12; i++)
            {
                Button btn = new Button();
                btn.Width = 250;
                btn.Height = 250;
                btn.BackColor = Color.Gray;

                while (tekrarEtmeyenRasgeleSayilar.Contains(rasgeleSayi))
                {
                    rasgeleSayi = rnd.Next(12);
                }
                tekrarEtmeyenRasgeleSayilar.Add(rasgeleSayi);

                btn.Tag = resimListesi[rasgeleSayi];  // Butonun arka planýnda resim yolunu tuttum.
                flpKartAlani.Controls.Add(btn);
                resimKartlari.Add(btn);

                btn.Click += Btn_Click;
            }
        }

        void ResimKartlariniPasifEt()
        {
            foreach (var resimKarti in resimKartlari)
            {
                resimKarti.Enabled = false;
            }
            resimAcmaSayaci = 0;
        }
        void ResimKartlariniAktifEt()
        {
            foreach (var resimKarti in resimKartlari)
            {
                resimKarti.Enabled = true;
            }
            resimAcmaSayaci = 0;
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            Button tiklananKart = (Button)sender;

            resimAcmaSayaci++;
            if (resimAcmaSayaci == 2)
            {
                ResimKartlariniPasifEt();
            }

            tiklananKart.BackgroundImage = Image.FromFile(tiklananKart.Tag.ToString());
            tiklananKart.BackgroundImageLayout = ImageLayout.Stretch;

            //Týklanan iki resim kartý kaydedildi.
            if (birinciTiklananResimKarti == null)
            {
                birinciTiklananResimKarti = tiklananKart;
            }
            else
            {
                ikinciTiklananResimKarti = tiklananKart;

                //Eþleþme kontrolü
                if (birinciTiklananResimKarti.Tag.ToString() == ikinciTiklananResimKarti.Tag.ToString())
                {
                    birinciTiklananResimKarti = null;
                    ikinciTiklananResimKarti = null;
                    ResimKartlariniAktifEt();
                    acilanResimSayisi++;
                }
                else
                {
                    tmrYanlisKartlariKapat.Start();
                }
            }
            if (acilanResimSayisi==6)
            {
                OyunuBitir();
            }
        }

        void OyunuBitir()
        {
            DialogResult dr = MessageBox.Show("Tebrikler oyunu kazandýnýz! Yeniden oynamak ister misiniz?","Bilgi",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                tekrarEtmeyenRasgeleSayilar.Clear();
                acilanResimSayisi = 0;
                resimAcmaSayaci = 0;
                birinciTiklananResimKarti = null;
                ikinciTiklananResimKarti = null;
                for ( int i = 0;  i < resimKartlari.Count;  i++)
                {
                    resimKartlari[i].BackgroundImage = null;
                    resimKartlari[i] = null;
                }
                flpKartAlani.Controls.Clear();
                resimKartlari.Clear();
                
                
                KartOlustur();
            }
            else
            {
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KartOlustur();
        }

        private void tmrYanlisKartlariKapat_Tick(object sender, EventArgs e)
        {
            birinciTiklananResimKarti.BackgroundImage = null;
            ikinciTiklananResimKarti.BackgroundImage = null;

            birinciTiklananResimKarti = null;
            ikinciTiklananResimKarti = null;

            tmrYanlisKartlariKapat.Stop();
            ResimKartlariniAktifEt();
        }
    }
}
