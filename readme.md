R10.net için hazırladığım bu componetle basit olarak kayan yazı animasyonu yapabilirsiniz.


Toolbox a sağ tıklayıp choose items i seçin ve .net framework components den KayanYazi.dll i seçin. Toolbox ınıza gelen
YaziKaydir kontrolünü  formunuza ekleyin. ayrıca form kodlarınızın en üstüne 
c# için        using KayanYazi; 
vb.net için    Imports KayanYazi

ekleyin.


                //*********************  C# örneği  *****************   //

            // tüm formu kaplar. Eğer isterseniz boyutunu istediğiniz şekilde ayarlayabilirsiniz,otomatik konumlandırır kendini
            yaziKaydir1.Dock = DockStyle.Fill;  
          
          // istediğiniz kadar yazı ekleyebilirsiniz
            
            yaziKaydir1.YaziEkle("Kayan Yazı V1.0");
            yaziKaydir1.YaziEkle("Coded By Ertan");
            yaziKaydir1.YaziEkle("----------------------");
            yaziKaydir1.YaziEkle("It's a free componet");
            yaziKaydir1.YaziEkle("Do it what you want");
            yaziKaydir1.YaziEkle("Thank you");
            yaziKaydir1.YaziEkle("----------------------");
            
            // kontrolün arkaplan rengini ayarlar, standart olarak form rengindedir
          
          yaziKaydir1.ArkaPlanRengiAyarla(Color.Blue);
            
            // Yazının rengini belirtir. Eğer ayarlamazsanız standart olarak siyahtır
            
            yaziKaydir1.YaziRengiAyarla(Color.White);
            
            // yazının boyutunu ayarlar. Eğer ayarlanmazsa standart olarak 12 dir
            
            yaziKaydir1.FontBoyutuAyarla(10);
            
            // yazının hizalanmasını belirler. ortalamalarda ya da sola/sağa dayalı olarak ayarlanabilir
            
            yaziKaydir1.YaziHizalamaAyarla(ContentAlignment.MiddleCenter);
            
            
            //animasyonu başlatır.  
            //1. parametre de animasyon şekli belirtilir.(yukarı,aşağı,sağ ve sol)
            //2. parametrede kayma hızı milisaniye cinsinden ayarlanır.değer azaldıkça hız artar
            //3. parametrede ise yazının kontrol içindeki konumu ayarlanır. Burada iki çeşit konumlandırma mevcuttur
            //a) kaydırma yukarı/aşağı ise: yazı konumu ortalı,sağa ve sola hizalı olabilir. Başka bir hizalama geçerli değil
            //b) kaydırma sol/sağ ise: yazı konumu ortalı,yukarı ve aşağı hizalı olabilir. Başka bir hizlama geçerli değil
            
            yaziKaydir1.Basla(YaziKaydir.KaydirmaTuru.Yukari, 100,YaziKaydir.Pozisyon.Ortalı);
            
            
            /********************Ek Özellikler  ******************************/
            
            // Animasyonu durdurmak için
              private void button1_Click(object sender, EventArgs e)
             {
              yaziKaydir1.Dur();
             }
            
            
            // Duran animasyonu devam ettirmek için
             private void button2_Click(object sender, EventArgs e)
             {
              yaziKaydir1.DevamEt();
             }
             
             // eklenen tüm içeriği temizlemek için. temizlendi ise true, değilse false dönderir
              bool Temizlendi= TumYazilariTemizle();
             
            
            //*********************  C# örneği bitti  *****************   //
            
            
            
            ' ******************** Vb.net Örneği ************************* '
            
              ' tüm formu kaplar. Eğer isterseniz boyutunu istediğiniz şekilde ayarlayabilirsiniz,otomatik konumlandırır kendini
        YaziKaydir1.Dock = DockStyle.Fill

        ' istediğiniz kadar yazı ekleyebilirsiniz

        YaziKaydir1.YaziEkle("Kayan Yazı V1.0")
        YaziKaydir1.YaziEkle("Coded By Ertan")
        YaziKaydir1.YaziEkle("----------------------")
        YaziKaydir1.YaziEkle("It's a free componet")
        YaziKaydir1.YaziEkle("Do it what you want")
        YaziKaydir1.YaziEkle("Thank you")
        YaziKaydir1.YaziEkle("----------------------")

        ' kontrolün arkaplan rengini ayarlar, standart olarak form rengindedir

        YaziKaydir1.ArkaPlanRengiAyarla(Color.Blue)

        ' Yazının rengini belirtir. Eğer ayarlamazsanız standart olarak siyahtır

        YaziKaydir1.YaziRengiAyarla(Color.White)

        ' yazının boyutunu ayarlar. Eğer ayarlanmazsa standart olarak 12 dir

        YaziKaydir1.FontBoyutuAyarla(10)

        ' yazının hizalanmasını belirler. ortalamalarda ya da sola/sağa dayalı olarak ayarlanabilir

        YaziKaydir1.YaziHizalamaAyarla(ContentAlignment.MiddleCenter)


        'animasyonu başlatır.  
        '1. parametre de animasyon şekli belirtilir.(yukarı,aşağı,sağ ve sol)
        '2. parametrede kayma hızı milisaniye cinsinden ayarlanır.değer azaldıkça hız artar
        '3. parametrede ise yazının kontrol içindeki konumu ayarlanır. Burada iki çeşit konumlandırma mevcuttur
        'a) kaydırma yukarı/aşağı ise: yazı konumu ortalı,sağa ve sola hizalı olabilir. Başka bir hizalama geçerli değil
        'b) kaydırma sol/sağ ise: yazı konumu ortalı,yukarı ve aşağı hizalı olabilir. Başka bir hizlama geçerli değil

        YaziKaydir1.Basla(YaziKaydir.KaydirmaTuru.Yukari, 100, YaziKaydir.Pozisyon.Ortalı)
        
        ' ********************Ek Özellikler  ****************************** '
       
       ' Animasyonu durdurmak için
        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        YaziKaydir1.Dur()

       End Sub
      
       'Duran animasyonu devam ettirmek için
       Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
       YaziKaydir1.DevamEt()
       End Sub


          ' ******************** Vb.net Örneği  Bitti  ************************* '

