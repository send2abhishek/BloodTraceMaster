using BloodTrace.Pages;
using BloodTrace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BloodTrace
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignInPage : ContentPage
	{
		public SignInPage()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {

            ApiServices services = new ApiServices();
            bool response = await services.LoginUser(EntEmail.Text, EntPassword.Text);

            if (!response)
            {
                await DisplayAlert("Alert", "Something Wrong..", "Cancel");
            }

            else
            {
                //here we want to add homepage before signPage if user Successful logins
                Navigation.InsertPageBefore(new HomePage(), this);
                await Navigation.PopAsync();
            }

        }

        private void TapSignUp_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }
    }
}