using System;
using System.IO;

// пространство имен такое же как и у SportTradeEntities из папки Models
namespace SportApp.Models
{
    // класс Product public - публичный
    // partial - частичный, т.е. его часть в другом файле
    public partial class Product
    {
        /// <summary>
        /// Возвращает абсолютный путь к изображению
        /// </summary>
        public string GetPhoto
        {
            get
            {
                if (ProductPhoto is null)
                    return Directory.GetCurrentDirectory() + @"\Images\picture.png";
                return Directory.GetCurrentDirectory() + @"\Images\" + ProductPhoto.Trim();
            }
        }
        /// <summary>
        /// Задает цвет фона элемента "#7fff00", если скидка больше 15%
        /// </summary>
        public string GetColor
        {
            get
            {
                if (ProductDiscountAmount > 15)
                    return "#7fff00";
                else
                    return "#fff";
            }
        }
        /// <summary>
        /// Стоимость товара с учетом скидки
        /// </summary>
        public double GetPriceWithDiscount
        {
            get
            {
                double p = Convert.ToDouble(ProductCost);
                byte d = Convert.ToByte(ProductDiscountAmount);
                return p * (100 - d) / 100;
            }
        }
        /// <summary>
        /// Стиль текста - перечеркнутый для товаров со скидкой
        /// </summary>
        public string GetTextDecoration
        {
            get
            {
                if (ProductDiscountAmount > 0)
                    return "Strikethrough";
            return null;
            }
        }
        /// <summary>
        /// Если скидка есть то отображаем компонент
        /// </summary>
        public string GetVisibility
        {
            get
            {
                if (ProductDiscountAmount > 0)
                    return "Visible";
                return "Collapsed";
            }
        }
        /// <summary>
        /// Количество товара на складе с учетом единицы измерения
        /// </summary>
        public string GetCountInStock
        {
            get
            {
                return $"в наличии на складе {ProductQuantityInStock} {UnitType.UnitTypeName}";
            }
        }
        
    }
}

