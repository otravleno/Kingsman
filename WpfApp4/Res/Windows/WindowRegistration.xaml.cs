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

namespace WpfApp4.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowRegistration.xaml
    /// </summary>
    public partial class WindowRegistration : Window
    {
        public WindowRegistration()
        {
            InitializeComponent();

            CmbGender.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGender.DisplayMemberPath = "GenderName";
            CmbGender.SelectedIndex = 0;
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            // валидация
            if (string.IsNullOrWhiteSpace(TbLastName.Text))
            {
                MessageBox.Show("Поле Фамилия не заполнено");
                return;
            }

            if (string.IsNullOrWhiteSpace(TbFirstName.Text))
            {
                MessageBox.Show("Поле Имя не заполнено");
                return;
            }
            // добавление 
            DB.Client addClient = new DB.Client();
            addClient.Login = TbLogin.Text;
            addClient.Password = PbPassword.Password;
            addClient.Phone = TbPhone.Text;
            addClient.FirstName = TbFirstName.Text;
            addClient.LastName = TbLastName.Text;
            if (TbMiddleName.Text != string.Empty)
            {
                addClient.Patronymic = TbMiddleName.Text;
            }
            addClient.GenderCode = (CmbGender.SelectedItem as DB.Gender).GenderCode;

            ClassHelper.EF.Context.Client.Add(addClient);

            // сохранение
            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Пользователь успешно добавлен");

        }
    }
}
