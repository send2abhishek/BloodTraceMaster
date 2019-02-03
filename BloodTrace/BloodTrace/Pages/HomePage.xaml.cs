using BloodTrace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BloodTrace.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, true);
            
        }

        private void Tblogout_Clicked(object sender, EventArgs e)
        {

            Settings.UserName = "";
            Settings.Passsword = "";
            Settings.AccessToken = "";
            Navigation.InsertPageBefore(new SignInPage(),this);
            Navigation.PopAsync();
        }
    }
}