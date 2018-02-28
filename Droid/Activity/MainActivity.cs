using System;
using System.Collections.Generic;
using System.Collections;

using Android.App;
using Android.Views;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Widget;

using Techserv.Droid.Adapter;
using Techserv.Droid.Model;
using Android.Content;

namespace Techserv.Droid
{
     
    [Activity(Label = "Techserv", Theme = "@style/Theme.Techserv", Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {
        private List<Job> mListItems;
        ListView listView;

        DrawerLayout drawerLayout;
        NavigationView navigationView;

        protected override void OnCreate(Bundle bundle)  
        {  
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.main_screen);
            SetupDrawer();
            SetupListView();
        }  
        void setupDrawerContent(NavigationView navigationView)  
        {  
            navigationView.NavigationItemSelected += (sender, e) =>  
            {  
                e.MenuItem.SetChecked(true);  
                drawerLayout.CloseDrawers();  
            };  
        }  
        public override bool OnCreateOptionsMenu(IMenu menu)  
        {  
            //Navigation Drawer Layout Menu Creation
            navigationView.InflateMenu(Resource.Menu.nav_menu);  
            return true;  
        } 

        void SetupDrawer()
        {
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            // Create ActionBarDrawerToggle button and add it to the toolbar  
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, 
                                                         toolbar, 
                                                         Resource.String.drawer_open, 
                                                         Resource.String.drawer_close);
            drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            setupDrawerContent(navigationView); //Calling Function
        }

        void SetupListView()
        {
            listView = (ListView) FindViewById<ListView>(Resource.Id.job_listview);

            mListItems = new List<Job>();
            mListItems.Add(new Job(100101));


            JobAdapter adapter = new JobAdapter(this, mListItems);
            listView.Adapter = adapter;

            listView.ItemClick += (sender, e) =>
            {
                long id = listView.GetItemIdAtPosition(e.Position);
                PresentJobActivity(id);
            };
        }

        void PresentJobActivity(long jobId)
        {
            var intent = new Intent(this, typeof(JobActivity));
            intent.SetFlags(ActivityFlags.NewTask);
            intent.PutExtra(Constants.JOB_ID, jobId);
            StartActivity(intent);
        }
    }
}