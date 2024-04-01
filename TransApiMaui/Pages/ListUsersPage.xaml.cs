using TransApiMaui.Models;

namespace TransApiMaui.Pages;

public partial class ListUsersPage : ContentPage
{
	public ListUsersPage(List<UserInfo> lsUserInfo)
	{
		InitializeComponent();
        UserListView.ItemsSource = lsUserInfo;
    }
}