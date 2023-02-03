using System;
using CommunityToolkit.Mvvm.ComponentModel;
using PlaylistBuilder.Services;

namespace PlaylistBuilder.ViewModels
{
	public partial class LoginViewModel : ViewModel
	{
		public LoginViewModel(ISpotifyService spotifyService)
		{
            this.spotifyService = spotifyService;
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
			await spotifyService.Initialize(code);
		}
	}
}

