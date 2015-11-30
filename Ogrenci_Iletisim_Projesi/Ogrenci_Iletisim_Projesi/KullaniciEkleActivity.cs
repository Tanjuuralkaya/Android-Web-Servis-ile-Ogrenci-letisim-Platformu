using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Ogrenci_Iletisim_Projesi
{
    [Activity(Label = "Activity1")]
    public class KullaniciEkleActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.KullaniciEkle);
            // Create your application here
            //web servis baðlantýsý için refenrans oluþturulu
            List<String> liste = new List<string>();

            EditText ad = (EditText)FindViewById(Resource.Id.ad_giris);
            EditText soyisim = (EditText)FindViewById(Resource.Id.soyad_giris);
            EditText email = (EditText)FindViewById(Resource.Id.e_mail_giris);
            RadioGroup cins = (RadioGroup)FindViewById(Resource.Id.rd_group_cinsiyet);
            RadioGroup unvan = (RadioGroup)FindViewById(Resource.Id.rd_unvan_group);
            Spinner bolum = (Spinner)FindViewById(Resource.Id.spin_bolum);
            EditText sifre = (EditText)FindViewById(Resource.Id.sifre_giris);
            EditText resim = (EditText)FindViewById(Resource.Id.resim_yolu);
            Button btnKayit = (Button)FindViewById(Resource.Id.btnKayit);

            WebService.Service1 servis = new WebService.Service1();
            try
            {
                liste.AddRange(servis.BolumCek());
                ArrayAdapter<String> adapter_state = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleSpinnerItem, liste);
                adapter_state.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
                bolum.Adapter = adapter_state;
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }

            btnKayit.Click += delegate
           {
               String isim = ad.Text;
               String soyad = soyisim.Text;
               String mail = email.Text;
               int cinsiyet = cins.CheckedRadioButtonId;
               if (cinsiyet == 2131099659)
                   cinsiyet = 1;
               else
                   cinsiyet = 2;
               int unv = unvan.CheckedRadioButtonId;
               if (unv == 2131099662)
                   unv = 1;
               else
                   unv = 2;
               int spn = (int)bolum.SelectedItemId + 1;
               String sfr = sifre.Text;
               String rsm = resim.Text;
               Boolean cevap = servis.KullaniciKayit(isim, soyad, mail,
                   cinsiyet, unv, spn, sfr, rsm);
               if (cevap.Equals(true))
               {
                   Toast.MakeText(this, "Baþarýyla kaydýnýz" +
                       " yapýldý.", ToastLength.Short);
                   Toast.MakeText(this, "Þimdi giriþ sayfasýna" +
                       " yönlendiriliyorsunuz...", ToastLength.Short);
                   StartActivity(new Intent(this, typeof(MainActivity)));
               }
               else
                   Toast.MakeText(this, "Kayýt iþlemi sýrasýnda beklenmeyen bir " +
                       "hata oluþtu lütfen tekrar deneyiniz.", ToastLength.Short);
           };
        }
    }
}
