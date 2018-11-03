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

namespace Learning
{
    public class SubmitEventArgs : EventArgs
    {
        private string name;
        private string email;
        private string password;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        
        public SubmitEventArgs(string n,string e,string p):base()
        {
            Name = n;
            Email = e;
            Password = p;   
        }

    }

    class DialogSignUp:DialogFragment 
    {

        private EditText gUserName;
        private EditText gEmail;
        private EditText gPassword;
        private Button gButton;

        public event EventHandler<SubmitEventArgs> sumbitComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_signup, container, false);

            gUserName = view.FindViewById<EditText>(Resource.Id.username);
            gEmail = view.FindViewById<EditText>(Resource.Id.email);
            gPassword = view.FindViewById<EditText>(Resource.Id.password);
            gButton = view.FindViewById<Button>(Resource.Id.button1);

            gButton.Click += submit;

            return view;
        }
        
        private void submit(Object sender, EventArgs e)
        {
            sumbitComplete.Invoke(this, new SubmitEventArgs(gUserName.Text,gEmail.Text,gPassword.Text));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {

            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);// set the title bar to invisible

            base.OnActivityCreated(savedInstanceState);

            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;//set the animation

             

            Dialog.Window.Attributes.Width =Convert.ToInt32(0.8*ViewGroup.LayoutParams.MatchParent);
            Dialog.Window.Attributes.Height = ViewGroup.LayoutParams.WrapContent;

        }
 
    }
}