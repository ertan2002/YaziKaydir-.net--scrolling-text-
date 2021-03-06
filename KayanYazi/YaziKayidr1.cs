﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace KayanYazi
{
    public partial class YaziKaydir : UserControl
    {
        #region Private Variables
        private List<string> yazilar;
        private Label AnaYazi;
        private int X;
        private int Y;
        private int Hiz;
        private Color YaziRengi;
        private Color ArkaPlanRengi;
        private KaydirmaTuru Tur;
        private Pozisyon pozisyon;
        private bool? AnimasyonDurum =null;
        #endregion

        #region Public Enums
        public enum KaydirmaTuru
        {
            Yukari, Asagi, Sag, Sol

        }

        public enum Pozisyon
        {
            SagaHizali, SolaHizali, Ortalı, YukariHizali, AsagiHizali
        } 
        #endregion

        
        #region Ctor
        public YaziKaydir()
        {
            InitializeComponent();
            yazilar = new List<string>();
            AnaYazi = new Label();


            AnaYazi.Location = new System.Drawing.Point(0, 0);
            AnaYazi.Name = "lblAna";
            AnaYazi.Size = new System.Drawing.Size(35, 13);
            AnaYazi.TabIndex = 0;
            AnaYazi.AutoSize = true;
            AnaYazi.Visible = false;
            AnaYazi.TextAlign = ContentAlignment.BottomRight;
            this.panel1.Controls.Add(this.AnaYazi);

            X = 0;
            Y = 0;
          
            YaziRengi = Color.Black;
            ArkaPlanRengi = Color.White;
            AnaYazi.Font = new Font(AnaYazi.Font.FontFamily.Name, 12);

        } 
        #endregion

        #region Settings
        /// <summary>
        /// Yazının font rengini ayarlar.
        /// </summary>
        /// <param name="yaziRengi">Color türünden renk parametresi alır. Örnek: Color.White</param>
        public void YaziRengiAyarla(Color yaziRengi)
        {
            YaziRengi = yaziRengi;

        }

        /// <summary>
        /// Kontrolün arkaplan rengini belirler
        /// </summary>
        /// <param name="arkaPlanRengi">Color türünden renk parametresi alır. Örnek: Color.Blue</param>
        public void ArkaPlanRengiAyarla(Color arkaPlanRengi)
        {
            ArkaPlanRengi = arkaPlanRengi;
        }

        /// <summary>
        /// Yazıyı kendi içinde hizalar
        /// </summary>
        /// <param name="hizalama">ContentAlignment türünden parametre alır. Örnek: ContentAlignment.MiddleCenter</param>
        public void YaziHizalamaAyarla(ContentAlignment hizalama)
        {
            
            AnaYazi.TextAlign = hizalama;
        }

        /// <summary>
        /// Yazının fontunu belirler
        /// </summary>
        /// <param name="boyut">int türünden değer alır.</param>
        public void FontBoyutuAyarla(int boyut)
        {
            AnaYazi.Font = new Font(AnaYazi.Font.FontFamily.Name, boyut);
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Kaydırılmak istenilen yazılar eklenir
        /// </summary>
        /// <param name="yazi">kaydırmak istediğiniz yazı</param>
        /// <param name="hiz">saniye cinsinden ters orantılı olarak hız</param>
        public void YaziEkle(string yazi)
        {
            yazilar.Add(yazi);

        }

        /// <summary>
        /// Eklenmiş olan tüm yazılar silinip içerik temizlenir
        /// </summary>
        /// <returns>Temizleme işlemi başarılı ise true, değil ise false değeri geri dönderir</returns>
        public bool TumYazilariTemizle()
        {
            if(yazilar.Count==0)
                return false;
            else
            {
                yazilar.Clear();
                AnaYazi.Text = "";
            }

            return true;

        }

        /// <summary>
        /// Kaydırma işlemi başlar
        /// </summary>
        /// <param name="tur">kaydırma yönün belirlenir</param>
        /// <param name="hiz">milisaniye cinsinden hız.değer arttıkça kayma yavaşlar</param>
        /// /// <param name="pozisyon">pozisyon türünden enum ile yazıyı kontrol içinde konumlandırır</param>
        public void Basla(KaydirmaTuru tur, int hiz, Pozisyon pozisyon)
        {
            if (yazilar.Count ==0)
                MessageBox.Show("Lütfen kaydırmak istediğiniz yazıyı ekleyin");
            else
            {
                Hiz = hiz;
                Tur = tur;

                tmrKaydir.Interval = Hiz;
                this.pozisyon = pozisyon;


                AnaYazi.ForeColor = YaziRengi;
                panel1.BackColor = ArkaPlanRengi;
                string tmpSuffix = "";
                if (Tur == KaydirmaTuru.Sol || Tur == KaydirmaTuru.Sag)
                {
                    tmpSuffix = " ";
                    X = panel1.Width;

                }
                else
                {
                    tmpSuffix = "\n";
                    Y = panel1.Height;

                }


                foreach (string yazi in yazilar)
                {
                    AnaYazi.Text += yazi + tmpSuffix;

                }
                AnaYazi.Location = new System.Drawing.Point(X, Y);
                AnaYazi.Visible = true;
                tmrKaydir.Start();
                AnimasyonDurum = true;
            }

            
        }

        /// <summary>
        /// Hareketli Animasyonu Durdurur
        /// </summary>
        public void Dur()
        {
            if(AnimasyonDurum==null)
            {
                MessageBox.Show("Başlatılmayan animasyon durdurulamaz.");
            }
            else if((bool) AnimasyonDurum)
            {
                tmrKaydir.Stop();
                AnimasyonDurum = false;
            }
            
        }

        /// <summary>
        /// Durdurulan animasyona kaldığı yerden devam eder
        /// </summary>
        public void DevamEt()
        {
            if(AnimasyonDurum==null)
            {
                MessageBox.Show("Başlatılmayan animasyon devam ettirilemez");
            }
            else if ((bool) (!AnimasyonDurum) )
            {
                tmrKaydir.Start();
                AnimasyonDurum = true;
            }
        }
        #endregion

        #region Private Methods
        private void Kay()
        {
            switch (Tur)
            {
                case KaydirmaTuru.Yukari:
                    PozisyonAyarla(1);

                    if (Y < -this.Height)
                        Y = this.Height;
                    else
                        Y -= 5;

                    break;
                case KaydirmaTuru.Asagi:
                    PozisyonAyarla(1);

                    if (Y > this.Height)
                        Y = -10 - this.Height;
                    else
                        Y += 5;

                    break;
                case KaydirmaTuru.Sag:
                    PozisyonAyarla(2);
                    if (X > this.Width)
                        X = 0 - AnaYazi.Width;
                    else
                        X += 5;


                    break;
                case KaydirmaTuru.Sol:
                    PozisyonAyarla(2);
                    if (X < -10 - AnaYazi.Width)
                        X = this.Width;
                    else
                        X -= 5;
                    break;

            }

        }

        private void PozisyonAyarla(int tip)
        {
            if (tip == 1) //yukarı-aşağı
            {
                if (pozisyon == Pozisyon.Ortalı)
                    X = (panel1.Width - AnaYazi.Width) / 2;

                else if (pozisyon == Pozisyon.SolaHizali)
                    X = 10;

                else if (pozisyon == Pozisyon.SagaHizali)
                    X = panel1.Width - AnaYazi.Width - 10;
            }
            else //sağ sol
            {
                if (pozisyon == Pozisyon.Ortalı)
                    Y = (panel1.Height - AnaYazi.Height) / 2;
                else if (pozisyon == Pozisyon.YukariHizali)
                    Y = 10;
                else if (pozisyon == Pozisyon.AsagiHizali)
                    Y = panel1.Height - AnaYazi.Height - 10;

            }
        }
        #endregion



        #region Private Events
        private void tmrKaydir_Tick(object sender, EventArgs e)
        {
            Kay();
            AnaYazi.Location = new Point(X, Y);

        }
        #endregion
        

       

        
    }
}
