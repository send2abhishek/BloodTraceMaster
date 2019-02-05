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

        private void TapGestureRecognizer_TappedFindBood(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FindBlood());
        }

        private void TapGestureRecognizer_Register(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterBlood());
        }
        private void TapGestureRecognizer_LatestDonor(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LatestBlood());
        }
        private void TapGestureRecognizer_Help(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HelpDonar());
        }
    }
}