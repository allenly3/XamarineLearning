using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using ToolBar = Android.Support.V7.Widget.Toolbar;

namespace Learning
{
    [Activity(Label = "XamaringLearning",Theme ="@style/AppTheme", MainLauncher = true)]
    public class Test : AppCompatActivity
    {

        DrawerLayout mDrawerLayout;
        List<string> mLeftItems = new List<string>();

        ArrayAdapter mArrayAdapter;
        ListView mLeftDrawer;

        ActionBarDrawerToggle mtg;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.test);

            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            SlidingTabsFragment fragment = new SlidingTabsFragment();
            transaction.Replace(Resource.Id.sample_content_fragment, fragment);
            transaction.Commit();

            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.myDrawer);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.leftview);
            Android.Support.V7.App.ActionBar actionBar = this.SupportActionBar;

            mLeftItems.Add("Home");
            mLeftItems.Add("Login");
            mLeftItems.Add("Sign Up");
            mLeftItems.Add("About");

            mtg = new ActionBarDrawerToggle(this, mDrawerLayout, Resource.String.open_drawer, Resource.String.close_drawer);
            mArrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleExpandableListItem1, mLeftItems);

            mLeftDrawer.Adapter = mArrayAdapter;

            mDrawerLayout.SetDrawerListener(mtg);
            actionBar.SetDisplayHomeAsUpEnabled(true);
            actionBar.SetHomeButtonEnabled(true);

            mLeftDrawer.ItemClick += MLeftDrawer_ItemClick;

        }

        private void MLeftDrawer_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
           if(mLeftItems[e.Position]=="Login")
            {
                Intent intent = new Intent(this, typeof(LoginPage));
                StartActivity(intent);
            }
            else if (mLeftItems[e.Position] == "Sign Up")
            {
                Intent intent = new Intent(this, typeof(LoginPage));
                StartActivity(intent);
            }
 
           else if (mLeftItems[e.Position] == "About")
            {
                Intent intent = new Intent(this, typeof(About));
                StartActivity(intent);
            }
           else if(mLeftItems[e.Position] == "Home")
            {
                mDrawerLayout.CloseDrawers();
            }

        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            mtg.SyncState();
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (mtg.OnOptionsItemSelected(item))
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

    }
}