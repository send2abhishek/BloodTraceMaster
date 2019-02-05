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
	public partial class FindBlood : ContentPage
	{
		public FindBlood ()
		{
			InitializeComponent ();
            
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            string country = FindCountry.Items[FindCountry.SelectedIndex];
            string bloodGroup = BloodGroup.Items[BloodGroup.SelectedIndex].Trim().Replace("+", "%2B");

            Navigation.PushAsync(new DonorListPage(country, bloodGroup));
        }
    }
}