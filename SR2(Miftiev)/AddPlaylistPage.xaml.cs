using System;
using Microsoft.Maui.Controls;

namespace SR2_Miftiev_;

public partial class AddPlaylistPage : ContentPage
{
	public AddPlaylistPage()
	{
		InitializeComponent();
	}

    private async void OnAddPlaylistClicked(object sender, EventArgs e)
    {
        var playlist = new Playlist
        {
            Title = TitleEntry.Text,
            Description = DescriptionEntry.Text,
            CreationDate = DateTime.Now,
            UserId = 1 // Замените на текущий ID пользователя
        };

        using (var context = new MusicCollectionContext())
        {
            context.Playlists.Add(playlist);
            await context.SaveChangesAsync();
        }

        await DisplayAlert("Успех", "Плейлист добавлен!", "OK");
        await Navigation.PopAsync(); 
    }
}