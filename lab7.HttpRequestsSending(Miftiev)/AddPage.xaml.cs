using lab7.HttpRequestsSending_Miftiev_.Entities;
using System.Text.Json;
using System.Text;
using System.Xml.Linq;
using System.Net;  


namespace lab7.HttpRequestsSending_Miftiev_;

public partial class AddPage : ContentPage
{
    private async void AddRequestBut(object sender, EventArgs e)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://10.0.2.2:8080/api/");

        ProductRequest data = new ProductRequest(Name.Text, Desc.Text);
        string json = JsonSerializer.Serialize(data);
        StringContent payload = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("product", payload);
        AppShell.Current.DisplayAlert("Èíôîðìèðîâàíèå", "Îòâåò ïîëó÷åí!", "ÎÊ");

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

        if (response.IsSuccessStatusCode)
        {
            AppShell.Current.DisplayAlert("Óñïåõ", "Òîâàð óñïåøíî äîáàâëåí!", "ÎÊ");
            return;
        }
    }
}