namespace PlaylistBuilder.Services;

public class SpotifyService : ISpotifyService
{
    private string accessToken;

    public SpotifyService()
    {
    }

    public async Task<bool> Initialize(string authCode)
    {
        var bytes = Encoding.UTF8.GetBytes($"{Constants.SpotifyClientId}:{Constants.SpotifyClientSecret}");
        var authHeader = Convert.ToBase64String(bytes);

        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authHeader);

        var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>()
        {
            new("code", authCode),
            new("redirect_uri", Constants.RedirectUrl),
            new("grant_type", "authorization_code")
        });

        var response = await client.PostAsync("https://accounts.spotify.com/api/token", content);

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<AuthResult>(json);

        accessToken = result.AccessToken;

        return response.IsSuccessStatusCode;
    }
}

