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
	public partial class DonorProfilePage : ContentPage
	{

        private string _email;
        private string _phoneNbr;
		public DonorProfilePage (BloodUser bloodUser)
		{
			InitializeComponent ();

            ImgDonor.Source = bloodUser.FullLogoPath;
            LblDonorName.Text = bloodUser.UserName;
            lblBloodGroup.Text = bloodUser.BloodGroup;
            lblCountry.Text = bloodUser.Country;
            _email = bloodUser.Email;
            _phoneNbr = bloodUser.Phone;
        }
	}
}