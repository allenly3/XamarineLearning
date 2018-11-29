using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;

namespace Learning
{
    public class SlidingTabsFragment : Fragment
    {
        private SlidingTabScrollView mSlidingTabScrollView;
        private ViewPager mViewPager;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_sample, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            mSlidingTabScrollView = view.FindViewById<SlidingTabScrollView>(Resource.Id.sliding_tabs);
            mViewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager);
            mViewPager.Adapter = new SamplePagerAdapter(this.Context);

            mSlidingTabScrollView.ViewPager = mViewPager;
        }

        public class SamplePagerAdapter : PagerAdapter
        {
            List<string> items = new List<string>();
            private List<Person> mItems;
            Context context;


            public SamplePagerAdapter(Context context) : base()
            {
                items.Add("Instruction");
                items.Add("Video");
                this.context = context;

            }

            public override int Count
            {
                get { return items.Count; }
            }

            public override bool IsViewFromObject(View view, Java.Lang.Object obj)
            {
                return view == obj;
            }

            public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
            {
                View view = LayoutInflater.From(container.Context).Inflate(Resource.Layout.pager_item, container, false);
                container.AddView(view);

                TextView txtTitle = view.FindViewById<TextView>(Resource.Id.item_title);
                int pos = position + 1;
                //txtTitle.Text = pos.ToString();

                ListView lv = view.FindViewById<ListView>(Resource.Id.myListView);
                if (pos == 1)
                {
                    

                    mItems = new List<Person>();
                    Person a = new Person();
                    a.firstName = "Allen";
                    a.lastName = "LIU";
                    a.age = "Guess";
                    a.gender = "Male";
                    mItems.Add(a);

                    mItems.Add(new Person() { firstName = "Lebron", lastName = "James", age = "34", gender = "Male" });
                    mItems.Add(new Person() { firstName = "Chris", lastName = "Paul", age = "34", gender = "Male" });
                }
                else
                {
                    

                    mItems = new List<Person>();
                    Person a = new Person();
                    a.firstName = "YIIIIIIIIII";
                    a.lastName = "LIUUUUUUU";
                    a.age = "Guess";
                    a.gender = "Male";
                    mItems.Add(a);

                    mItems.Add(new Person() { firstName = "Kobe", lastName = "James", age = "34", gender = "Male" });
                    mItems.Add(new Person() { firstName = "HAHA", lastName = "Paul", age = "34", gender = "Male" });

                }



                MyListViewAdapter adapter = new MyListViewAdapter(context, mItems);


                lv.Adapter = adapter;
                return view;
            }

            public string GetHeaderTitle (int position)
            {
                return items[position];
            }

            public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object obj)
            {
                container.RemoveView((View)obj);
            }
        }
    }
}