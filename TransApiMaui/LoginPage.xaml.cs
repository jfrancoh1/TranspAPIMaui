using TransApiMaui.Services;
using TransApiMaui.Models;
using TransApiMaui.Pages;

namespace TransApiMaui;

public partial class LoginPage : ContentPage
{
	private readonly ILoginRepository _loginRepository = new LoginService();
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void Login_Clicked(object sender, EventArgs e)
	{
		string userId=txtUserId.Text;
		string password=txtPassword.Text;
		if(userId == null || password == null)
		{
			await DisplayAlert("Warning", "Please Input UserId and Password", "Ok");
			return;
		}

        ResponseDto<ResponseLogin> responseLogin = await _loginRepository.Login(userId, password);
		if (responseLogin.Response == "200")
		{
			await Navigation.PushAsync(new HomePage(responseLogin.Data));
		}
        else if (responseLogin.Response == "401")
        {
            await DisplayAlert("Warning", "UserId or Password is incorrect", "Ok");
        }
        else
		{
            await DisplayAlert("Warning", "Internal Server Error", "Ok");
        }

    }
}