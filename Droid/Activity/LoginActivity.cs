
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;

namespace Techserv.Droid
{
    [Activity(Label = "LoginActivity", MainLauncher = true)]
    public class LoginActivity : Activity
    {
        FrameLayout progressBarHolder;
        AlphaAnimation inAnimation;
        AlphaAnimation outAnimation;

        Button loginBtn;
        EditText usernameEditText;
        EditText passwordEditText;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle); 
            SetContentView(Resource.Layout.login);
            SetupBtnAndFields();
        }

        void SetupBtnAndFields()
        {
            progressBarHolder = FindViewById<FrameLayout>(Resource.Id.progress_bar_holder);
            loginBtn = FindViewById<Button>(Resource.Id.login_button);
            usernameEditText = FindViewById<EditText>(Resource.Id.username_edit_text);
            passwordEditText = FindViewById<EditText>(Resource.Id.password_edit_text);

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
            ShowProgressBar();

            //TODO: Check login information here
            return false;
        }

        void ShowProgressBar()
        {
            inAnimation = new AlphaAnimation(0f, 1f);
            inAnimation.Duration = 200;
            progressBarHolder.Animation = inAnimation;
            progressBarHolder.Visibility = ViewStates.Visible;
        }

        void HideProgressBar()
        {
            outAnimation = new AlphaAnimation(1f, 0f);
            inAnimation.Duration = 200;
            progressBarHolder.Animation = outAnimation;
            progressBarHolder.Visibility = ViewStates.Gone;
        }
    }
}
