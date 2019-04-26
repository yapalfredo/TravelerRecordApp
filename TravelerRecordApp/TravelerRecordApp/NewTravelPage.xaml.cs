using Plugin.Geolocator;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerRecordApp.Logic;
using TravelerRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelerRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTravelPage : ContentPage
	{
		public NewTravelPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = await VenueLogic.GetVenues(position.Latitude, position.Longitude);
            listViewVenue.ItemsSource = venues;

        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                var selectedVenue = listViewVenue.SelectedItem as Venue;
                var firstCategory = selectedVenue.categories.FirstOrDefault();

                Post post = new Post()
                {
                    Experience = entryExperience.Text,
                    CategoryID = firstCategory.id,
                    CategoryName = firstCategory.name,
                    Address = selectedVenue.location.address,
                    Distance = selectedVenue.location.distance,
                    Latitude = selectedVenue.location.lat,
                    Longitude = selectedVenue.location.lng,
                    VenueName = selectedVenue.name,
                    UserID = App.user.Id
                };

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

               await App.MobileService.GetTable<Post>().InsertAsync(post);
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