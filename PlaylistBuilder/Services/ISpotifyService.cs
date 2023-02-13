using System;
namespace PlaylistBuilder.Services;

public interface ISpotifyService
{
    Task<bool> Initialize(string authCode);
    Task<bool> IsSignedIn();

    Task<SearchResult> Search(string searchText, string types);
}

