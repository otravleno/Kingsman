﻿using System;
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

namespace WpfApp4.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowCart.xaml
    /// </summary>
    public partial class WindowCart : Window
    {
        public WindowCart()
        {
            InitializeComponent();
            GetListServise();
        }

        private void GetListServise()
        {
            LvCartService.ItemsSource = ClassHelper.CartServiceClass.ServiceCart;

        }

        private void BtnRomoveToCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DB.Service; // получаем выбранную запись

            ClassHelper.CartServiceClass.ServiceCart.Remove(service);

            GetListServise();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
