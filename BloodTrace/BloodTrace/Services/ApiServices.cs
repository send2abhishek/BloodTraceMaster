using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BloodTrace.Models;
using Newtonsoft.Json;

namespace BloodTrace.Services
{
    public class ApiServices
    {

        public async Task<bool> RegisterUser(string email,string password,string confirmPassword)
        {
            var RegisterModel = new RegisterModel()
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };
            // httpClient is used for Couminicate With the server
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(RegisterModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var resposne =await httpClient.PostAsync("http://bloodtr.azurewebsites.net/api/Account/Register", content);
            return resposne.IsSuccessStatusCode;
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>() {

                new KeyValuePair<string,string>("username",email),
                new KeyValuePair<string,string>("password", password),
                new KeyValuePair<string,string>("grant_type","password"),
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "http://bloodtr.azurewebsites.net/Token");

            //In this we are posting data in form of Url Encode 
            request.Content = new FormUrlEncodedContent(keyValues);

            // httpClient is used for Couminicate With the server
            var httpClient = new HttpClient();
            var resposne = await httpClient.SendAsync(request);

            //to read the response from the server
            var content = resposne.Content.ReadAsStringAsync();
            return resposne.IsSuccessStatusCode;
        }

        public async Task<List<BloodUser>> FindBlood(string country, string bloodType)
        {

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers
                .AuthenticationHeaderValue("bearer", "we will add later");
            var bloodApiUrl = "http://bloodtr.azurewebsites.net/api/BloodUsers";

            //httpClient.GetStringAsync(http://bloodtr.azurewebsites.net/api/BloodUsers?bloodGroup="+bloodType + "&country="+country);

            var json=await httpClient.GetStringAsync($"{bloodApiUrl}?bloodGroup={bloodType}&country={country}");

            return JsonConvert.DeserializeObject<List<BloodUser>>(json);
        }


        public async Task<List<BloodUser>> LatestBloodUser()
        {

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers
                .AuthenticationHeaderValue("bearer", "we will add later");
            var bloodApiUrl = "http://bloodtr.azurewebsites.net/api/BloodUsers";

            var json = await httpClient.GetStringAsync(bloodApiUrl);

            return JsonConvert.DeserializeObject<List<BloodUser>>(json);
        }


        public async Task<bool> RegisterDonar(BloodUser bloodUser)
        {

            var json = JsonConvert.SerializeObject(bloodUser);
            var httpClient = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var resposne = await httpClient.PostAsync("http://bloodtr.azurewebsites.net/api/BloodUsers", content);
            return resposne.IsSuccessStatusCode;
        }
    }
}
