using Microsoft.Win32;
using SportApp.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using Word = Microsoft.Office.Interop.Word;

namespace SportApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderTicketWindow.xaml
    /// </summary>
    public partial class OrderTicketWindow : Window
    {
        
        Order _currentOrder; // текущий заказ
        User _currentUser;// текущий пользователь
        public OrderTicketWindow(Order order)
        {
            InitializeComponent();
            LoadDataAndInit(order);
        }
        // Загрузка и инициализация данных
        void LoadDataAndInit(Order order)
        {
            _currentOrder = order;
            DataGridOrderItems.ItemsSource = null;
            DataGridOrderItems.ItemsSource = Basket.GetBasket;

            _currentUser = Manager.CurrentUser;
            if (_currentUser != null)
            {
                TextBlockOrderNumber.Text = $"Заказ №{_currentOrder.OrderID} на имя " +
                    $"{ _currentUser.UserSurname} {_currentUser.UserName} {_currentUser.UserPatronymic} оформлен";
            }
            else
            { TextBlockOrderNumber.Text = $"Заказ №{_currentOrder.OrderID} оформлен"; }
            TextBlockTotalCost.Text = $"Итого {Basket.GetTotalCost:C}";
            TextBlockOrderCreateDate.Text = _currentOrder.OrderCreateDate.ToLongDateString();
            TextBlockOrderDeliveryDate.Text = _currentOrder.OrderDeliveryDate.ToLongDateString();
            TextBlockOrderGetCode.Text = _currentOrder.OrderGetCode.ToString();
            TextBlockPickupPoint.Text = _currentOrder.PickupPoint.Address;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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


                    Word.Table table = document.Tables.Add(tableRange, Basket.GetCount + 1, 6);
                    //table.Range.Bold = 0;
                    table.Borders.InsideLineStyle = table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    table.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    Word.Range cellRange;
                    cellRange = table.Cell(1, 1).Range;
                    cellRange.Text = "Наименование товара";
                    cellRange = table.Cell(1, 2).Range;
                    cellRange.Text = "Количество";
                    cellRange = table.Cell(1, 3).Range;
                    cellRange.Text = "Стоимость товара без скидки";
                    cellRange = table.Cell(1, 4).Range;
                    cellRange.Text = "Скидка";
                    cellRange = table.Cell(1, 5).Range;
                    cellRange.Text = "Стоимость с учётом скидки";
                    cellRange = table.Cell(1, 6).Range;
                    cellRange.Text = "ИТОГО";
                    table.Rows[1].Range.Bold = 1;
                    table.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    int i = 0;
                    foreach (var item in Basket.GetBasket)
                    {
                        cellRange = table.Cell(i + 2, 1).Range;
                        cellRange.Text = item.Key.ProductName;
                        cellRange = table.Cell(i + 2, 2).Range;
                        cellRange.Text = item.Value.Count.ToString();
                        cellRange = table.Cell(i + 2, 3).Range;
                        cellRange.Text = item.Key.ProductCost.ToString("f2");
                        cellRange = table.Cell(i + 2, 4).Range;
                        cellRange.Text = Convert.ToString(item.Key.ProductDiscountAmount);
                        cellRange = table.Cell(i + 2, 5).Range;
                        cellRange.Text = item.Key.GetPriceWithDiscount.ToString("f2");
                        cellRange = table.Cell(i + 2, 6).Range;
                        cellRange.Text = item.Value.Total.ToString("f2");
                        i++;
                    }
                    Word.Paragraph generalSumProduct = document.Paragraphs.Add();
                    Word.Range generalRange = generalSumProduct.Range;
                    generalRange.Text = $"\nОбщая сумма заказа: {Basket.GetTotalCost:f2} руб.";
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
    }
}
