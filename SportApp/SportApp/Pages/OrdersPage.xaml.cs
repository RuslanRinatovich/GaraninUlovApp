using SportApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SportApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {

        int _itemcount = 0;
        public OrdersPage()
        {
            InitializeComponent();
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            // открытие редактирования товара
            // передача выбранного товара в AddGoodPage
           // Manager.MainFrame.Navigate(new AddOrderPage((sender as Button).DataContext as Order));
        }

        private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //событие отображения данного Page
            // обновляем данные каждый раз когда активируется этот Page
            if (Visibility == Visibility.Visible)
            {
                DataGridGood.ItemsSource = null;
                //загрузка обновленных данных
                SportTradeEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                List<Order> goods = SportTradeEntities.GetContext().Orders.OrderBy(p => p.OrderDeliveryDate).ToList();
                DataGridGood.ItemsSource = goods;
                _itemcount = goods.Count;

                var statuses = SportTradeEntities.GetContext().OrderStatus.OrderBy(p => p.OrderStatusName).ToList();
                statuses.Insert(0, new OrderStatu
                {
                    OrderStatusName = "Все типы"
                }
                );
                ComboStatus.ItemsSource = statuses;
                ComboStatus.SelectedIndex = 0;
                TextBlockCount.Text = $" Результат запроса: {goods.Count} записей из {goods.Count}";
            }
        }

        private void BtnAddClick(object sender, RoutedEventArgs e)
        {
            // открытие  AddGoodPage для добавления новой записи
         //   Manager.MainFrame.Navigate(new AddOrderPage(null));
        }

        private void BtnDeleteClick(object sender, RoutedEventArgs e)
        {
            // удаление выбранного товара из таблицы
            //получаем все выделенные товары
            var selectedGoods = DataGridGood.SelectedItems.Cast<Order>().ToList();
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedGoods.Count()} записей???",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    // берем из списка удаляемых товаров один элемент
                    Order x = selectedGoods[0];
                    // проверка, есть ли у товара в таблице о продажах связанные записи
                    // если да, то выбрасывается исключение и удаление прерывается
                    if (x.OrderProducts.Count > 0)
                        throw new Exception("Есть записи в продажах");

                    SportTradeEntities.GetContext().Orders.Remove(x);
                    //сохраняем изменения
                    SportTradeEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Order> goods = SportTradeEntities.GetContext().Orders.OrderBy(p => p.OrderDeliveryDate).ToList();
                    DataGridGood.ItemsSource = null;
                    DataGridGood.ItemsSource = goods;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // отображение номеров строк в DataGrid
        private void DataGridGoodLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

      
        private void TBoxSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }
        // Поиск товаров конкретного производителя
        private void ComboTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }
        /// <summary>
        /// Метод для фильтрации и сортировки данных
        /// </summary>
        private void UpdateData()
        {
            // получаем текущие данные из бд
            var currentGoods = SportTradeEntities.GetContext().Orders.OrderBy(p => p.OrderDeliveryDate).ToList();
            // выбор только тех товаров, по определенному диапазону скидки
          
            // выбор тех товаров, в названии которых есть поисковая строка
            currentGoods = currentGoods.Where(p => p.OrderID.ToString().ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            if (ComboStatus.SelectedIndex > 0)
            {
                currentGoods = currentGoods.Where(p => p.OrderStatusID == ((ComboStatus.SelectedItem) as OrderStatu).OrderStatusID).ToList();
            }
            // сортировка
            if (ComboSort.SelectedIndex >= 0)
            {
                // сортировка по возрастанию цены
                if (ComboSort.SelectedIndex == 0)
                    currentGoods = currentGoods.OrderBy(p => p.OrderDeliveryDate).ToList();
                // сортировка по убыванию цены
                if (ComboSort.SelectedIndex == 1)
                    currentGoods = currentGoods.OrderByDescending(p => p.OrderDeliveryDate).ToList();
            }
            // В качестве источника данных присваиваем список данных
            DataGridGood.ItemsSource = currentGoods;
            // отображение количества записей
            TextBlockCount.Text = $" Результат запроса: {currentGoods.Count} записей из {_itemcount}";
        }
        // сортировка товаров 
        private void ComboSortSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void BtnPickupPoints_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PickupPointPage());
        }

        private void BtnUnitType_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnStatus_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new StatusPage());
        }
    }
}



