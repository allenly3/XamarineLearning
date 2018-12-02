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

namespace Learning
{
    [Activity(Label = "About")]
    public class About : Activity
    {

        ListView lv;
        ArrayAdapter mArrayAdapter;
        List<string> name = new List<string>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.about);
            // Create your application here

         
            lv = FindViewById<ListView>(Resource.Id.vvv);
            name.Add("COPY RIGHT");
            name.Add(" ");
            name.Add("YI LIU C0704825");
            name.Add("Vraj Shah C0714962");
            name.Add("Preksh Mehta C0705974");
            name.Add("Moez Narsidani C0716607");
            mArrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleExpandableListItem1, name);

            lv.Adapter = mArrayAdapter;

        }
    }
}
