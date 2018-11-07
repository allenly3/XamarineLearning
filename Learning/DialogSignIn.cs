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
    class DialogSignIn:DialogFragment
    {

        private EditText gUserName;
        private EditText gPassword;
 
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
             base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_signin, container, false);

            gUserName = view.FindViewById<EditText>(Resource.Id.username);
            gPassword = view.FindViewById<EditText>(Resource.Id.password);
     

            
            return view;

        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;


            Dialog.Window.Attributes.Width = Convert.ToInt32(0.8 * ViewGroup.LayoutParams.MatchParent);
            Dialog.Window.Attributes.Height = ViewGroup.LayoutParams.WrapContent;
        }
    }
}