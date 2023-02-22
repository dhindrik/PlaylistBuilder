namespace PlaylistBuilder.Views;

public partial class ArtistView
{
    private readonly ArtistViewModel viewModel;

    public ArtistView(ArtistViewModel viewModel)
	{
		InitializeComponent();
        this.viewModel = viewModel;

        BindingContext = viewModel;
    }
}
