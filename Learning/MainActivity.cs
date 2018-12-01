using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using System;
using Android.Views;
using Android.Content;

namespace Learning
{
    [Activity(Label = "@string/app_name", Theme = "@style/CustomActionBarTheme")]
    public class MainActivity : Activity
    {

        private List<Person> mItems;
        private ListView mListView;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            mListView = FindViewById<ListView>(Resource.Id.myListView);

           
            mItems = new List<Person>();
            Person a = new Person();
            a.firstName = "Allen";
            a.lastName = "LIU";
            a.age = "Guess";
            a.gender = "Male";
            mItems.Add(a);

            mItems.Add(new Person() { firstName = "Lebron", lastName = "YIIII", age = "34", gender = "Male" });
            mItems.Add(new Person() { firstName = "Chris", lastName = "LIU", age = "34", gender = "Male" });




            MyListViewAdapter adapter = new MyListViewAdapter(this, mItems);
            

            mListView.Adapter = adapter;


            mListView.ItemClick += itemClick;

            mListView.ItemLongClick += MListView_ItemLongClick;
 


        }

        private void MListView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            if (mItems[e.Position].firstName=="Allen")
            {
                var intent = new Intent(this, typeof(LoginPage));
                intent.PutExtra("f", mItems[e.Position].firstName);
                intent.PutExtra("l", mItems[e.Position].lastName);
                StartActivity(intent);
            }

            else if(mItems[e.Position].firstName== "Lebron")
            {
                Intent intent = new Intent(this, typeof(Swap));
                StartActivity(intent);
            }
            else
            {
                Intent intent = new Intent(this, typeof(Test));
                StartActivity(intent);

            }
        }

        private void itemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.WriteLine(mItems[e.Position].firstName);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }
    }
}