using System.Collections.ObjectModel;

namespace PlaylistBuilder.ViewModels;

public partial class HomeViewModel : ViewModel
{
    private readonly ISpotifyService spotifyService;

    public HomeViewModel(ISpotifyService spotifyService)
    {
        this.spotifyService = spotifyService;
    }

    [ObservableProperty]
    private bool isSearching;

    [ObservableProperty]
    private bool hasResult;

    [ObservableProperty]
    private string searchText;

    [ObservableProperty]
    private ObservableCollection<SearchItemViewModel> artists;

    [ObservableProperty]
    private ObservableCollection<SearchItemViewModel> albums;

    [ObservableProperty]
    private ObservableCollection<SearchItemViewModel> tracks;

    [RelayCommand]
    private void StartSearch()
    {
        IsSearching = true;
    }

    [RelayCommand]
    private async Task Search()
    {
        try
        {
            IsBusy = true;

            var types = "artist,album,track";

            var result = await spotifyService.Search(SearchText, types);

            var artists = result.Artists.Items.Select(x => new SearchItemViewModel()
            {
                Title = x.Name,
                ImageUrl = x.Images.Any() ?  x.Images.First().Url : null,
                TapCommand = NavigateToArtistCommand,
            }).ToList();

            Artists = new ObservableCollection<SearchItemViewModel>(artists);

            var albums = result.Albums.Items.Select(x => new SearchItemViewModel()
            {
                Title = x.Name,
                ImageUrl = x.Images.Any() ? x.Images.First().Url : null,
                TapCommand = NavigateToAlbumCommand,
            });

            Albums = new ObservableCollection<SearchItemViewModel>(albums);

            var tracks = result.Tracks.Items.Select(x => new SearchItemViewModel()
            {
                Title = x.Name,
                SubTitle = x.Artists.Any() ?  x.Artists.First().Name : null,
                ImageUrl = x.Album.Images.Any() ? x.Album.Images.First().Url : null,
                TapCommand = NavigateToTrackCommand,
            });

            Tracks = new ObservableCollection<SearchItemViewModel>(tracks);

            HasResult = true;
        }
        catch(Exception ex)
        {
            await HandleException(ex);
        }

        IsBusy = false;
    }

    [RelayCommand]
    private void NavigateToArtist()
    {

    }

    [RelayCommand]
    private void NavigateToAlbum()
    {

    }

    [RelayCommand]
    private void NavigateToTrack()
    {

    }
}

public class SearchItemViewModel : ViewModel
{
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string ImageUrl { get; set; }
    public ICommand TapCommand { get; set; }
}
