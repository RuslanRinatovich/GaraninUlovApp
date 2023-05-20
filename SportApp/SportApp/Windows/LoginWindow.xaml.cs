using SportApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace SportApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        // Переменная флаг, меняет свое значение, 
        // если пользователь не смог ввести с первого раза пароль и логин
        // если b == true, то отобразим капчу
        bool b = false; 
        // таймер
        DispatcherTimer timer = new DispatcherTimer();
        int seconds = 0; // секунды
        string captcha = ""; // текст капчи
        public LoginWindow()
        {
            InitializeComponent();
            LoadAndInitData();
        }

        /// <summary>
        /// Загружает и инициализирует данные
        /// </summary>
        void LoadAndInitData()
        {
            this.Height = 200; // задаем высоту окна
            timer.Tick += timer_Tick; // к событию Tick таймера привязываем обработчик события
            // скрываем строки с капчой
            RowCaptcha1.Height = new GridLength(0);
            RowCaptcha2.Height = new GridLength(0);
            TbLogin.Text = "loginDEcph2018";
            TbPass.Password = "7YpE0p";
        }

        // обаботчик события срабатывает через каждые т секунд
        void timer_Tick(object sender, EventArgs e)
        {
            seconds -= 1;
            TextBlockTime.Text = $"Осталось {seconds} секунд до разблокировки";
            if (seconds == 0) // оставливаем таймер, разблокировываем кнопку
            {
                BtnOk.IsEnabled = true;
                TextBlockTime.Text = "";
                timer.Stop();
            }
            
        }

        private void BtnOkClick(object sender, RoutedEventArgs e)
        {
            try
            {  //загрузка всех пользователей из БД в список
                List<User> users = SportTradeEntities.GetContext().Users.ToList();
                //попытка найти пользователя с указанным паролем и логином
                //если такого пользователя не будет обнаружено то переменная u будет равна null
                User user = users.FirstOrDefault(
                    p => p.UserPassword == TbPass.Password && p.UserLogin == TbLogin.Text);
                // удачный вход после ввода пароля и логина или пароля, логина и капчи
                if ((user != null && !b) || (user != null && b && TbCaptcha.Text == captcha))
                {
                    // в классе Manager свойство CurrentUser хранит информацию о пользователе,
                    // который вошел в систему
                    Manager.CurrentUser = user;
                    // логин и пароль корректные запускаем главную форму приложения
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Owner = this;
                    this.Hide();// скрываем форму авторизации
                    mainWindow.Show();
                 
                }
                else
                {
                    MessageBox.Show("Не верный логин или пароль");
                    // меняем высоту формы
                    this.Height = 350;
                    // вызываем метод отображения капчи
                    ShowCaptcha();

                    if (b) // если неправильно ввели логин, пароль и капчу 
                    {
                        // задаем параметры таймера, событие Tick срабатывает через каждую секунду
                        timer.Interval = TimeSpan.FromSeconds(1);
                        // блокируем кнопку
                        BtnOk.IsEnabled = false;
                        // на  10 секунд
                        seconds = 10;
                        // отображает сколько секунд осталось до разблокировки
                        TextBlockTime.Text = $"Осталось {seconds} секунд до разблокировки";
                        // включаем таймер
                        timer.Start(); 
                    }
                    b = true; // становится истинной, если неправильно ввели логин, пароль и капчу 
                    RowCaptcha1.Height = new GridLength(34);
                    RowCaptcha2.Height = new GridLength(1, GridUnitType.Star);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        //код кнопки Cancel
        private void BtnCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        // попытка закрыть приложение
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // на экране отображается форма с двумя кнопками
            MessageBoxResult x = MessageBox.Show("Вы действительно хотите закрыть приложение?",
           "Выйти", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (x == MessageBoxResult.Cancel)
                e.Cancel = true;
        }

        private void BtnGuestMode_Click(object sender, RoutedEventArgs e)
        {
            // вход в режиме гостя
            Manager.CurrentUser = null;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Owner = this;
            this.Hide();
            mainWindow.Show();
        }

        private void BtnRenewCaptcha_Click(object sender, RoutedEventArgs e)
        {
            // кнопка обновить капчу
            ShowCaptcha();
        }
        /// <summary>
        /// отображает капчу
        /// </summary>
        void ShowCaptcha()
        {
            // из класса MakeCaptcha вызываем метод CreateImage
            var tuple = MakeCaptcha.CreateImage(300, 100, 5);
            // получаем ImageSource
            ImageCaptcha.Source = tuple.image;
            // получаем текст капчи
            captcha = tuple.captcha;
        }
    }
}
