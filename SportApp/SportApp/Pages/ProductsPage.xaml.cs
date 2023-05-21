using SportApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SportApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        int _itemcount = 0;
        public ProductsPage()
        {
            InitializeComponent();
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            // открытие редактирования товара
            // передача выбранного товара в AddGoodPage
            Manager.MainFrame.Navigate(new AddProductPage((sender as Button).DataContext as Product));
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
                List<Product> goods = SportTradeEntities.GetContext().Products.OrderBy(p => p.ProductName).ToList();
                DataGridGood.ItemsSource = goods;
                _itemcount = goods.Count;
                TextBlockCount.Text = $" Результат запроса: {goods.Count} записей из {goods.Count}";
            }
        }

        private void BtnAddClick(object sender, RoutedEventArgs e)
        {
            // открытие  AddGoodPage для добавления новой записи
            Manager.MainFrame.Navigate(new AddProductPage(null));
        }

        private void BtnDeleteClick(object sender, RoutedEventArgs e)
        {
            // удаление выбранного товара из таблицы
            //получаем все выделенные товары
            var selectedGoods = DataGridGood.SelectedItems.Cast<Product>().ToList();
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedGoods.Count()} записей???",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    // берем из списка удаляемых товаров один элемент
                    Product x = selectedGoods[0];
                    // проверка, есть ли у товара в таблице о продажах связанные записи
                    // если да, то выбрасывается исключение и удаление прерывается
                    if (x.OrderProducts.Count > 0)
                        throw new Exception("Есть записи в продажах");

                    SportTradeEntities.GetContext().Products.Remove(x);
                    //сохраняем изменения
                    SportTradeEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Product> goods = SportTradeEntities.GetContext().Products.OrderBy(p => p.ProductName).ToList();
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

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // удаление выбранного товара из таблицы
            //получаем все выделенные товары
            Product selectedGoods = (sender as Button).DataContext as Product;
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить запись???",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                   
                    // проверка, есть ли у товара в таблице о продажах связанные записи
                    // если да, то выбрасывается исключение и удаление прерывается
                    if (selectedGoods.OrderProducts.Count > 0)
                        throw new Exception("Есть записи в продажах");

                    SportTradeEntities.GetContext().Products.Remove(selectedGoods);
                    //сохраняем изменения
                    SportTradeEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Product> goods = SportTradeEntities.GetContext().Products.OrderBy(p => p.ProductName).ToList();
                    DataGridGood.ItemsSource = null;
                    DataGridGood.ItemsSource = goods;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
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
            var currentGoods = SportTradeEntities.GetContext().Products.OrderBy(p => p.ProductName).ToList();
            // выбор только тех товаров, по определенному диапазону скидки
            if (ComboDiscont.SelectedIndex == 1)
                currentGoods = currentGoods.Where(p => p.ProductDiscountAmount < 10).ToList();
            if (ComboDiscont.SelectedIndex == 2)
                currentGoods = currentGoods.Where(p => (p.ProductDiscountAmount >= 10 && p.ProductDiscountAmount < 15)).ToList();
            if (ComboDiscont.SelectedIndex == 3)
                currentGoods = currentGoods.Where(p => p.ProductDiscountAmount >= 15).ToList();
            // выбор тех товаров, в названии которых есть поисковая строка
            currentGoods = currentGoods.Where(p => p.ProductName.ToLower().Contains(TBoxSearch.Text.ToLower())|| p.ProductArticleNumber.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            // сортировка
            if (ComboSort.SelectedIndex >= 0)
            {
                // сортировка по возрастанию цены
                if (ComboSort.SelectedIndex == 0)
                    currentGoods = currentGoods.OrderBy(p => p.ProductCost).ToList();
                // сортировка по убыванию цены
                if (ComboSort.SelectedIndex == 1)
                    currentGoods = currentGoods.OrderByDescending(p => p.ProductCost).ToList();
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

        private void BtnSupplier_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new SupplierPage());
        }

        private void BtnManufacturer_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ManufacturerPage());
        }

        private void BtnCategory_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CategoryPage());
        }

        private void BtnUnitType_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new UnitPage());
        }
    }
}



