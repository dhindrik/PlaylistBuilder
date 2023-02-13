namespace PlaylistBuilder.Views;

public partial class HomeView
{
    private readonly HomeViewModel homeViewModel;

    public HomeView(HomeViewModel homeViewModel)
	{
		InitializeComponent();
        this.homeViewModel = homeViewModel;

        BindingContext = homeViewModel;
    }
}
