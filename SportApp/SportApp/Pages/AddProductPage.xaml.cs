using Microsoft.Win32;
using SportApp.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SportApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        // текущий товар
        private Product _currentProduct = new Product();
        // путь к файлу
        private string _filePath = null;
        // название текущей главной фотографии
        private string _photoName = null;
        // флаг меняется, если фото товара поменялось
        private bool _photoChanged = false;
        // текущая папка приложения
        private static string _currentDirectory =
            Directory.GetCurrentDirectory() + @"\Images\";

        public AddProductPage(Product selectedProduct)
        {

            InitializeComponent();
            LoadAndInitData(selectedProduct);
        }

        void LoadAndInitData(Product selectedProduct)
        {     // если передано null, то мы добавляем новый товар
            if (selectedProduct != null)
            {
                _currentProduct = selectedProduct;
                _filePath = _currentDirectory + _currentProduct.ProductPhoto;
            }
            // контекст данных текущий товар
            DataContext = _currentProduct;
            _photoName = _currentProduct.ProductPhoto;
            //загрузка в выпалдающие списки
            // категории товаров
            ComboCategory.ItemsSource = SportTradeEntities.GetContext().ProductCategories.
                ToList();
            // производители товаров
            ComboManufacturer.ItemsSource = SportTradeEntities.GetContext().ProductManufacturers.
                ToList();
            // поставщики товаров
            ComboSupplier.ItemsSource = SportTradeEntities.GetContext().ProductSuppliers.
                ToList();
            // единицы измерения товаров
            ComboUnitType.ItemsSource = SportTradeEntities.GetContext().UnitTypes.
                ToList();
        }

        /// <summary>
        /// Проверка полей ввод на корректыне данные
        /// </summary>
        /// <returns>текст StringBuilder содержащий ошибки, если они есть</returns>
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            // проверка полей на содержимое
            if (string.IsNullOrWhiteSpace(_currentProduct.ProductArticleNumber))
                s.AppendLine("Поле артикул пустое");
            if (string.IsNullOrWhiteSpace(_currentProduct.ProductName))
                s.AppendLine("Поле название пустое");
            if (_currentProduct.ProductCategory == null)
                s.AppendLine("Выберите категорию продукции");
            if (_currentProduct.ProductManufacturer == null)
                s.AppendLine("Выберите производителя");
            if (_currentProduct.ProductSupplier == null)
                s.AppendLine("Выберите поставщика");
            if (_currentProduct.UnitType == null)
                s.AppendLine("Выберите единицу измерения");
            if (string.IsNullOrWhiteSpace(DoubleUpDownProductCost.Value.ToString()))
                s.AppendLine("Поле стоимость пустое");
            if (string.IsNullOrWhiteSpace(_currentProduct.ProductDescription))
                s.AppendLine("Поле описание пустое");

            if (string.IsNullOrWhiteSpace(IntegerUpDownQuantityInStock.Value.ToString()))
                s.AppendLine("Поле количество пустое");
            if (string.IsNullOrWhiteSpace(IntegerUpDownDiscountAmount.Text))
                s.AppendLine("Поле скидка пустое");
            if (string.IsNullOrWhiteSpace(IntegerUpDownDiscountAmountMax.Text))
                s.AppendLine("Поле максимальная скидка пустое");

            //// если поле стоимость не пустое,
            //// проверяем данные на корректность
            //if (!string.IsNullOrWhiteSpace(TextBoxProductCost.Text))
            //{
            //    double x = 0;
            //    if (!double.TryParse(TextBoxProductCost.Text, out x))
            //        s.AppendLine("Стоимость только число");
            //    else if (x < 0)
            //    {
            //        s.AppendLine("Стоимость не может быть отрицательной");
            //    }
            //}
            // если поле количество не пустое,
            // проверяем данные на корректность
            //if (!string.IsNullOrWhiteSpace(TextBoxProductQuantityInStock.Text))
            //{
            //    int x = 0;
            //    if (!int.TryParse(TextBoxProductQuantityInStock.Text, out x))
            //        s.AppendLine("Количество только число");
            //    else if (x < 0)
            //    {
            //        s.AppendLine("Количество не может быть отрицательной");
            //    }
            //}
         
            // если поле скидка не пустое,
            // проверяем данные на корректность
            //if (!string.IsNullOrWhiteSpace(TextBoxProductDiscountAmount.Text))
            //{
            //    int x = 0;
            //    if (!int.TryParse(TextBoxProductDiscountAmount.Text, out x))
            //        s.AppendLine("Скидка только число");
            //    else if (x < 0)
            //    {
            //        s.AppendLine("Скидка не может быть отрицательной");
            //    }
            //}

            //// если поле максимальная скидка не пустое,
            //// проверяем данные на корректность
            //if (!string.IsNullOrWhiteSpace(TextBoxProductDiscountAmountMax.Text))
            //{
            //    int x = 0;
            //    if (!int.TryParse(TextBoxProductDiscountAmountMax.Text, out x))
            //        s.AppendLine("Максимальная скидка только число");
            //    else if (x < 0)
            //    {
            //        s.AppendLine("Максимальная скидка не может быть отрицательной");
            //    }
            //}
            //// максимальная скидка не может быть меньше, чем текущая скидка
            //if (!string.IsNullOrWhiteSpace(TextBoxProductDiscountAmount.Text) && !string.IsNullOrWhiteSpace(TextBoxProductDiscountAmountMax.Text))
            //{
            //    int x, y;
            //    if (int.TryParse(TextBoxProductDiscountAmountMax.Text, out x) && int.TryParse(TextBoxProductDiscountAmount.Text, out y))
            //    {
            //        if (x < y)
            //        {
            //            s.AppendLine("Максимальная скидка не может быть меньше действующей скидки");
            //        }
            //    }
            //}
             return s;
        }

        private void BtnSaveClick(object sender, RoutedEventArgs e)
        {
            StringBuilder _error = CheckFields();
            // если ошибки есть, то выводим ошибки в MessageBox
            // и прерываем выполнение 
            if (_error.Length > 0)
            {
                MessageBox.Show(_error.ToString());
                return;
            }
            // проверка полей прошла успешно
            // если товар новый, то его ID == 0
            if (_currentProduct.ProductID == 0)
            {
                // добавление нового товара, 
                // формируем новое название файла картинки,
                // так как в папке может быть файл с тем же именем
                if (_filePath != null)
                {
                    string photo = ChangePhotoName();
                    // путь куда нужно скопировать файл
                    string dest = _currentDirectory + photo;
                    File.Copy(_filePath, dest);
                    _currentProduct.ProductPhoto = photo;
                }
                // добавляем товар в БД
                SportTradeEntities.GetContext().Products.Add(_currentProduct);
            }
            try
            { // если изменилось изображение
                if (_photoChanged)
                {
                    string photo = ChangePhotoName();
                    string dest = _currentDirectory + photo;
                    File.Copy(_filePath, dest);
                    _currentProduct.ProductPhoto = photo;
                }
                SportTradeEntities.GetContext().SaveChanges();  // Сохраняем изменения в БД
                MessageBox.Show("Запись Изменена");
                Manager.MainFrame.GoBack();  // Возвращаемся на предыдущую форму
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        // загрузка фото 
        private void BtnLoadClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //Диалог открытия файла
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                // диалог вернет true, если файл был открыт
                if (op.ShowDialog() == true)
                {
                    // проверка размера файла
                    // по условию файл дожен быть не более 2Мб.
                    FileInfo fileInfo = new FileInfo(op.FileName);
                    if (fileInfo.Length > (1024 * 1024 * 2))
                    {
                        // размер файла меньше 2Мб. Поэтому выбрасывается новое исключение
                        throw new Exception("Размер файла должен быть меньше 2Мб");
                    }
                    ImagePhoto.Source = new BitmapImage(new Uri(op.FileName));
                    _photoName = op.SafeFileName;
                    _filePath = op.FileName;
                    _photoChanged = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                _filePath = null;
            }
        }
        //подбор имени файла
        string ChangePhotoName()
        {
            string x = _currentDirectory + _photoName;
            string photoname = _photoName;
            int i = 0;
            if (File.Exists(x))
            {
                while (File.Exists(x))
                {
                    i++;
                    x = _currentDirectory + i.ToString() + photoname;
                }
                photoname = i.ToString() + photoname;
            }
            return photoname;
        }

        private void IntegerUpDownDiscountAmountMax_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

      
            IntegerUpDownDiscountAmount.Maximum = IntegerUpDownDiscountAmountMax.Value;
            if (IntegerUpDownDiscountAmount.Value > IntegerUpDownDiscountAmountMax.Value)
                IntegerUpDownDiscountAmount.Value = IntegerUpDownDiscountAmountMax.Value;
        }
    }
}
