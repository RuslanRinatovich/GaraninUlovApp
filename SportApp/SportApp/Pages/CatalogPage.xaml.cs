using SportApp.Models;
using SportApp.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SportApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        int _itemcount = 0; // 
        Product _selectedProduct = null;
        public CatalogPage()
        {
            InitializeComponent();
            LoadAndInitData();
        }

        void LoadAndInitData()
        {
            // загрузка данных в listview сортируем по названию
            ListBoxProducts.ItemsSource = 
                SportTradeEntities.GetContext().Products.
                OrderBy(p => p.ProductName).ToList();
            _itemcount = ListBoxProducts.Items.Count;
            // скрываем кнопки корзины
            BtnBasket.Visibility = Visibility.Collapsed;
            TextBlockBasketInfo.Visibility = Visibility.Collapsed;
            // отображение количества записей
            TextBlockCount.Text = $" Результат запроса: {_itemcount} записей из {_itemcount}";
            Basket.ClearBasket();
        }
            private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                //обновление данных после каждой активации окна
                if (Visibility == Visibility.Visible)
                {
                SportTradeEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    ListBoxProducts.ItemsSource = SportTradeEntities.GetContext().Products.OrderBy(p => p.ProductName).ToList();
                }
            }
            // Поиск товаров, которые содержат данную поисковую строку
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
                ListBoxProducts.ItemsSource = currentGoods;
                // отображение количества записей
                TextBlockCount.Text = $" Результат запроса: {currentGoods.Count} записей из {_itemcount}";
            }
            // сортировка товаров 
            private void ComboSortSelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                UpdateData();
            }
        
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            // контекстное меню по нажатию правой кнопки мыши
            // если товар не выбран, завершаем работу
            if (_selectedProduct == null)
                return;
            // добавляем товар в корзину
            Basket.AddProductInBasket(_selectedProduct);
            // отображаем кнопку и текстовое поле
            if (Basket.GetCount > 0)
            {
                BtnBasket.Visibility = Visibility.Visible;
                TextBlockBasketInfo.Visibility = Visibility.Visible;
                TextBlockBasketInfo.Text = $"В корзине {Basket.GetCount} товаров";
                BadgeBasketCount.Badge = Basket.GetCount;
            }

        }

        private void ListBoxProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //получаем всех выделенный товар
            _selectedProduct = null;
            var selected = ListBoxProducts.SelectedItems.Cast<Product>().ToList();
            if (selected.Count == 0) return;
            _selectedProduct = selected[0];
        }

        private void BtnBasket_Click(object sender, RoutedEventArgs e)
        {
            // кнопка Корзина
            NewOrderWindow newOrderWindow = new NewOrderWindow();
            newOrderWindow.ShowDialog();
            if (Basket.GetCount > 0)
            {
                BtnBasket.Visibility = Visibility.Visible;
                TextBlockBasketInfo.Visibility = Visibility.Visible;
                BadgeBasketCount.Badge = Basket.GetCount;
            }
            else
            {
                BadgeBasketCount.Badge = "";
                BtnBasket.Visibility = Visibility.Collapsed;
                TextBlockBasketInfo.Visibility = Visibility.Collapsed;
            }
           
        }
    }
    }
