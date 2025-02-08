using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ElectronicShop_Miftiev_.DatabaseContext;
using ElectronicShop_Miftiev_.Entities;

namespace ElectronicShop_Miftiev_
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            string title = TitleTB.Text;
            string description = DescriptionTB.Text;
            string amount = AmountTB.Text;

            bool isTitleEmpty = string.IsNullOrWhiteSpace(title);
            if (isTitleEmpty)
            {
                MessageBox.Show("Заголовок товара не может быть пустым!", "Ошибка");
                return;
            }

            bool isDescriptionEmpty = string.IsNullOrWhiteSpace(description);
            if (isDescriptionEmpty)
            {
                MessageBox.Show("Описание товара не может быть пустым!", "Ошибка");
                return;
            }

            bool isAmountEmpty = string.IsNullOrWhiteSpace(amount);
            if (isAmountEmpty)
            {
                MessageBox.Show("Количество товавра не может ббыть пустым!", "Ошибка");
                return;
            }

            ApplicationDbContext dbContext = new ApplicationDbContext();

            bool isTitleAlreadyExist = dbContext.Products.Any(p => p.Title == title);
            if (isTitleAlreadyExist)
            {
                MessageBox.Show("Товар с данным заголовком уже существует!", "Ошибка");
                return;
            }

            int amouConvertedToInteger = Convert.ToInt32(amount);
            ProductEntity product = new ProductEntity(title, description, amouConvertedToInteger);
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            MessageBox.Show("Товар успешно добавлен!", "Успех");
            Close();
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            Close();
        }
    }
}
