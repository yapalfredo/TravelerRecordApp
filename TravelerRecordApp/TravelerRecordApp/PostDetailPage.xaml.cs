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
	public partial class PostDetailPage : ContentPage
	{

        //global variable type <Post> to be used
        //for capturing the object from HistoryPage
        Post selectedPost;

        //here the selected item from the HistoryPage
        //is passed through the constructor for this page
		public PostDetailPage (Post selectedPost)
		{
			InitializeComponent ();

            this.selectedPost = selectedPost;
            entryExperience.Text = selectedPost.Experience;

		}

        private void ButtonUpdate_Clicked(object sender, EventArgs e)
        {
            selectedPost.Experience = entryExperience.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(selectedPost);
                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience successfully updated", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Experience failed to be updated", "Ok");
                }
            }
        }

        private void ButtonDelete_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(selectedPost);
                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience successfully deleted", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Experience failed to be deleted", "Ok");
                }
            }
        }
    }
}