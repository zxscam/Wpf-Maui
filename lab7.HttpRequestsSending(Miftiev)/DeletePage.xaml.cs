using lab7.HttpRequestsSending_Miftiev_.Entities;
using System.Net;
using System.Text.Json;
using System.Text;
using System.Xml.Linq;

namespace lab7.HttpRequestsSending_Miftiev_;

public partial class DeletePage : ContentPage
{
	public DeletePage()
	{
		InitializeComponent();
	}

    private async void DeleteRequestBut(object sender, EventArgs e)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://10.0.2.2:8080/api/");

        int productId;
        if (!int.TryParse(Id.Text, out productId))
        {
            await AppShell.Current.DisplayAlert("Ошибка", "Некорректный ID продукта.", "ОК");
            return;
        }

        HttpResponseMessage response = await client.DeleteAsync($"product/{productId}");

        if (response.StatusCode == HttpStatusCode.InternalServerError)
        {
            string message = await response.Content.ReadAsStringAsync();
            AnswerRequestInformation.Text = message;
            SemanticScreenReader.Announce(AnswerRequestInformation.Text);
            return;
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            string message = await response.Content.ReadAsStringAsync();
            AnswerRequestInformation.Text = message;
            SemanticScreenReader.Announce(AnswerRequestInformation.Text);
            return;
        }

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            string message = await response.Content.ReadAsStringAsync();
            AnswerRequestInformation.Text = message;
            SemanticScreenReader.Announce(AnswerRequestInformation.Text);
            return;
        }

        if (response.IsSuccessStatusCode)
        {
            await AppShell.Current.DisplayAlert("Успех", "Товар успешно удалён!", "ОК");
            return;
        }


        string defaultMessage = await response.Content.ReadAsStringAsync();
        AnswerRequestInformation.Text = defaultMessage;
        SemanticScreenReader.Announce(AnswerRequestInformation.Text);
    }

}