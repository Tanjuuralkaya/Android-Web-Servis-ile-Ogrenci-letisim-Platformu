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
    [Activity(Label = "SiniflarActivity")]
    public class SiniflarActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Siniflar);
            // Create your application here

            Button btnSinif1 = (Button)FindViewById(Resource.Id.btnSinif1);
            Button btnSinif2 = (Button)FindViewById(Resource.Id.btnSinif2);
            Button btnSinif3 = (Button)FindViewById(Resource.Id.btnSinif3);
            Button btnSinif4 = (Button)FindViewById(Resource.Id.btnSinif4);

            int bolum = Intent.GetIntExtra("extraBolum", 0);
            int k_id = Intent.GetIntExtra("extraKullaniciId", 0);


           
            btnSinif1.Click += delegate
            {
                Intent i = new Intent(this, typeof(DerslerActivity));
                i.PutExtra("extraBolum", bolum);
                i.PutExtra("extraSinif", 1);
                i.PutExtra("extraKullaniciId", k_id);
                StartActivity(i);
            };

            btnSinif2.Click += delegate
            {
                Intent i = new Intent(this, typeof(DerslerActivity));
                i.PutExtra("extraBolum", bolum);
                i.PutExtra("extraSinif", 2);
                i.PutExtra("extraKullaniciId", k_id);
                StartActivity(i);
            };

            btnSinif3.Click += delegate
            {
                Intent i = new Intent(this, typeof(DerslerActivity));
                i.PutExtra("extraBolum", bolum);
                i.PutExtra("extraSinif", 3);
                i.PutExtra("extraKullaniciId", k_id);
                StartActivity(i);
            };

            btnSinif4.Click += delegate
            {
                Intent i = new Intent(this, typeof(DerslerActivity));
                i.PutExtra("extraBolum", bolum);
                i.PutExtra("extraSinif", 4);
                i.PutExtra("extraKullaniciId", k_id);
                StartActivity(i);
            };
        }
    }
}