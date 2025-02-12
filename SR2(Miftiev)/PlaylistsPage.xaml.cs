using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Controls;

namespace SR2_Miftiev_;


public partial class PlaylistsPage : ContentPage
{
	public PlaylistsPage()
	{
		InitializeComponent();
        LoadPlaylists();
    }

    private async void LoadPlaylists()
    {
        using (var context = new MusicCollectionContext())
        {
            var playlists = await context.Playlists.ToListAsync();
            PlaylistsListView.ItemsSource = playlists;
        }
    }
}