using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.Data.SqlClient;
using System.Net;
using System.Collections.Specialized;

namespace Learning
{
    public class SubmitEventArgs : EventArgs
    {
        private string name;
        private string email;
        private string password;
        private string repassword;

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
        public string Repassword
        {
            get { return repassword; }
            set { repassword = value; }
        }
        
        public SubmitEventArgs(string n,string p):base()
        {
            Name = n;
      
            Password = p;   
        }

    }

    class DialogSignUp:DialogFragment 
    {

        private EditText gUserName;
        private EditText gEmail;
        private EditText gPassword;
        private EditText gRepassword;
        private Button gButton;
        private TextView gResult;

        public event EventHandler<SubmitEventArgs> sumbitComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_signup, container, false);

            gUserName = view.FindViewById<EditText>(Resource.Id.username);
            gEmail = view.FindViewById<EditText>(Resource.Id.email);
            gPassword = view.FindViewById<EditText>(Resource.Id.password);
            gRepassword = view.FindViewById<EditText>(Resource.Id.repassword);
            gButton = view.FindViewById<Button>(Resource.Id.button1);
            gResult = view.FindViewById<TextView>(Resource.Id.result);
            gButton.Click += submit;

            return view;
        }
        
        private void submit(Object sender, EventArgs e)
        {


            WebClient client = new WebClient();
            Uri uri = new Uri("http://127.0.0.1/index.php");

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("name", gUserName.Text);
            parameters.Add("password", gPassword.Text);

            client.UploadValuesCompleted += Client_UploadValuesCompleted;
            client.UploadValuesTaskAsync(uri, parameters);


        }

        private void Client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            sumbitComplete.Invoke(this, new SubmitEventArgs(gUserName.Text,  gPassword.Text));
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