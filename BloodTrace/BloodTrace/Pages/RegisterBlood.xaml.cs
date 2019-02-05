using BloodTrace.Models;
using BloodTrace.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
	public partial class RegisterBlood : ContentPage
	{

        public MediaFile file;
		public RegisterBlood ()
		{
			InitializeComponent ();
		}

        private async void TapOpenCamera_Tapped(object sender, EventArgs e)
        {

            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

            ImgDonor.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });

        }

        private async void BtnSub_Clicked(object sender, EventArgs e)
        {
            var imageArray=FilesHelper.ReadFully(file.GetStream());
            file.Dispose();

            var country = pickerCountry.Items[pickerCountry.SelectedIndex];
            var bloodGroup = pickerBloodGroup.Items[pickerBloodGroup.SelectedIndex];

            var bloodUser = new BloodUser()
            {
                UserName = EntName.Text,
                Email=EntEmail.Text,
                Phone=EntPhone.Text,
                BloodGroup= bloodGroup,
                Country= country,
                ImageArray= imageArray

            };

            ApiServices sevices = new ApiServices();

            var response = await sevices.RegisterDonar(bloodUser);

            if (!response)
            {
                await DisplayAlert("Alert", "Something Went Wrong", "Cancel");
            }

            else
            {
                await DisplayAlert("Hi", "Your Record Has Been Added", "Okay");
            }
        }
    }
}