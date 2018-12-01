using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Learning
{
    [Activity(Label = "LoginPage",Theme = "@style/AppTheme")]
    public class LoginPage : Activity
    {

        private Button gbtSignin;
        private Button gbtSignup;
        private ProgressBar progressbar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Login);

    

            TextView tv= FindViewById<TextView>(Resource.Id.wel);

            tv.Text = "Welcome To Xamarin !";

            gbtSignup = FindViewById<Button>(Resource.Id.signup);
            gbtSignin = FindViewById<Button>(Resource.Id.signin);
            gbtSignup.Click += GbtSignup_click;
            gbtSignin.Click += GbtSignin_Click;

            progressbar = FindViewById<ProgressBar>(Resource.Id.progressBar1);
        }

        private void GbtSignin_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            DialogSignIn popWindow = new DialogSignIn();
            popWindow.Show(transaction, "dialog");
  
        }

        private void GbtSignup_click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            
            DialogSignUp popUpWindow = new DialogSignUp();
            popUpWindow.Show(transaction,"dialog");

            popUpWindow.sumbitComplete += PopUpWindow_sumbitComplete;
        }

        private void PopUpWindow_sumbitComplete(object sender, SubmitEventArgs e)
        {
            //at this step, we gonna send the information to the server
            progressbar.Visibility = ViewStates.Visible;
            Thread thread = new Thread(ActLikeARequest);
            thread.Start();
            string username = e.Name;
        }
        private void ActLikeARequest()
        {
            Thread.Sleep(3000);

            RunOnUiThread(() => { progressbar.Visibility = ViewStates.Invisible; });
        }
    }
}