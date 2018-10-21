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
using Java.Lang;

namespace Learning
{
    class MyListViewAdapter : BaseAdapter<Person>
    {

        private List<Person> mItems;
        private Context mContext;
        public MyListViewAdapter(Context context,List<Person> items)
        {
           mItems = items;
            mContext = context;
        }

       

        public override int Count
        {
            get
            {
                return mItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Person this[int position]
        {
            get
            {
                return mItems[position];
            }
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if(row==null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.row, null, false);
            }
            TextView firstName = row.FindViewById<TextView>(Resource.Id.fName);
            TextView lastName = row.FindViewById<TextView>(Resource.Id.lName);
            TextView age = row.FindViewById<TextView>(Resource.Id.age);
            TextView gender = row.FindViewById<TextView>(Resource.Id.gender);

            firstName.Text = mItems[position].firstName;
            lastName.Text = mItems[position].lastName;
            age.Text = mItems[position].age;
            gender.Text = mItems[position].gender;

            return row;
        }


    }
}