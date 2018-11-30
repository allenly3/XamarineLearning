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
    class ContentAdatper:BaseAdapter<ContentOject>
    {
        private List<ContentOject> items;
        private Context context;

        public ContentAdatper(Context context, List<ContentOject> items)
        {
            this.context = context;
            this.items = items;
        }

        public override ContentOject this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
      
            if(position%2==0)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.instruction, null, false);

            }
            else
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.instruction1, null, false);
            }
            TextView num = row.FindViewById<TextView>(Resource.Id.num);
            TextView title = row.FindViewById<TextView>(Resource.Id.Title);

            num.Text = items[position].num;
            title.Text = items[position].name;

            return row;
        }
    }
}