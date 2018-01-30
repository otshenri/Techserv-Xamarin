
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

namespace Techserv.Droid
{
    [Activity(Label = "LoginActivity", MainLauncher = true)]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle); 
            SetContentView(Resource.Layout.login);
            SetupBtnAndFields();
        }

        void SetupBtnAndFields()
        {
            Button loginBtn = FindViewById<Button>(Resource.Id.login_button);
            EditText usernameEditText = FindViewById<EditText>(Resource.Id.username_edit_text);
            EditText passwordEditText = FindViewById<EditText>(Resource.Id.password_edit_text);

            loginBtn.Click += delegate
            {
                String username = usernameEditText.Text;
                String password = passwordEditText.Text;

                if (IsCorrectCredentials(username, password))
                {
                    PresentMainActivity();
                }
                else 
                {
                    passwordEditText.Text = "";
                }
            };
        }

        void PresentMainActivity()
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.SetFlags(ActivityFlags.NewTask);
            StartActivity(intent);
            Finish();
        }

        private Boolean IsCorrectCredentials(String username, String password)
        {
            
            //TODO: Check login information here
            return false;
        }
    }
}
