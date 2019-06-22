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





        private Dictionary<string, string> a = new Dictionary<string, string> {
            {"Hello", "word"}
        };

        private void RefreshResults(ListView listView)
        {
            var b = new List<string>();
            foreach (var item in a) // под андроед пишут непонятые гении. Юзайте веб разработку по андр)0))) 
            {
                b.Add(item.Key);
            }

            var adapterForResults = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, b);
            listView.Adapter = adapterForResults; // кек да я говнокодер, сами под ведроед пишите
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.FuckUpLayout);



            var lv = FindViewById<ListView>(Resource.Id.fuckUpList);


            RefreshResults(lv);
        }
    }
}
