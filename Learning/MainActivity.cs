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
            a.firstName = "ALlen";
            a.lastName = "LIU";
            a.age = "Guess";
            a.gender = "Male";
            mItems.Add(a);

            mItems.Add(new Person() { firstName = "Lebron", lastName = "James", age = "34", gender = "Male" });
            mItems.Add(new Person() { firstName = "Chris", lastName = "Paul", age = "34", gender = "Male" });




            MyListViewAdapter adapter = new MyListViewAdapter(this, mItems);
            

            mListView.Adapter = adapter;




        }
    }
}