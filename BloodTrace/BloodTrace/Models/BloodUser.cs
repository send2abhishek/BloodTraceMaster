using System;
using System.Collections.Generic;
using System.Text;

namespace BloodTrace.Models
{
    public class BloodUser
    {

        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }


        public string Country { get; set; }

        
        public string BloodGroup { get; set; }
        public string Imagepath { get; set; }

        public string FullLogoPath
        {

            get
            {
                if (string.IsNullOrEmpty(Imagepath)){

                    return string.Empty;
                }

                return String.Format("http://bloodtr.azurewebsites.net/{0}", Imagepath.Substring(1));
            }
        }

        public int Date { get; set; }

        public byte[] ImageArray { get; set; }
    }
}

