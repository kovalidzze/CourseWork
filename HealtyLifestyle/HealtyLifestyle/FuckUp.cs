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

namespace HealtyLifestyle
{
    [Activity(Label = "FuckUp")]
    public class FuckUp : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.FuckUpLayout);

            var ab = new Intent(this, typeof(LL1));
            var ba = new Intent(this, typeof(LL2));

            var a = new Dictionary<string, Intent> {
                {"a", ab},
                {"b", ba}
            };

            var tt = new List<string>
            {
                "a",
                "b"
            };


            var lv = FindViewById<ListView>(Resource.Id.fuckUpList);
            var b = new List<string>();
            foreach (var item in a) // под андроед пишут непонятые гении. Юзайте веб разработку по андр)0))) 
            {
                b.Add(item.Key);
            }



            var adapterForResults = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, b);
            lv.Adapter = adapterForResults; // кек да я говнокодер, сами под ведроед пишите


            lv.ItemClick += my_Click_matherFUCKER;

            void my_Click_matherFUCKER(object sender, AdapterView.ItemClickEventArgs e)
            {
                //resultsNames = new List<string>();
                //Toast.MakeText(this, Results.results[e.Position].Name, ToastLength.Short).Show(); // БЛЯТЬ АДДд

                //Results.GetAll().RemoveAt(e.Position);
                //JsonSaver.Save(resultsTable);
                //RefreshResults(resultsList);

                StartActivity(a[tt[e.Position]]);
            }





        }
    }
}
