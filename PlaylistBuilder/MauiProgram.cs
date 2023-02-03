global using Microsoft.Extensions.Logging;
global using PlaylistBuilder.ViewModels;
global using PlaylistBuilder.Views;
global using PlaylistBuilder.Models;

global using TinyMvvm;

global using CommunityToolkit;
global using CommunityToolkit.Mvvm.Input;
global using PlaylistBuilder.Services;

global using System.Text.Json.Serialization;
global using System;
global using System.Net;
global using System.Text;
global using System.Text.Json;


namespace PlaylistBuilder;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddTransient<LoginViewModel>();

		builder.Services.AddTransient<LoginView>();

		builder.Services.AddSingleton<ISpotifyService, SpotifyService>();

        return builder.Build();
	}
}

