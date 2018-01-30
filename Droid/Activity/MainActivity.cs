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
            SetContentView(Resource.Layout.Main);
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
            mListItems.Add(new Job(1));

            JobAdapter adapter = new JobAdapter(this, mListItems);

            //listView.SetAdapter(adapter);
            listView.Adapter = adapter;
        }
    }
}