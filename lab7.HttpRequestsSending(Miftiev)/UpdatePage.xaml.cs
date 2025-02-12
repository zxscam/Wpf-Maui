using lab7.HttpRequestsSending_Miftiev_.Entities;
using System.Text.Json;
using System.Text;
using System.Xml.Linq;
using System.Net;

namespace lab7.HttpRequestsSending_Miftiev_;

public partial class UpdatePage : ContentPage
{
    public UpdatePage()
    {
        InitializeComponent();
    }

    private async void UpdateRequestBut(object sender, EventArgs e)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://10.0.2.2:8080/api/");

        ProductRequest data = new ProductRequest(Name.Text, Desc.Text);
        string json = JsonSerializer.Serialize(data);
        StringContent payload = new StringContent(json, Encoding.UTF8, "application/json");

        int productId;
        if (!int.TryParse(Id.Text, out productId))
        {
            await AppShell.Current.DisplayAlert("Ошибка", "Некорректный ID продукта.", "ОК");
            return;
        }

        HttpResponseMessage response = await client.PutAsync($"product/{productId}", payload);

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
            await AppShell.Current.DisplayAlert("Успех", "Товар успешно обновлён!", "ОК");
            return;
        }


        string defaultMessage = await response.Content.ReadAsStringAsync();
        AnswerRequestInformation.Text = defaultMessage;
        SemanticScreenReader.Announce(AnswerRequestInformation.Text);
    }


}