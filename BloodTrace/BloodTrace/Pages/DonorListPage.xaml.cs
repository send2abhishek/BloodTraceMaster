using BloodTrace.Models;
using BloodTrace.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BloodTrace.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DonorListPage : ContentPage
	{

        public ObservableCollection<BloodUser> BloodUsers;
        private string country;
        private string bloodGroup;

        public DonorListPage (string country, string bloodGroup)
		{
			InitializeComponent ();
            this.country = country;
            this.bloodGroup = bloodGroup;
            BloodUsers = new ObservableCollection<BloodUser>();

            FindBloodDonors();

        }

        private async void FindBloodDonors()
        {

            ApiServices apiServices = new ApiServices();
            var bloodUsers = await apiServices.FindBlood(country, bloodGroup);

            foreach(var bloodUser in bloodUsers)
            {

                BloodUsers.Add(bloodUser);
            }

            LvBoodDonors.ItemsSource = BloodUsers;
        }

        private void LvBoodDonors_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedDonor = e.SelectedItem as BloodUser;

            if(selectedDonor != null)
            {
                Navigation.PushAsync(new DonorProfilePage(selectedDonor));
            }

            ((ListView)sender).SelectedItem = null;
            
        }
    }
}