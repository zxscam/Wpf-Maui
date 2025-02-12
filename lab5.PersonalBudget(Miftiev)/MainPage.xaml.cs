using lab5.PersonalBudget_Miftiev_.Entities;
using lab5.PersonalBudget_Miftiev_.DatabaseContext;

namespace lab5.PersonalBudget_Miftiev_


{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();

            RefreshCollectionView();
        }

        private void GoToAddTransactionPage(object sender, EventArgs e)
        {
            AppShell.Current.GoToAsync(nameof(AddTransactionPage), true);
        }


        private void RefreshData(object sender, EventArgs e)
        {
            RefreshCollectionView();
            RefreshV.IsRefreshing = false;
        }
        private void RefreshCollectionView()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            TransactionCL.ItemsSource = dbContext.Transactions.ToList();

        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            int Col = dbContext.Transactions.ToList().Count;
            col.Text = $"Количество всех затрат: {Col}";
            SemanticScreenReader.Announce(col.Text);
            decimal Sum = 0;

            foreach (TransactionEntity T in dbContext.Transactions.ToList())
            {
                Sum += T.Amount;
            }

            sum.Text = $"Сумма всех затрат: {Sum}";
            SemanticScreenReader.Announce(sum.Text);

        }

    }

}
