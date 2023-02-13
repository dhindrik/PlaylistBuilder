namespace PlaylistBuilder.ViewModels;

public partial class LoginViewModel : ViewModel
{
	public LoginViewModel(ISpotifyService spotifyService)
	{
            this.spotifyService = spotifyService;
        }

        public async override Task Initialize()
        {
            await base.Initialize();

		IsBusy = true;

		try
		{
			if (await spotifyService.IsSignedIn())
			{
				await Navigation.NavigateTo("//Home");
			}
		}
		catch (Exception ex)
		{
			await HandleException(ex);
		}

		IsBusy = false;
        }

        [ObservableProperty]
	private bool showLogin;
        private readonly ISpotifyService spotifyService;

        [RelayCommand]
	public void OpenLogin()
	{
		ShowLogin = true;
	}

	public async Task HandleAuthCode(string code)
	{
		var result = await spotifyService.Initialize(code);

		if(result)
		{
			await Navigation.NavigateTo("Home");
		}
	}
}

