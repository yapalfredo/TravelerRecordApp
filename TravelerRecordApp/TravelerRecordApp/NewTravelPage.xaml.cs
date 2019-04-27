using Plugin.Geolocator;
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
	public partial class NewTravelPage : ContentPage
	{
        Post post;
		public NewTravelPage ()
		{
			InitializeComponent ();
            post = new Post();
            stackLayoutContainer.BindingContext = post;
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = await Venue.GetVenues(position.Latitude, position.Longitude);
            listViewVenue.ItemsSource = venues;

        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                var selectedVenue = listViewVenue.SelectedItem as Venue;
                var firstCategory = selectedVenue.categories.FirstOrDefault();

                //Post post = new Post()
                //{
                //    Experience = entryExperience.Text,
                post.CategoryID = firstCategory.id;
                post.CategoryName = firstCategory.name;
                post.Address = selectedVenue.location.address;
                post.Distance = selectedVenue.location.distance;
                post.Latitude = selectedVenue.location.lat;
                post.Longitude = selectedVenue.location.lng;
                post.VenueName = selectedVenue.name;
                post.UserID = App.user.Id;
                //};

                /* using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                 {
                     conn.CreateTable<Post>();
                     int rows = conn.Insert(post);
                     if (rows > 0)
                     {
                         DisplayAlert("Success", "Experience successfully inserted", "Ok");
                     }
                     else
                     {
                         DisplayAlert("Failure", "Experience failed to be inserted", "Ok");
                     }
                 }*/

                //await App.MobileService.GetTable<Post>().InsertAsync(post);
               Post.Insert(post);
               await DisplayAlert("Success", "Experience successfully inserted", "Ok");

            }
            catch (NullReferenceException nre)
            {
              await DisplayAlert("Failure", nre.Message, "Ok");
            }
            catch (Exception ex)
            {
              await DisplayAlert("Failure", ex.Message, "Ok");
            }

           
        }
    }
}