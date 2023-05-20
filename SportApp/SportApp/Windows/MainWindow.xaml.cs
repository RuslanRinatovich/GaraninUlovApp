using SportApp.Models;
using SportApp.Pages;
using System;
using System.Windows;

namespace SportApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
     {
        User _currentUser; //текущий пользователь в системе
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
           
        }
        /// <summary>
        /// загружаем данные и инициализируем переменные
        /// </summary>
        void LoadData()
        {
            _currentUser = Manager.CurrentUser;
            if (_currentUser != null)
            {
                TextBlockName.Text = $"Вы вошли как: {_currentUser.UserSurname} {_currentUser.UserName} {_currentUser.UserPatronymic}";
            }
            MainFrame.Navigate(new CatalogPage());
            Manager.MainFrame = MainFrame;
        }
        private void WindowClosed(object sender, EventArgs e)
        {
            // показать владельца формы
            Owner.Show();
            // или если надо, то можно закрыть приложение  командой
            // App.Current.Shutdown();
        }
        //событие попытки закрытия окна,
        // если пользователь выберет Cancel, то форму не закроем
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult x = MessageBox.Show("Вы действительно хотите выйти?",
                "Выйти", MessageBoxButton.OKCancel,
                MessageBoxImage.Question);
            if (x == MessageBoxResult.Cancel)
                e.Cancel = true;
        }
        // Кнопка назад
        private void BtnBackClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
        // Кнопка навигации
        private void BtnEditGoodsClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductsPage());
        }
        // Событие отрисовки страницы
        // Скрываем или показываем кнопку Назад 
        // Скрываем или показываем кнопки Для перехода к остальным страницам
        private void MainFrameContentRendered(object sender, EventArgs e)
        {
            // проверяем кто вошел систему
            if (_currentUser == null || _currentUser.RoleID == 1) // клиент или гость
            {
                
                if (MainFrame.CanGoBack)
                {
                    BtnBack.Visibility = Visibility.Hidden;
                    BtnEditGoods.Visibility = Visibility.Collapsed;
                    BtnEditOrders.Visibility = Visibility.Collapsed;
                }
                else
                {
                    BtnBack.Visibility = Visibility.Collapsed;
                    BtnEditGoods.Visibility = Visibility.Collapsed;
                    BtnEditOrders.Visibility = Visibility.Collapsed;
                }
                return;
            }
            if (_currentUser.RoleID == 3) // менеджер
            {
                if (MainFrame.CanGoBack)
                {
                    BtnBack.Visibility = Visibility.Visible;
                    BtnEditGoods.Visibility = Visibility.Collapsed;
                    BtnEditOrders.Visibility = Visibility.Collapsed;
                }
                else
                {
                    BtnBack.Visibility = Visibility.Collapsed;
                    BtnEditGoods.Visibility = Visibility.Collapsed;
                    BtnEditOrders.Visibility = Visibility.Visible;
                }
                return;
            }
            if (_currentUser.RoleID == 2) // админ
            {
                if (MainFrame.CanGoBack)
                {
                    BtnBack.Visibility = Visibility.Visible;
                    BtnEditGoods.Visibility = Visibility.Collapsed;
                    BtnEditOrders.Visibility = Visibility.Collapsed;
                }
                else
                {
                    BtnBack.Visibility = Visibility.Collapsed;
                    BtnEditGoods.Visibility = Visibility.Visible;
                    BtnEditOrders.Visibility = Visibility.Visible;
                }
                return;
            }
          
        }

        private void BtnEditOrders_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OrdersPage());
        }
    }
}


