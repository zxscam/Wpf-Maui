using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ElectronicShop_Miftiev_.DatabaseContext;
using ElectronicShop_Miftiev_.Entities;

namespace ElectronicShop_Miftiev_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void OpenAddProductWindow(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.ShowDialog();
            LoadData();
        }

        private void GoToEditProductWindow(object sender, SelectionChangedEventArgs e)
        {
            ProductEntity selectedProduct = (ProductEntity)ProductsLV.SelectedItem;
            if (selectedProduct == null) return;

            EditProductWindow editProductWindow = new EditProductWindow(selectedProduct.Id);
            editProductWindow.ShowDialog();
            LoadData();
        }
        private void LoadData()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            ProductsLV.ItemsSource = dbContext.Products.ToList();
        }
    }
}