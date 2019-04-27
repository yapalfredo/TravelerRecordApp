using SQLite;
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
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                // using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                //{
                // var postTable = conn.Table<Post>().ToList();
                //Just trying to see if I can push this to github
                var postTable = await Post.Read();

                var categoriesCount = Post.PostCategories(postTable);

                listViewCategories.ItemsSource = categoriesCount;
                labelPostCount.Text = postTable.Count.ToString();

               // }
            }
            catch (NullReferenceException nre)
            {
                await DisplayAlert("Error", nre.Message, "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
            
          
        }
    }
}