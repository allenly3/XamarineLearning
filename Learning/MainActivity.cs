using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;

namespace Learning
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private List<string> mItems;
        private ListView mListView;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            mListView = FindViewById<ListView>(Resource.Id.myListView);

           
            mItems = new List<string>();
            mItems.Add("Bob");
            mItems.Add("Tom");
            mItems.Add("Jim");


            MyListViewAdapter adapter = new MyListViewAdapter(this, mItems);
            

            mListView.Adapter = adapter;




        }
    }
}