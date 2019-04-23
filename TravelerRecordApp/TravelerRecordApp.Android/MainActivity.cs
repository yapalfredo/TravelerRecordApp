﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Plugin.Permissions;

namespace TravelerRecordApp.Droid
{
    [Activity(Label = "TravelerRecordApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            
            //--- This line is used for initializing the MAPS 
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            //------------------------------------------------

            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);


            //these 3 lines will be used for loading sqlite-----
            string dbName = "travel_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fullpath = Path.Combine(folderPath, dbName);
            //---------------------------------------------------

            LoadApplication(new App(fullpath));
        }


        //This is only done in Android
        //Not require for iOS
        //This will make sure that it will ask user
        //to give permission for the maps
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}