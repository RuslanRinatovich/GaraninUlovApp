using System.Data.Entity; // нужно добавить для контекста

// пространство имен такое же как и у SportTradeEntities из папки Models
namespace SportApp.Models
{
    // класс SportTradeEntities public - публичный
    // partial - частичный, т.е. его часть в другом файле
    // унаследован от класса DbContext
    public partial class SportTradeEntities : DbContext
    {
        private static SportTradeEntities _context;
        /// <summary>
        /// Метод возвращающий контекст подключения
        /// </summary>
        /// <returns></returns>
        public static SportTradeEntities GetContext()
        {
            if (_context == null)
            {
                _context = new SportTradeEntities();
            }
            return _context;
        }
    }
}