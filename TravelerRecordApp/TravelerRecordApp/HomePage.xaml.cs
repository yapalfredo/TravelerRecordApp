using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerRecordApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelerRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : TabbedPage
	{
        HomeVM viewModel;

		public HomePage ()
		{
			InitializeComponent ();
            viewModel = new HomeVM();
            BindingContext = viewModel;
		}


        // ---- NOT NEEDED ANYMORE WHEN USING ICOMMAND
        //------------------------------------------------------------------
        //private void ToolbarItem_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new NewTravelPage());
        //}
    }
}