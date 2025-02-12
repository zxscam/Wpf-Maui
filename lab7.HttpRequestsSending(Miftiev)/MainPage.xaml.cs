using lab7.HttpRequestsSending_Miftiev_.Entities;
using System.Text.Json;
using System.Net;
using System.Transactions;  

namespace lab7.HttpRequestsSending_Miftiev_
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private async void SendRequestBut(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://10.0.2.2:8080/api/");

            HttpResponseMessage response = await client.GetAsync("product");
            AppShell.Current.DisplayAlert("Информирование", "Ответ получен!", "ОК");

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                string message = await response.Content.ReadAsStringAsync();
                AnswerRequestInformation.Text = message;
                SemanticScreenReader.Announce(AnswerRequestInformation.Text);
                return;
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<ProductResponse> products = JsonSerializer.Deserialize<List<ProductResponse>>(json);

                if (products == null)
                {
                    AppShell.Current.DisplayAlert("Ошибка", "Список был пуст!", "ОК");
                    return;
                }

                RequestCV.ItemsSource = products.ToList();
            }

        }

        private void GoToAddPage(object sender, EventArgs e)
        {
            AppShell.Current.GoToAsync(nameof(AddPage));

        }
        private void GoToGetProductPage(object sender, EventArgs e)
        {
            AppShell.Current.GoToAsync(nameof(GetProductPage));

        }
        private void GoToUpdatePage(object sender, EventArgs e)
        {
            AppShell.Current.GoToAsync(nameof(UpdatePage));

        }
        private void GoToDeletePage(object sender, EventArgs e)
        {
            AppShell.Current.GoToAsync(nameof(DeletePage));

        }

    }
}
