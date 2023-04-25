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
using WpfApp4.ClassHelper;

namespace WpfApp4.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowService.xaml
    /// </summary>
    public partial class WindowService : Window
    {
        public WindowService()
        {
            InitializeComponent();
            GetListService();
        }

        // получиние списка услуг
        private void GetListService()
        {
            LvService.ItemsSource = ClassHelper.EF.Context.Service.ToList();
        }

        // добавление услуги
        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {
            WindowAddService addServiceWindow = new WindowAddService();
            addServiceWindow.ShowDialog();

            // Обновляем лист
            GetListService();
        }

        // радактирование услуги
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DB.Service; // получаем выбранную запись

            WindowEditService editServiceWindow = new WindowEditService(service);
            editServiceWindow.ShowDialog();

            GetListService();
        }

        // добавление в корзину
        private void BtnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DB.Service; // получаем выбранную запись


            CartServiceClass.ServiceCart.Add(service);

            MessageBox.Show($"Услуга {service.ServiceName} добавлена в корзину!");
        }

        private void BtnGoToCart_Click(object sender, RoutedEventArgs e)
        {
            WindowCart cartWindow = new WindowCart();
            cartWindow.ShowDialog();
        }
    }
}
