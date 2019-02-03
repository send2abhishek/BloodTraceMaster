using BloodTrace.Services;
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
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            ApiServices services = new ApiServices();

            bool response = await services.RegisterUser(RgtEmail.Text, RgtPassword.Text, RgtCPassword.Text);

            if (!response)
            {
                await DisplayAlert("Alert", "Something went wrong...", "Cancel");
            }
            else
            {
                await DisplayAlert("Hi", "Your Account Created...", "Okay");

                await Navigation.PopToRootAsync();
            }
        }

        private void RgtEmail_Focused(object sender, FocusEventArgs e)
        {

            
            //if ((emailText.Length) < 10)
            //{
            //    labelTest.Text = "Error occured";
            //}
        }
    }
}