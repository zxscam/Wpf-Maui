using lab7.HttpRequestsSending_Miftiev_.Entities;
using System.Net;
using System.Text.Json;

namespace lab7.HttpRequestsSending_Miftiev_;

public partial class GetProductPage : ContentPage
{
    private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://10.0.2.2:8080/api/") };

    private async void GetRequestBut(object sender, EventArgs e)
    {
        try
        {
            if (!int.TryParse(Id.Text, out int productId))
            {
                await AppShell.Current.DisplayAlert("Ошибка", "Некорректный ID продукта.", "ОК");
                return;
            }

            HttpResponseMessage response = await client.GetAsync($"product/{productId}");

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

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string json = await response.Content.ReadAsStringAsync();
                ProductResponse productResponse = JsonSerializer.Deserialize<ProductResponse>(json);

                if (productResponse == null)
                {
                    await AppShell.Current.DisplayAlert("Ошибка", "Товар не найден!", "ОК");
                    return;
                }

                GetCV.ItemsSource = new List<ProductResponse> { productResponse };
            }
        }
        catch (Exception ex)
        {
            await AppShell.Current.DisplayAlert("Ошибка", $"Произошла ошибка: {ex.Message}", "ОК");
        }
    }
}
