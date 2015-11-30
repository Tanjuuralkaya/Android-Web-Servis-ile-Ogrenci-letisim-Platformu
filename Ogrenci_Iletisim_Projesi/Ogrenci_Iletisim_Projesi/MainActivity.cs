using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Ogrenci_Iletisim_Projesi
{
    [Activity(Label = "Ogrenci_Iletisim_Projesi", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button btnGiris = (Button)FindViewById(Resource.Id.btnGiris);
            Button btnKayit = (Button)FindViewById(Resource.Id.btnkayit);
            TextView ad = (EditText)FindViewById(Resource.Id.k_adi_girdi);
            TextView sifre = (EditText)FindViewById(Resource.Id.k_sifre_girdi);
            btnGiris.Click += delegate
            {
                String ad_email = ad.Text;
                String sfr = sifre.Text;
                
                String text = ad_email+" "+sfr;
                Toast.MakeText(this,text,ToastLength.Short).Show();
                WebService.Service1 servis = new WebService.Service1();
                String cevap = servis.GirisKontrol(ad_email,sfr);
                if (!cevap.Equals("Kullanıcı girişi başarısız!"))
                {
                    int kullanici_id = servis.KullaniciIdGetir();
                    int bolum = Convert.ToInt32(cevap);
                    Intent intent = new Intent(this, typeof(SiniflarActivity));
                    intent.PutExtra("extraBolum", bolum);
                    intent.PutExtra("extraKullaniciId", kullanici_id);
                    StartActivity(intent);
                }
                else
                    Toast.MakeText(this, "Kullanıcı bilgileri hatalı "+
                "kontrol ediniz...", ToastLength.Long).Show();
            };


            btnKayit.Click += delegate
            {
                StartActivity(new Intent(this, typeof(KullaniciEkleActivity)));
            };
        }
    }
}

