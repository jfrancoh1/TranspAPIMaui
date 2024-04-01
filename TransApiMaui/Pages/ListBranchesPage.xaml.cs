using TransApiMaui.Models;

namespace TransApiMaui.Pages;

public partial class ListBranchesPage : ContentPage
{
	public ListBranchesPage(List<BranchInfo> lsBranchInfo)
	{
		InitializeComponent();
        UserListView.ItemsSource = lsBranchInfo;
    }
}