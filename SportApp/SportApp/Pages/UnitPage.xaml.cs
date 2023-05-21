using SportApp.Models;
using SportApp.Windows;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace SportApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для UnitPage.xaml
    /// </summary>
    public partial class UnitPage : Page
    {
        int _itemcount = 0;
        public UnitPage()
        {
            InitializeComponent();
        }



        void LoadData()
        {
            try
            {
                DataGridGood.ItemsSource = null;
                //загрузка обновленных данных
                SportTradeEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                List<UnitType> goods = SportTradeEntities.GetContext().UnitTypes.OrderBy(p => p.UnitTypeName).ToList();
                DataGridGood.ItemsSource = goods;
                _itemcount = goods.Count;
                TextBlockCount.Text = $" Результат запроса: {goods.Count} записей из {goods.Count}";
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }


        private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //событие отображения данного Page
            // обновляем данные каждый раз когда активируется этот Page
            if (Visibility == Visibility.Visible)
            {
                LoadData();
            }
        }

        private void BtnAddClick(object sender, RoutedEventArgs e)
        {
            try
            {


                UnitWindow window = new UnitWindow(new UnitType());
                if (window.ShowDialog() == true)
                {
                    SportTradeEntities.GetContext().UnitTypes.Add(window.currentItem);
                    SportTradeEntities.GetContext().SaveChanges();
                    LoadData();
                    MessageBox.Show("Запись добавлена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void BtnDeleteClick(object sender, RoutedEventArgs e)
        {
            // удаление выбранного товара из таблицы
            //получаем все выделенные товары
            UnitType selectedGoods = (sender as Button).DataContext as UnitType;
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
                    if (selectedGoods.Products.Count > 0)
                        throw new Exception("Есть записи в продажах");

                    SportTradeEntities.GetContext().UnitTypes.Remove(selectedGoods);
                    //сохраняем изменения
                    SportTradeEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    LoadData();
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
            var currentGoods = SportTradeEntities.GetContext().UnitTypes.OrderBy(p => p.UnitTypeName).ToList();
            // выбор только тех товаров, по определенному диапазону скидки

            currentGoods = currentGoods.Where(p => p.UnitTypeName.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            // сортировка
            if (ComboSort.SelectedIndex >= 0)
            {
                // сортировка по возрастанию цены
                if (ComboSort.SelectedIndex == 0)
                    currentGoods = currentGoods.OrderBy(p => p.UnitTypeName).ToList();
                // сортировка по убыванию цены
                if (ComboSort.SelectedIndex == 1)
                    currentGoods = currentGoods.OrderByDescending(p => p.UnitTypeName).ToList();
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

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //  если ни одного объекта не выделено, выходим
                if (DataGridGood.SelectedItem == null) return;
                // получаем выделенный объект
                UnitType selected = DataGridGood.SelectedItem as UnitType;

                UnitWindow window = new UnitWindow(selected);


                if (window.ShowDialog() == true)
                {
                    if (window.currentItem != null)
                    {
                        SportTradeEntities.GetContext().Entry(window.currentItem).State = EntityState.Modified;
                        SportTradeEntities.GetContext().SaveChanges();
                        LoadData();
                        MessageBox.Show("Запись изменена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    SportTradeEntities.GetContext().Entry(window.currentItem).Reload();
                    LoadData();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}