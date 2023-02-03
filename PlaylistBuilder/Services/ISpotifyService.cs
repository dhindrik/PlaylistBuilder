using System;
namespace PlaylistBuilder.Services;

public interface ISpotifyService
{
    Task<bool> Initialize(string authCode);
}

