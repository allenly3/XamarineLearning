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
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class Swap : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

          

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
     
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            SlidingTabsFragment fragment = new SlidingTabsFragment();
            transaction.Replace(Resource.Id.sample_content_fragment, fragment);
            transaction.Commit();

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

    }
}