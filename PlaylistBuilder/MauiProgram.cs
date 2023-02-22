global using Microsoft.Extensions.Logging;
global using PlaylistBuilder.ViewModels;
global using PlaylistBuilder.Views;
global using PlaylistBuilder.Models;
global using PlaylistBuilder.Services;


global using TinyMvvm;

global using CommunityToolkit;
global using CommunityToolkit.Mvvm.Input;
global using CommunityToolkit.Mvvm.ComponentModel;

global using System.Text.Json.Serialization;
global using System;
global using System.Net;
global using System.Text;
global using System.Text.Json;
global using System.Windows.Input;
global using System.Collections.ObjectModel;

global using CommunityToolkit.Maui;

namespace PlaylistBuilder;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.UseTinyMvvm()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<ArtistViewModel>();

        builder.Services.AddTransient<LoginView>();
        builder.Services.AddTransient<HomeView>();
        builder.Services.AddTransient<ArtistView>();

        builder.Services.AddSingleton<ISpotifyService, SpotifyService>();
        builder.Services.AddSingleton<ISecureStorageService, SecureStorageService>();

		RegisterRoutes();

        return builder.Build();
	}

	private static void RegisterRoutes()
	{
		Routing.RegisterRoute("Artist", typeof(ArtistView));
	}
}

