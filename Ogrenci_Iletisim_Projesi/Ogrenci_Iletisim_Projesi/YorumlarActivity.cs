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
    [Activity(Label = "YorumlarActivity")]
    public class YorumlarActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Yorumlar);
            WebService.Service1 servis = new WebService.Service1();

            ListView list = (ListView)FindViewById(Resource.Id.listView1);
            TextView text = (TextView)FindViewById(Resource.Id.editText1);
            TextView rsm_yolu = (TextView)FindViewById(Resource.Id.editText2);
            Button btn = (Button)FindViewById(Resource.Id.button1);
            int k_id = Intent.GetIntExtra("extraKullaniciId", 1);
            int selected_ders = Intent.GetIntExtra("selectedvalue", 1);
            List<String> listeYorum = new List<String>();
            listeYorum.AddRange(servis.YorumlariGetir(selected_ders));           
            ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, 
                Android.Resource.Layout.SimpleListItem1, listeYorum);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            list.SetAdapter(adapter);
            list.Clickable = false;
            btn.Click += delegate
            {
                String yorum = text.Text;
                String resim_yolu = rsm_yolu.Text;
                Boolean cevap =servis.YorumEkle(yorum, resim_yolu, k_id, selected_ders);
                if (cevap == true)
                {
                    Toast.MakeText(this, "Yorum baþarýyla eklendi...", ToastLength.Short).Show();
                    text.Text = "";
                }
                else
                    Toast.MakeText(this, "Yorum ekleme baþarýsýz...", ToastLength.Short).Show();
            };
        }
    }
}