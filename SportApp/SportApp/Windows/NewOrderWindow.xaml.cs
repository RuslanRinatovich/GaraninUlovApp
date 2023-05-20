using Microsoft.Win32;
using SportApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Word = Microsoft.Office.Interop.Word;

namespace SportApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для NewOrderWindow.xaml
    /// </summary>
    public partial class NewOrderWindow : Window
    {
        Order _currentOrder;
        User _currentUser;
        public NewOrderWindow()
        {
            InitializeComponent();
            LoadDataAndInit();
        }

        /// <summary>
        /// Загрузка и инициализация полей
        /// </summary>
        void LoadDataAndInit()
        {
            // источник данных корзина
            ListBoxOrderProducts.ItemsSource = Basket.GetBasket;
            // создаем новый заказ
            _currentOrder = CreateNewOrder();
            // текущий пользователь
            _currentUser = Manager.CurrentUser;
            if (_currentUser != null)
            {
                TextBlockOrderNumber.Text = $"Заказ №{_currentOrder.OrderID} на имя " +
                    $"{ _currentUser.UserSurname} {_currentUser.UserName} {_currentUser.UserPatronymic}";
            }
            else
            { 
                TextBlockOrderNumber.Text = $"Заказ №{_currentOrder.OrderID}";
            }
            TextBlockTotalCost.Text = $"Итого {Basket.GetTotalCost:C}";
            TextBlockOrderCreateDate.Text = _currentOrder.OrderCreateDate.ToLongDateString();
            TextBlockOrderDeliveryDate.Text = _currentOrder.OrderDeliveryDate.ToLongDateString();
            TextBlockOrderGetCode.Text = _currentOrder.OrderGetCode.ToString();
            ComboPickupPoint.ItemsSource = SportTradeEntities.GetContext().
                PickupPoints.ToList();
        }

        /// <summary>
        /// Создает новый заказ
        /// </summary>
        /// <returns>новый заказ Order</returns>
        static Order CreateNewOrder()
        {
                Order order = new Order();
                order.OrderID = SportTradeEntities.GetContext().Orders.
                Max(p => p.OrderID) + 1; 
                order.OrderCreateDate = DateTime.Now;
                order.OrderStatusID = 1;
                if (Basket.IsOnStock)
                    order.OrderDeliveryDate = DateTime.Now.AddDays(3);
                else
                    order.OrderDeliveryDate = DateTime.Now.AddDays(6);
                Random rnd = new Random();
                order.OrderGetCode = rnd.Next(100, 1000);
            return order;
        }
  


        private void BtnOkClick(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
        private void BtnDeleteClick(object sender, RoutedEventArgs e)
        {
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить товар из корзины???",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                if (ListBoxOrderProducts.SelectedIndex >= 0)
                {
                    var x = (ListBoxOrderProducts.SelectedValue as Product);
                    Basket.DeleteProductFromBasket(x);
                    ListBoxOrderProducts.Items.Refresh();
                    TextBlockTotalCost.Text = $"Итого {Basket.GetTotalCost:C}";
                }
            }
        }

        // проверка данных в поле количество
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) // при нажатии на кнопку Enter
            {
                TextBox textBox = sender as TextBox;
                int k = ListBoxOrderProducts.SelectedIndex;

                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    int x = 0;
                    if (!int.TryParse(textBox.Text, out x))
                    {
                        MessageBox.Show("Количество только число");
                        return;
                    }
                    x = Convert.ToInt32(textBox.Text);
                    if (x < 0)
                    {
                        MessageBox.Show("Количество не может быть отрицательным");
                    }
                    else if (x == 0)
                    {
                        Product product = textBox.Tag as Product;
                        MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {product.ProductName} из корзины???", 
                            "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                        if (messageBoxResult == MessageBoxResult.OK)
                        {
                            Basket.DeleteProductFromBasket(product);
                            ListBoxOrderProducts.Items.Refresh();
                            ListBoxOrderProducts.SelectedIndex = k;
                        }
                    }
                    else
                    {
                        Product product = textBox.Tag as Product;
                        Basket.SetCount(product, x);
                        ListBoxOrderProducts.Items.Refresh();
                        ListBoxOrderProducts.SelectedIndex = k;
                    }
                }
            }
            if (e.Key == Key.Escape) // клавиша ESC
            {
                int k = ListBoxOrderProducts.SelectedIndex;
                ListBoxOrderProducts.Items.Refresh();
                ListBoxOrderProducts.SelectedIndex = k;
            }
            TextBlockTotalCost.Text = $"Итого {Basket.GetTotalCost:C}";
        }

        // В поле количество можно вводить только цифры
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }

        // кнопка оформить покупку
        private void BtnBuyItem_Click(object sender, RoutedEventArgs e)
        {
            // если не выбран пункт выдачи, отображаем в сообщение
            if (ComboPickupPoint.SelectedItem == null)
            {
                MessageBox.Show("не выбран пункт выдачи");
                return;
            }

            MessageBoxResult messageBoxResult = MessageBox.Show($"Оформить покупку???", 
                "Оформление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                // пункт выдачи
                _currentOrder.PickupPointID = Convert.ToInt32(ComboPickupPoint.SelectedValue);
                // добавляем товар
                SportTradeEntities.GetContext().Orders.Add(_currentOrder);
                //формируем данные в OrderProduct (товары заказа)
                foreach (var item in Basket.GetBasket)
                {
                    OrderProduct orderProduct = new OrderProduct();
                    orderProduct.OrderID = _currentOrder.OrderID;
                    orderProduct.ProductID = item.Key.ProductID;
                    orderProduct.Count = item.Value.Count;
                    Product product = SportTradeEntities.GetContext().Products.FirstOrDefault(p => p.ProductID == item.Key.ProductID);
                    if (item.Value.Count >= product.ProductQuantityInStock)
                        product.ProductQuantityInStock = 0;
                    else                    product.ProductQuantityInStock -= item.Value.Count;
                    SportTradeEntities.GetContext().OrderProducts.Add(orderProduct);
                }
                SportTradeEntities.GetContext().SaveChanges();  // Сохраняем изменения в БД
                // показываем талон заказа в новом окне 
                OrderTicketWindow orderTicketWindow = new OrderTicketWindow(_currentOrder);
                orderTicketWindow.ShowDialog();

                // очищаем корзину
                Basket.ClearBasket();
                this.Close();
            }
        }

       
    }
}
