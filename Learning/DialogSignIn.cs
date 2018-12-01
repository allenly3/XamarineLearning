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
        private Button gSignInbt;
 
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
             base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_signin, container, false);

            gUserName = view.FindViewById<EditText>(Resource.Id.username);
            gPassword = view.FindViewById<EditText>(Resource.Id.password);
            gSignInbt = view.FindViewById<Button>(Resource.Id.bt1);

            gSignInbt.Click += GSignInbt_Click;
            
            return view;

        }

        private void GSignInbt_Click(object sender, EventArgs e)
        {
            
            if(gUserName.Text=="allenly3"&&gPassword.Text=="123")
            {
                Toast.MakeText(this.Context, "Successful", ToastLength.Long).Show();
                this.Dismiss();
            }
            else
            {
                Toast.MakeText(this.Context, "Failed", ToastLength.Long).Show();
                this.Dismiss();
            }
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