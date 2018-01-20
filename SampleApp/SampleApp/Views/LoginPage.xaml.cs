using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            img.Source = "icon.png";
            btnLogin.Clicked += async (s, e) =>
            {
                if (!string.IsNullOrEmpty(uname.Text) && !string.IsNullOrEmpty(pass.Text))
                {
                    Dictionary<string, string> formParam = new Dictionary<string, string>();
                    formParam.Add("Email", uname.Text);
                    formParam.Add("Password", pass.Text);



                    if (uname.Text.Equals("Sumeet") && pass.Text.Equals("123456"))
                    {
                        UserInformation.Username = uname.Text;
                       // UserInformation.Image = "https://lh3.googleusercontent.com/-0Olet6FXcxA/AAAAAAAAAAI/AAAAAAAAAAA/3_ZjPngHGYQ/s128-c-k/photo.jpg";
                        App.Current.MainPage = new MenuPage();

                        //your authentication call here
                        //result = await Controller.UserController.Authenticate(formParam); 
                    }
                    else
                    {
                        await DisplayAlert("Login Failed", "Username or Password is incorrect", "OK");
                    }  
                }
                else
                {
                    await DisplayAlert("Username And Password Required", "Please Check the internat connection", "OK");
                } 

            };
        }
    }
}
