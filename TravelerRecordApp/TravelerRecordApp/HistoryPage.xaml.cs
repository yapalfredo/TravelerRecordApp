﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelerRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryPage : ContentPage
	{
		public HistoryPage ()
		{
			InitializeComponent ();
		}

        //Executed everytime we navigate
        //to this page  (which is also the
        // requires connection database)
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            /*using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();
                listViewPost.ItemsSource = posts;
            }*/

            //var posts = await App.MobileService.GetTable<Post>().Where(p => p.UserID == App.user.Id).ToListAsync();
            var posts = await Post.Read();
            listViewPost.ItemsSource = posts;
        }

        private void ListViewPost_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            //casting using "as" because it's an object
            var selectedPost = listViewPost.SelectedItem as Post;

            //this will launch a content page
            //if the selection is not NULL
            if (selectedPost != null)
            {
                Navigation.PushAsync(new PostDetailPage(selectedPost));
            }
        }
    }
}