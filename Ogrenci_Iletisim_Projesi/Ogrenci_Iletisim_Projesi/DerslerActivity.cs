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
    [Activity(Label = "DerslerActivity")]
    public class DerslerActivity : Activity
    {

       static List<String> idListe = new List<String>();
       static List<int> idIntListe = new List<int>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Dersler);
            ListView myListView = (ListView)FindViewById(Resource.Id.listView1);
            int sinif = Intent.GetIntExtra("extraSinif", 1);
            int bolum = Intent.GetIntExtra("extraBolum", 1);
            int k_id = Intent.GetIntExtra("extraKullaniciId", 1);
            List<String> dersListe = new List<String>();
            WebService.Service1 servis = new WebService.Service1();
            idListe.AddRange(servis.DersIdCek(bolum, sinif));
            listeIntCevir(idListe);
            dersListe.AddRange(servis.DersAdiCek(bolum, sinif));
            ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, + 
                Android.Resource.Layout.SimpleListItem1, dersListe);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);        
            myListView.SetAdapter(adapter);

            myListView.ChoiceMode = ChoiceMode.Single;
            myListView.Clickable = true;
            myListView.ItemClick += (object sender, Android.Widget.AdapterView.ItemClickEventArgs e)=>
            {
                string selectedFromList = myListView.GetItemIdAtPosition(e.Position).ToString();
                int selectedvalue = Convert.ToInt32(selectedFromList);
                selectedvalue = idIntListe[selectedvalue];
                var intent = new Intent(this, typeof(YorumlarActivity));
                intent.PutExtra("selectedvalue", selectedvalue);
                intent.PutExtra("extraKullaniciId", k_id);
                StartActivity(intent);
            };
        }
       
        public void listeIntCevir(List<String> a)
        {
            foreach(String b in a)
            {
                idIntListe.Add(Convert.ToInt32(b));
            }
        }
    }
}
