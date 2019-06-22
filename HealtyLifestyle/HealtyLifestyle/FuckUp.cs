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
        private List<string> fuckUpDisp = new List<string>();

        private Dictionary<string, string> a = new Dictionary<string, string> {
            {"Hello", "word"}
        };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var lv = FindViewById<ListView>(Resource.Id.fuckUpList);
            foreach(var item in a)
            {
                fuckUpDisp.Add(item.Key);
            }

            var adapterForResults = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, fuckUpDisp);
            lv.Adapter = adapterForResults; // кек да я говнокодер, сами под ведроед пишите
        }
    }
}
