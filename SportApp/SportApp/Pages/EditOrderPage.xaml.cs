using Microsoft.Win32;
using SportApp.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Word = Microsoft.Office.Interop.Word;

namespace SportApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditOrderPage.xaml
    /// </summary>
    public partial class EditOrderPage : Page
    {
        Order _currentOrder; // текущий заказ
        User _currentUser;// текущий пользователь
        public EditOrderPage(Order order)
        {
            InitializeComponent();
            LoadDataAndInit(order);
        }
        // Загрузка и инициализация данных
        void LoadDataAndInit(Order order)
        {
           
            
            _currentOrder = order;
            DataGridOrderItems.ItemsSource = null;
            DataGridOrderItems.ItemsSource = order.OrderProducts;
            _currentUser = Manager.CurrentUser;
            if (order.User != null)
            {
                TextBlockOrderNumber.Text = $"Заказ №{_currentOrder.OrderID} на имя " +
                    $"{ _currentUser.UserSurname} {_currentUser.UserName} {_currentUser.UserPatronymic} оформлен";
            }
            else
            { TextBlockOrderNumber.Text = $"Заказ №{_currentOrder.OrderID} оформлен"; }
            TextBlockTotalCost.Text = $"Итого {order.TotalCost:C}";
            TextBlockOrderCreateDate.Text = _currentOrder.OrderCreateDate.ToLongDateString();
            TextBlockOrderDeliveryDate.Text = _currentOrder.OrderDeliveryDate.ToLongDateString();
            TextBlockOrderGetCode.Text = _currentOrder.OrderGetCode.ToString();
            TextBlockPickupPoint.Text = _currentOrder.PickupPoint.Address;
           
            DataContext = _currentOrder;
            var statuses = SportTradeEntities.GetContext().OrderStatus.OrderBy(p => p.OrderStatusName).ToList();

            ComboStatus.ItemsSource = statuses;
        }

      

        private void BtnSavePDF_Click(object sender, RoutedEventArgs e)
        {
            PrintInPdf(_currentOrder);
        }

        void PrintInPdf(Order order)
        {
            try
            {
                string path = null;
                // указываем файл для сохранения
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF (.pdf)|*.pdf"; // Filter files by extension
                                                            // если диалог завершился успешно
                if (saveFileDialog.ShowDialog() == true)
                {
                    path = saveFileDialog.FileName;
                    Word.Application application = new Word.Application();
                    Word.Document document = application.Documents.Add();
                    Word.Paragraph paragraph = document.Paragraphs.Add();
                    Word.Range range = paragraph.Range;
                    range.Font.Bold = 1;
                    range.Text = $"Номер заказа: {order.OrderID}";
                    range.InsertParagraphAfter();

                    range = paragraph.Range;
                    range.Font.Bold = 0;
                    range.Text = $"Дата заказа: {order.OrderCreateDate}\n" +
                        $"Дата получения заказа: {order.OrderDeliveryDate}\n" +
                        $"Пункт выдачи: {order.PickupPoint.Address}";
                    range.InsertParagraphAfter();

                    range = paragraph.Range;
                    range.Font.Bold = 1;
                    range.Text = $"Код получения: {order.OrderGetCode}";
                    range.InsertParagraphAfter();
                    range.Font.Bold = 0;

                    Word.Paragraph tableParagraph = document.Paragraphs.Add();
                    Word.Range tableRange = tableParagraph.Range;


                    Word.Table table = document.Tables.Add(tableRange, order.OrderProducts.Count + 1, 7);
                    //table.Range.Bold = 0;
                    table.Borders.InsideLineStyle = table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    table.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    Word.Range cellRange;
                    cellRange = table.Cell(1, 1).Range;
                    cellRange.Text = "№";
                    cellRange = table.Cell(1, 2).Range;
                    cellRange.Text = "Наименование товара";
                    cellRange = table.Cell(1, 3).Range;
                    cellRange.Text = "Количество";
                    cellRange = table.Cell(1, 4).Range;
                    cellRange.Text = "Стоимость товара без скидки";
                    cellRange = table.Cell(1, 5).Range;
                    cellRange.Text = "Скидка";
                    cellRange = table.Cell(1, 6).Range;
                    cellRange.Text = "Стоимость с учётом скидки";
                    cellRange = table.Cell(1, 7).Range;
                    cellRange.Text = "ИТОГО";
                    table.Rows[1].Range.Bold = 1;
                    table.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    int i = 0;
                    foreach (var item in order.OrderProducts)
                    {
                        cellRange = table.Cell(i + 2, 1).Range;
                        cellRange.Text = (i+1).ToString();
                        cellRange = table.Cell(i + 2, 2).Range;
                        cellRange.Text = item.Product.ProductName;
                        cellRange = table.Cell(i + 2, 3).Range;
                        cellRange.Text = item.Count.ToString();
                        cellRange = table.Cell(i + 2, 4).Range;
                        cellRange.Text = item.Product.ProductCost.ToString("f2");
                        cellRange = table.Cell(i + 2, 5).Range;
                        cellRange.Text = Convert.ToString(item.Product.ProductDiscountAmount);
                        cellRange = table.Cell(i + 2, 6).Range;
                        cellRange.Text = item.Product.GetPriceWithDiscount.ToString("f2");
                        cellRange = table.Cell(i + 2, 7).Range;
                        cellRange.Text = item.Total.ToString("f2");
                        i++;
                    }
                    Word.Paragraph generalSumProduct = document.Paragraphs.Add();
                    Word.Range generalRange = generalSumProduct.Range;
                    generalRange.Text = $"\nОбщая сумма заказа: {order.TotalCost:f2} руб.";
                    document.SaveAs2($@"{path}", Word.WdExportFormat.wdExportFormatPDF);
                    MessageBox.Show("Талон сохранен");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        // отображение номеров строк в DataGrid
        private void DataGridGoodLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSaveStatus_Click(object sender, RoutedEventArgs e)
        {
           
            if (ComboStatus.SelectedIndex == -1)
            {
              
                return;
            }
           
           
            try
            { // если изменилось изображение
              
                SportTradeEntities.GetContext().SaveChanges();  // Сохраняем изменения в БД
                MessageBox.Show("Запись сохранена");
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
