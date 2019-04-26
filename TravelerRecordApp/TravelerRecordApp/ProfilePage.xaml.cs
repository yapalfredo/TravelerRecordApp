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
                var postTable = await App.MobileService.GetTable<Post>().ToListAsync();

                    var categories = (from p in postTable
                                      orderby p.CategoryID
                                      select p.CategoryName).Distinct().ToList();

                    //Same as above LINQ
                    //var categories2 = postTable.OrderBy(p => p.CategoryID).Select(p => CategoryName).Distinct().ToList();

                    Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
                    foreach (var category in categories)
                    {
                        var count = (from p in postTable
                                     where p.CategoryName == category
                                     select p).ToList().Count;

                        //The same thing as above as well 
                        //var count2 = postTable.Where(p => p.CategoryName == category).ToList().Count;

                        categoriesCount.Add(category, count);
                    }

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