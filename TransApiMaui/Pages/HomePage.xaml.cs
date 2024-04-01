using Microsoft.Maui.ApplicationModel.Communication;
using TransApiMaui.Models;
using TransApiMaui.Services;

namespace TransApiMaui.Pages;

public partial class HomePage : ContentPage
{
    private readonly string _tokenuser;
    private readonly IUsersRepository _usersRepository = new UsersService();
    private readonly IBranchesRepository _branchesRepository = new BranchesService();
    public HomePage(ResponseLogin responseLogin)
	{
		InitializeComponent();
        UserNameLabel.Text = $"Nombre: {responseLogin.user.name}";
        UserLastNameLabel.Text = $"Apellido: {responseLogin.user.lastName}";
        UserPhoneNumberLabel.Text = $"Teléfono: {responseLogin.user.phoneNumber}";
        UserDocumentLabel.Text = $"Documento: {responseLogin.user.document}";
        _tokenuser = responseLogin.token;
    }

    private async void Users_Clicked(object sender, EventArgs e)
    {
        ResponseDto<List<UserInfo>> responseLogin = await _usersRepository.GetAll(_tokenuser);
        if (responseLogin.Response == "200")
        {
            await Navigation.PushAsync(new ListUsersPage(responseLogin.Data));
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

    private async void Branches_Clicked(object sender, EventArgs e)
    {
        ResponseDto<List<BranchInfo>> responseLogin = await _branchesRepository.GetAll(_tokenuser);
        if (responseLogin.Response == "200")
        {
            await Navigation.PushAsync(new ListBranchesPage(responseLogin.Data));
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